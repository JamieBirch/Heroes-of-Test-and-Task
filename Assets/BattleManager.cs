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
        LinkedListNode<Stack> nextActive;
        if (activeStack.Next != null)
        {
            nextActive = activeStack.Next;
        }
        else
        {
            nextActive = allStacksOrdered.First;
        }
        
        AssignAsActive(nextActive);
    }
    
    public void EndTurn()
    {
        if (activeStack.Value.unit.EndTurn())
        {
            activeStack.Value.turnCube.SetActive(false);
            SwitchToNextStack();
        }
        else
        {
            Debug.Log("Go Again");
            activeStack.Value.ResetTurnActions();
        }
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
