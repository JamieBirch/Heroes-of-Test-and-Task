using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stack : MonoBehaviour
{
    public Unit unit;
    public int unitCount;
    private int totalHealth;
    private Player owner;
    public Canvas info;
    public Text count;
    public bool isActive;
    
    public Vector3 target;
    public bool targetSet;

    void Update()
    {
        count.text = unitCount.ToString();
        
        if (targetSet && transform.position != target)
        {
            Move();
        }
        else
        {
            targetSet = false;
        }
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
    public IEnumerator DoTurn()
    {
        Debug.Log("go " + unit + "count " + unitCount);
        yield return new WaitUntil(() => !isActive);
        //TODO
        // yield return null;
    }
    
    public void Move()
    {
        if (targetSet)
        {
            // Debug.Log(transform.position);
            // Debug.Log("move to tile " + targetPosition);
   
            float distanceThisFrame = unit.speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, distanceThisFrame);
        }
    }

    public void SetMoveTarget(Vector3 cellCenter)
    {
        target = new Vector3(cellCenter.x, transform.position.y, cellCenter.z);
        targetSet = true;
    }
}
