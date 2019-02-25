using HeBianGu.Product.General.Logger;
using HeBianGu.Product.Module.LED;
using HeBianGu.Product.Module.Voice;
using HeBianGu.Product.Server.ActiveMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.Domain.ServerManager
{
    public class ServerManager
    {
        public static ServerManager Instance = new ServerManager();


        ActiveMQService _activeMQService = new ActiveMQService();

        public void StartClient()
        {
            //  Message：注册消息
            _activeMQService.Clear().Register<LedMessageNotice>().Register<VoiceMessageNotice>();

            string mac = this.GetMacAddress();

            //  Message：启动客户端
            _activeMQService.StartClient(mac);


        }

        public string GetMacAddress()
        {
            try
            {
                //获取网卡硬件地址 
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                }
                moc = null;
                mc = null;

                mac = mac.Replace(':', '-');

                this.LogInfo(mac);

                return mac;
            }
            catch (Exception ex)
            {
                this.LogInfo("获取Mac地址错误：");
                this.LogError(ex);
                return null;
            }
        }

        public void StartServer()
        {
            _activeMQService.StartServer();
        }

        public void SendMessage(string message)
        {
            _activeMQService.SendMessage(message);
        }

        public void InitLogger()
        {
            Log4Servcie.Instance.InitLogger();
        }

        public void LogInfo(string message)
        {
            Log4Servcie.Instance.Info(message);
        }

        public void LogError(Exception ex)
        {
            Log4Servcie.Instance.Error(ex);
        }
    }
}
