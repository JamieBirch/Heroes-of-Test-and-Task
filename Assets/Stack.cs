using UnityEngine;

public class Stack : MonoBehaviour
{
    public Unit unit;
    public int unitCount;
    private int topUnitHealth;
    private Player owner;
    public Canvas info;

    private void OnMouseEnter()
    {
        info.enabled = true;
    }
    
    private void OnMouseExit()
    {
        info.enabled = false;
    }

    //TODO rename method
    public void Go()
    {
        Debug.Log("go " + unit + "count " + unitCount);
        //TODO
    }
}
