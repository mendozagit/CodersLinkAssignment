﻿using System.Collections.Generic;

namespace CodersLinkAssignment.Aplication.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T data, string message = null)
        {
            Success = true;
            Message = message;
            Data = data;
        }

        public Response(string message)
        {
            Success = false;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
