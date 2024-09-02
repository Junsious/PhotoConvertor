namespace PhotoEditor
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ComboBox cmbOutputFormat;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Label lblOutputFormat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnCompress = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.cmbOutputFormat = new System.Windows.Forms.ComboBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblOutputFormat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(12, 12);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(120, 23);
            this.btnSelectImage.TabIndex = 0;
            this.btnSelectImage.Text = "Select Image";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 41);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(760, 400);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(138, 14);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(634, 20);
            this.txtFilePath.TabIndex = 2;
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(12, 447);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(120, 23);
            this.btnCompress.TabIndex = 3;
            this.btnCompress.Text = "Compress Image";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(138, 447);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(120, 23);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert Image";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // cmbOutputFormat
            // 
            this.cmbOutputFormat.FormattingEnabled = true;
            this.cmbOutputFormat.Items.AddRange(new object[] {
            
            "PNG",
            "JPEG",
            "JPG",
            "GIF",
            "BMP",
            "TIFF"
            });
            this.cmbOutputFormat.Location = new System.Drawing.Point(264, 447);
            this.cmbOutputFormat.Name = "cmbOutputFormat";
            this.cmbOutputFormat.Size = new System.Drawing.Size(121, 21);
            this.cmbOutputFormat.TabIndex = 5;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(138, 38);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(0, 13);
            this.lblFilePath.TabIndex = 6;
            // 
            // lblOutputFormat
            // 
            this.lblOutputFormat.AutoSize = true;
            this.lblOutputFormat.Location = new System.Drawing.Point(264, 431);
            this.lblOutputFormat.Name = "lblOutputFormat";
            this.lblOutputFormat.Size = new System.Drawing.Size(77, 13);
            this.lblOutputFormat.TabIndex = 7;
            this.lblOutputFormat.Text = "Output Format:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(784, 481);
            this.Controls.Add(this.lblOutputFormat);
            this.Controls.Add(this.cmbOutputFormat);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnCompress);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnSelectImage);
            this.Name = "Form1";
            this.Text = "Photo Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
