using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public static class ControlExtension
    {
        public static void Execute<T>(this T control, Action<T> action) where T : Control {
            if (control.InvokeRequired) {
                control.Invoke(action, control);
            }
            else {
                action(control);
            }
        }
    }
}
