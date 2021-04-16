
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
            this.TimerInterval_Label = new System.Windows.Forms.Label();
            this.TimerInterval_Input = new System.Windows.Forms.NumericUpDown();
            this.TimerIntervalUnit_Label = new System.Windows.Forms.Label();
            this.Timeout_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Timeout_Input = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.TimerInterval_Input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timeout_Input)).BeginInit();
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
            // TimerInterval_Label
            // 
            this.TimerInterval_Label.AutoSize = true;
            this.TimerInterval_Label.Location = new System.Drawing.Point(13, 388);
            this.TimerInterval_Label.Name = "TimerInterval_Label";
            this.TimerInterval_Label.Size = new System.Drawing.Size(56, 17);
            this.TimerInterval_Label.TabIndex = 4;
            this.TimerInterval_Label.Text = "监控频率";
            // 
            // TimerInterval_Input
            // 
            this.TimerInterval_Input.Location = new System.Drawing.Point(76, 387);
            this.TimerInterval_Input.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimerInterval_Input.Name = "TimerInterval_Input";
            this.TimerInterval_Input.Size = new System.Drawing.Size(54, 23);
            this.TimerInterval_Input.TabIndex = 5;
            this.TimerInterval_Input.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimerInterval_Input.ValueChanged += new System.EventHandler(this.TimerInterval_Input_ValueChanged);
            // 
            // TimerIntervalUnit_Label
            // 
            this.TimerIntervalUnit_Label.AutoSize = true;
            this.TimerIntervalUnit_Label.Location = new System.Drawing.Point(137, 388);
            this.TimerIntervalUnit_Label.Name = "TimerIntervalUnit_Label";
            this.TimerIntervalUnit_Label.Size = new System.Drawing.Size(20, 17);
            this.TimerIntervalUnit_Label.TabIndex = 6;
            this.TimerIntervalUnit_Label.Text = "秒";
            // 
            // Timeout_Label
            // 
            this.Timeout_Label.AutoSize = true;
            this.Timeout_Label.Location = new System.Drawing.Point(204, 388);
            this.Timeout_Label.Name = "Timeout_Label";
            this.Timeout_Label.Size = new System.Drawing.Size(56, 17);
            this.Timeout_Label.TabIndex = 7;
            this.Timeout_Label.Text = "超时时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "秒";
            // 
            // Timeout_Input
            // 
            this.Timeout_Input.Location = new System.Drawing.Point(267, 389);
            this.Timeout_Input.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.Timeout_Input.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Timeout_Input.Name = "Timeout_Input";
            this.Timeout_Input.Size = new System.Drawing.Size(79, 23);
            this.Timeout_Input.TabIndex = 9;
            this.Timeout_Input.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Timeout_Input.ValueChanged += new System.EventHandler(this.Timeout_Input_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 430);
            this.Controls.Add(this.Timeout_Input);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Timeout_Label);
            this.Controls.Add(this.TimerIntervalUnit_Label);
            this.Controls.Add(this.TimerInterval_Input);
            this.Controls.Add(this.TimerInterval_Label);
            this.Controls.Add(this.Add_Button);
            this.Controls.Add(this.Stop_Button);
            this.Controls.Add(this.Monitor_Button);
            this.Controls.Add(this.flowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "监听器";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TimerInterval_Input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timeout_Input)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button Monitor_Button;
        private System.Windows.Forms.Button Stop_Button;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.Label TimerInterval_Label;
        private System.Windows.Forms.NumericUpDown TimerInterval_Input;
        private System.Windows.Forms.Label TimerIntervalUnit_Label;
        private System.Windows.Forms.Label Timeout_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Timeout_Input;
    }
}

