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

    // private GameManager _gameManager;
    private BattleManager _battleManager;
    
    private void Awake()
    {
        instance = this;
        grid = gameObject.GetComponent<Grid>();
    }
    
    void Start() {
        
        // _gameManager = GameManager.instance;
        _battleManager = BattleManager.instance;
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        // Vector3 mousePos = GetMousePosition();
        // Debug.Log(mousePos);
        Vector3Int worldToCell;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit) && !raycastHit.transform.CompareTag(Utils.UNIT_TAG))
        {
            worldToCell = PositionToCell(raycastHit.point);
            // return raycastHit.point;
        }
        else
        {
            return;
        }
        
        // Vector3Int worldToCell = PositionToCell(mousePos);

        if (!worldToCell.Equals(previousMousePos))
        {
            highlight(worldToCell);
            interactiveMap.SetTile(previousMousePos, defaultTile);
            previousMousePos = worldToCell;
        }

        if (Input.GetMouseButton(0))
        {
            if (isInDistance(previousMousePos))
            {
                Vector3 cellCenter = grid.GetCellCenterWorld(previousMousePos);
                _battleManager.GetActiveStack().SetMoveTarget(cellCenter);
            }
            else
            {
                Debug.Log("too far");
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

    private void highlight(Vector3Int worldToCell)
    {
        // Debug.Log(worldToCell);
        Stack activeStack = _battleManager.GetActiveStack();
        int unitMovement = activeStack.unit.movement;
        Vector3Int tile = activeStack.GetTile();
        if (withinReach(worldToCell, tile, unitMovement))
        {
            interactiveMap.SetTile(worldToCell, availableTile);
        }
        else
        {
            interactiveMap.SetTile(worldToCell, unavailableTile);
        }
    }

    private bool withinReach(Vector3Int tile1, Vector3Int tile2, int unitMovement)
    {
        return Utils.WithinDistance(tile1, tile2, unitMovement + 1);
    }

    public void highlightInDistanceTiles(Unit unit)
    {
        Vector3 unitPosition = unit.transform.position;
        int unitMovement = unit.movement;
        BoundsInt boundsInt = new BoundsInt(Vector3Int.FloorToInt(new Vector3(unitPosition.x, unitPosition.y, 0)), new Vector3Int(unitMovement, unitMovement, 3));
        // BoundsInt boundsInt = interactiveMap.cellBounds;
        Debug.Log(boundsInt);
        // TileBase[] tilesBlock = interactiveMap.GetTilesBlock(boundsInt);
        foreach (Vector3Int position in boundsInt.allPositionsWithin)
        {
            Debug.Log(position);
            Vector3Int worldToCell = grid.WorldToCell(position);

            if (worldToCell != null)
            {
                highlight(worldToCell);
            }
            // Vector3Int worldToCell = grid.WorldToCell(position);
        }
    }

    private bool isInDistance(Vector3Int vector3Int)
    {
        //TODO
        int currentUnitMovement = _battleManager.GetActiveStack().unit.movement;
        Vector3 gridCellSize = grid.cellSize;
        // Debug.Log("cell size " + gridCellSize);
        return true;
    }

    Vector3 GetMousePosition ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        //TODO
        return new Vector3Int(0, 0, 0);
    }
    
    
}
