using System;

namespace Team_enDEVor
{
    namespace Utility
    {
        namespace App
        {
            public static class AppEnvironmentInfo
            {
                public enum EEnvironment
                {   // How do I distinguish between development and staging environment...!?
                    Development,
                    //Staging,
                    //QA,
                    Production
                }
                private static readonly EEnvironment environment;

                static AppEnvironmentInfo()
                {

#if UNITY_EDITOR || UNITY_EDITOR_64 || UNITY_EDITOR_WIN
                    environment = EEnvironment.Development;
#elif UNITY_ANDROID || UNITY_IOS
                    environment = EEnvironment.Production;
#endif
                }

                public static EEnvironment GetEnvironmentInfo()
                {
                    return environment;
                }
            }
        }
    }
}