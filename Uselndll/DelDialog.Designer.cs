namespace Uselndll
{
    partial class DelDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelDialog));
            this.comboAllCard = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelTrue = new System.Windows.Forms.Button();
            this.btnDelCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDelName = new System.Windows.Forms.TextBox();
            this.txtBoxDelLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboAllCard
            // 
            this.comboAllCard.FormattingEnabled = true;
            this.comboAllCard.Location = new System.Drawing.Point(115, 24);
            this.comboAllCard.Name = "comboAllCard";
            this.comboAllCard.Size = new System.Drawing.Size(237, 23);
            this.comboAllCard.TabIndex = 0;
            this.comboAllCard.SelectedIndexChanged += new System.EventHandler(this.comboAllCard_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择保存记录";
            // 
            // btnDelTrue
            // 
            this.btnDelTrue.Location = new System.Drawing.Point(115, 121);
            this.btnDelTrue.Name = "btnDelTrue";
            this.btnDelTrue.Size = new System.Drawing.Size(107, 26);
            this.btnDelTrue.TabIndex = 2;
            this.btnDelTrue.Text = "删除";
            this.btnDelTrue.UseVisualStyleBackColor = true;
            this.btnDelTrue.Click += new System.EventHandler(this.btnDelTrue_Click);
            // 
            // btnDelCancel
            // 
            this.btnDelCancel.Location = new System.Drawing.Point(245, 121);
            this.btnDelCancel.Name = "btnDelCancel";
            this.btnDelCancel.Size = new System.Drawing.Size(107, 26);
            this.btnDelCancel.TabIndex = 3;
            this.btnDelCancel.Text = "取消";
            this.btnDelCancel.UseVisualStyleBackColor = true;
            this.btnDelCancel.Click += new System.EventHandler(this.btnDelCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "该记录姓名";
            // 
            // txtDelName
            // 
            this.txtDelName.Location = new System.Drawing.Point(115, 62);
            this.txtDelName.Name = "txtDelName";
            this.txtDelName.ReadOnly = true;
            this.txtDelName.Size = new System.Drawing.Size(237, 25);
            this.txtDelName.TabIndex = 6;
            this.txtDelName.TextChanged += new System.EventHandler(this.txtDelName_TextChanged);
            // 
            // txtBoxDelLog
            // 
            this.txtBoxDelLog.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxDelLog.Location = new System.Drawing.Point(359, 24);
            this.txtBoxDelLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxDelLog.Multiline = true;
            this.txtBoxDelLog.Name = "txtBoxDelLog";
            this.txtBoxDelLog.ReadOnly = true;
            this.txtBoxDelLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxDelLog.Size = new System.Drawing.Size(164, 123);
            this.txtBoxDelLog.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(347, 15);
            this.label3.TabIndex = 52;
            this.label3.Text = "注：删除后该数据不导出Excel，对应图像会被删除";
            // 
            // DelDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 159);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxDelLog);
            this.Controls.Add(this.txtDelName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDelCancel);
            this.Controls.Add(this.btnDelTrue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboAllCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DelDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "删除";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_close);
            this.Load += new System.EventHandler(this.DelDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboAllCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelTrue;
        private System.Windows.Forms.Button btnDelCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDelName;
        private System.Windows.Forms.TextBox txtBoxDelLog;
        private System.Windows.Forms.Label label3;
    }
}