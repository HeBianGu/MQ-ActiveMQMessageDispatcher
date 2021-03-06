﻿using HeBianGu.Product.Domain.ServerManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HeBianGu.Product.App.WindowServiceHost
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServerManager.Instance.InitLogger();

            ServerManager.Instance.LogInfo("Window服务准备启动！");

            int count = 0;

            while (true)
            {
                try
                {
                    count++;

                    ServerManager.Instance.LogInfo($"准备开始启动客户端:尝试{count}次");

                    ServerManager.Instance.StartClient();

                    ServerManager.Instance.LogInfo("启动客户端完成");

                    ServerManager.Instance.LogInfo("Window服务启动完成！");

                    break;

                }
                catch (Exception ex)
                {
                    ServerManager.Instance.LogInfo("启动客户端错误");

                    ServerManager.Instance.LogError(ex);

                    ServerManager.Instance.LogInfo("一分钟后进行自动重连");

                    Thread.Sleep(60 * 1000);
                }
            }

        }

        protected override void OnStop()
        {

            ServerManager.Instance.LogInfo("Window服务停止！");
        }
    }
}
