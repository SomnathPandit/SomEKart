using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SomEKart.Common
{
    public interface ILogger
    {
        void Log(string message);
        void Error(string error);
        void Info(string message);
    }

    public class Logger : ILogger
    {
        public void Error(string error)
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }

        public void Log(string message)
        {
            throw new NotImplementedException();
        }
    }
}
