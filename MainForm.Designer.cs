
namespace ProjectMonitor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Monitor_Button = new System.Windows.Forms.Button();
            this.Stop_Button = new System.Windows.Forms.Button();
            this.Add_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(634, 368);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // Monitor_Button
            // 
            this.Monitor_Button.Location = new System.Drawing.Point(512, 387);
            this.Monitor_Button.Name = "Monitor_Button";
            this.Monitor_Button.Size = new System.Drawing.Size(61, 33);
            this.Monitor_Button.TabIndex = 2;
            this.Monitor_Button.Text = "监听";
            this.Monitor_Button.UseVisualStyleBackColor = true;
            this.Monitor_Button.Click += new System.EventHandler(this.Monitor_Button_Click);
            // 
            // Stop_Button
            // 
            this.Stop_Button.Location = new System.Drawing.Point(580, 388);
            this.Stop_Button.Name = "Stop_Button";
            this.Stop_Button.Size = new System.Drawing.Size(67, 32);
            this.Stop_Button.TabIndex = 3;
            this.Stop_Button.Text = "停止";
            this.Stop_Button.UseVisualStyleBackColor = true;
            this.Stop_Button.Click += new System.EventHandler(this.Stop_Button_Click);
            // 
            // Add_Button
            // 
            this.Add_Button.Location = new System.Drawing.Point(439, 387);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(67, 33);
            this.Add_Button.TabIndex = 1;
            this.Add_Button.Text = "添加";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 430);
            this.Controls.Add(this.Add_Button);
            this.Controls.Add(this.Stop_Button);
            this.Controls.Add(this.Monitor_Button);
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "MainForm";
            this.Text = "监听器";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button Monitor_Button;
        private System.Windows.Forms.Button Stop_Button;
        private System.Windows.Forms.Button Add_Button;
    }
}

