using System;

namespace V8.Utility.LogUtils
{
    public interface IloggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
        void LogError(Exception ex, string message);
        void LogError(Exception ex);
    }
}
