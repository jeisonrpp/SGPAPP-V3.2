
namespace SGPAPP
{
    partial class frmEmpresas
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pfechan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pCed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pPrueba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRes2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pCT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pFecham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PruebaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSav = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.pdocname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tableLayoutPanel9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radGridView1);
            this.groupBox2.Controls.Add(this.dataGridView3);
            this.groupBox2.Controls.Add(this.tableLayoutPanel9);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.groupBox2.Location = new System.Drawing.Point(15, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(865, 330);
            this.groupBox2.TabIndex = 121;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pruebas Pendientes";
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.Location = new System.Drawing.Point(9, 64);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(850, 260);
            this.radGridView1.TabIndex = 142;
            this.radGridView1.ThemeName = "Office2013Light";
            this.radGridView1.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.radGridView1_RowFormatting);
            this.radGridView1.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.radGridView1_CellFormatting);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(404, 25);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(10, 12);
            this.dataGridView3.TabIndex = 124;
            this.dataGridView3.Visible = false;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.txtConsulta, 0, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(7, 27);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(269, 32);
            this.tableLayoutPanel9.TabIndex = 117;
            // 
            // txtConsulta
            // 
            this.txtConsulta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtConsulta.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtConsulta.ForeColor = System.Drawing.Color.Silver;
            this.txtConsulta.Location = new System.Drawing.Point(2, 3);
            this.txtConsulta.Margin = new System.Windows.Forms.Padding(2);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(265, 26);
            this.txtConsulta.TabIndex = 99;
            this.txtConsulta.Text = "Digite nombre o cedula";
            this.txtConsulta.TextChanged += new System.EventHandler(this.txtConsulta_TextChanged);
            this.txtConsulta.Enter += new System.EventHandler(this.txtConsulta_Enter);
            this.txtConsulta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsulta_KeyPress);
            this.txtConsulta.Leave += new System.EventHandler(this.txtConsulta_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.groupBox1.Location = new System.Drawing.Point(15, 384);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(865, 225);
            this.groupBox1.TabIndex = 123;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultados";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pid,
            this.pName,
            this.pdir,
            this.pMail,
            this.pfechan,
            this.pedad,
            this.pCed,
            this.pTipo,
            this.pPrueba,
            this.pRes,
            this.pCT,
            this.pRes2,
            this.pCT2,
            this.pFecha,
            this.pFecham,
            this.pHora,
            this.PruebaID,
            this.cIng});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.Location = new System.Drawing.Point(7, 25);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.Size = new System.Drawing.Size(852, 191);
            this.dataGridView2.TabIndex = 121;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Pid
            // 
            this.Pid.HeaderText = "Id de Paciente";
            this.Pid.Name = "Pid";
            this.Pid.ReadOnly = true;
            // 
            // pName
            // 
            this.pName.HeaderText = "Paciente";
            this.pName.Name = "pName";
            this.pName.ReadOnly = true;
            // 
            // pdir
            // 
            this.pdir.HeaderText = "Direccion";
            this.pdir.Name = "pdir";
            this.pdir.ReadOnly = true;
            // 
            // pMail
            // 
            this.pMail.HeaderText = "Email";
            this.pMail.Name = "pMail";
            this.pMail.ReadOnly = true;
            // 
            // pfechan
            // 
            this.pfechan.HeaderText = "Fecha Nacimiento";
            this.pfechan.Name = "pfechan";
            this.pfechan.ReadOnly = true;
            // 
            // pedad
            // 
            this.pedad.HeaderText = "Edad";
            this.pedad.Name = "pedad";
            this.pedad.ReadOnly = true;
            // 
            // pCed
            // 
            this.pCed.HeaderText = "Cedula";
            this.pCed.Name = "pCed";
            this.pCed.ReadOnly = true;
            // 
            // pTipo
            // 
            this.pTipo.HeaderText = "Tipo Prueba";
            this.pTipo.Name = "pTipo";
            this.pTipo.ReadOnly = true;
            // 
            // pPrueba
            // 
            this.pPrueba.HeaderText = "Prueba";
            this.pPrueba.Name = "pPrueba";
            this.pPrueba.ReadOnly = true;
            // 
            // pRes
            // 
            this.pRes.HeaderText = "Resultado";
            this.pRes.Name = "pRes";
            this.pRes.ReadOnly = true;
            // 
            // pCT
            // 
            this.pCT.HeaderText = "CT";
            this.pCT.Name = "pCT";
            this.pCT.ReadOnly = true;
            // 
            // pRes2
            // 
            this.pRes2.HeaderText = "Resultado2";
            this.pRes2.Name = "pRes2";
            this.pRes2.ReadOnly = true;
            // 
            // pCT2
            // 
            this.pCT2.HeaderText = "CT2";
            this.pCT2.Name = "pCT2";
            this.pCT2.ReadOnly = true;
            // 
            // pFecha
            // 
            this.pFecha.HeaderText = "Fecha";
            this.pFecha.Name = "pFecha";
            this.pFecha.ReadOnly = true;
            // 
            // pFecham
            // 
            this.pFecham.HeaderText = "Fecha Muestra";
            this.pFecham.Name = "pFecham";
            this.pFecham.ReadOnly = true;
            // 
            // pHora
            // 
            this.pHora.HeaderText = "Hora Muestra";
            this.pHora.Name = "pHora";
            this.pHora.ReadOnly = true;
            // 
            // PruebaID
            // 
            this.PruebaID.HeaderText = "ID de Prueba";
            this.PruebaID.Name = "PruebaID";
            this.PruebaID.ReadOnly = true;
            this.PruebaID.Visible = false;
            // 
            // cIng
            // 
            this.cIng.HeaderText = "Ingles";
            this.cIng.Name = "cIng";
            this.cIng.ReadOnly = true;
            this.cIng.Visible = false;
            // 
            // btnSav
            // 
            this.btnSav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnSav.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSav.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSav.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnSav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSav.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSav.ForeColor = System.Drawing.Color.White;
            this.btnSav.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSav.Location = new System.Drawing.Point(719, 617);
            this.btnSav.Name = "btnSav";
            this.btnSav.Size = new System.Drawing.Size(164, 41);
            this.btnSav.TabIndex = 127;
            this.btnSav.Text = "Procesar Pacientes";
            this.btnSav.UseVisualStyleBackColor = false;
            this.btnSav.Click += new System.EventHandler(this.btnSav_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Ebrima", 12F);
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.Location = new System.Drawing.Point(856, 7);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.TabIndex = 128;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btndel
            // 
            this.btndel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btndel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btndel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btndel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btndel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btndel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndel.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndel.ForeColor = System.Drawing.Color.White;
            this.btndel.Location = new System.Drawing.Point(15, 617);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(153, 41);
            this.btndel.TabIndex = 129;
            this.btndel.Text = "Eliminar Resultado";
            this.btndel.UseVisualStyleBackColor = false;
            this.btndel.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pdocname});
            this.dataGridView4.Location = new System.Drawing.Point(574, 31);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(10, 11);
            this.dataGridView4.TabIndex = 125;
            this.dataGridView4.Visible = false;
            // 
            // pdocname
            // 
            this.pdocname.HeaderText = "DocName";
            this.pdocname.Name = "pdocname";
            // 
            // frmEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(896, 663);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnSav);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEmpresas";
            this.Text = "Envios Masivos";
            this.Load += new System.EventHandler(this.frmEmpresas_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.Button btnSav;
        internal System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn pdocname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pName;
        private System.Windows.Forms.DataGridViewTextBoxColumn pdir;
        private System.Windows.Forms.DataGridViewTextBoxColumn pMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn pfechan;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedad;
        private System.Windows.Forms.DataGridViewTextBoxColumn pCed;
        private System.Windows.Forms.DataGridViewTextBoxColumn pTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn pPrueba;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn pCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRes2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pCT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn pFecham;
        private System.Windows.Forms.DataGridViewTextBoxColumn pHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn PruebaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIng;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
    }
}