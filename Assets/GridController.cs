using UnityEngine;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    public static GridController instance;
    
    private Grid grid;
    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tile defaultTile = null;
    [SerializeField] private Tile hoverTile = null;
    private Vector3Int previousMousePos = new Vector3Int();

    private GameManager _gameManager;
    
    private void Awake()
    {
        instance = this;
    }
    
    void Start() {
        grid = gameObject.GetComponent<Grid>();
        _gameManager = GameManager.instance;
    }

    void Update()
    {
        Vector3Int mousePos = GetMousePosition();
        // Debug.Log(mousePos);
        Vector3Int worldToCell = grid.WorldToCell(mousePos);

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
                _gameManager.currentUnit.target = new Vector3(cellCenter.x, _gameManager.currentUnit.transform.position.y, cellCenter.z);
                _gameManager.currentUnit.targetSet = true;
                // _gameManager.currentUnit.Move(cellCenter);
            }
            else
            {
                Debug.Log("too far");
            }
        }
    }

    private void highlight(Vector3Int worldToCell)
    {
        // Debug.Log(worldToCell);
        interactiveMap.SetTile(worldToCell, hoverTile);
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
        int currentUnitMovement = _gameManager.currentUnit.movement;
        Vector3 gridCellSize = grid.cellSize;
        // Debug.Log("cell size " + gridCellSize);
        //TODO
        return true;
    }

    Vector3Int GetMousePosition ()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            Vector3Int position = Vector3Int.FloorToInt(raycastHit.point);
            return position;
        }
        //TODO
        return new Vector3Int(0, 0, 0);
    }
}
