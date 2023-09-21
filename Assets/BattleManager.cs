using System;
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
        StartCoroutine(PlayerTurn());
    }

    private IEnumerator PlayerTurn()
    {
        
        
        //TODO
        Move();
        yield return new WaitForSeconds(2f);
    }

    public void Move()
    {
        // StartCoroutine(activeStack.Move(new Vector3(0,0,0)));
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
