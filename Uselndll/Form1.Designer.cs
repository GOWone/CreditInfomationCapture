namespace Uselndll
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReadLog = new System.Windows.Forms.TextBox();
            this.btnSekectFolder = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnOutput = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSelectHis = new System.Windows.Forms.Button();
            this.advice = new System.Windows.Forms.Label();
            this.txtBoxInput = new System.Windows.Forms.TextBox();
            this.txtBoxOutput = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.totalCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtCardName = new System.Windows.Forms.TextBox();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveToExcel = new System.Windows.Forms.Button();
            this.btnChangeSave = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.HeadUpdate = new System.Windows.Forms.Label();
            this.autoReadMode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 11F);
            this.button1.Location = new System.Drawing.Point(18, 482);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(292, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "读卡";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 419);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "ID号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 387);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "姓名：";
            // 
            // txtReadLog
            // 
            this.txtReadLog.BackColor = System.Drawing.Color.White;
            this.txtReadLog.Location = new System.Drawing.Point(16, 587);
            this.txtReadLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtReadLog.Multiline = true;
            this.txtReadLog.Name = "txtReadLog";
            this.txtReadLog.ReadOnly = true;
            this.txtReadLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReadLog.Size = new System.Drawing.Size(294, 123);
            this.txtReadLog.TabIndex = 26;
            this.txtReadLog.TextChanged += new System.EventHandler(this.txtReadLog_TextChanged);
            // 
            // btnSekectFolder
            // 
            this.btnSekectFolder.Location = new System.Drawing.Point(359, 587);
            this.btnSekectFolder.Name = "btnSekectFolder";
            this.btnSekectFolder.Size = new System.Drawing.Size(311, 25);
            this.btnSekectFolder.TabIndex = 27;
            this.btnSekectFolder.Text = "选择导入文件夹";
            this.btnSekectFolder.UseVisualStyleBackColor = true;
            this.btnSekectFolder.Click += new System.EventHandler(this.btnSekectFolder_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(359, 618);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(311, 25);
            this.textBox1.TabIndex = 28;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(359, 685);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(311, 25);
            this.textBox2.TabIndex = 30;
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(359, 654);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(311, 25);
            this.btnOutput.TabIndex = 29;
            this.btnOutput.Text = "选择导出文件夹";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10F);
            this.label11.Location = new System.Drawing.Point(348, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 17);
            this.label11.TabIndex = 36;
            this.label11.Text = "当前照片";
            // 
            // btnSelectHis
            // 
            this.btnSelectHis.Location = new System.Drawing.Point(792, 25);
            this.btnSelectHis.Name = "btnSelectHis";
            this.btnSelectHis.Size = new System.Drawing.Size(120, 25);
            this.btnSelectHis.TabIndex = 41;
            this.btnSelectHis.Text = "选择";
            this.btnSelectHis.UseVisualStyleBackColor = true;
            this.btnSelectHis.Click += new System.EventHandler(this.btnSelectHis_Click);
            // 
            // advice
            // 
            this.advice.AutoSize = true;
            this.advice.ForeColor = System.Drawing.SystemColors.Highlight;
            this.advice.Location = new System.Drawing.Point(430, 30);
            this.advice.Name = "advice";
            this.advice.Size = new System.Drawing.Size(52, 15);
            this.advice.TabIndex = 46;
            this.advice.Text = "未选中";
            // 
            // txtBoxInput
            // 
            this.txtBoxInput.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxInput.Location = new System.Drawing.Point(695, 587);
            this.txtBoxInput.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxInput.Multiline = true;
            this.txtBoxInput.Name = "txtBoxInput";
            this.txtBoxInput.ReadOnly = true;
            this.txtBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxInput.Size = new System.Drawing.Size(186, 123);
            this.txtBoxInput.TabIndex = 50;
            this.txtBoxInput.TextChanged += new System.EventHandler(this.txtBoxInput_TextChanged);
            // 
            // txtBoxOutput
            // 
            this.txtBoxOutput.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxOutput.Location = new System.Drawing.Point(906, 587);
            this.txtBoxOutput.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxOutput.Multiline = true;
            this.txtBoxOutput.Name = "txtBoxOutput";
            this.txtBoxOutput.ReadOnly = true;
            this.txtBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxOutput.Size = new System.Drawing.Size(257, 123);
            this.txtBoxOutput.TabIndex = 51;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(540, 30);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(232, 15);
            this.label21.TabIndex = 58;
            this.label21.Text = "注：进行照片上下调节时请勿拍照";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 11F);
            this.button3.Location = new System.Drawing.Point(819, 483);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 47);
            this.button3.TabIndex = 59;
            this.button3.Text = "缩放图像";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label22.Location = new System.Drawing.Point(1019, 568);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(52, 15);
            this.label22.TabIndex = 62;
            this.label22.Text = "总量：";
            // 
            // totalCount
            // 
            this.totalCount.AutoSize = true;
            this.totalCount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.totalCount.Location = new System.Drawing.Point(1077, 568);
            this.totalCount.Name = "totalCount";
            this.totalCount.Size = new System.Drawing.Size(15, 15);
            this.totalCount.TabIndex = 63;
            this.totalCount.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(692, 567);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 65;
            this.label1.Text = "导入图像列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(903, 567);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 66;
            this.label2.Text = "导出图像列表";
            // 
            // btnForward
            // 
            this.btnForward.Font = new System.Drawing.Font("宋体", 11F);
            this.btnForward.Location = new System.Drawing.Point(663, 483);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(150, 47);
            this.btnForward.TabIndex = 67;
            this.btnForward.Text = "下一张";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("宋体", 11F);
            this.btnNext.Location = new System.Drawing.Point(507, 482);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(150, 47);
            this.btnNext.TabIndex = 68;
            this.btnNext.Text = "上一张";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtCardName
            // 
            this.txtCardName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardName.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardName.Location = new System.Drawing.Point(97, 381);
            this.txtCardName.Name = "txtCardName";
            this.txtCardName.Size = new System.Drawing.Size(188, 28);
            this.txtCardName.TabIndex = 69;
            // 
            // txtCardID
            // 
            this.txtCardID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardID.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardID.Location = new System.Drawing.Point(97, 415);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(188, 28);
            this.txtCardID.TabIndex = 70;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(15, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 73;
            this.label4.Text = "获取身份信息";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(18, 57);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(292, 418);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 72;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(351, 57);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(812, 418);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(41, 89);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(244, 285);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // saveToExcel
            // 
            this.saveToExcel.Location = new System.Drawing.Point(1044, 25);
            this.saveToExcel.Name = "saveToExcel";
            this.saveToExcel.Size = new System.Drawing.Size(120, 25);
            this.saveToExcel.TabIndex = 75;
            this.saveToExcel.Text = "导出清单";
            this.saveToExcel.UseVisualStyleBackColor = true;
            this.saveToExcel.Click += new System.EventHandler(this.saveToExcel_Click);
            // 
            // btnChangeSave
            // 
            this.btnChangeSave.Font = new System.Drawing.Font("宋体", 11F);
            this.btnChangeSave.Location = new System.Drawing.Point(351, 482);
            this.btnChangeSave.Name = "btnChangeSave";
            this.btnChangeSave.Size = new System.Drawing.Size(150, 47);
            this.btnChangeSave.TabIndex = 76;
            this.btnChangeSave.Text = "更名保存";
            this.btnChangeSave.UseVisualStyleBackColor = true;
            this.btnChangeSave.Click += new System.EventHandler(this.btnChangeSave_Click);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(975, 501);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(189, 28);
            this.textBox3.TabIndex = 39;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(918, 25);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(120, 25);
            this.btnDel.TabIndex = 77;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.Location = new System.Drawing.Point(1025, 483);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 78;
            this.label6.Text = "图像名称";
            // 
            // HeadUpdate
            // 
            this.HeadUpdate.AutoSize = true;
            this.HeadUpdate.Font = new System.Drawing.Font("宋体", 9F);
            this.HeadUpdate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.HeadUpdate.Location = new System.Drawing.Point(808, 569);
            this.HeadUpdate.Name = "HeadUpdate";
            this.HeadUpdate.Size = new System.Drawing.Size(67, 15);
            this.HeadUpdate.TabIndex = 79;
            this.HeadUpdate.Text = "手动刷新";
            this.HeadUpdate.Click += new System.EventHandler(this.HeadUpdate_Click);
            // 
            // autoReadMode
            // 
            this.autoReadMode.Location = new System.Drawing.Point(190, 25);
            this.autoReadMode.Name = "autoReadMode";
            this.autoReadMode.Size = new System.Drawing.Size(120, 25);
            this.autoReadMode.TabIndex = 81;
            this.autoReadMode.Text = "自动读卡";
            this.autoReadMode.UseVisualStyleBackColor = true;
            this.autoReadMode.Click += new System.EventHandler(this.autoReadMode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 721);
            this.Controls.Add(this.autoReadMode);
            this.Controls.Add(this.HeadUpdate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnChangeSave);
            this.Controls.Add(this.saveToExcel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtCardID);
            this.Controls.Add(this.txtCardName);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalCount);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtBoxOutput);
            this.Controls.Add(this.txtBoxInput);
            this.Controls.Add(this.advice);
            this.Controls.Add(this.btnSelectHis);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSekectFolder);
            this.Controls.Add(this.txtReadLog);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图像采集系统(精伦)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtReadLog;
        private System.Windows.Forms.Button btnSekectFolder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSelectHis;
        private System.Windows.Forms.Label advice;
        private System.Windows.Forms.TextBox txtBoxInput;
        private System.Windows.Forms.TextBox txtBoxOutput;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label totalCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtCardName;
        private System.Windows.Forms.TextBox txtCardID;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveToExcel;
        private System.Windows.Forms.Button btnChangeSave;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label HeadUpdate;
        private System.Windows.Forms.Button autoReadMode;
    }
}

