namespace AA26_UI會停頓與不順暢_Windows_Forms
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnBySleep = new System.Windows.Forms.Button();
            this.btnByDelay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(107, 62);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(540, 196);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // btnBySleep
            // 
            this.btnBySleep.BackColor = System.Drawing.Color.Red;
            this.btnBySleep.ForeColor = System.Drawing.Color.White;
            this.btnBySleep.Location = new System.Drawing.Point(107, 304);
            this.btnBySleep.Name = "btnBySleep";
            this.btnBySleep.Size = new System.Drawing.Size(226, 66);
            this.btnBySleep.TabIndex = 1;
            this.btnBySleep.Text = "休息3秒，會造成停頓";
            this.btnBySleep.UseVisualStyleBackColor = false;
            this.btnBySleep.Click += new System.EventHandler(this.btnBySleep_Click);
            // 
            // btnByDelay
            // 
            this.btnByDelay.BackColor = System.Drawing.Color.Green;
            this.btnByDelay.ForeColor = System.Drawing.Color.White;
            this.btnByDelay.Location = new System.Drawing.Point(357, 304);
            this.btnByDelay.Name = "btnByDelay";
            this.btnByDelay.Size = new System.Drawing.Size(290, 66);
            this.btnByDelay.TabIndex = 2;
            this.btnByDelay.Text = "休息3秒，不會造成停頓";
            this.btnByDelay.UseVisualStyleBackColor = false;
            this.btnByDelay.Click += new System.EventHandler(this.btnByDelay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnByDelay);
            this.Controls.Add(this.btnBySleep);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form1";
            this.Text = "UI會停頓與不順暢WinForms";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnBySleep;
        private System.Windows.Forms.Button btnByDelay;
    }
}

