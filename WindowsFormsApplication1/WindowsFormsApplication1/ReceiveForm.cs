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
    public partial class ReceiveForm : Form
    {
        private bool IsProcessing;

        public ReceiveForm() {
            InitializeComponent();
        }

        private void btnReceive_Click(object sender, EventArgs e) {
            if (chkAnsyc.Checked) {
                ReceiveAsync();
            }
            else {
                Receive();
            }
        }

        private void Receive() {
            txtLabel.Text = string.Empty;
            txtMessage.Text = "Waiting...";
            SetBusy(true);
            this.Update();

            MessageQueue queue = Common.GetMessageQueue();
            Message message;
            try {
                message = queue.Receive(new TimeSpan(0, 0, 10));
            }
            catch {
                txtMessage.Text = string.Empty;
                SetBusy(false);
                MessageBox.Show("No message found in the queue.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Type[] targetTypes = new Type[1];
            MessageType msgType;
            if (!Enum.TryParse(message.Label, out msgType)) {
                msgType = MessageType.Text;
            }

            switch (msgType) {
                case MessageType.Text:
                    targetTypes[0] = typeof(String);
                    break;
                case MessageType.Object:
                    targetTypes[0] = typeof(JesseMessage);
                    break;
                case MessageType.Binary:
                    targetTypes[0] = typeof(JesseMessage2);
                    break;
                default:
                    throw new InvalidEnumArgumentException("Message Label", (int)msgType, typeof(MessageType));
            }

            if (msgType == MessageType.Binary) {
                message.Formatter = new BinaryMessageFormatter();
            }
            else {
                message.Formatter = new XmlMessageFormatter(targetTypes);
            }

            if (message.Body is IMessage) {
                var body = message.Body as IMessage;
                txtMessage.Text = body.Message;
            }
            else {
                txtMessage.Text = message.Body.ToString();
            }
            txtLabel.Text = message.Label;
            SetBusy(false);
        }

        private void ReceiveAsync() {
            if (IsProcessing) {
                return;
            }
            txtLabel.Text = string.Empty;
            txtMessage.Text = "Waiting...";
            SetBusy(true);
            this.Update();

            MessageQueue queue = Common.GetMessageQueue();
            queue.ReceiveCompleted += queue_ReceiveCompleted;
            IsProcessing = true;
            queue.BeginReceive();
        }

        void queue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e) {
            Message message = e.Message;
            Type[] targetTypes = new Type[1];
            MessageType msgType;
            if (!Enum.TryParse(message.Label, out msgType)) {
                msgType = MessageType.Text;
            }

            switch (msgType) {
                case MessageType.Text:
                    targetTypes[0] = typeof(String);
                    break;
                case MessageType.Object:
                    targetTypes[0] = typeof(JesseMessage);
                    break;
                case MessageType.Binary:
                    targetTypes[0] = typeof(JesseMessage2);
                    break;
                default:
                    throw new InvalidEnumArgumentException("Message Label", (int)msgType, typeof(MessageType));
            }

            if (msgType == MessageType.Binary) {
                message.Formatter = new BinaryMessageFormatter();
            }
            else {
                message.Formatter = new XmlMessageFormatter(targetTypes);
            }

            if (message.Body is IMessage) {
                var body = message.Body as IMessage;
                txtMessage.Execute(x => x.Text = body.Message);
            }
            else {
                txtMessage.Execute(x => x.Text = message.Body.ToString());
            }
            txtLabel.Execute(x => x.Text = message.Label);
            SetBusy(false);
            IsProcessing = false;
        }

        private void SetBusy(bool isBusy) {
            var cursor = this.DefaultCursor;
            if (isBusy) {
                cursor = Cursors.WaitCursor;
            }

            this.Execute(x => x.Cursor = cursor);

            foreach (var item in this.Controls) {
                if (item is TextBox) {
                    ((TextBox)item).Execute(x => x.Cursor = cursor);
                }
            }
        }
    }
}
