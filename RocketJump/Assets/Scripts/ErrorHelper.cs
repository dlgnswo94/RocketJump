using UnityEngine;

public class ErrorHelper
{
    #region Null Check
    public static bool IsNull(Object obj)
    {
        if (!obj)
            return true;
        return false;
    }

    public static bool IsNull(Object obj, string message)
    {
        if (!obj)
        {
            LogHelper.ErrorMessage(message);
            return true;
        }
        return false;
    }

    public static bool IsNull(Object obj, string message, params object[] args)
    {
        if (!obj)
        {
            LogHelper.ErrorMessage(message, args);
            return true;
        }
        return false;
    }

    public static bool IsNull(Object[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (!obj[i])
                return true;
        }
        return false;
    }

    public static bool IsNull(Object[] obj, string message)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (!obj[i])
            {
                LogHelper.ErrorMessage(message);
                return true;
            }
        }
        return false;
    }

    public static bool IsNull(Object[] obj, string message, params object[] args)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (!obj[i])
            {
                LogHelper.ErrorMessage(message, args);
                return true;
            }
        }
        return false;
    }

    public static bool IsNull(object args)
    {
        if (args == null)
            return true;
        return false;
    }

    public static bool IsNull(object args, string message)
    {
        if (args == null)
        {
            LogHelper.ErrorMessage(message);
            return true;
        }
        return false;
    }

    public static bool IsNull(object args, string message, params object[] arguments)
    {
        if (args == null)
        {
            LogHelper.ErrorMessage(message, arguments);
            return true;
        }
        return false;
    }

    public static bool IsNull(object[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == null)
                return true;
        }
        return false;
    }

    public static bool IsNull(object[] args, string message)
    {
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == null)
            {
                LogHelper.ErrorMessage(message);
                return true;
            }    
        }
        return false;
    }

    public static bool IsNull(object[] args, string message, params object[] arguments)
    {
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == null)
            {
                LogHelper.ErrorMessage(message, arguments);
                return true;
            }
        }
        return false;
    }

    public static bool IsNullOrEmpty(string str)
    {
        if (string.IsNullOrEmpty(str))
            return true;
        return false;
    }

    public static bool IsNullOrEmpty(string str, string message)
    {
        if (string.IsNullOrEmpty(str))
        {
            LogHelper.WarningMessage(message);
            return true;
        }
        return false;
    }

    public static bool IsNullOrEmpty(string str, string message, params object[] args)
    {
        if (string.IsNullOrEmpty(str))
        {
            LogHelper.WarningMessage(message, args);
            return true;
        }
        return false;
    }
    #endregion Null Check

    #region Maximum Value Check
    public static bool IsMaximum(int val, int maximumVal)
    {
        if (val >= maximumVal)
            return true;
        return false;
    }

    public static bool IsMaximum(int val, int maximumVal, string message)
    {
        if (val >= maximumVal)
        {
            LogHelper.WarningMessage(message);
            return true;
        }
        return false;
    }

    public static bool IsMaximum(int val, int maximumVal, string message, params object[] args)
    {
        if (val >= maximumVal)
        {
            LogHelper.WarningMessage(message, args);
            return true;
        }
        return false;
    }
    #endregion Maximum Value Check
}