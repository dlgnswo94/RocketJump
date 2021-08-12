using UnityEngine;

public class NullReferenceChecker
{
    public static bool IsNull(Object obj)
    {
        if (!obj)
            return true;
        return false;
    }

    public static bool IsNullOrEmpty(string str)
    {
        if (string.IsNullOrEmpty(str))
            return true;
        return false;
    }
}