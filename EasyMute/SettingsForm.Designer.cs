namespace EasyMute
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.CaptureDevicesComboBox = new System.Windows.Forms.ComboBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.HotKeyTextBox = new System.Windows.Forms.TextBox();
            this.NotificationsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mikrofon:";
            // 
            // CaptureDevicesComboBox
            // 
            this.CaptureDevicesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CaptureDevicesComboBox.FormattingEnabled = true;
            this.CaptureDevicesComboBox.Location = new System.Drawing.Point(107, 33);
            this.CaptureDevicesComboBox.Name = "CaptureDevicesComboBox";
            this.CaptureDevicesComboBox.Size = new System.Drawing.Size(307, 28);
            this.CaptureDevicesComboBox.TabIndex = 1;
            this.CaptureDevicesComboBox.SelectionChangeCommitted += new System.EventHandler(this.CaptureDevicesComboBox_SelectionChangeCommitted);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(76, 201);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(149, 36);
            this.SaveBtn.TabIndex = 2;
            this.SaveBtn.Text = "Speichern";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(234, 201);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(149, 36);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Abbrechen";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hotkey:";
            // 
            // HotKeyTextBox
            // 
            this.HotKeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HotKeyTextBox.Location = new System.Drawing.Point(107, 89);
            this.HotKeyTextBox.Name = "HotKeyTextBox";
            this.HotKeyTextBox.Size = new System.Drawing.Size(215, 28);
            this.HotKeyTextBox.TabIndex = 5;
            this.HotKeyTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HotKeyTextBox_KeyUp);
            // 
            // NotificationsCheckBox
            // 
            this.NotificationsCheckBox.AutoSize = true;
            this.NotificationsCheckBox.Location = new System.Drawing.Point(107, 148);
            this.NotificationsCheckBox.Name = "NotificationsCheckBox";
            this.NotificationsCheckBox.Size = new System.Drawing.Size(213, 24);
            this.NotificationsCheckBox.TabIndex = 7;
            this.NotificationsCheckBox.Text = "Benachrichtigungen aktiv";
            this.NotificationsCheckBox.UseVisualStyleBackColor = true;
            this.NotificationsCheckBox.CheckedChanged += new System.EventHandler(this.NotificationsCheckBox_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.SaveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(460, 263);
            this.Controls.Add(this.NotificationsCheckBox);
            this.Controls.Add(this.HotKeyTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.CaptureDevicesComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CaptureDevicesComboBox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HotKeyTextBox;
        private System.Windows.Forms.CheckBox NotificationsCheckBox;
    }
}