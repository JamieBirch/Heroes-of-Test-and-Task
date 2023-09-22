using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stack : MonoBehaviour
{
    public Unit unit;
    public int unitCount;
    private int totalHealth;
    
    public bool leftPlayer;
    public bool isControlled;
    public Player Owner;
    
    public Canvas info;
    public Text name;
    public Text healthUnit;
    public Text healthTotal;
    public Text movement;
    public Text initiative;
    public Text count;
    
    public GameObject turnCube;
    public Renderer turnCubeRenderer;
    
    // public bool isActive;
    
    public Vector3 targetTile;
    public bool targetSet;
    
    private BattleManager _battleManager;
    private GridController _gridController;
    private GameManager _gameManager;

    private bool _attackedOrUsedAbilityThisTurn;
    private bool _movedThisTurn;

    private Vector3Int occupiedTile;

    void Start()
    {
        totalHealth = unitCount * unit.health;
        
        //UI
        name.text = unit.name;
        healthUnit.text = unit.health.ToString();
        healthTotal.text = totalHealth.ToString();
        movement.text = unit.movement.ToString();
        initiative.text = unit.initiative.ToString();
        info.enabled = false;
        
        _battleManager = BattleManager.instance;
        _gridController = GridController.instance;
        _gameManager = GameManager.instance;

        AssignOccupiedTile();
        AssignPlayer();
    }

    private void AssignOccupiedTile()
    {
        Vector3 pos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3Int positionToCell = _gridController.PositionToCell(pos);
        occupiedTile = positionToCell;
    }

    private void AssignPlayer()
    {
        Player owner;
        if (leftPlayer)
        {
            owner = PlayersManager.instance.GetLeftPlayer();
        }
        else
        {
            owner = PlayersManager.instance.GetRightPlayer();
        }

        owner.addStack();

        AssignOwner(owner);
    }

    private void AssignOwner(Player owner)
    {
        Owner = owner;
        turnCubeRenderer.material = owner.HighlightMaterial;
    }

    void Update()
    {
        count.text = unitCount.ToString();
        healthTotal.text = totalHealth.ToString();
        
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
        info.enabled = true;
    }
    
    private void OnMouseExit()
    {
        info.enabled = false;
    }

    private void OnMouseDown()
    {
        Stack activeStack = _battleManager.GetActiveStack();

        if (this == activeStack) 
            return;

        if (Owner == activeStack.Owner)
        {
            Debug.Log("You can't attack your units");
            return;
        }

        if (activeStack._attackedOrUsedAbilityThisTurn)
        {
            Debug.Log("You have spent your action this turn");
            return;
        }

        StartCoroutine(activeStack.Attack(this));
    }

    public void Move()
    {
        if (targetSet)
        {
            float distanceThisFrame = unit.speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetTile, distanceThisFrame);
        }
    }

    public void SetMoveTarget(Vector3 cellCenter)
    {
        if (_movedThisTurn)
            return;
        
        //TODO
        // if (isOccupied)
        targetTile = new Vector3(cellCenter.x, transform.position.y, cellCenter.z);
        Vector3Int positionToCell = _gridController.PositionToCell(targetTile);

        occupiedTile = positionToCell;
        targetSet = true;
        _movedThisTurn = true;
    }

    public IEnumerator Attack(Stack targetStack)
    {
        // Debug.Log("attack an enemy");
        //Damage

        int damage = unit.Attack(targetStack);
        if (damage > 0)
        {
            int totalDamage = damage * unitCount;
            Debug.Log("total damage: " + totalDamage);
            targetStack.TakeDamage(totalDamage);
        }
        _attackedOrUsedAbilityThisTurn = true;
        yield return new WaitForSeconds(2f);
    }

    private void TakeDamage(int damage)
    {
        if (totalHealth > damage)
        {
            Debug.Log("total health before hit: " + totalHealth);
            totalHealth -= damage;
            Debug.Log("total health after hit: " + totalHealth);

            unitCount = totalHealth / unit.health;
            Debug.Log("updated unit count after hit: " + unitCount);
            
            unit.TakeDamage(damage);
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        //TODO
        Debug.Log("destroyed");

        if (Owner.GetStacksAlive() == 1)
        {
            _gameManager.GameOver();
        }
        else
        {
            Owner.substractStack();
        }
        

        _battleManager.RemoveFromStacks(this);
        Destroy(gameObject);
    }

    public void ResetTurnActions()
    {
        _attackedOrUsedAbilityThisTurn = false;
        _movedThisTurn = false;
    }

    public Vector3Int GetTile()
    {
        return occupiedTile;
    }

    public bool CanMove()
    {
        return !_movedThisTurn;
    }

    public void ChangeOwner()
    {
        Player newOwner = PlayersManager.instance.GetOtherPlayer(Owner);
        AssignOwner(newOwner);
    }
}
