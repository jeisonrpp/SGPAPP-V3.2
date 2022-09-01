namespace SGPAPP
{
    partial class frmReportesEmpresas
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportesEmpresas));
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.cbbPrueba = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.btnExcel = new Telerik.WinControls.UI.RadButton();
            this.cbbEmpresa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radScrollablePanel1.Location = new System.Drawing.Point(12, 12);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.BackColor = System.Drawing.Color.White;
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnExcel);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radGridView1);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.groupBox2);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(879, 506);
            this.radScrollablePanel1.Size = new System.Drawing.Size(881, 508);
            this.radScrollablePanel1.TabIndex = 146;
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.Location = new System.Drawing.Point(14, 109);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(777, 388);
            this.radGridView1.TabIndex = 150;
            this.radGridView1.ThemeName = "Office2013Light";
            // 
            // radButton2
            // 
            this.radButton2.Image = ((System.Drawing.Image)(resources.GetObject("radButton2.Image")));
            this.radButton2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton2.Location = new System.Drawing.Point(453, 31);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(37, 41);
            this.radButton2.TabIndex = 3;
            this.radButton2.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.radButton2.ThemeName = "Office2013Light";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // cbbPrueba
            // 
            this.cbbPrueba.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbPrueba.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbPrueba.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.cbbPrueba.ForeColor = System.Drawing.Color.DimGray;
            this.cbbPrueba.FormattingEnabled = true;
            this.cbbPrueba.Items.AddRange(new object[] {
            "Cedula",
            "Pasaporte"});
            this.cbbPrueba.Location = new System.Drawing.Point(248, 22);
            this.cbbPrueba.Name = "cbbPrueba";
            this.cbbPrueba.Size = new System.Drawing.Size(187, 24);
            this.cbbPrueba.TabIndex = 137;
            this.cbbPrueba.Text = "Seleccione la Prueba";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbbEmpresa);
            this.groupBox2.Controls.Add(this.radButton2);
            this.groupBox2.Controls.Add(this.cbbPrueba);
            this.groupBox2.Controls.Add(this.dtp1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtp2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(14, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(507, 93);
            this.groupBox2.TabIndex = 148;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtrar por Empresa";
            // 
            // dtp1
            // 
            this.dtp1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(61, 26);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(103, 23);
            this.dtp1.TabIndex = 126;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 127;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 126;
            this.label1.Text = "Desde:";
            // 
            // dtp2
            // 
            this.dtp2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp2.Location = new System.Drawing.Point(61, 55);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(103, 23);
            this.dtp2.TabIndex = 125;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcel.Location = new System.Drawing.Point(797, 109);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 67);
            this.btnExcel.TabIndex = 151;
            this.btnExcel.Text = "\r\n\r\nExportar \r\na Excel";
            this.btnExcel.ThemeName = "Office2013Light";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // cbbEmpresa
            // 
            this.cbbEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbEmpresa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbEmpresa.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.cbbEmpresa.ForeColor = System.Drawing.Color.DimGray;
            this.cbbEmpresa.FormattingEnabled = true;
            this.cbbEmpresa.Items.AddRange(new object[] {
            "Cedula",
            "Pasaporte"});
            this.cbbEmpresa.Location = new System.Drawing.Point(248, 55);
            this.cbbEmpresa.Name = "cbbEmpresa";
            this.cbbEmpresa.Size = new System.Drawing.Size(187, 24);
            this.cbbEmpresa.TabIndex = 138;
            this.cbbEmpresa.Text = "Seleccione la Empresa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(194, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 139;
            this.label3.Text = "Desde:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(194, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 140;
            this.label4.Text = "Desde:";
            // 
            // frmReportesEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(905, 532);
            this.Controls.Add(this.radScrollablePanel1);
            this.Name = "frmReportesEmpresas";
            this.Text = "Reportes por Empresas";
            this.Load += new System.EventHandler(this.frmReportesEmpresas_Load);
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Telerik.WinControls.UI.RadButton radButton2;
        private System.Windows.Forms.ComboBox cbbPrueba;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private Telerik.WinControls.UI.RadButton btnExcel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbEmpresa;
    }
}