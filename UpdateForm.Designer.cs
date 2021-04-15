
namespace ServerInfo
{
    partial class UpdateForm
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
            this.UpdateForm_Url_TextBox = new System.Windows.Forms.TextBox();
            this.UpdateForm_Url_Label = new System.Windows.Forms.Label();
            this.UpdateForm_Title_TextBox = new System.Windows.Forms.TextBox();
            this.UpdateForm_Title_Label = new System.Windows.Forms.Label();
            this.UpdateForm_Cancel_Button = new System.Windows.Forms.Button();
            this.UpdateForm_Save_Button = new System.Windows.Forms.Button();
            this.UpdateForm_Warn_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.UpdateForm_Warn_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UpdateForm_Url_TextBox
            // 
            this.UpdateForm_Url_TextBox.Location = new System.Drawing.Point(64, 41);
            this.UpdateForm_Url_TextBox.Name = "UpdateForm_Url_TextBox";
            this.UpdateForm_Url_TextBox.Size = new System.Drawing.Size(284, 23);
            this.UpdateForm_Url_TextBox.TabIndex = 17;
            // 
            // UpdateForm_Url_Label
            // 
            this.UpdateForm_Url_Label.AutoSize = true;
            this.UpdateForm_Url_Label.Location = new System.Drawing.Point(18, 44);
            this.UpdateForm_Url_Label.Name = "UpdateForm_Url_Label";
            this.UpdateForm_Url_Label.Size = new System.Drawing.Size(40, 17);
            this.UpdateForm_Url_Label.TabIndex = 16;
            this.UpdateForm_Url_Label.Text = "地  址";
            // 
            // UpdateForm_Title_TextBox
            // 
            this.UpdateForm_Title_TextBox.Location = new System.Drawing.Point(64, 12);
            this.UpdateForm_Title_TextBox.Name = "UpdateForm_Title_TextBox";
            this.UpdateForm_Title_TextBox.Size = new System.Drawing.Size(284, 23);
            this.UpdateForm_Title_TextBox.TabIndex = 15;
            // 
            // UpdateForm_Title_Label
            // 
            this.UpdateForm_Title_Label.AutoSize = true;
            this.UpdateForm_Title_Label.Location = new System.Drawing.Point(18, 15);
            this.UpdateForm_Title_Label.Name = "UpdateForm_Title_Label";
            this.UpdateForm_Title_Label.Size = new System.Drawing.Size(40, 17);
            this.UpdateForm_Title_Label.TabIndex = 14;
            this.UpdateForm_Title_Label.Text = "名  称";
            // 
            // UpdateForm_Cancel_Button
            // 
            this.UpdateForm_Cancel_Button.Location = new System.Drawing.Point(297, 206);
            this.UpdateForm_Cancel_Button.Name = "UpdateForm_Cancel_Button";
            this.UpdateForm_Cancel_Button.Size = new System.Drawing.Size(50, 23);
            this.UpdateForm_Cancel_Button.TabIndex = 13;
            this.UpdateForm_Cancel_Button.Text = "取消";
            this.UpdateForm_Cancel_Button.UseVisualStyleBackColor = true;
            this.UpdateForm_Cancel_Button.Click += new System.EventHandler(this.UpdateForm_Cancel_Button_Click);
            // 
            // UpdateForm_Save_Button
            // 
            this.UpdateForm_Save_Button.Location = new System.Drawing.Point(236, 206);
            this.UpdateForm_Save_Button.Name = "UpdateForm_Save_Button";
            this.UpdateForm_Save_Button.Size = new System.Drawing.Size(55, 23);
            this.UpdateForm_Save_Button.TabIndex = 12;
            this.UpdateForm_Save_Button.Text = "保存";
            this.UpdateForm_Save_Button.UseVisualStyleBackColor = true;
            this.UpdateForm_Save_Button.Click += new System.EventHandler(this.UpdateForm_Save_Button_Click);
            // 
            // UpdateForm_Warn_RichTextBox
            // 
            this.UpdateForm_Warn_RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UpdateForm_Warn_RichTextBox.Location = new System.Drawing.Point(64, 70);
            this.UpdateForm_Warn_RichTextBox.Name = "UpdateForm_Warn_RichTextBox";
            this.UpdateForm_Warn_RichTextBox.Size = new System.Drawing.Size(283, 130);
            this.UpdateForm_Warn_RichTextBox.TabIndex = 19;
            this.UpdateForm_Warn_RichTextBox.Text = "";
            // 
            // UpdateForm_Warn_Label
            // 
            this.UpdateForm_Warn_Label.AutoSize = true;
            this.UpdateForm_Warn_Label.Location = new System.Drawing.Point(17, 70);
            this.UpdateForm_Warn_Label.Name = "UpdateForm_Warn_Label";
            this.UpdateForm_Warn_Label.Size = new System.Drawing.Size(40, 17);
            this.UpdateForm_Warn_Label.TabIndex = 18;
            this.UpdateForm_Warn_Label.Text = "提  醒";
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 241);
            this.Controls.Add(this.UpdateForm_Warn_RichTextBox);
            this.Controls.Add(this.UpdateForm_Warn_Label);
            this.Controls.Add(this.UpdateForm_Url_TextBox);
            this.Controls.Add(this.UpdateForm_Url_Label);
            this.Controls.Add(this.UpdateForm_Title_TextBox);
            this.Controls.Add(this.UpdateForm_Title_Label);
            this.Controls.Add(this.UpdateForm_Cancel_Button);
            this.Controls.Add(this.UpdateForm_Save_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox UpdateForm_Url_TextBox;
        private System.Windows.Forms.Label UpdateForm_Url_Label;
        private System.Windows.Forms.TextBox UpdateForm_Title_TextBox;
        private System.Windows.Forms.Label UpdateForm_Title_Label;
        private System.Windows.Forms.Button UpdateForm_Cancel_Button;
        private System.Windows.Forms.Button UpdateForm_Save_Button;
        private System.Windows.Forms.RichTextBox UpdateForm_Warn_RichTextBox;
        private System.Windows.Forms.Label UpdateForm_Warn_Label;
    }
}