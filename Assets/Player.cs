using UnityEngine;

public class Player
{
    //weird?
    // public bool leftPlayer;
    public string Name;
    public Material HighlightMaterial;

    private int _stacksAlive = 0;

    public Player(string name, Material material)
    {
        this.Name = name;
        this.HighlightMaterial = material;
    }
    
    public int substractStack()
    {
        return _stacksAlive--;
    }
    
    public void addStack()
    {
        _stacksAlive++;
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
