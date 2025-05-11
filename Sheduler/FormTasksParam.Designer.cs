namespace Sheduler {
    partial class FormTasksParam {
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
            this.textBoxTask = new System.Windows.Forms.TextBox();
            this.labelTask = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelDet = new System.Windows.Forms.Label();
            this.textBoxDet = new System.Windows.Forms.TextBox();
            this.labelCreate = new System.Windows.Forms.Label();
            this.dateTimePickerCreate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDone = new System.Windows.Forms.DateTimePicker();
            this.labelDone = new System.Windows.Forms.Label();
            this.labelClose = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.dateTimePickerClose = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // textBoxTask
            // 
            this.textBoxTask.Location = new System.Drawing.Point(105, 8);
            this.textBoxTask.Name = "textBoxTask";
            this.textBoxTask.Size = new System.Drawing.Size(303, 20);
            this.textBoxTask.TabIndex = 31;
            // 
            // labelTask
            // 
            this.labelTask.AutoSize = true;
            this.labelTask.Location = new System.Drawing.Point(7, 11);
            this.labelTask.Name = "labelTask";
            this.labelTask.Size = new System.Drawing.Size(59, 13);
            this.labelTask.TabIndex = 33;
            this.labelTask.Text = "Завдання:";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(328, 259);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(82, 23);
            this.buttonOK.TabIndex = 32;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelDet
            // 
            this.labelDet.AutoSize = true;
            this.labelDet.Location = new System.Drawing.Point(7, 37);
            this.labelDet.Name = "labelDet";
            this.labelDet.Size = new System.Drawing.Size(60, 13);
            this.labelDet.TabIndex = 34;
            this.labelDet.Text = "Детально:";
            // 
            // textBoxDet
            // 
            this.textBoxDet.Location = new System.Drawing.Point(105, 34);
            this.textBoxDet.Multiline = true;
            this.textBoxDet.Name = "textBoxDet";
            this.textBoxDet.Size = new System.Drawing.Size(303, 125);
            this.textBoxDet.TabIndex = 35;
            // 
            // labelCreate
            // 
            this.labelCreate.AutoSize = true;
            this.labelCreate.Location = new System.Drawing.Point(8, 170);
            this.labelCreate.Name = "labelCreate";
            this.labelCreate.Size = new System.Drawing.Size(92, 13);
            this.labelCreate.TabIndex = 36;
            this.labelCreate.Text = "Дата створення:";
            // 
            // dateTimePickerCreate
            // 
            this.dateTimePickerCreate.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePickerCreate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerCreate.Location = new System.Drawing.Point(105, 166);
            this.dateTimePickerCreate.Name = "dateTimePickerCreate";
            this.dateTimePickerCreate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerCreate.TabIndex = 37;
            // 
            // dateTimePickerDone
            // 
            this.dateTimePickerDone.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePickerDone.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDone.Location = new System.Drawing.Point(105, 192);
            this.dateTimePickerDone.Name = "dateTimePickerDone";
            this.dateTimePickerDone.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDone.TabIndex = 39;
            // 
            // labelDone
            // 
            this.labelDone.AutoSize = true;
            this.labelDone.Location = new System.Drawing.Point(7, 196);
            this.labelDone.Name = "labelDone";
            this.labelDone.Size = new System.Drawing.Size(93, 13);
            this.labelDone.TabIndex = 38;
            this.labelDone.Text = "Дата виконання:";
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.Location = new System.Drawing.Point(7, 222);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(85, 13);
            this.labelClose.TabIndex = 40;
            this.labelClose.Text = "Дата закриття:";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(328, 165);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(80, 73);
            this.buttonClose.TabIndex = 42;
            this.buttonClose.Text = "Закрити завдання";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // dateTimePickerClose
            // 
            this.dateTimePickerClose.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePickerClose.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerClose.Location = new System.Drawing.Point(105, 218);
            this.dateTimePickerClose.Name = "dateTimePickerClose";
            this.dateTimePickerClose.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerClose.TabIndex = 43;
            // 
            // FormTasksParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 295);
            this.Controls.Add(this.dateTimePickerClose);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelClose);
            this.Controls.Add(this.dateTimePickerDone);
            this.Controls.Add(this.labelDone);
            this.Controls.Add(this.dateTimePickerCreate);
            this.Controls.Add(this.labelCreate);
            this.Controls.Add(this.textBoxDet);
            this.Controls.Add(this.labelDet);
            this.Controls.Add(this.textBoxTask);
            this.Controls.Add(this.labelTask);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTasksParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметри завдання";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTask;
        private System.Windows.Forms.Label labelTask;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelDet;
        private System.Windows.Forms.TextBox textBoxDet;
        private System.Windows.Forms.Label labelCreate;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDone;
        private System.Windows.Forms.Label labelDone;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DateTimePicker dateTimePickerClose;
    }
}