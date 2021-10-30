using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardChecker : MonoBehaviour
{
    public enum EErrorLevel
    {
        None = 0,
        Warning,
        Error
    }

    public static bool IsCorrect(bool standard, bool compare, EErrorLevel setErrorLevel, string message = "")
    {
        if (standard == compare)
            return true;

        if (!string.IsNullOrEmpty(message))
        {
            switch (setErrorLevel)
            {
                case EErrorLevel.None:
                    LogHelper.LogMessage(message);
                    break;

                case EErrorLevel.Warning:
                    LogHelper.WarningMessage(message);
                    break;

                case EErrorLevel.Error:
                    LogHelper.ErrorMessage(message);
                    break;
            }
        }

        return false;
    }
}