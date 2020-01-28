namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLog = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo50 = new System.Windows.Forms.RadioButton();
            this.rdo48 = new System.Windows.Forms.RadioButton();
            this.rdo47 = new System.Windows.Forms.RadioButton();
            this.rdo46 = new System.Windows.Forms.RadioButton();
            this.rdo45 = new System.Windows.Forms.RadioButton();
            this.rdo44 = new System.Windows.Forms.RadioButton();
            this.rdo43 = new System.Windows.Forms.RadioButton();
            this.rdo42 = new System.Windows.Forms.RadioButton();
            this.rdo41 = new System.Windows.Forms.RadioButton();
            this.rdo36 = new System.Windows.Forms.RadioButton();
            this.rdo31 = new System.Windows.Forms.RadioButton();
            this.rdo30 = new System.Windows.Forms.RadioButton();
            this.rdo29 = new System.Windows.Forms.RadioButton();
            this.rdo28 = new System.Windows.Forms.RadioButton();
            this.rdo27 = new System.Windows.Forms.RadioButton();
            this.rdo26 = new System.Windows.Forms.RadioButton();
            this.rdo11 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(8, 142);
            this.txtLog.Margin = new System.Windows.Forms.Padding(2);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(841, 194);
            this.txtLog.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 351);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "검색";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(718, 351);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 41);
            this.button2.TabIndex = 2;
            this.button2.Text = "크롤링 시작";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo50);
            this.groupBox1.Controls.Add(this.rdo48);
            this.groupBox1.Controls.Add(this.rdo47);
            this.groupBox1.Controls.Add(this.rdo46);
            this.groupBox1.Controls.Add(this.rdo45);
            this.groupBox1.Controls.Add(this.rdo44);
            this.groupBox1.Controls.Add(this.rdo43);
            this.groupBox1.Controls.Add(this.rdo42);
            this.groupBox1.Controls.Add(this.rdo41);
            this.groupBox1.Controls.Add(this.rdo36);
            this.groupBox1.Controls.Add(this.rdo31);
            this.groupBox1.Controls.Add(this.rdo30);
            this.groupBox1.Controls.Add(this.rdo29);
            this.groupBox1.Controls.Add(this.rdo28);
            this.groupBox1.Controls.Add(this.rdo27);
            this.groupBox1.Controls.Add(this.rdo26);
            this.groupBox1.Controls.Add(this.rdo11);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(840, 122);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "지역설정";
            // 
            // rdo50
            // 
            this.rdo50.AutoSize = true;
            this.rdo50.Location = new System.Drawing.Point(221, 90);
            this.rdo50.Margin = new System.Windows.Forms.Padding(2);
            this.rdo50.Name = "rdo50";
            this.rdo50.Size = new System.Drawing.Size(59, 16);
            this.rdo50.TabIndex = 16;
            this.rdo50.Text = "제주도";
            this.rdo50.UseVisualStyleBackColor = true;
            // 
            // rdo48
            // 
            this.rdo48.AutoSize = true;
            this.rdo48.Location = new System.Drawing.Point(122, 90);
            this.rdo48.Margin = new System.Windows.Forms.Padding(2);
            this.rdo48.Name = "rdo48";
            this.rdo48.Size = new System.Drawing.Size(71, 16);
            this.rdo48.TabIndex = 15;
            this.rdo48.Text = "경상남도";
            this.rdo48.UseVisualStyleBackColor = true;
            // 
            // rdo47
            // 
            this.rdo47.AutoSize = true;
            this.rdo47.Location = new System.Drawing.Point(16, 90);
            this.rdo47.Margin = new System.Windows.Forms.Padding(2);
            this.rdo47.Name = "rdo47";
            this.rdo47.Size = new System.Drawing.Size(71, 16);
            this.rdo47.TabIndex = 14;
            this.rdo47.Text = "경상북도";
            this.rdo47.UseVisualStyleBackColor = true;
            // 
            // rdo46
            // 
            this.rdo46.AutoSize = true;
            this.rdo46.Location = new System.Drawing.Point(616, 59);
            this.rdo46.Margin = new System.Windows.Forms.Padding(2);
            this.rdo46.Name = "rdo46";
            this.rdo46.Size = new System.Drawing.Size(71, 16);
            this.rdo46.TabIndex = 13;
            this.rdo46.Text = "전라남도";
            this.rdo46.UseVisualStyleBackColor = true;
            // 
            // rdo45
            // 
            this.rdo45.AutoSize = true;
            this.rdo45.Location = new System.Drawing.Point(517, 59);
            this.rdo45.Margin = new System.Windows.Forms.Padding(2);
            this.rdo45.Name = "rdo45";
            this.rdo45.Size = new System.Drawing.Size(71, 16);
            this.rdo45.TabIndex = 12;
            this.rdo45.Text = "전라북도";
            this.rdo45.UseVisualStyleBackColor = true;
            // 
            // rdo44
            // 
            this.rdo44.AutoSize = true;
            this.rdo44.Location = new System.Drawing.Point(419, 59);
            this.rdo44.Margin = new System.Windows.Forms.Padding(2);
            this.rdo44.Name = "rdo44";
            this.rdo44.Size = new System.Drawing.Size(71, 16);
            this.rdo44.TabIndex = 11;
            this.rdo44.Text = "충청남도";
            this.rdo44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo44.UseVisualStyleBackColor = true;
            // 
            // rdo43
            // 
            this.rdo43.AutoSize = true;
            this.rdo43.Location = new System.Drawing.Point(320, 59);
            this.rdo43.Margin = new System.Windows.Forms.Padding(2);
            this.rdo43.Name = "rdo43";
            this.rdo43.Size = new System.Drawing.Size(71, 16);
            this.rdo43.TabIndex = 10;
            this.rdo43.Text = "충청북도";
            this.rdo43.UseVisualStyleBackColor = true;
            // 
            // rdo42
            // 
            this.rdo42.AutoSize = true;
            this.rdo42.Location = new System.Drawing.Point(221, 59);
            this.rdo42.Margin = new System.Windows.Forms.Padding(2);
            this.rdo42.Name = "rdo42";
            this.rdo42.Size = new System.Drawing.Size(59, 16);
            this.rdo42.TabIndex = 9;
            this.rdo42.Text = "강원도";
            this.rdo42.UseVisualStyleBackColor = true;
            // 
            // rdo41
            // 
            this.rdo41.AutoSize = true;
            this.rdo41.Location = new System.Drawing.Point(122, 59);
            this.rdo41.Margin = new System.Windows.Forms.Padding(2);
            this.rdo41.Name = "rdo41";
            this.rdo41.Size = new System.Drawing.Size(59, 16);
            this.rdo41.TabIndex = 8;
            this.rdo41.Text = "경기도";
            this.rdo41.UseVisualStyleBackColor = true;
            // 
            // rdo36
            // 
            this.rdo36.AutoSize = true;
            this.rdo36.Location = new System.Drawing.Point(16, 59);
            this.rdo36.Margin = new System.Windows.Forms.Padding(2);
            this.rdo36.Name = "rdo36";
            this.rdo36.Size = new System.Drawing.Size(83, 16);
            this.rdo36.TabIndex = 7;
            this.rdo36.Text = "세종특별시";
            this.rdo36.UseVisualStyleBackColor = true;
            // 
            // rdo31
            // 
            this.rdo31.AutoSize = true;
            this.rdo31.Location = new System.Drawing.Point(616, 29);
            this.rdo31.Margin = new System.Windows.Forms.Padding(2);
            this.rdo31.Name = "rdo31";
            this.rdo31.Size = new System.Drawing.Size(47, 16);
            this.rdo31.TabIndex = 6;
            this.rdo31.Text = "울산";
            this.rdo31.UseVisualStyleBackColor = true;
            // 
            // rdo30
            // 
            this.rdo30.AutoSize = true;
            this.rdo30.Location = new System.Drawing.Point(517, 29);
            this.rdo30.Margin = new System.Windows.Forms.Padding(2);
            this.rdo30.Name = "rdo30";
            this.rdo30.Size = new System.Drawing.Size(47, 16);
            this.rdo30.TabIndex = 5;
            this.rdo30.Text = "대전";
            this.rdo30.UseVisualStyleBackColor = true;
            // 
            // rdo29
            // 
            this.rdo29.AutoSize = true;
            this.rdo29.Location = new System.Drawing.Point(419, 29);
            this.rdo29.Margin = new System.Windows.Forms.Padding(2);
            this.rdo29.Name = "rdo29";
            this.rdo29.Size = new System.Drawing.Size(47, 16);
            this.rdo29.TabIndex = 4;
            this.rdo29.Text = "광주";
            this.rdo29.UseVisualStyleBackColor = true;
            // 
            // rdo28
            // 
            this.rdo28.AutoSize = true;
            this.rdo28.Location = new System.Drawing.Point(320, 29);
            this.rdo28.Margin = new System.Windows.Forms.Padding(2);
            this.rdo28.Name = "rdo28";
            this.rdo28.Size = new System.Drawing.Size(47, 16);
            this.rdo28.TabIndex = 3;
            this.rdo28.Text = "인천";
            this.rdo28.UseVisualStyleBackColor = true;
            // 
            // rdo27
            // 
            this.rdo27.AutoSize = true;
            this.rdo27.Location = new System.Drawing.Point(221, 29);
            this.rdo27.Margin = new System.Windows.Forms.Padding(2);
            this.rdo27.Name = "rdo27";
            this.rdo27.Size = new System.Drawing.Size(47, 16);
            this.rdo27.TabIndex = 2;
            this.rdo27.Text = "대구";
            this.rdo27.UseVisualStyleBackColor = true;
            // 
            // rdo26
            // 
            this.rdo26.AutoSize = true;
            this.rdo26.Location = new System.Drawing.Point(122, 29);
            this.rdo26.Margin = new System.Windows.Forms.Padding(2);
            this.rdo26.Name = "rdo26";
            this.rdo26.Size = new System.Drawing.Size(47, 16);
            this.rdo26.TabIndex = 1;
            this.rdo26.Text = "부산";
            this.rdo26.UseVisualStyleBackColor = true;
            // 
            // rdo11
            // 
            this.rdo11.AutoSize = true;
            this.rdo11.Checked = true;
            this.rdo11.Location = new System.Drawing.Point(16, 29);
            this.rdo11.Margin = new System.Windows.Forms.Padding(2);
            this.rdo11.Name = "rdo11";
            this.rdo11.Size = new System.Drawing.Size(47, 16);
            this.rdo11.TabIndex = 0;
            this.rdo11.TabStop = true;
            this.rdo11.Text = "서울";
            this.rdo11.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(258, 354);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 32);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 364);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "시작 번호";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(534, 364);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "동시작업수";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.Location = new System.Drawing.Point(624, 354);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(71, 32);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 409);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLog);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "국민건강보험공단 크롤러";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdo50;
        private System.Windows.Forms.RadioButton rdo48;
        private System.Windows.Forms.RadioButton rdo47;
        private System.Windows.Forms.RadioButton rdo46;
        private System.Windows.Forms.RadioButton rdo45;
        private System.Windows.Forms.RadioButton rdo44;
        private System.Windows.Forms.RadioButton rdo43;
        private System.Windows.Forms.RadioButton rdo42;
        private System.Windows.Forms.RadioButton rdo41;
        private System.Windows.Forms.RadioButton rdo36;
        private System.Windows.Forms.RadioButton rdo31;
        private System.Windows.Forms.RadioButton rdo30;
        private System.Windows.Forms.RadioButton rdo29;
        private System.Windows.Forms.RadioButton rdo28;
        private System.Windows.Forms.RadioButton rdo27;
        private System.Windows.Forms.RadioButton rdo26;
        private System.Windows.Forms.RadioButton rdo11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
    }
}

