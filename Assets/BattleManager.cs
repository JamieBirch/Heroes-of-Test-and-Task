using System.Collections;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    
    public Stack friend;
    public Stack enemy;

    private Stack activeStack;

    public Stack GetActiveStack()
    {
        return activeStack;
    }

    private void Update()
    {
        activeStack.Move();
    }

    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        activeStack = friend;
        // StartCoroutine(PlayerTurn());
        StartCoroutine(StartBattle());
    }

    private IEnumerator StartBattle()
    {
        yield return new WaitForSeconds(2f);
        PlayerTurn();
    }

    private IEnumerator PlayerTurn()
    {
        //TODO
        // Debug.Log("Attack");

        Attack(enemy);
        yield return new WaitForSeconds(2f);
    }

    public void Attack(Stack targetStack)
    {
        StartCoroutine(activeStack.Attack(targetStack));
    }

    private IEnumerator WaitFor(float time)
    {
        yield return new WaitForSeconds(time);
    }

    private void SwitchActiveStack()
    {
        if (activeStack == friend)
        {
            activeStack = enemy;
        }
        else
        {
            activeStack = friend;
        }
    }
}
