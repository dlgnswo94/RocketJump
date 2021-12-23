using UnityEngine;

namespace Team_enDEVor
{
    namespace Utility
    {
        public static class NullChecker
        {
            public static bool IsNull(object obj, string errorMessage, params object[] args)
            {
                if (obj != null)
                    return false;

                LogSender.SendLog(errorMessage, Enum.ELogType.Error, args);
                return true;
            }

            public static bool IsNull(Object obj, string errorMessage, params object[] args)
            {
                if (obj != null)
                    return false;

                LogSender.SendLog(errorMessage, Enum.ELogType.Error, args);
                return true;
            }

            public static bool IsNull(object[] obj, string errorMessage, params object[] args)
            {
                for (int i = 0; i < obj.Length; i++)
                {
                    if (obj[i] == null)
                    {
                        LogSender.SendLog(errorMessage, Enum.ELogType.Error, args);
                        return true;
                    }
                }
                return false;
            }

            public static bool IsNull(Object[] obj, string errorMessage, params object[] args)
            {
                for (int i = 0; i < obj.Length; i++)
                {
                    if (obj[i] == null)
                    {
                        LogSender.SendLog(errorMessage, Enum.ELogType.Error, args);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}