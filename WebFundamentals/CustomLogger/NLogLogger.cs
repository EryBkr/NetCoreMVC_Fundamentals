﻿using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFundamentals.CustomLogger
{
    public class NLogLogger
    {
        public void LogWithNLog(string message)
        {
            var logger=LogManager.GetLogger("loggerFile"); //NLog configteki ismi atadık
            logger.Log(LogLevel.Error, message);
        }
    }
}
