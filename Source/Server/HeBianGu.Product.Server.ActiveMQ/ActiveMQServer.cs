﻿using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.Server.ActiveMQ
{
    /// <summary>
    /// 发送消息服务类
    /// </summary>
    class ActiveMQServer
    {
        private IConnectionFactory factory;

        string _userName;
        string _passWord;

        bool _flag;

        public void Init(string user, string pw, string brokerUri)
        {
            _userName = user;
            _passWord = pw;

            try
            {
                //初始化工厂
                factory = new ConnectionFactory(brokerUri);

                ActiveMQDomain.Instance.LogInfo("初始化成功");


                _flag = true;
            }
            catch (Exception ex)
            {
                ActiveMQDomain.Instance.LogInfo("初始化失败");
                ActiveMQDomain.Instance.LogError(ex);
            }
        }

        public void SendMessage(string ms,string group)
        {
            if (!_flag) return;

            //建立工厂连接
            using (IConnection connection = factory.CreateConnection())
            {
                //通过工厂连接创建Session会话
                using (ISession session = connection.CreateSession())
                {
                    //通过会话创建生产者，方法里new出来MQ的Queue
                    IMessageProducer prod = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("firstQueue"));
                    //创建一个发送消息的对象
                    ITextMessage message = prod.CreateTextMessage();
                    //给这个消息对象赋实际的消息
                    message.Text = ms; 

                    //设置消息对象的属性，是Queue的过滤条件也是P2P的唯一指定属性
                    message.Properties.SetString("filter", group);

                    prod.Send(message, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);
                    message.Text += "发送成功" + Environment.NewLine;
                }
            }
        }
    }
}
