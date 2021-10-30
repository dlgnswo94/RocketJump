using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultValueChecker<T> : MonoBehaviour
{
    public static bool IsDefaultValue(T value, string nullMessage = "This value is NULL! Check the value!", 
        string noneDefaultMessage = "This value is not default value!")
    {
        if (ErrorHelper.IsNull(value, nullMessage))
            return false;

        if ( value.Equals(default(T)) )
            return true;

        LogHelper.WarningMessage(noneDefaultMessage);
        return false;
    }
}