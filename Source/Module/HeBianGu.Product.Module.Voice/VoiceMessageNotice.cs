using HeBianGu.Product.Base.Interface;
using HeBianGu.Product.Domain.ModuleManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.Module.Voice
{
    public class VoiceMessageNotice : IRegisterMessage
    {
        public void Notice(string message)
        {

            Console.WriteLine(message);

            ModuleManager.Instance.LogInfo(message);

            SpeechService.Instance.Speek(message);
        }
    }
}
