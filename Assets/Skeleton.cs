public class Skeleton : Unit
{
    public bool isInMotherStack;
    
    public override int Attack(Stack targetStack)
    {
        //Can they attack from distance???
        if (IsClose(targetStack))
        {
            return Utils.RandomIntBetween(dmgMeleeMin, dmgMeleeMax);
        }

        return 0;
    }

    public override void TakeDamage()
    {
        //TODO
    }
}
