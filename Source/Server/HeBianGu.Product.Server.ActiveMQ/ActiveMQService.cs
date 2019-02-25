using Apache.NMS;
using HeBianGu.Product.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.Server.ActiveMQ
{
    /// <summary>
    /// ActiveMQ注册接收总服务
    /// </summary>
    public class ActiveMQService
    {
        #region - 客户端 -

        ActiveMQClient _activeMQClient = new ActiveMQClient();

        List<IRegisterMessage> _registerMessages = new List<IRegisterMessage>();

        /// <summary> 启动客户端 </summary>
        public void StartClient(string mac)
        {  
            _activeMQClient.Init(mac,ActiveMQDomain.Instance.GetBrokerUri());

            _activeMQClient.BeginMessage += l =>
            {
                foreach (var item in _registerMessages)
                {
                    ITextMessage textMessage = l as ITextMessage;
                    item.Notice(textMessage.Text);
                }
            };
        }

        /// <summary> 注册订阅消息 </summary>
        public ActiveMQService Register<T>() where T : IRegisterMessage
        {
            T t = Activator.CreateInstance<T>();

            _registerMessages.Add(t);

            return this;
        }

        /// <summary> 清理注册的事假 </summary>
        public ActiveMQService Clear()
        {
            _registerMessages.Clear();

            return this;
        }

        #endregion

        #region - 服务端 -

        ActiveMQServer _activeMQServer = new ActiveMQServer();

        /// <summary> 启动服务端 </summary>
        public void StartServer()
        {
            string user = ActiveMQDomain.Instance.GetUser();
            string pw = ActiveMQDomain.Instance.GetUser();
            string url = ActiveMQDomain.Instance.GetBrokerUri();

            _activeMQServer.Init(user, pw, url);
        }

        /// <summary> 发送消息 </summary>
        public void SendMessage(string message)
        {
            _activeMQServer.SendMessage(message, "D0-03-4B-CC-FB-7F");

            _activeMQServer.SendMessage(message, "E4-3A-6E-21-14-D0");
        }

        #endregion
    }

}
