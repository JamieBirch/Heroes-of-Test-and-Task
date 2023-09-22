
public class Archer : Unit
{
    public override int Attack(Stack targetStack)
    {
        //TODO if someone is close, can't shoot
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
