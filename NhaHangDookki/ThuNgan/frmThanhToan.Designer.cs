namespace NhaHangDookki.ThuNgan
{
    partial class frmThanhToan
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
            this.lblMaHDB = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.picQR = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaHDB
            // 
            this.lblMaHDB.AutoSize = true;
            this.lblMaHDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHDB.Location = new System.Drawing.Point(328, 667);
            this.lblMaHDB.Name = "lblMaHDB";
            this.lblMaHDB.Size = new System.Drawing.Size(116, 37);
            this.lblMaHDB.TabIndex = 1;
            this.lblMaHDB.Text = "Mã HĐ";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(278, 785);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(151, 37);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "Tổng tiền";
            // 
            // picQR
            // 
            this.picQR.Location = new System.Drawing.Point(198, 161);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(489, 421);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 0;
            this.picQR.TabStop = false;
            // 
            // frmXemHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 1048);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblMaHDB);
            this.Controls.Add(this.picQR);
            this.Name = "frmXemHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmXemHoaDon";
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label lblMaHDB;
        private System.Windows.Forms.Label lblTongTien;
    }
}