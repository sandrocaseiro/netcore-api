﻿using System;

namespace NetCoreAPI.Exceptions
{
    public abstract class BaseException : Exception
    {
        public BaseException()
            : base()
        {

        }

        public BaseException(Exception ex)
            : base(ex.Message, ex)
        {

        }

        public abstract AppErrors AppError { get; }
    }
}
