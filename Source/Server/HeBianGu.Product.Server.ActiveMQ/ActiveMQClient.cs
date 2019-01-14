using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.Server.ActiveMQ
{
    class ActiveMQClient
    {
        public event Action<IMessage> BeginMessage;

        public void Init(string brokerUri= "tcp://localhost:61616")
        {
            //创建连接工厂
            IConnectionFactory factory = new ConnectionFactory(brokerUri);
            //通过工厂构建连接
            IConnection connection = factory.CreateConnection();
            //这个是连接的客户端名称标识
            connection.ClientId = "firstQueueListener";
            //启动连接，监听的话要主动启动连接
            connection.Start();
            //通过连接创建一个会话
            ISession session = connection.CreateSession();
            //通过会话创建一个消费者，这里就是Queue这种会话类型的监听参数设置
            IMessageConsumer consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("firstQueue"), "filter='demo'");
            //注册监听事件
            consumer.Listener += l=>
            {
                ITextMessage msg = (ITextMessage)l;
                //异步调用下，否则无法回归主线程

                Task.Run(() => this.BeginMessage?.Invoke(msg));
            };
            //connection.Stop();
            //connection.Close();  

        }
        
    }
}
