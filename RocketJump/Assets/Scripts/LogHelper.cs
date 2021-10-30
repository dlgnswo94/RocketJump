using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogHelper
{
    #region Error Message
    public static void ErrorMessage(object message)
    {
        Debug.LogError(message);
    }

    public static void ErrorMessage(string message)
    {
        Debug.LogError(message);
    }

    public static void ErrorMessage(object message, Object context)
    {
        string format = string.Format((string)message, context);
        Debug.LogError(format);
    }

    public static void ErrorMessage(string format, params object[] args)
    {
        string strFormat = string.Format(format, args);
        Debug.LogError(strFormat);
    }
    
    public static void ErrorMessage(Object context, string format, params object[] args)
    {
        string strFormat = string.Format((System.IFormatProvider)context, format, args);
        Debug.LogError(strFormat);
    }
    #endregion Error Message

    #region Warning Message
    public static void WarningMessage(object message)
    {
        Debug.LogError(message);
    }

    public static void WarningMessage(string message)
    {
        Debug.LogError(message);
    }

    public static void WarningMessage(object message, Object context)
    {
        string format = string.Format((string)message, context);
        Debug.LogError(format);
    }

    public static void WarningMessage(string format, params object[] args)
    {
        string strFormat = string.Format(format, args);
        Debug.LogError(strFormat);
    }

    public static void WarningMessage(Object context, string format, params object[] args)
    {
        string strFormat = string.Format((System.IFormatProvider)context, format, args);
        Debug.LogError(strFormat);
    }
    #endregion Warning Message

    #region Log Message
    public static void LogMessage(object message)
    {
        Debug.LogError(message);
    }

    public static void LogMessage(string message)
    {
        Debug.LogError(message);
    }

    public static void LogMessage(object message, Object context)
    {
        string format = string.Format((string)message, context);
        Debug.LogError(format);
    }

    public static void LogMessage(string format, params object[] args)
    {
        string strFormat = string.Format(format, args);
        Debug.LogError(strFormat);
    }

    public static void LogMessage(Object context, string format, params object[] args)
    {
        string strFormat = string.Format((System.IFormatProvider)context, format, args);
        Debug.LogError(strFormat);
    }
    #endregion Log Message
}