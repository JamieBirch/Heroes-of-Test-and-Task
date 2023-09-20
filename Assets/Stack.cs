using System;
using UnityEngine;

public class Stack : MonoBehaviour
{
    private Unit unit;
    private int unitCount;
    private int topUnitHealth;
    private Player owner;

    private void OnMouseDown()
    {
        Debug.Log("hover " + unit + "count " + unitCount);
    }
}
