using System;
using UnityEngine;

namespace ServiceLocatorPattern
{
    public class Logger : ILoggerService
    {
        public void Log(string message)
        {
            Debug.Log("Logged : " + message);
        }
    }
}