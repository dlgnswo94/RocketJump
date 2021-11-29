using UnityEngine;

namespace TeamEnDEVor
{
    namespace Utility
    {
        public class ErrorChecker
        {
            public static bool IsNull(object obj, string message = "")
            {
                if (obj == null)
                {
                    string errorMessage = $@"{nameof(obj)} is null!";

                    if (string.IsNullOrEmpty(message))
                        LogBase.SendLog(LogBase.ELogType.Error, errorMessage);
                    else
                        LogBase.SendLog(LogBase.ELogType.Error, message);

                    return true;
                }
                return false;
            }

            public static bool IsNull(object[] obj, string message = "")
            {
                for (int i = 0; i < obj.Length; i++)
                {
                    if (obj[i] == null)
                    {
                        string errorMessage = $@"{nameof(obj)} - ({i}) is null!";

                        if (string.IsNullOrEmpty(message))
                            LogBase.SendLog(LogBase.ELogType.Error, errorMessage);
                        else
                            LogBase.SendLog(LogBase.ELogType.Error, message);

                        return true;
                    }
                }
                return false;
            }

            public static bool IsNull(Object obj, string message = "")
            {
                if (obj == null)
                {
                    string errorMessage = $@"{nameof(obj)} is null!";

                    if (string.IsNullOrEmpty(message))
                        LogBase.SendLog(LogBase.ELogType.Error, errorMessage);
                    else
                        LogBase.SendLog(LogBase.ELogType.Error, message);

                    return true;
                }
                return false;
            }

            public static bool IsNull(Object[] obj, string message = "")
            {
                for (int i = 0; i < obj.Length; i++)
                {
                    if (obj[i] == null)
                    {
                        string errorMessage = $@"{nameof(obj)} - ({i}) is null!";

                        if (string.IsNullOrEmpty(message))
                            LogBase.SendLog(LogBase.ELogType.Error, errorMessage);
                        else
                            LogBase.SendLog(LogBase.ELogType.Error, message);

                        return true;
                    }
                }
                return false;
            }
        }
    }
}