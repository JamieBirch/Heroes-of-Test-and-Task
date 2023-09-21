using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    
    private LinkedList<Stack> allStacksOrdered;
    private int currentRound;

    private LinkedListNode<Stack> activeStack;

    public Stack GetActiveStack()
    {
        return activeStack.Value;
    }

    private void Update()
    {
        activeStack.Value.Move();
    }

    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        currentRound = 1;
        allStacksOrdered = OrderStacksByInitiative();
        activeStack = allStacksOrdered.First;
        activeStack.Value.turnCube.SetActive(true);
    }

    private void SwitchToNextStack()
    {
        if (activeStack.Next != null)
        {
            activeStack = activeStack.Next;
        }
        else
        {
            activeStack = allStacksOrdered.First;
        }
        
        activeStack.Value.turnCube.SetActive(true);
    }
    
    public void EndTurn()
    {
        activeStack.Value.turnCube.SetActive(false);
        SwitchToNextStack();
    }
    
    private LinkedList<Stack> OrderStacksByInitiative()
    {
        GameObject[] allStacks = GameObject.FindGameObjectsWithTag(Utils.UNIT_TAG);
        
        IOrderedEnumerable<Stack> stacksOrdered = allStacks
            .Select(stack => stack.GetComponent<Stack>())
            .OrderByDescending(stack => stack.unit.initiative);
        
        return new LinkedList<Stack>(stacksOrdered);
    }
}
