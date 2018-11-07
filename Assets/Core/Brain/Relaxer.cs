using UnityEngine;

public class Relaxer
{
    public static float Relax(float modifier, int gainRate, float start, float target)
    {
        if (gainRate > 0)
        {
            float t = modifier * (1f / gainRate);
            return Mathf.Lerp(start, target, t);
        }
        return start;
    }
}