﻿namespace Dependency_Injection
{
    public class TimeService
    {
        public TimeService()
        {
            Time = DateTime.Now.ToLongTimeString();
        }
        public string Time { get; }
    }
}
