using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stack : MonoBehaviour
{
    public Unit unit;
    public int unitCount;
    private int totalHealth;
    private Player owner;
    
    public Canvas info;
    public Text name;
    public Text health;
    public Text movement;
    public Text initiative;
    public Text count;
    
    public bool isActive;
    
    public Vector3 targetTile;
    public bool targetSet;
    
    private BattleManager _battleManager;
    private GridController _gridController;

    private bool _attackedOrUsedAbilityThisTurn;
    private bool _movedThisTurn;

    private Vector3 occupiedTile;

    private void Start()
    {
        name.text = gameObject.name;
        health.text = unit.health.ToString();
        movement.text = unit.movement.ToString();
        initiative.text = unit.initiative.ToString();
        info.enabled = false;
        
        _battleManager = BattleManager.instance;
        _gridController = GridController.instance;

        Vector3 pos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3Int positionToCell = _gridController.PositionToCell(pos);
        Debug.Log(positionToCell);
        occupiedTile = positionToCell;
    }

    void Update()
    {
        count.text = unitCount.ToString();
        
        if (targetSet && transform.position != targetTile)
        {
            Move();
        }
        else
        {
            targetSet = false;
        }
    }

    private void OnMouseEnter()
    {
        // Debug.Log("mouse enter");
        info.enabled = true;
    }
    
    private void OnMouseExit()
    {
        // Debug.Log("mouse exit");
        info.enabled = false;
    }

    private void OnMouseDown()
    {
        Stack activeStack = _battleManager.GetActiveStack();

        if (this == activeStack) 
            return;

        activeStack.Attack(this);
    }

    public IEnumerator DoTurn()
    {
        Debug.Log("go " + unit + "count " + unitCount);
        yield return new WaitUntil(() => !isActive);
        //TODO
        // yield return null;
    }
    
    public void Move()
    {
        if (targetSet)
        {
            // Debug.Log(transform.position);
            // Debug.Log("move to tile " + targetPosition);
   
            float distanceThisFrame = unit.speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetTile, distanceThisFrame);
        }
    }

    public void SetMoveTarget(Vector3 cellCenter)
    {
        targetTile = new Vector3(cellCenter.x, transform.position.y, cellCenter.z);
        occupiedTile = cellCenter;
        targetSet = true;
        _movedThisTurn = true;
    }

    public IEnumerator Attack(Stack targetStack)
    {
        Debug.Log("attack an enemy");
        //Damage
        
        
        int damage = _calculateDamage();
        targetStack.TakeDamage(damage);
        _attackedOrUsedAbilityThisTurn = true;
        yield return new WaitForSeconds(2f);
    }

    private void TakeDamage(int damage)
    {
        //TODO
    }

    private int _calculateDamage()
    {
        //TODO
        return 0;
    }
    
    public void ResetTurnActions()
    {
        _attackedOrUsedAbilityThisTurn = false;
        _movedThisTurn = false;
    }
}
