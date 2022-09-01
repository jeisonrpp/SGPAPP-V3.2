
namespace SGPAPP
{
    partial class frmCitastime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCitastime));
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtMinSab = new System.Windows.Forms.TextBox();
            this.txtMaxSab = new System.Windows.Forms.TextBox();
            this.btnSavec = new System.Windows.Forms.Button();
            this.txtMinWeek = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtMaxWeek = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(32, 186);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(207, 32);
            this.label23.TabIndex = 156;
            this.label23.Text = "La configuracion de la hora debe \r\nser en formato 24 Horas.";
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label22.Location = new System.Drawing.Point(45, 131);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 32);
            this.label22.TabIndex = 155;
            this.label22.Text = "Hora Maxima\r\nSabados:\r\n";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label21.Location = new System.Drawing.Point(42, 95);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(95, 32);
            this.label21.TabIndex = 154;
            this.label21.Text = "Hora Minima\r\nSabados:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(42, 58);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(99, 32);
            this.label19.TabIndex = 153;
            this.label19.Text = "Hora Maxima\nLun-Vie:\r\n";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMinSab
            // 
            this.txtMinSab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinSab.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtMinSab.ForeColor = System.Drawing.Color.Gray;
            this.txtMinSab.Location = new System.Drawing.Point(148, 101);
            this.txtMinSab.Name = "txtMinSab";
            this.txtMinSab.Size = new System.Drawing.Size(202, 26);
            this.txtMinSab.TabIndex = 152;
            // 
            // txtMaxSab
            // 
            this.txtMaxSab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaxSab.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtMaxSab.ForeColor = System.Drawing.Color.Gray;
            this.txtMaxSab.Location = new System.Drawing.Point(148, 137);
            this.txtMaxSab.Name = "txtMaxSab";
            this.txtMaxSab.Size = new System.Drawing.Size(202, 26);
            this.txtMaxSab.TabIndex = 151;
            // 
            // btnSavec
            // 
            this.btnSavec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnSavec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavec.ForeColor = System.Drawing.Color.White;
            this.btnSavec.Image = ((System.Drawing.Image)(resources.GetObject("btnSavec.Image")));
            this.btnSavec.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSavec.Location = new System.Drawing.Point(285, 172);
            this.btnSavec.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnSavec.Name = "btnSavec";
            this.btnSavec.Size = new System.Drawing.Size(65, 52);
            this.btnSavec.TabIndex = 150;
            this.btnSavec.Text = "Guardar";
            this.btnSavec.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSavec.UseVisualStyleBackColor = false;
            this.btnSavec.Click += new System.EventHandler(this.btnSavec_Click);
            // 
            // txtMinWeek
            // 
            this.txtMinWeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinWeek.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtMinWeek.ForeColor = System.Drawing.Color.Gray;
            this.txtMinWeek.Location = new System.Drawing.Point(148, 30);
            this.txtMinWeek.Name = "txtMinWeek";
            this.txtMinWeek.Size = new System.Drawing.Size(202, 26);
            this.txtMinWeek.TabIndex = 148;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(42, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(95, 32);
            this.label20.TabIndex = 149;
            this.label20.Text = "Hora Minima\r\nLun-Vie:\r\n";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMaxWeek
            // 
            this.txtMaxWeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaxWeek.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtMaxWeek.ForeColor = System.Drawing.Color.Gray;
            this.txtMaxWeek.Location = new System.Drawing.Point(148, 66);
            this.txtMaxWeek.Name = "txtMaxWeek";
            this.txtMaxWeek.Size = new System.Drawing.Size(202, 26);
            this.txtMaxWeek.TabIndex = 147;
            // 
            // frmCitastime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(383, 248);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtMinSab);
            this.Controls.Add(this.txtMaxSab);
            this.Controls.Add(this.btnSavec);
            this.Controls.Add(this.txtMinWeek);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtMaxWeek);
            this.MaximizeBox = false;
            this.Name = "frmCitastime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion Citas";
            this.Load += new System.EventHandler(this.frmCitastime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtMinSab;
        private System.Windows.Forms.TextBox txtMaxSab;
        private System.Windows.Forms.Button btnSavec;
        private System.Windows.Forms.TextBox txtMinWeek;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtMaxWeek;
    }
}