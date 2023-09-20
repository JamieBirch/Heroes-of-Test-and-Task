using UnityEngine;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    
    private Grid grid;
    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tile defaultTile = null;
    [SerializeField] private Tile hoverTile = null;
    
    private Vector3Int previousMousePos = new Vector3Int();
    
    void Start() {
        grid = gameObject.GetComponent<Grid>();
    }

    void Update()
    {
        Vector3Int mousePos = GetMousePosition();
        Vector3Int worldToCell = grid.WorldToCell(mousePos);

        if (!worldToCell.Equals(previousMousePos)) {
            interactiveMap.SetTile(worldToCell, hoverTile);
            interactiveMap.SetTile(previousMousePos, defaultTile);
            previousMousePos = worldToCell;
        }
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
