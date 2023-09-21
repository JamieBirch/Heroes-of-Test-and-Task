using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GridController _gridController;

    public Canvas GameOverCanvas;
    
    // public Player leftPlayer;
    // public Player rightPlayer;

    /*public string leftPlayerName;
    public string rightPlayerName;
    
    public Material leftPlayerMaterial;
    public Material rightPlayerMaterial;*/

    // public List<Stack> allStacksOrdered;
    // public Unit currentUnit = null;
    // public Stack currentStack = null;
    // public string unitTag;
    // public int currentRound;
    public bool gameOver = false;
    // public bool endRound = false;
    // public bool endTurn = false;

    private BattleManager _battleManager;
    
    private void Awake()
    {
        instance = this;
    }
    
    void Start() {
        _battleManager = BattleManager.instance;
        
    }

    /*private void StartGame()
    {
        currentRound = 1;
        allStacksOrdered = OrderStacksByInitiative();
    }*/

    /*private void NextRound()
    {
        foreach (Stack currentStack in allStacksOrdered)
        {
            this.currentStack = currentStack;
            currentUnit = currentStack.unit;
            currentStack.isActive = true;
            StartCoroutine(currentStack.DoTurn());
        }

        endRound = true;
        currentRound++;
    }*/

    /*private List<Stack> OrderStacksByInitiative()
    {
        // List<GameObject> allStacks = GameObject.FindGameObjectsWithTag(unitTag).ToList();
        GameObject[] allStacks = GameObject.FindGameObjectsWithTag(unitTag);
        // Debug.Log("1");
        List<Stack> stacksOrdered = allStacks
            .Select(stack => stack.GetComponent<Stack>())
            .OrderByDescending(stack => stack.unit.initiative)
            .ToList();
        // Debug.Log("2");
        return stacksOrdered;
    }*/


    public void GameOver()
    {
        gameOver = true;
        
        throw new System.NotImplementedException();
    }
}
