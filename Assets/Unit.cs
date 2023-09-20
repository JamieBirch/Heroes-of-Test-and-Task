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
    public Vector3 target;
    public bool targetSet;

    public virtual void Attack()
    {
        Debug.Log("Attack");
    }
    
    public virtual void Move(Vector3 targetPosition)
    {
        if (targetSet)
        {
            // Debug.Log(transform.position);
            // Debug.Log("move to tile " + targetPosition);
   
            float distanceThisFrame = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, distanceThisFrame);
        }
    }
    
    public virtual void Skip()
    {
        Debug.Log("Skip turn");
    }
}
