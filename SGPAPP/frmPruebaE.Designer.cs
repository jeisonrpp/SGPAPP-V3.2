
namespace SGPAPP
{
    partial class frmPruebaE
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbbMetodo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbPrueba = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radGridView4 = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView4.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.8453F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.1547F));
            this.tableLayoutPanel1.Controls.Add(this.cbbMetodo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbbPrueba, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbbTipo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(362, 96);
            this.tableLayoutPanel1.TabIndex = 103;
            // 
            // cbbMetodo
            // 
            this.cbbMetodo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbMetodo.Enabled = false;
            this.cbbMetodo.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F);
            this.cbbMetodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.cbbMetodo.FormattingEnabled = true;
            this.cbbMetodo.Items.AddRange(new object[] {
            "Por Correo"});
            this.cbbMetodo.Location = new System.Drawing.Point(139, 67);
            this.cbbMetodo.Name = "cbbMetodo";
            this.cbbMetodo.Size = new System.Drawing.Size(208, 27);
            this.cbbMetodo.TabIndex = 31;
            this.cbbMetodo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTipo_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(70, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "Metodo:";
            // 
            // cbbPrueba
            // 
            this.cbbPrueba.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbPrueba.Enabled = false;
            this.cbbPrueba.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F);
            this.cbbPrueba.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.cbbPrueba.FormattingEnabled = true;
            this.cbbPrueba.Location = new System.Drawing.Point(139, 35);
            this.cbbPrueba.Name = "cbbPrueba";
            this.cbbPrueba.Size = new System.Drawing.Size(208, 27);
            this.cbbPrueba.TabIndex = 18;
            this.cbbPrueba.DropDown += new System.EventHandler(this.cbbPrueba_DropDown);
            this.cbbPrueba.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTipo_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(74, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Prueba:";
            // 
            // cbbTipo
            // 
            this.cbbTipo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbTipo.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F);
            this.cbbTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.cbbTipo.FormattingEnabled = true;
            this.cbbTipo.Location = new System.Drawing.Point(139, 3);
            this.cbbTipo.Name = "cbbTipo";
            this.cbbTipo.Size = new System.Drawing.Size(208, 27);
            this.cbbTipo.TabIndex = 15;
            this.cbbTipo.DropDown += new System.EventHandler(this.cbbTipo_DropDown);
            this.cbbTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTipo_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(20, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tipo de Prueba:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.radGridView4);
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(39, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(881, 468);
            this.groupBox3.TabIndex = 135;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Asignar Pruebas";
            // 
            // radGridView4
            // 
            this.radGridView4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView4.Location = new System.Drawing.Point(6, 140);
            // 
            // 
            // 
            this.radGridView4.MasterTemplate.AllowAddNewRow = false;
            this.radGridView4.MasterTemplate.AllowDeleteRow = false;
            this.radGridView4.MasterTemplate.AllowEditRow = false;
            this.radGridView4.MasterTemplate.EnableFiltering = true;
            this.radGridView4.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView4.Name = "radGridView4";
            this.radGridView4.Size = new System.Drawing.Size(869, 322);
            this.radGridView4.TabIndex = 142;
            this.radGridView4.ThemeName = "Office2013Light";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(392, 507);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(151, 37);
            this.radButton1.TabIndex = 136;
            this.radButton1.Text = "Asignar Pruebas";
            this.radButton1.ThemeName = "Office2013Light";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radScrollablePanel1.Location = new System.Drawing.Point(12, 14);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.BackColor = System.Drawing.Color.White;
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radButton1);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(937, 562);
            this.radScrollablePanel1.Size = new System.Drawing.Size(939, 564);
            this.radScrollablePanel1.TabIndex = 137;
            // 
            // frmPruebaE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(963, 588);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.radScrollablePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPruebaE";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Pruebas Empresas";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.frmPruebaE_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView4.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbbMetodo;
        public System.Windows.Forms.ComboBox cbbPrueba;
        public System.Windows.Forms.ComboBox cbbTipo;
        private System.Windows.Forms.GroupBox groupBox3;
        public Telerik.WinControls.UI.RadGridView radGridView4;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
    }
}
