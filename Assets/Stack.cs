using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stack : MonoBehaviour
{
    public Unit unit;
    public int unitCount;
    private int topUnitHealth;
    private Player owner;
    public Canvas info;
    public Text count;
    public bool isActive;

    void Update()
    {
        count.text = unitCount.ToString();
    }

    private void OnMouseEnter()
    {
        info.enabled = true;
    }
    
    private void OnMouseExit()
    {
        info.enabled = false;
    }

    //TODO rename method
    public IEnumerator Go()
    {
        Debug.Log("go " + unit + "count " + unitCount);
        yield return new WaitUntil(() => !isActive);
        //TODO
        // yield return null;
    }
}
