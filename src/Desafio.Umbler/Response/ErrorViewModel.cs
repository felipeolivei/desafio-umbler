using Newtonsoft.Json;
using System;

namespace Desafio.Umbler.Response
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}