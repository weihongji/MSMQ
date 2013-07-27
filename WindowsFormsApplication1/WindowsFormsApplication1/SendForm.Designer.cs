namespace WindowsFormsApplication1
{
    partial class SendForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSendObject = new System.Windows.Forms.Button();
            this.btnSendBinary = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(66, 28);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(202, 44);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.Text = "Hello!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Message";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(70, 142);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(96, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSendObject
            // 
            this.txtSendObject.Location = new System.Drawing.Point(205, 142);
            this.txtSendObject.Name = "txtSendObject";
            this.txtSendObject.Size = new System.Drawing.Size(96, 23);
            this.txtSendObject.TabIndex = 5;
            this.txtSendObject.Text = "Send &Object";
            this.txtSendObject.UseVisualStyleBackColor = true;
            this.txtSendObject.Click += new System.EventHandler(this.txtSendObject_Click);
            // 
            // btnSendBinary
            // 
            this.btnSendBinary.Location = new System.Drawing.Point(205, 187);
            this.btnSendBinary.Name = "btnSendBinary";
            this.btnSendBinary.Size = new System.Drawing.Size(96, 23);
            this.btnSendBinary.TabIndex = 5;
            this.btnSendBinary.Text = "Send &Binary";
            this.btnSendBinary.UseVisualStyleBackColor = true;
            this.btnSendBinary.Click += new System.EventHandler(this.btnSendBinary_Click);
            // 
            // SendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 242);
            this.Controls.Add(this.btnSendBinary);
            this.Controls.Add(this.txtSendObject);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SendForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button txtSendObject;
        private System.Windows.Forms.Button btnSendBinary;
    }
}

