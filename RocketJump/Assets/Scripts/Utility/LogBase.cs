using UnityEngine;

namespace TeamEnDEVor
{
    namespace Utility
    {
        public class LogBase
        {
            public enum ELogType
            {
                None = 0,
                Log,
                Warning,
                Error,
            }

            public static string NameOfLogType(ELogType type)
            {
                return nameof(type);
            }

            public static void SendLog(ELogType type, string message = "")
            {
                if (string.IsNullOrEmpty(message))
                {
                    Debug.LogWarning("This message is null or empty!");
                    return;
                }

                switch (type)
                {
                    case ELogType.Log:
                        Debug.Log(message);
                        break;

                    case ELogType.Warning:
                        Debug.LogWarning(message);
                        break;

                    case ELogType.Error:
                        Debug.LogError(message);
                        break;

                    default:
                        Debug.LogWarning("Choose LogType!");
                        return;
                }
            }
        }
    }
}