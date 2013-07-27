using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public enum MessageType
    {
        Text = 1,
        Object = 2,
        Binary = 3
    }

    public class JesseMessage : IMessage
    {
        public string Message { get; set; }

        public JesseMessage() { }

        public JesseMessage(string message) {
            this.Message = message;
        }
    }

    [Serializable]
    public class JesseMessage2 : IMessage
    {
        public string Message { get; set; }

        public JesseMessage2() { }

        public JesseMessage2(string message) {
            this.Message = message;
        }
    }

    public interface IMessage
    {
        string Message { get; set; }
    }
}
