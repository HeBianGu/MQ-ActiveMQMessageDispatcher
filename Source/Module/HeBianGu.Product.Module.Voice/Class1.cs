using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.Module.Voice
{
    /// <summary> 语音服务 </summary>
    public class SpeechService
    {
        SpeechSynthesizer hello = new SpeechSynthesizer();

        public static SpeechService Instance = new SpeechService();

        /// <summary> 输出语音 </summary>
        public void Speek(string str)
        {
            this.Stop();

            hello.SpeakAsync(str);
        }

        /// <summary> 停止播放语音 </summary>
        public void Stop()
        {
            hello.SpeakAsyncCancelAll();
        }
    }
}
