﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebMotors.Domain.Notifications
{
    public class Notification
    {
        public string Key { get; }
        public string Message { get; }

        public Notification(string key, string message)
        {
            Key = key;
            Message = message;
        }
    }
}
