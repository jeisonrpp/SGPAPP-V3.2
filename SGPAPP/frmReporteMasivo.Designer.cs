
namespace SGPAPP
{
    partial class frmReporteMasivo
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.cbbPrueba = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.btnCarga = new Telerik.WinControls.UI.RadButton();
            this.btnSav = new Telerik.WinControls.UI.RadButton();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbPrueba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbPrueba.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbPrueba.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCarga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.Location = new System.Drawing.Point(33, 81);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            gridViewTextBoxColumn1.HeaderText = "Valor CT";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewCheckBoxColumn1.Checked = Telerik.WinControls.Enumerations.ToggleState.On;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.HeaderText = "Reportar";
            gridViewCheckBoxColumn1.Name = "column2";
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewCheckBoxColumn1});
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(1065, 626);
            this.radGridView1.TabIndex = 133;
            this.radGridView1.ThemeName = "Office2013Light";
            this.radGridView1.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.radGridView1_CellBeginEdit);
            // 
            // cbbPrueba
            // 
            this.cbbPrueba.AutoSizeDropDownHeight = true;
            this.cbbPrueba.AutoSizeDropDownToBestFit = true;
            this.cbbPrueba.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbPrueba.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // cbbPrueba.NestedRadGridView
            // 
            this.cbbPrueba.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.cbbPrueba.EditorControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPrueba.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbbPrueba.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.cbbPrueba.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.cbbPrueba.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.cbbPrueba.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.cbbPrueba.EditorControl.MasterTemplate.AllowDeleteRow = false;
            this.cbbPrueba.EditorControl.MasterTemplate.AllowEditRow = false;
            this.cbbPrueba.EditorControl.MasterTemplate.AutoExpandGroups = true;
            this.cbbPrueba.EditorControl.MasterTemplate.EnableGrouping = false;
            this.cbbPrueba.EditorControl.MasterTemplate.ShowFilteringRow = false;
            this.cbbPrueba.EditorControl.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.cbbPrueba.EditorControl.Name = "NestedRadGridView";
            this.cbbPrueba.EditorControl.ReadOnly = true;
            this.cbbPrueba.EditorControl.ShowGroupPanel = false;
            this.cbbPrueba.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.cbbPrueba.EditorControl.TabIndex = 0;
            this.cbbPrueba.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.cbbPrueba.ForeColor = System.Drawing.Color.DimGray;
            this.cbbPrueba.Location = new System.Drawing.Point(33, 45);
            this.cbbPrueba.Name = "cbbPrueba";
            this.cbbPrueba.Size = new System.Drawing.Size(285, 24);
            this.cbbPrueba.TabIndex = 134;
            this.cbbPrueba.TabStop = false;
            this.cbbPrueba.ThemeName = "Office2013Light";
            this.cbbPrueba.SelectedIndexChanged += new System.EventHandler(this.cbbPrueba_SelectedIndexChanged);
            // 
            // btnCarga
            // 
            this.btnCarga.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.btnCarga.Location = new System.Drawing.Point(324, 46);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(136, 24);
            this.btnCarga.TabIndex = 135;
            this.btnCarga.Text = "Cargar Pruebas";
            this.btnCarga.ThemeName = "Office2013Light";
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // btnSav
            // 
            this.btnSav.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSav.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSav.Location = new System.Drawing.Point(476, 718);
            this.btnSav.Name = "btnSav";
            this.btnSav.Size = new System.Drawing.Size(170, 41);
            this.btnSav.TabIndex = 136;
            this.btnSav.Text = "Procesar Resultados";
            this.btnSav.ThemeName = "Office2013Light";
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
            this.btnCerrar.Location = new System.Drawing.Point(1061, 32);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.TabIndex = 137;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radScrollablePanel1.BackColor = System.Drawing.Color.White;
            this.radScrollablePanel1.Location = new System.Drawing.Point(10, 21);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(1108, 749);
            this.radScrollablePanel1.Size = new System.Drawing.Size(1110, 751);
            this.radScrollablePanel1.TabIndex = 138;
            // 
            // frmReporteMasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1132, 787);
            this.ControlBox = false;
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnSav);
            this.Controls.Add(this.btnCarga);
            this.Controls.Add(this.cbbPrueba);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radScrollablePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReporteMasivo";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte Masivo";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.frmReporteMasivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbPrueba.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbPrueba.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbPrueba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCarga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.RadMultiColumnComboBox cbbPrueba;
        private Telerik.WinControls.UI.RadButton btnCarga;
        private Telerik.WinControls.UI.RadButton btnSav;
        internal System.Windows.Forms.Button btnCerrar;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
    }
}
