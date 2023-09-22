using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{
    // [SerializeField] private Camera camera;
    public static GridController instance;
    
    private Grid grid;
    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tile defaultTile = null;
    [SerializeField] private Tile hoverTile = null;
    [SerializeField] private Tile availableTile = null;
    [SerializeField] private Tile unavailableTile = null;
    private Vector3Int previousMousePos = new Vector3Int();

    private BattleManager _battleManager;
    
    private void Awake()
    {
        instance = this;
        grid = gameObject.GetComponent<Grid>();
    }
    
    void Start() {
        
        _battleManager = BattleManager.instance;
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        Vector3Int worldToCell;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit) && !raycastHit.transform.CompareTag(Utils.UNIT_TAG))
        {
            worldToCell = PositionToCell(raycastHit.point);
        }
        else
        {
            return;
        }
        
        if (!worldToCell.Equals(previousMousePos))
        {
            Highlight(worldToCell);
            interactiveMap.SetTile(previousMousePos, defaultTile);
            previousMousePos = worldToCell;
        }

        if (Input.GetMouseButton(0))
        {
            Stack activeStack = _battleManager.GetActiveStack();
            if (WithinReach(previousMousePos, activeStack.GetTile(), activeStack.unit.movement) && !activeStack.targetSet)
            {
                Vector3 cellCenter = grid.GetCellCenterWorld(previousMousePos);
                activeStack.SetMoveTarget(cellCenter);
            }
        }
    }

    public Vector3Int PositionToCell(Vector3 mousePos)
    {
        // Debug.Log(mousePos);
        Vector3Int pos = Vector3Int.FloorToInt(mousePos);
        Vector3Int worldToCell = grid.WorldToCell(pos);
        return worldToCell;
    }

    public Vector3 CellToWorld(Vector3Int cellPosition)
    {
        return grid.WorldToCell(cellPosition);
    }

    private void Highlight(Vector3Int worldToCell)
    {
        // Debug.Log(worldToCell);
        Stack activeStack = _battleManager.GetActiveStack();
        int unitMovement = activeStack.unit.movement;
        Vector3Int tile = activeStack.GetTile();
        if (WithinReach(worldToCell, tile, unitMovement) && activeStack.CanMove())
        {
            interactiveMap.SetTile(worldToCell, availableTile);
        }
        else
        {
            interactiveMap.SetTile(worldToCell, unavailableTile);
        }
    }

    private static bool WithinReach(Vector3Int tile1, Vector3Int tile2, int unitMovement)
    {
        return Utils.WithinDistance(tile1, tile2, unitMovement + 1);
    }

}
