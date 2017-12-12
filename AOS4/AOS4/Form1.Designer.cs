namespace AOS4
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pic = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.bar1 = new System.Windows.Forms.TrackBar();
            this.bar2 = new System.Windows.Forms.TrackBar();
            this.relief = new System.Windows.Forms.Button();
            this.rezk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(12, 12);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(640, 480);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(724, 438);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // bar1
            // 
            this.bar1.Location = new System.Drawing.Point(707, 38);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(104, 45);
            this.bar1.TabIndex = 2;
            // 
            // bar2
            // 
            this.bar2.Location = new System.Drawing.Point(707, 167);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(104, 45);
            this.bar2.TabIndex = 3;
            // 
            // relief
            // 
            this.relief.Location = new System.Drawing.Point(724, 89);
            this.relief.Name = "relief";
            this.relief.Size = new System.Drawing.Size(75, 23);
            this.relief.TabIndex = 4;
            this.relief.Text = "Apply";
            this.relief.UseVisualStyleBackColor = true;
            this.relief.Click += new System.EventHandler(this.relief_Click);
            // 
            // rezk
            // 
            this.rezk.Location = new System.Drawing.Point(724, 218);
            this.rezk.Name = "rezk";
            this.rezk.Size = new System.Drawing.Size(75, 23);
            this.rezk.TabIndex = 5;
            this.rezk.Text = "Apply";
            this.rezk.UseVisualStyleBackColor = true;
            this.rezk.Click += new System.EventHandler(this.rezk_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 504);
            this.Controls.Add(this.rezk);
            this.Controls.Add(this.relief);
            this.Controls.Add(this.bar2);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pic);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.TrackBar bar1;
        private System.Windows.Forms.TrackBar bar2;
        private System.Windows.Forms.Button relief;
        private System.Windows.Forms.Button rezk;
    }
}

