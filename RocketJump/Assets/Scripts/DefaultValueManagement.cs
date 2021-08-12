using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefaultValueManagement<T>
{
    public static T GetDefaultValue()
    {
        T temp = default(T);
        return temp;
    }
}