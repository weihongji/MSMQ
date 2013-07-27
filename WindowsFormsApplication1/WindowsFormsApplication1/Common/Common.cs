using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using Message = System.Messaging.Message;

namespace WindowsFormsApplication1
{
    public class Common
    {
        private const string QUEUE_NAME = @".\private$\JesseQueue";

        public static MessageQueue GetMessageQueue() {
            return GetMessageQueue(QUEUE_NAME);
        }

        public static MessageQueue GetMessageQueue(string path) {
            MessageQueue queue;
            if (MessageQueue.Exists(path)) {
                try {
                    queue = new MessageQueue(path);
                }
                catch (Exception e) {
                    throw new Exception("Error Getting Queue", e);
                }
            }
            else {
                try {
                    queue = MessageQueue.Create(path);
                }
                catch (Exception e) {
                    //Error could occur creating queue if the code does not have sufficient permissions to create queues.
                    throw new Exception("Error Creating Queue", e);
                }
            }
            return queue;
        }
    }
}
