public class Player
{
    public string Name;

    private int _stacksAlive = 0;

    public void substractStack()
    {
        _stacksAlive--;
    }
    
    public void setStacks(int count)
    {
        _stacksAlive = count;
    }

    public int GetStacksAlive()
    {
        return _stacksAlive;
    }
}
