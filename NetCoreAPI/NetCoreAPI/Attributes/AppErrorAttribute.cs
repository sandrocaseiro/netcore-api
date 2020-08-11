using System;

namespace NetCoreAPI.Attributes
{
    public class AppErrorAttribute : Attribute
    {
        public AppErrorAttribute(int httpStatus, int code, string messageRes)
        {
            HttpStatus = httpStatus;
            Code = code;
            MessageRes = messageRes;
        }

        public int HttpStatus { get; private set; }
        public int Code { get; private set; }
        public string MessageRes { get; private set; }
    }
}
