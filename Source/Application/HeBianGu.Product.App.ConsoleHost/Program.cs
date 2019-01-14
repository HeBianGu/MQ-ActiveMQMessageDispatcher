using HeBianGu.Product.Domain.ServerManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.App.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {

            ServerManager.Instance.InitLogger();

            ServerManager.Instance.LogInfo("准备开始启动客户端");

            try
            {
                ServerManager.Instance.StartClient();

                ServerManager.Instance.LogInfo("启动客户端完成");
            }
            catch(Exception ex)
            {
                ServerManager.Instance.LogError(ex);
            }

            Console.Read();
        }
    }
}
