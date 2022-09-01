
namespace SGPAPP
{
    partial class frmRolesEmpresa
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition5 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition6 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.dgbAdd = new System.Windows.Forms.DataGridView();
            this.uid3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgbRemove = new System.Windows.Forms.DataGridView();
            this.uid2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idempresa2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCanc = new Telerik.WinControls.UI.RadButton();
            this.btnSav = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnRemove = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radGridView5 = new Telerik.WinControls.UI.RadGridView();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.uid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emnom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgbRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCanc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView5.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radScrollablePanel1.BackColor = System.Drawing.Color.White;
            this.radScrollablePanel1.Location = new System.Drawing.Point(12, 12);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.dgbAdd);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.dgbRemove);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnCanc);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnSav);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radLabel2);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radLabel1);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnRemove);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnAdd);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radGridView1);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radGridView5);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(828, 507);
            this.radScrollablePanel1.Size = new System.Drawing.Size(830, 509);
            this.radScrollablePanel1.TabIndex = 1;
            // 
            // dgbAdd
            // 
            this.dgbAdd.AllowUserToAddRows = false;
            this.dgbAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbAdd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uid3,
            this.emid,
            this.fecha3});
            this.dgbAdd.Location = new System.Drawing.Point(278, 436);
            this.dgbAdd.Name = "dgbAdd";
            this.dgbAdd.Size = new System.Drawing.Size(11, 23);
            this.dgbAdd.TabIndex = 154;
            this.dgbAdd.Visible = false;
            // 
            // uid3
            // 
            this.uid3.HeaderText = "Userid";
            this.uid3.Name = "uid3";
            // 
            // emid
            // 
            this.emid.HeaderText = "emid";
            this.emid.Name = "emid";
            // 
            // fecha3
            // 
            this.fecha3.HeaderText = "Fecha";
            this.fecha3.Name = "fecha3";
            // 
            // dgbRemove
            // 
            this.dgbRemove.AllowUserToAddRows = false;
            this.dgbRemove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbRemove.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uid2,
            this.idempresa2,
            this.Fecha2,
            this.User2});
            this.dgbRemove.Location = new System.Drawing.Point(22, 436);
            this.dgbRemove.Name = "dgbRemove";
            this.dgbRemove.Size = new System.Drawing.Size(10, 23);
            this.dgbRemove.TabIndex = 153;
            this.dgbRemove.Visible = false;
            // 
            // uid2
            // 
            this.uid2.HeaderText = "Userid";
            this.uid2.Name = "uid2";
            // 
            // idempresa2
            // 
            this.idempresa2.HeaderText = "idempresa";
            this.idempresa2.Name = "idempresa2";
            // 
            // Fecha2
            // 
            this.Fecha2.HeaderText = "Fecha";
            this.Fecha2.Name = "Fecha2";
            // 
            // User2
            // 
            this.User2.HeaderText = "User";
            this.User2.Name = "User2";
            // 
            // btnCanc
            // 
            this.btnCanc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCanc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCanc.Location = new System.Drawing.Point(706, 455);
            this.btnCanc.Name = "btnCanc";
            this.btnCanc.Size = new System.Drawing.Size(98, 34);
            this.btnCanc.TabIndex = 151;
            this.btnCanc.Text = "Cancelar";
            this.btnCanc.ThemeName = "Office2010Silver";
            this.btnCanc.Click += new System.EventHandler(this.btnCanc_Click);
            // 
            // btnSav
            // 
            this.btnSav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSav.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSav.Location = new System.Drawing.Point(586, 455);
            this.btnSav.Name = "btnSav";
            this.btnSav.Size = new System.Drawing.Size(98, 34);
            this.btnSav.TabIndex = 150;
            this.btnSav.Text = "Guardar";
            this.btnSav.ThemeName = "Office2013Light";
            this.btnSav.Click += new System.EventHandler(this.btnSav_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.radLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radLabel2.Location = new System.Drawing.Point(442, 25);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(228, 19);
            this.radLabel2.TabIndex = 149;
            this.radLabel2.Text = "Empresas habilitadas al Usuario:";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.radLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radLabel1.Location = new System.Drawing.Point(22, 26);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(78, 19);
            this.radLabel1.TabIndex = 148;
            this.radLabel1.Text = "Empresas:";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemove.Image = global::SGPAPP.Properties.Resources.icons8_arrow_pointing_left_35;
            this.btnRemove.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRemove.Location = new System.Drawing.Point(390, 279);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(46, 45);
            this.btnRemove.TabIndex = 147;
            this.btnRemove.ThemeName = "Office2010Silver";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnAdd.Image = global::SGPAPP.Properties.Resources.icons8_arrow_35;
            this.btnAdd.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(390, 163);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(46, 45);
            this.btnAdd.TabIndex = 146;
            this.btnAdd.ThemeName = "Office2013Light";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.Location = new System.Drawing.Point(442, 50);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition5;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(362, 380);
            this.radGridView1.TabIndex = 145;
            this.radGridView1.ThemeName = "Office2013Light";
            // 
            // radGridView5
            // 
            this.radGridView5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radGridView5.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGridView5.Location = new System.Drawing.Point(22, 50);
            // 
            // 
            // 
            this.radGridView5.MasterTemplate.AllowAddNewRow = false;
            this.radGridView5.MasterTemplate.AllowDeleteRow = false;
            this.radGridView5.MasterTemplate.AllowDragToGroup = false;
            this.radGridView5.MasterTemplate.AllowEditRow = false;
            this.radGridView5.MasterTemplate.EnableFiltering = true;
            this.radGridView5.MasterTemplate.ViewDefinition = tableViewDefinition6;
            this.radGridView5.Name = "radGridView5";
            this.radGridView5.Size = new System.Drawing.Size(362, 380);
            this.radGridView5.TabIndex = 144;
            this.radGridView5.ThemeName = "Office2013Light";
            this.radGridView5.SelectionChanged += new System.EventHandler(this.radGridView5_SelectionChanged);
            // 
            // uid
            // 
            this.uid.HeaderText = "Userid";
            this.uid.Name = "uid";
            // 
            // idempresa
            // 
            this.idempresa.HeaderText = "ID";
            this.idempresa.Name = "idempresa";
            // 
            // emnom
            // 
            this.emnom.HeaderText = "Empresa";
            this.emnom.Name = "emnom";
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            // 
            // frmRolesEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(854, 533);
            this.Controls.Add(this.radScrollablePanel1);
            this.Name = "frmRolesEmpresa";
            this.Text = "Habilitar Empresas";
            this.Load += new System.EventHandler(this.frmRolesEmpresa_Load);
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel1.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgbRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCanc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView5.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private System.Windows.Forms.DataGridView dgbRemove;
        private Telerik.WinControls.UI.RadButton btnCanc;
        private Telerik.WinControls.UI.RadButton btnSav;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnRemove;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadGridView radGridView5;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private System.Windows.Forms.DataGridViewTextBoxColumn uid;
        private System.Windows.Forms.DataGridViewTextBoxColumn idempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn emnom;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridView dgbAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn uid3;
        private System.Windows.Forms.DataGridViewTextBoxColumn emid;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha3;
        private System.Windows.Forms.DataGridViewTextBoxColumn uid2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idempresa2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha2;
        private System.Windows.Forms.DataGridViewTextBoxColumn User2;
    }
}