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

    public int speed = 3;
    
    public virtual int Attack(Stack targetStack)
    {
        return 0;
    }

    public virtual void TakeDamage()
    {
        
    }
    
    public bool IsClose(Stack targetStack)
    {
        Vector3 myTile = GetComponent<Stack>().GetTile();
        Vector3 enemyTile = targetStack.GetTile();
        return Utils.WithinDistance(myTile, enemyTile, 2f);
    }
}
