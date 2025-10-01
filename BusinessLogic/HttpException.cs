﻿using System.Net;

namespace BusinessLogic
{
    [Serializable]
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public HttpException() { }

        public HttpException(string message, HttpStatusCode statusCode )
            : base(message) 
        {
            this.StatusCode = statusCode;
        }
        public HttpException(string message, HttpStatusCode code, Exception inner) 
            : base(message, inner)
        {
            this.StatusCode = code;
        }
        protected HttpException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
