
namespace SGPAPP
{
    partial class frmModificaEmpresa
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
            this.btnMD = new Telerik.WinControls.UI.RadButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.txteEmp = new System.Windows.Forms.TextBox();
            this.txtEEmail = new System.Windows.Forms.TextBox();
            this.txtEcont = new System.Windows.Forms.MaskedTextBox();
            this.txtEdir = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnMD)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMD
            // 
            this.btnMD.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMD.Location = new System.Drawing.Point(170, 320);
            this.btnMD.Name = "btnMD";
            this.btnMD.Size = new System.Drawing.Size(149, 24);
            this.btnMD.TabIndex = 0;
            this.btnMD.Text = "Guardar";
            this.btnMD.ThemeName = "Office2013Light";
            this.btnMD.Click += new System.EventHandler(this.btnMD_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox8.Controls.Add(this.tableLayoutPanel10);
            this.groupBox8.Controls.Add(this.tableLayoutPanel11);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.groupBox8.Location = new System.Drawing.Point(12, 13);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(470, 260);
            this.groupBox8.TabIndex = 141;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Datos Empresa";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel10.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(16, 18);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 4;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(139, 238);
            this.tableLayoutPanel10.TabIndex = 116;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.label6.Location = new System.Drawing.Point(62, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 120;
            this.label6.Text = "Empresa:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.label10.Location = new System.Drawing.Point(13, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 16);
            this.label10.TabIndex = 106;
            this.label10.Text = "No. de Contacto:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.label11.Location = new System.Drawing.Point(85, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 16);
            this.label11.TabIndex = 105;
            this.label11.Text = "Email:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.label12.Location = new System.Drawing.Point(58, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 16);
            this.label12.TabIndex = 107;
            this.label12.Text = "Direccion:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.txteEmp, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.txtEEmail, 0, 2);
            this.tableLayoutPanel11.Controls.Add(this.txtEcont, 0, 3);
            this.tableLayoutPanel11.Controls.Add(this.txtEdir, 0, 1);
            this.tableLayoutPanel11.Location = new System.Drawing.Point(158, 18);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 4;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(294, 238);
            this.tableLayoutPanel11.TabIndex = 113;
            // 
            // txteEmp
            // 
            this.txteEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txteEmp.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txteEmp.ForeColor = System.Drawing.Color.Gray;
            this.txteEmp.Location = new System.Drawing.Point(3, 16);
            this.txteEmp.MaxLength = 50;
            this.txteEmp.Name = "txteEmp";
            this.txteEmp.Size = new System.Drawing.Size(288, 26);
            this.txteEmp.TabIndex = 0;
            // 
            // txtEEmail
            // 
            this.txtEEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEEmail.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtEEmail.ForeColor = System.Drawing.Color.Gray;
            this.txtEEmail.Location = new System.Drawing.Point(3, 134);
            this.txtEEmail.MaxLength = 50;
            this.txtEEmail.Name = "txtEEmail";
            this.txtEEmail.Size = new System.Drawing.Size(288, 26);
            this.txtEEmail.TabIndex = 2;
            // 
            // txtEcont
            // 
            this.txtEcont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEcont.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtEcont.ForeColor = System.Drawing.Color.Gray;
            this.txtEcont.Location = new System.Drawing.Point(3, 194);
            this.txtEcont.Mask = "(999) 000-0000";
            this.txtEcont.Name = "txtEcont";
            this.txtEcont.Size = new System.Drawing.Size(288, 26);
            this.txtEcont.TabIndex = 3;
            // 
            // txtEdir
            // 
            this.txtEdir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEdir.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtEdir.ForeColor = System.Drawing.Color.Gray;
            this.txtEdir.Location = new System.Drawing.Point(3, 75);
            this.txtEdir.MaxLength = 200;
            this.txtEdir.Name = "txtEdir";
            this.txtEdir.Size = new System.Drawing.Size(288, 26);
            this.txtEdir.TabIndex = 1;
            // 
            // frmModificaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 373);
            this.Controls.Add(this.btnMD);
            this.Controls.Add(this.groupBox8);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModificaEmpresa";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Modificar Empresa";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.btnMD)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnMD;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        public System.Windows.Forms.TextBox txteEmp;
        public System.Windows.Forms.TextBox txtEEmail;
        public System.Windows.Forms.MaskedTextBox txtEcont;
        public System.Windows.Forms.TextBox txtEdir;
    }
}
