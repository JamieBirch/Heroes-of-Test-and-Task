using UnityEngine;

public class Skeleton : Unit
{
    public bool isInMotherStack;
    
    public override int Attack(Stack targetStack)
    {
        //Can they attack from distance???
        if (IsClose(targetStack))
        {
            return dmgMeleeMax;
        }
        else
        {
            Debug.Log("Target is too far");
            return 0;
        }
    }

    public override void TakeDamage(int damage)
    {
        //TODO
    }
}
