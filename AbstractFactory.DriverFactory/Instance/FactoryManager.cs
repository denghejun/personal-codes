using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.DriverFactory.Instance
{
    public static class FactoryManager
    {
        //private static DriverFactory.Abstract.DriverFactory _factory = null;
        public static AbstractFactory.DriverFactory.Abstract.DriverFactory Current
        {
            get
            {
                switch (ConfigurationManager.AppSettings["CurrentPerformanceType"])
                {
                    case "low":
                        return LowDriverFactory.Instance;
                    case "high":
                        return HighDriverFactory.Instance;
                    default:
                        throw new ConfigurationException("CurrentPerformanceType value in app.config is invalid.");
                }

                //return _factory ?? (_factory = Activator.CreateInstance(Type.GetType(ConfigurationManager.AppSettings["CurrentPerformanceType"])) as DriverFactory.Abstract.DriverFactory);
            }
        }
    }
}
