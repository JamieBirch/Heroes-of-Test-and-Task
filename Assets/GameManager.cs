using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GridController _gridController;
    
    public Player leftPlayer;
    public Player rightPlayer;

    // public List<Stack> allStacksOrdered;
    public Unit currentUnit = null;
    public Stack currentStack = null;
    public string unitTag;
    // public int currentRound;
    public bool gameOver = false;
    public bool endRound = false;
    public bool endTurn = false;

    private void Awake()
    {
        instance = this;
    }
    
    void Start() {
        _gridController = GridController.instance;
        // StartGame();
        // _gridController.highlightInDistanceTiles(currentUnit);
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


    
}
