using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        private SendForm form1 = null;
        private ReceiveForm form2 = null;

        public MainForm() {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e) {
            var form = form1;
            if (form == null || form.IsDisposed) {
                form = new SendForm();
                var x = (this.Location.X + this.Width / 2) - form.Width;
                var y = this.Location.Y + 200;
                form.Location = new Point(x, y);
            }
            form.Show();
            form.Focus();
        }

        private void btnReceive_Click(object sender, EventArgs e) {
            var form = form2;
            if (form == null || form.IsDisposed) {
                form = new ReceiveForm();
                var x = (this.Location.X + this.Width / 2) + 5;
                var y = this.Location.Y + 200;
                form.Location = new Point(x, y);
            }
            form.Show();
            form.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
