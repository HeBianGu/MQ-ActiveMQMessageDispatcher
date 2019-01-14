using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.Server.ActiveMQ
{
    class ActiveMQDomain
    {

        public static ActiveMQDomain Instance = new ActiveMQDomain();


        public void LogInfo(params string[] messages)
        {
            foreach (var item in messages)
            {
                Console.WriteLine(item);
            }
        }

        public void LogError(params Exception[] exs)
        {
            foreach (var item in exs)
            {
                Console.WriteLine(item);
            }
           
        }


        public string GetBrokerUri()
        {
            return "tcp://192.168.1.11:61616";
        }

        public string GetUser()
        {
            return null;
        }

        public string GetPassWord()
        {
            return null;
        }
    }
}
