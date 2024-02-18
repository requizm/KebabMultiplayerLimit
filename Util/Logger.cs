using HarmonyLib;
using System;
using System.IO;
using UnityEngine;

namespace KebabMultiplayerLimit.Util
{
    public static class Logger
    {
        static string filename = $"{DateTime.Now.ToFileTime()}.log";

        public static void Init()
        {
            try
            {
                Info("Init" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                FileLog.Log($"Failed to create log file: {ex.GetType()} {ex.Message}" + Environment.NewLine);
                throw ex;
            }
        }
        private static void Log(string message, bool stackTrace = false)
        {
            File.AppendAllText(filename, message + Environment.NewLine);
            if (stackTrace)
            {
                File.AppendAllText(filename, StackTraceUtility.ExtractStackTrace() + Environment.NewLine);
            }
        }

        public static void Log(string prefix, string message, bool stackTrace = false)
        {
            Log(prefix + message, stackTrace);
        }

        public static void Info(string message, bool stackTrace = false)
        {
            string prefix = "[INFO] ";
            Log(prefix + message, stackTrace);
        }

        public static void Verbose(string message, bool stackTrace = false)
        {
            string prefix = "[VERBOSE] ";
            Log(prefix + message, stackTrace);
        }

        public static void Warning(string message, bool stackTrace = false)
        {
            string prefix = "[WARNING] ";
            Log(prefix + message, stackTrace);
        }

        public static void Error(string message, bool stackTrace = false)
        {
            string prefix = "[ERROR] ";
            Log(prefix + message, stackTrace);
        }
    }
}
