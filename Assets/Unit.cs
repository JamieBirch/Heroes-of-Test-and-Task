using UnityEngine;

public class Unit : MonoBehaviour
{
    public int health;
    public int movement;
    public int initiative;
    
    public int dmgMeleeMin;
    public int dmgMeleeMax;
    public int dmgRangedMin;
    public int dmgRangedMax;

    public virtual void Attack()
    {
        Debug.Log("Attack");
    }
    
    public virtual void Move()
    {
        Debug.Log("Move");
    }
    
    public virtual void Skip()
    {
        Debug.Log("Skip turn");
    }
}
