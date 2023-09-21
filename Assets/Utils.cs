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
}
