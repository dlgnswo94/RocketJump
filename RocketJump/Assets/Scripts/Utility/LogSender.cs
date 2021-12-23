using UnityEngine;
using Team_enDEVor.Utility.App;
using Team_enDEVor.Utility.Enum;

namespace Team_enDEVor
{
    namespace Utility
    {
        public static class LogSender
        {
            public static void SendLog(string message, ELogType logLevel, params object[] args)
            {
                if (AppEnvironmentInfo.GetEnvironmentInfo() == AppEnvironmentInfo.EEnvironment.Production)
                    return;

                string messageFormat = message;

                if (string.IsNullOrEmpty(messageFormat))
                {
                    Debug.Log("This message is null or empty!");
                    return;
                }

                if (args != null)
                    messageFormat = string.Format(messageFormat, args);

                switch (logLevel)
                {
                    case ELogType.Log:
                        Debug.Log(messageFormat);
                        break;

                    case ELogType.Warning:
                        Debug.LogWarning(messageFormat);
                        break;

                    case ELogType.Error:
                        Debug.LogError(messageFormat);
                        break;

                    case ELogType.Assertion:
                        Debug.LogAssertion(messageFormat);
                        break;

                    case ELogType.Exception:
                        // Add Later...
                        //Debug.LogException();
                        break;

                    default:
                        Debug.Log("Unregistered log type.");
                        break;
                }
            }
        }
    }
}