
namespace ServerInfo
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddForm_Save_Button = new System.Windows.Forms.Button();
            this.AddForm_Cancel_Button = new System.Windows.Forms.Button();
            this.AddForm_Title_Label = new System.Windows.Forms.Label();
            this.AddForm_Title_TextBox = new System.Windows.Forms.TextBox();
            this.AddForm_Url_Label = new System.Windows.Forms.Label();
            this.AddForm_Url_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AddForm_Save_Button
            // 
            this.AddForm_Save_Button.Location = new System.Drawing.Point(237, 71);
            this.AddForm_Save_Button.Name = "AddForm_Save_Button";
            this.AddForm_Save_Button.Size = new System.Drawing.Size(55, 23);
            this.AddForm_Save_Button.TabIndex = 0;
            this.AddForm_Save_Button.Text = "保存";
            this.AddForm_Save_Button.UseVisualStyleBackColor = true;
            this.AddForm_Save_Button.Click += new System.EventHandler(this.AddForm_Save_Button_Click);
            // 
            // AddForm_Cancel_Button
            // 
            this.AddForm_Cancel_Button.Location = new System.Drawing.Point(298, 71);
            this.AddForm_Cancel_Button.Name = "AddForm_Cancel_Button";
            this.AddForm_Cancel_Button.Size = new System.Drawing.Size(50, 23);
            this.AddForm_Cancel_Button.TabIndex = 1;
            this.AddForm_Cancel_Button.Text = "取消";
            this.AddForm_Cancel_Button.UseVisualStyleBackColor = true;
            this.AddForm_Cancel_Button.Click += new System.EventHandler(this.AddForm_Cancel_Button_Click);
            // 
            // AddForm_Title_Label
            // 
            this.AddForm_Title_Label.AutoSize = true;
            this.AddForm_Title_Label.Location = new System.Drawing.Point(18, 16);
            this.AddForm_Title_Label.Name = "AddForm_Title_Label";
            this.AddForm_Title_Label.Size = new System.Drawing.Size(40, 17);
            this.AddForm_Title_Label.TabIndex = 2;
            this.AddForm_Title_Label.Text = "名  称";
            // 
            // AddForm_Title_TextBox
            // 
            this.AddForm_Title_TextBox.Location = new System.Drawing.Point(64, 13);
            this.AddForm_Title_TextBox.Name = "AddForm_Title_TextBox";
            this.AddForm_Title_TextBox.Size = new System.Drawing.Size(284, 23);
            this.AddForm_Title_TextBox.TabIndex = 3;
            // 
            // AddForm_Url_Label
            // 
            this.AddForm_Url_Label.AutoSize = true;
            this.AddForm_Url_Label.Location = new System.Drawing.Point(18, 45);
            this.AddForm_Url_Label.Name = "AddForm_Url_Label";
            this.AddForm_Url_Label.Size = new System.Drawing.Size(40, 17);
            this.AddForm_Url_Label.TabIndex = 4;
            this.AddForm_Url_Label.Text = "地  址";
            // 
            // AddForm_Url_TextBox
            // 
            this.AddForm_Url_TextBox.Location = new System.Drawing.Point(64, 42);
            this.AddForm_Url_TextBox.Name = "AddForm_Url_TextBox";
            this.AddForm_Url_TextBox.Size = new System.Drawing.Size(284, 23);
            this.AddForm_Url_TextBox.TabIndex = 5;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 107);
            this.Controls.Add(this.AddForm_Url_TextBox);
            this.Controls.Add(this.AddForm_Url_Label);
            this.Controls.Add(this.AddForm_Title_TextBox);
            this.Controls.Add(this.AddForm_Title_Label);
            this.Controls.Add(this.AddForm_Cancel_Button);
            this.Controls.Add(this.AddForm_Save_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加";
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddForm_Save_Button;
        private System.Windows.Forms.Button AddForm_Cancel_Button;
        private System.Windows.Forms.Label AddForm_Title_Label;
        private System.Windows.Forms.TextBox AddForm_Title_TextBox;
        private System.Windows.Forms.Label AddForm_Url_Label;
        private System.Windows.Forms.TextBox AddForm_Url_TextBox;
    }
}