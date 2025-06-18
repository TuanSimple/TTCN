namespace NhaHangDookki.ThuNgan
{
    partial class frmInHoaDon
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
            this.rtbHoaDon = new System.Windows.Forms.RichTextBox();
            this.btnIn = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // rtbHoaDon
            // 
            this.rtbHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbHoaDon.Location = new System.Drawing.Point(0, 0);
            this.rtbHoaDon.Name = "rtbHoaDon";
            this.rtbHoaDon.Size = new System.Drawing.Size(736, 806);
            this.rtbHoaDon.TabIndex = 0;
            this.rtbHoaDon.Text = "";
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnIn.IconColor = System.Drawing.Color.Black;
            this.btnIn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIn.Location = new System.Drawing.Point(506, 671);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(174, 90);
            this.btnIn.TabIndex = 1;
            this.btnIn.Text = "In hóa đơn";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // frmInHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 806);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.rtbHoaDon);
            this.Name = "frmInHoaDon";
            this.Text = "frmInHoaDon";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbHoaDon;
        private FontAwesome.Sharp.IconButton btnIn;
    }
}