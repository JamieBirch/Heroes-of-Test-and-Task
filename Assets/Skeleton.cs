using UnityEngine;

public class Skeleton : Unit
{
    public GameObject SkeletonStackPrefab;
    public bool isInMotherStack;
    private int stacksProduced;
    
    public override int Attack(Stack targetStack)
    {
        //Can they attack from distance???
        if (IsClose(targetStack))
        {
            return dmgMeleeMax;
        }
        else
        {
            Debug.Log("Target is too far");
            return 0;
        }
    }

    public override void TakeDamage(int damage)
    {
        /*if (isInMotherStack && stacksProduced < 3)
        {
            Stack stack = GetComponent<Stack>();
            Vector3Int occupiedTile = stack.GetTile();
            Vector3[] nearbyTiles = Utils.FindNearbyTiles(occupiedTile);
            foreach (var nearbyTile in nearbyTiles)
            {
                //TODO
                // if (!isOccupied(nearbyTile))
                // {
                Vector3 worldCoordinates = stack.GetWorldCoordinates(nearbyTile);
                GameObject newStack = Instantiate(SkeletonStackPrefab, worldCoordinates, Quaternion.identity);
                Skeleton skeleton = newStack.GetComponent<Skeleton>();

                float multiplier;
                switch (stacksProduced)
                {
                    case 0:
                        multiplier = 0.7f;
                        break;
                    case 1:
                        multiplier = 0.4f;
                        break;
                    case 2:
                        multiplier = 0.1f;
                        break;
                    default:
                        multiplier = 0;
                        Debug.Log("something weird here");
                        break;
                }
                skeleton.health = (int)(skeleton.health * multiplier); //todo: round up
                skeleton.dmgMeleeMax = (int)(skeleton.dmgMeleeMax * multiplier); //todo: round up
                skeleton.movement = (int)(skeleton.movement * multiplier); //todo: round up
                skeleton.initiative = (int)(skeleton.initiative * multiplier); //todo: round up

                newStack.GetComponent<Stack>().AssignOwner(stack.Owner);
                //TODO put new stack in initiative


                // break;
                // }
            }
        }*/
    }
}
