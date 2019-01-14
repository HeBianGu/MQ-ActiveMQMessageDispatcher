using HeBianGu.Product.General.Logger;
using HeBianGu.Product.Module.LED;
using HeBianGu.Product.Module.Voice;
using HeBianGu.Product.Server.ActiveMQ;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _activeMQService.Register<LedMessageNotice>();
            _activeMQService.Register<VoiceMessageNotice>();

            //  Message：启动客户端
            _activeMQService.StartClient();

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
