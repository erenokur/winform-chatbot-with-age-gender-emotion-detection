namespace age_gender_detection
{
    partial class Form1
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
            this.VideoPanel = new System.Windows.Forms.Panel();
            this.RobotEye = new System.Windows.Forms.PictureBox();
            this.RobotPanel = new System.Windows.Forms.Panel();
            this.DialogPanel = new System.Windows.Forms.Panel();
            this.MainTable = new System.Windows.Forms.TableLayoutPanel();
            this.LeftTable = new System.Windows.Forms.TableLayoutPanel();
            this.BottomTable = new System.Windows.Forms.TableLayoutPanel();
            this.TempSpeechText = new System.Windows.Forms.RichTextBox();
            this.AgeLabel = new System.Windows.Forms.Label();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.VideoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RobotEye)).BeginInit();
            this.MainTable.SuspendLayout();
            this.LeftTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // VideoPanel
            // 
            this.VideoPanel.Controls.Add(this.RobotEye);
            this.VideoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoPanel.Location = new System.Drawing.Point(3, 3);
            this.VideoPanel.Name = "VideoPanel";
            this.VideoPanel.Size = new System.Drawing.Size(291, 289);
            this.VideoPanel.TabIndex = 0;
            // 
            // TempSpeechText
            // 
            this.TempSpeechText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TempSpeechText.Location = new System.Drawing.Point(0, 0);
            this.TempSpeechText.Name = "TempSpeechText";
            this.TempSpeechText.Size = new System.Drawing.Size(291, 289);
            this.TempSpeechText.TabIndex = 0;
            this.TempSpeechText.TabStop = false;
            // 
            // RobotEye
            // 
            this.RobotEye.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RobotEye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotEye.Location = new System.Drawing.Point(0, 0);
            this.RobotEye.Name = "RobotEye";
            this.RobotEye.Size = new System.Drawing.Size(291, 289);
            this.RobotEye.TabIndex = 0;
            this.RobotEye.TabStop = false;
            // 
            // RobotPanel
            // 
            this.RobotPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotPanel.Location = new System.Drawing.Point(3, 416);
            this.RobotPanel.Name = "RobotPanel";
            this.RobotPanel.Size = new System.Drawing.Size(291, 171);
            this.RobotPanel.TabIndex = 1;
            // 
            // DialogPanel
            // 
            this.DialogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DialogPanel.Location = new System.Drawing.Point(306, 3);
            this.DialogPanel.Name = "DialogPanel";
            this.DialogPanel.Size = new System.Drawing.Size(702, 590);
            this.DialogPanel.TabIndex = 2;
            // 
            // MainTable
            // 
            this.MainTable.ColumnCount = 2;
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.MainTable.Controls.Add(this.LeftTable);
            this.MainTable.Controls.Add(this.BottomTable);
            this.MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTable.Location = new System.Drawing.Point(0, 0);
            this.MainTable.Name = "MainTable";
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTable.Size = new System.Drawing.Size(1011, 596);
            this.MainTable.TabIndex = 3;
            // 
            // BottomTable
            // 
            this.BottomTable.ColumnCount = 1;
            this.BottomTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomTable.Controls.Add(this.TempSpeechText, 0, 1);
            this.BottomTable.Controls.Add(this.DialogPanel, 0, 0);
            this.BottomTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomTable.Location = new System.Drawing.Point(0, 0);
            this.BottomTable.Name = "MainTable";
            this.BottomTable.RowCount = 2;
            this.BottomTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.BottomTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BottomTable.Size = new System.Drawing.Size(1011, 596);
            this.BottomTable.TabIndex = 3;
            // 
            // LeftTable
            // 
            this.LeftTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LeftTable.Controls.Add(this.VideoPanel, 0, 0);
            this.LeftTable.Controls.Add(this.RobotPanel, 0, 3);
            this.LeftTable.Controls.Add(this.AgeLabel, 0, 2);
            this.LeftTable.Controls.Add(this.GenderLabel, 0, 1);
            this.LeftTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftTable.Location = new System.Drawing.Point(3, 3);
            this.LeftTable.Name = "LeftTable";
            this.LeftTable.RowCount = 4;
            this.LeftTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LeftTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.LeftTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.LeftTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.LeftTable.Size = new System.Drawing.Size(297, 590);
            this.LeftTable.TabIndex = 3;
            // 
            // AgeLabel
            // 
            this.AgeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AgeLabel.Location = new System.Drawing.Point(3, 354);
            this.AgeLabel.Name = "AgeLabel";
            this.AgeLabel.Size = new System.Drawing.Size(291, 59);
            this.AgeLabel.TabIndex = 2;
            this.AgeLabel.Text = "Kullanıcı yaşı belirleniyor";
            this.AgeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GenderLabel
            // 
            this.GenderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GenderLabel.Location = new System.Drawing.Point(3, 295);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(291, 59);
            this.GenderLabel.TabIndex = 3;
            this.GenderLabel.Text = "Kullanıcı cinsiyeti belirleniyor";
            this.GenderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 596);
            this.Controls.Add(this.MainTable);
            this.Name = "Form1";
            this.Text = "Form1";
            this.VideoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RobotEye)).EndInit();
            this.MainTable.ResumeLayout(false);
            this.LeftTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox TempSpeechText;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.Label AgeLabel;
        private System.Windows.Forms.Panel VideoPanel;
        private System.Windows.Forms.Panel RobotPanel;
        private System.Windows.Forms.Panel DialogPanel;
        private System.Windows.Forms.PictureBox RobotEye;
        private System.Windows.Forms.TableLayoutPanel BottomTable;
        private System.Windows.Forms.TableLayoutPanel LeftTable;
        private System.Windows.Forms.TableLayoutPanel MainTable;
    }
}
