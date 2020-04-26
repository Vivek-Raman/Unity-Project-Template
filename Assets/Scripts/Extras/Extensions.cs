using UnityEngine;

public static class Extensions
{
    /// <summary>
    /// Converts a Vector2 into a Vector3. Transformation is XY -> XZ.
    /// </summary>
    /// <param name="vector2">Value to be converted to Vector3.</param>
    /// <param name="y">Y component of the transformed vector.</param>
    /// <returns></returns>
    public static Vector3 ToVector3(this Vector2 vector2, float y = 0f)
    {
        return new Vector3(vector2.x, y, vector2.y);
    }
    
    /// <summary>
    /// Flips the variable and returns new state.
    /// </summary>
    /// <param name="b">Value to be toggled.</param>
    public static bool Toggle(this ref bool b)
    {
        b = !b;
        return b;
    }

    /// <summary>
    /// Returns 1 if true, 0 if false.
    /// </summary>
    /// <param name="b">Value to cast as integer.</param>
    /// <returns></returns>
    public static int AsInt(this bool b)
    {
        return b ? 1 : 0;
    }
}