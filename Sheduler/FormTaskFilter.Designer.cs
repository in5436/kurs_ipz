namespace Sheduler {
    partial class FormTaskFilter {
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
            this.groupBoxCreate = new System.Windows.Forms.GroupBox();
            this.rCreateNone = new System.Windows.Forms.RadioButton();
            this.rCreateYear = new System.Windows.Forms.RadioButton();
            this.rCreateHalfYear = new System.Windows.Forms.RadioButton();
            this.rCreateMonth = new System.Windows.Forms.RadioButton();
            this.rCreateWeek = new System.Windows.Forms.RadioButton();
            this.groupBoxDone = new System.Windows.Forms.GroupBox();
            this.rDoneMonth = new System.Windows.Forms.RadioButton();
            this.rDoneWeek = new System.Windows.Forms.RadioButton();
            this.rDoneDay = new System.Windows.Forms.RadioButton();
            this.rDoneOver = new System.Windows.Forms.RadioButton();
            this.rDoneNone = new System.Windows.Forms.RadioButton();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.rStatusNone = new System.Windows.Forms.RadioButton();
            this.rStatusClose = new System.Windows.Forms.RadioButton();
            this.rStatusCheck = new System.Windows.Forms.RadioButton();
            this.rStatusNotCheck = new System.Windows.Forms.RadioButton();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonDef = new System.Windows.Forms.Button();
            this.rStatusNotWork = new System.Windows.Forms.RadioButton();
            this.groupBoxCreate.SuspendLayout();
            this.groupBoxDone.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCreate
            // 
            this.groupBoxCreate.Controls.Add(this.rCreateNone);
            this.groupBoxCreate.Controls.Add(this.rCreateYear);
            this.groupBoxCreate.Controls.Add(this.rCreateHalfYear);
            this.groupBoxCreate.Controls.Add(this.rCreateMonth);
            this.groupBoxCreate.Controls.Add(this.rCreateWeek);
            this.groupBoxCreate.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCreate.Name = "groupBoxCreate";
            this.groupBoxCreate.Size = new System.Drawing.Size(243, 146);
            this.groupBoxCreate.TabIndex = 0;
            this.groupBoxCreate.TabStop = false;
            this.groupBoxCreate.Text = "По даті створення";
            // 
            // rCreateNone
            // 
            this.rCreateNone.AutoSize = true;
            this.rCreateNone.Location = new System.Drawing.Point(9, 115);
            this.rCreateNone.Name = "rCreateNone";
            this.rCreateNone.Size = new System.Drawing.Size(86, 17);
            this.rCreateNone.TabIndex = 4;
            this.rCreateNone.TabStop = true;
            this.rCreateNone.Text = "Без фільтра";
            this.rCreateNone.UseVisualStyleBackColor = true;
            // 
            // rCreateYear
            // 
            this.rCreateYear.AutoSize = true;
            this.rCreateYear.Location = new System.Drawing.Point(9, 92);
            this.rCreateYear.Name = "rCreateYear";
            this.rCreateYear.Size = new System.Drawing.Size(55, 17);
            this.rCreateYear.TabIndex = 3;
            this.rCreateYear.TabStop = true;
            this.rCreateYear.Text = "За рік";
            this.rCreateYear.UseVisualStyleBackColor = true;
            // 
            // rCreateHalfYear
            // 
            this.rCreateHalfYear.AutoSize = true;
            this.rCreateHalfYear.Location = new System.Drawing.Point(9, 68);
            this.rCreateHalfYear.Name = "rCreateHalfYear";
            this.rCreateHalfYear.Size = new System.Drawing.Size(78, 17);
            this.rCreateHalfYear.TabIndex = 2;
            this.rCreateHalfYear.TabStop = true;
            this.rCreateHalfYear.Text = "За півроку";
            this.rCreateHalfYear.UseVisualStyleBackColor = true;
            // 
            // rCreateMonth
            // 
            this.rCreateMonth.AutoSize = true;
            this.rCreateMonth.Location = new System.Drawing.Point(9, 44);
            this.rCreateMonth.Name = "rCreateMonth";
            this.rCreateMonth.Size = new System.Drawing.Size(75, 17);
            this.rCreateMonth.TabIndex = 1;
            this.rCreateMonth.TabStop = true;
            this.rCreateMonth.Text = "За місяць";
            this.rCreateMonth.UseVisualStyleBackColor = true;
            // 
            // rCreateWeek
            // 
            this.rCreateWeek.AutoSize = true;
            this.rCreateWeek.Location = new System.Drawing.Point(9, 20);
            this.rCreateWeek.Name = "rCreateWeek";
            this.rCreateWeek.Size = new System.Drawing.Size(84, 17);
            this.rCreateWeek.TabIndex = 0;
            this.rCreateWeek.TabStop = true;
            this.rCreateWeek.Text = "За тиждень";
            this.rCreateWeek.UseVisualStyleBackColor = true;
            // 
            // groupBoxDone
            // 
            this.groupBoxDone.Controls.Add(this.rDoneMonth);
            this.groupBoxDone.Controls.Add(this.rDoneWeek);
            this.groupBoxDone.Controls.Add(this.rDoneDay);
            this.groupBoxDone.Controls.Add(this.rDoneOver);
            this.groupBoxDone.Controls.Add(this.rDoneNone);
            this.groupBoxDone.Location = new System.Drawing.Point(270, 12);
            this.groupBoxDone.Name = "groupBoxDone";
            this.groupBoxDone.Size = new System.Drawing.Size(243, 146);
            this.groupBoxDone.TabIndex = 1;
            this.groupBoxDone.TabStop = false;
            this.groupBoxDone.Text = "По даті виконання";
            // 
            // rDoneMonth
            // 
            this.rDoneMonth.AutoSize = true;
            this.rDoneMonth.Location = new System.Drawing.Point(7, 115);
            this.rDoneMonth.Name = "rDoneMonth";
            this.rDoneMonth.Size = new System.Drawing.Size(76, 17);
            this.rDoneMonth.TabIndex = 4;
            this.rDoneMonth.TabStop = true;
            this.rDoneMonth.Text = "На місяць";
            this.rDoneMonth.UseVisualStyleBackColor = true;
            // 
            // rDoneWeek
            // 
            this.rDoneWeek.AutoSize = true;
            this.rDoneWeek.Location = new System.Drawing.Point(7, 92);
            this.rDoneWeek.Name = "rDoneWeek";
            this.rDoneWeek.Size = new System.Drawing.Size(85, 17);
            this.rDoneWeek.TabIndex = 3;
            this.rDoneWeek.TabStop = true;
            this.rDoneWeek.Text = "На тиждень";
            this.rDoneWeek.UseVisualStyleBackColor = true;
            // 
            // rDoneDay
            // 
            this.rDoneDay.AutoSize = true;
            this.rDoneDay.Location = new System.Drawing.Point(7, 68);
            this.rDoneDay.Name = "rDoneDay";
            this.rDoneDay.Size = new System.Drawing.Size(65, 17);
            this.rDoneDay.TabIndex = 2;
            this.rDoneDay.TabStop = true;
            this.rDoneDay.Text = "На добу";
            this.rDoneDay.UseVisualStyleBackColor = true;
            // 
            // rDoneOver
            // 
            this.rDoneOver.AutoSize = true;
            this.rDoneOver.Location = new System.Drawing.Point(7, 44);
            this.rDoneOver.Name = "rDoneOver";
            this.rDoneOver.Size = new System.Drawing.Size(72, 17);
            this.rDoneOver.TabIndex = 1;
            this.rDoneOver.TabStop = true;
            this.rDoneOver.Text = "На зараз";
            this.rDoneOver.UseVisualStyleBackColor = true;
            // 
            // rDoneNone
            // 
            this.rDoneNone.AutoSize = true;
            this.rDoneNone.Location = new System.Drawing.Point(7, 20);
            this.rDoneNone.Name = "rDoneNone";
            this.rDoneNone.Size = new System.Drawing.Size(86, 17);
            this.rDoneNone.TabIndex = 0;
            this.rDoneNone.TabStop = true;
            this.rDoneNone.Text = "Без фільтра";
            this.rDoneNone.UseVisualStyleBackColor = true;
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.rStatusNotWork);
            this.groupBoxStatus.Controls.Add(this.rStatusNone);
            this.groupBoxStatus.Controls.Add(this.rStatusClose);
            this.groupBoxStatus.Controls.Add(this.rStatusCheck);
            this.groupBoxStatus.Controls.Add(this.rStatusNotCheck);
            this.groupBoxStatus.Location = new System.Drawing.Point(13, 165);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(242, 141);
            this.groupBoxStatus.TabIndex = 2;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "По статусу";
            // 
            // rStatusNone
            // 
            this.rStatusNone.AutoSize = true;
            this.rStatusNone.Location = new System.Drawing.Point(8, 19);
            this.rStatusNone.Name = "rStatusNone";
            this.rStatusNone.Size = new System.Drawing.Size(86, 17);
            this.rStatusNone.TabIndex = 0;
            this.rStatusNone.TabStop = true;
            this.rStatusNone.Text = "Без фільтра";
            this.rStatusNone.UseVisualStyleBackColor = true;
            // 
            // rStatusClose
            // 
            this.rStatusClose.AutoSize = true;
            this.rStatusClose.Location = new System.Drawing.Point(8, 111);
            this.rStatusClose.Name = "rStatusClose";
            this.rStatusClose.Size = new System.Drawing.Size(63, 17);
            this.rStatusClose.TabIndex = 4;
            this.rStatusClose.TabStop = true;
            this.rStatusClose.Text = "Закриті";
            this.rStatusClose.UseVisualStyleBackColor = true;
            // 
            // rStatusCheck
            // 
            this.rStatusCheck.AutoSize = true;
            this.rStatusCheck.Location = new System.Drawing.Point(8, 88);
            this.rStatusCheck.Name = "rStatusCheck";
            this.rStatusCheck.Size = new System.Drawing.Size(137, 17);
            this.rStatusCheck.TabIndex = 3;
            this.rStatusCheck.TabStop = true;
            this.rStatusCheck.Text = "Перевірені, не закриті";
            this.rStatusCheck.UseVisualStyleBackColor = true;
            // 
            // rStatusNotCheck
            // 
            this.rStatusNotCheck.AutoSize = true;
            this.rStatusNotCheck.Location = new System.Drawing.Point(8, 65);
            this.rStatusNotCheck.Name = "rStatusNotCheck";
            this.rStatusNotCheck.Size = new System.Drawing.Size(94, 17);
            this.rStatusNotCheck.TabIndex = 2;
            this.rStatusNotCheck.TabStop = true;
            this.rStatusNotCheck.Text = "Не перевірені";
            this.rStatusNotCheck.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(269, 170);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(53, 13);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "По назві:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(270, 187);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(243, 20);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(439, 283);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonDef
            // 
            this.buttonDef.Location = new System.Drawing.Point(270, 283);
            this.buttonDef.Name = "buttonDef";
            this.buttonDef.Size = new System.Drawing.Size(161, 23);
            this.buttonDef.TabIndex = 6;
            this.buttonDef.Text = "За замовчуванням";
            this.buttonDef.UseVisualStyleBackColor = true;
            // 
            // rStatusNotWork
            // 
            this.rStatusNotWork.AutoSize = true;
            this.rStatusNotWork.Location = new System.Drawing.Point(8, 42);
            this.rStatusNotWork.Name = "rStatusNotWork";
            this.rStatusNotWork.Size = new System.Drawing.Size(86, 17);
            this.rStatusNotWork.TabIndex = 1;
            this.rStatusNotWork.TabStop = true;
            this.rStatusNotWork.Text = "Не виконані";
            this.rStatusNotWork.UseVisualStyleBackColor = true;
            // 
            // FormTaskFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 321);
            this.Controls.Add(this.buttonDef);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.groupBoxStatus);
            this.Controls.Add(this.groupBoxDone);
            this.Controls.Add(this.groupBoxCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTaskFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Фільтр по завданям";
            this.groupBoxCreate.ResumeLayout(false);
            this.groupBoxCreate.PerformLayout();
            this.groupBoxDone.ResumeLayout(false);
            this.groupBoxDone.PerformLayout();
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCreate;
        private System.Windows.Forms.RadioButton rCreateNone;
        private System.Windows.Forms.RadioButton rCreateYear;
        private System.Windows.Forms.RadioButton rCreateHalfYear;
        private System.Windows.Forms.RadioButton rCreateMonth;
        private System.Windows.Forms.RadioButton rCreateWeek;
        private System.Windows.Forms.GroupBox groupBoxDone;
        private System.Windows.Forms.RadioButton rDoneMonth;
        private System.Windows.Forms.RadioButton rDoneWeek;
        private System.Windows.Forms.RadioButton rDoneDay;
        private System.Windows.Forms.RadioButton rDoneOver;
        private System.Windows.Forms.RadioButton rDoneNone;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.RadioButton rStatusClose;
        private System.Windows.Forms.RadioButton rStatusCheck;
        private System.Windows.Forms.RadioButton rStatusNotCheck;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonDef;
        private System.Windows.Forms.RadioButton rStatusNone;
        private System.Windows.Forms.RadioButton rStatusNotWork;
    }
}