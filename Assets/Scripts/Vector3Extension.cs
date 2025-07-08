using UnityEngine;

public static class Vector2Extension
{
    public static float SqrDistance(this Vector2 start, Vector2 end)
    {
        return (end - start).sqrMagnitude;
    }

    public static bool IsEnoughClose(Vector2 start, Vector2 end, float distance)
    {
        return start.SqrDistance(end) <= distance * distance;
    }
}
