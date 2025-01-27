using UnityEngine;

public static class VectorUtils
{
    public static Vector2 V3ToV2(Vector3 v)
    {
        return new Vector2(v.x, v.y);
    }

    public static Vector3 V2ToV3(Vector3 v)
    {
        return new Vector3(v.x, v.y, 0);
    }

    public static Vector2 GetDirection2D(Vector2 v1, Vector2 v2)
    {
        return (v2 - v1).normalized;
    }

    public static float GetDistance2D(Vector2 v1, Vector2 v2)
    {
        return Vector2.Distance(v1, v2);
    }

    public static Vector2 GetPerpendicular2D(Vector2 v1, Vector2 v2)
    {
        Vector2 v = GetDirection2D(v1, v2);
        //Debug.Log($"[VectorUtils] direction: {v}");
        Vector2 pv = new Vector2(-v.y, v.x) / Mathf.Sqrt(Mathf.Pow(v.x, 2f) + Mathf.Pow(v.y, 2f));
        //Debug.Log($"[VectorUtils] perpendicular: {pv}");
        return pv.normalized;
    }
}
