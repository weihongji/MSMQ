using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message = System.Messaging.Message;

namespace WindowsFormsApplication1
{
    public partial class SendForm : Form
    {

        public SendForm() {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e) {
            SendMessage(MessageType.Text);
        }

        private void txtSendObject_Click(object sender, EventArgs e) {
            SendMessage(MessageType.Object);
        }

        private void btnSendBinary_Click(object sender, EventArgs e) {
            SendMessage(MessageType.Binary);
        }

        private void SendMessage(MessageType msgType) {
            if (!ValidateInput()) {
                return;
            }

            MessageQueue queue = Common.GetMessageQueue();
            object obj;
            switch (msgType) {
                case MessageType.Text:
                    obj = txtMessage.Text;
                    break;
                case MessageType.Object:
                    obj = new JesseMessage(txtMessage.Text);
                    break;
                case MessageType.Binary:
                    obj = new JesseMessage2(txtMessage.Text);
                    Message message = new Message() {
                        Label = msgType.ToString(),
                        Body = obj,
                        Formatter = new BinaryMessageFormatter(),
                        AppSpecific = 34,
                        Priority = MessagePriority.VeryHigh
                    };
                    queue.Send(message);
                    return;
                default:
                    throw new InvalidEnumArgumentException("msgType", (int)msgType, typeof(MessageType));
            }
            queue.Send(obj, msgType.ToString());
        }

        private bool ValidateInput() {
            txtMessage.Text = txtMessage.Text.Trim();
            if (txtMessage.Text.Length == 0) {
                MessageBox.Show(string.Format("{0} is required", "Message"));
                txtMessage.Focus();
                return false;
            }

            return true;
        }
    }
}
