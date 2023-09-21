using UnityEngine;

public class Knight : Unit
{
    public override int Attack(Stack targetStack)
    {
        if (IsClose(targetStack))
        {
            return Utils.RandomIntBetween(dmgMeleeMin, dmgMeleeMax);
        }

        return 0;
    }
}
