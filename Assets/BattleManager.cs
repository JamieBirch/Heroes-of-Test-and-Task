using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    // public Player leftPlayer;
    // public Player rightPlayer;
    
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
        AssignAsActive(allStacksOrdered.First);
    }

    private void AssignAsActive(LinkedListNode<Stack> linkedListNode)
    {
        activeStack = linkedListNode;
        activeStack.Value.turnCube.SetActive(true);
        activeStack.Value.ResetTurnActions();
    }

    private void SwitchToNextStack()
    {
        // Debug.Log("Left has " + leftPlayer.GetStacksAlive());
        // Debug.Log("Right has " + rightPlayer.GetStacksAlive());
        
        LinkedListNode<Stack> nextActive;
        if (activeStack.Next != null)
        {
            nextActive = activeStack.Next;
        }
        else
        {
            nextActive = allStacksOrdered.First;
        }
        
        Debug.Log("Player has " + nextActive.Value.Owner.GetStacksAlive());

        AssignAsActive(nextActive);
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

    public void RemoveFromStacks(Stack stack)
    {
        allStacksOrdered.Remove(stack);
    }
}
