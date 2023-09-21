
public class Archer : Unit
{
    public override int Attack(Stack targetStack)
    {
        if (IsClose(targetStack))
        {
            return Utils.RandomIntBetween(dmgMeleeMin, dmgMeleeMax);
        }
        else
        {
            return Utils.RandomIntBetween(dmgRangedMin, dmgRangedMax);
        }
    }
}
