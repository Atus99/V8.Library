﻿using NLog;
using System;

namespace V8.Utility.LogUtils
{
    public class LoggerManager : IloggerManager
    {
        private ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }
        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogError(Exception ex)
        {
            logger.Error(ex);
        }

        public void LogError(Exception ex, string message)
        {
            logger.Error(ex, message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }
        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
