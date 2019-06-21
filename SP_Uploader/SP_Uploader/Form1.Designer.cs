namespace SP_Uploader
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbSharePointURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDocLib = new System.Windows.Forms.TextBox();
            this.btSubmit = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btCheckSource = new System.Windows.Forms.Button();
            this.tbLimit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SharePoint URL";
            // 
            // tbSharePointURL
            // 
            this.tbSharePointURL.Location = new System.Drawing.Point(123, 10);
            this.tbSharePointURL.Name = "tbSharePointURL";
            this.tbSharePointURL.Size = new System.Drawing.Size(353, 20);
            this.tbSharePointURL.TabIndex = 1;
            this.tbSharePointURL.Text = "https://dksh.sharepoint.com/sites/QAHECDMS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Document Library";
            // 
            // tbDocLib
            // 
            this.tbDocLib.Location = new System.Drawing.Point(123, 38);
            this.tbDocLib.Name = "tbDocLib";
            this.tbDocLib.Size = new System.Drawing.Size(353, 20);
            this.tbDocLib.TabIndex = 3;
            this.tbDocLib.Text = "SUPPLIER_MIG";
            // 
            // btSubmit
            // 
            this.btSubmit.Location = new System.Drawing.Point(493, 273);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(88, 23);
            this.btSubmit.TabIndex = 4;
            this.btSubmit.Text = "Execute";
            this.btSubmit.UseVisualStyleBackColor = true;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(12, 74);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResult.Size = new System.Drawing.Size(460, 222);
            this.tbResult.TabIndex = 5;
            // 
            // btCheckSource
            // 
            this.btCheckSource.Location = new System.Drawing.Point(493, 72);
            this.btCheckSource.Name = "btCheckSource";
            this.btCheckSource.Size = new System.Drawing.Size(88, 23);
            this.btCheckSource.TabIndex = 6;
            this.btCheckSource.Text = "Check Source";
            this.btCheckSource.UseVisualStyleBackColor = true;
            this.btCheckSource.Click += new System.EventHandler(this.btCheckSource_Click);
            // 
            // tbLimit
            // 
            this.tbLimit.Location = new System.Drawing.Point(493, 207);
            this.tbLimit.Name = "tbLimit";
            this.tbLimit.Size = new System.Drawing.Size(88, 20);
            this.tbLimit.TabIndex = 7;
            this.tbLimit.Text = "100";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 327);
            this.Controls.Add(this.tbLimit);
            this.Controls.Add(this.btCheckSource);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.btSubmit);
            this.Controls.Add(this.tbDocLib);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSharePointURL);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "DMS SharePoint Uploader Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSharePointURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDocLib;
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button btCheckSource;
        private System.Windows.Forms.TextBox tbLimit;
    }
}

