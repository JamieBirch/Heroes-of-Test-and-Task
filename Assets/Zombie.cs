public class Zombie : Unit
{
    public override int Attack(Stack targetStack)
    {
        if (IsClose(targetStack))
        {
            targetStack.isControlled = true;
            targetStack.ChangeOwner();
        }

        return 0;
    }
}
