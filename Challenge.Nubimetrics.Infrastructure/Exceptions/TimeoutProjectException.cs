﻿using System;

namespace Challenge.Nubimetrics.Infrastructure.Exceptions
{
    public class TimeoutProjectException : ProjectException
    {
        public TimeoutProjectException() { }

        public TimeoutProjectException(string message) : base(message) { }

        public TimeoutProjectException(string message, Exception inner) : base(message, inner) { }
    }
}
