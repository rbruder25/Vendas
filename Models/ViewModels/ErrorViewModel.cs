using System;
using System.Diagnostics;

namespace SalesWebMvc.Models.VielModels 
{
    public class ErrorViewModel
    {
        internal Activity requestId;

        public string RequestId { get; set; }
        public string  Message { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}