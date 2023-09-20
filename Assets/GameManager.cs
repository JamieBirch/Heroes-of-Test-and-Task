using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GridController _gridController;
    
    public Player leftPlayer;
    public Player rightPlayer;

    public Unit currentUnit = null;
    
    private void Awake()
    {
        instance = this;
    }
    
    void Start() {
        _gridController = GridController.instance;
        // _gridController.highlightInDistanceTiles(currentUnit);
    }
}
