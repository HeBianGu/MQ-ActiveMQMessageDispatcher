using HeBianGu.Product.General.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.Domain.ModuleManager
{
    public class ModuleManager
    {

        public static ModuleManager Instance = new ModuleManager();

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
