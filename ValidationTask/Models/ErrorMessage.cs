﻿namespace ValidationTask.Models
{
    public class ErrorMessage
    {
        public int StatusCode { get; set; }
        public string Title { get; set; }

        public string ExceptionMessage { get; set; }
    }
}
