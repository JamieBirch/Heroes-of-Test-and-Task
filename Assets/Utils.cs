using UnityEngine;
using Random = System.Random;

public static class Utils
{
    public const string UNIT_TAG = "Unit";

    public static int RandomIntBetween(int min, int max)
    {
        Random random = new Random();
        return (int)(random.NextDouble() * (max-min) + min);
    }

    public static bool WithinDistance(Vector3 a, Vector3 b, float distance)
    {
        float distanceBetweenPoints = Vector3.Distance(a, b);
        // Debug.Log(distance);
        return distanceBetweenPoints < distance;
    }
    
    public static Vector3[] FindNearbyTiles(Vector3 a)
    {
        return new[]
        {
            new Vector3(a.x - 1, a.y - 1, a.z),
            new Vector3(a.x - 1, a.y + 1, a.z),
            new Vector3(a.x - 1, a.y, a.z),
            new Vector3(a.x, a.y - 1, a.z),
            new Vector3(a.x, a.y + 1, a.z),
            new Vector3(a.x, a.y, a.z),
        };
    }
    
    
    public static float GenerateRandomChance()
    {
        Random random = new Random();
        return (float)random.NextDouble() * 100;
    }
}
