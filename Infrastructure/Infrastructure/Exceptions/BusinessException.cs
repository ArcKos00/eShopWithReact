﻿namespace Infrastructure.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string message)
            : base(message)
        {
        }

        public BusinessException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
