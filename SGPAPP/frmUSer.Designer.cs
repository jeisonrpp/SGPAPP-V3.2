
namespace SGPAPP
{
    partial class frmUSer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUSer));
            this.cbbStatus = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cbbNivel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.radGridView5 = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtConsultaR = new System.Windows.Forms.TextBox();
            this.btnSav = new Telerik.WinControls.UI.RadButton();
            this.btnUpd = new Telerik.WinControls.UI.RadButton();
            this.btnCanc = new Telerik.WinControls.UI.RadButton();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.btnEmpresa = new Telerik.WinControls.UI.RadButton();
            this.btnDel = new Telerik.WinControls.UI.RadButton();
            this.btnRoles = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView5.MasterTemplate)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCanc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmpresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbStatus
            // 
            this.cbbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbStatus.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbStatus.ForeColor = System.Drawing.Color.DimGray;
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbbStatus.Location = new System.Drawing.Point(772, 251);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(209, 25);
            this.cbbStatus.TabIndex = 129;
            this.cbbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbStatus_KeyPress);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.White;
            this.label25.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(701, 255);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(59, 16);
            this.label25.TabIndex = 142;
            this.label25.Text = "Estado:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbbNivel
            // 
            this.cbbNivel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbNivel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbNivel.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNivel.ForeColor = System.Drawing.Color.DimGray;
            this.cbbNivel.FormattingEnabled = true;
            this.cbbNivel.Items.AddRange(new object[] {
            "Admin",
            "Digitador",
            "Analista",
            "Hibrido"});
            this.cbbNivel.Location = new System.Drawing.Point(772, 293);
            this.cbbNivel.Name = "cbbNivel";
            this.cbbNivel.Size = new System.Drawing.Size(209, 25);
            this.cbbNivel.TabIndex = 130;
            this.cbbNivel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbNivel_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(715, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 136;
            this.label5.Text = "Nivel:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(678, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 135;
            this.label4.Text = "Contraseña:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPass
            // 
            this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPass.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtPass.ForeColor = System.Drawing.Color.DimGray;
            this.txtPass.Location = new System.Drawing.Point(772, 208);
            this.txtPass.MaxLength = 25;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(209, 26);
            this.txtPass.TabIndex = 128;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(698, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 134;
            this.label3.Text = "Usuario:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUser.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtUser.ForeColor = System.Drawing.Color.DimGray;
            this.txtUser.Location = new System.Drawing.Point(772, 165);
            this.txtUser.MaxLength = 50;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(209, 26);
            this.txtUser.TabIndex = 127;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(703, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 133;
            this.label2.Text = "Cedula:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCed
            // 
            this.txtCed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCed.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCed.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtCed.ForeColor = System.Drawing.Color.DimGray;
            this.txtCed.Location = new System.Drawing.Point(772, 122);
            this.txtCed.MaxLength = 15;
            this.txtCed.Name = "txtCed";
            this.txtCed.Size = new System.Drawing.Size(209, 26);
            this.txtCed.TabIndex = 126;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(698, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 132;
            this.label1.Text = "Nombre:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNom
            // 
            this.txtNom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNom.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtNom.ForeColor = System.Drawing.Color.DimGray;
            this.txtNom.Location = new System.Drawing.Point(772, 79);
            this.txtNom.MaxLength = 50;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(209, 26);
            this.txtNom.TabIndex = 125;
            // 
            // radGridView5
            // 
            this.radGridView5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView5.Location = new System.Drawing.Point(24, 79);
            // 
            // 
            // 
            this.radGridView5.MasterTemplate.AllowAddNewRow = false;
            this.radGridView5.MasterTemplate.AllowDeleteRow = false;
            this.radGridView5.MasterTemplate.AllowEditRow = false;
            this.radGridView5.MasterTemplate.EnableFiltering = true;
            this.radGridView5.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView5.Name = "radGridView5";
            this.radGridView5.Size = new System.Drawing.Size(649, 429);
            this.radGridView5.TabIndex = 143;
            this.radGridView5.ThemeName = "Office2013Light";
            this.radGridView5.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.radGridView5_CellFormatting);
            this.radGridView5.FilterChanged += new Telerik.WinControls.UI.GridViewCollectionChangedEventHandler(this.radGridView5_FilterChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.txtConsultaR, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(24, 29);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(269, 34);
            this.tableLayoutPanel5.TabIndex = 144;
            // 
            // txtConsultaR
            // 
            this.txtConsultaR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtConsultaR.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtConsultaR.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtConsultaR.ForeColor = System.Drawing.Color.DimGray;
            this.txtConsultaR.Location = new System.Drawing.Point(2, 4);
            this.txtConsultaR.Margin = new System.Windows.Forms.Padding(2);
            this.txtConsultaR.Name = "txtConsultaR";
            this.txtConsultaR.Size = new System.Drawing.Size(265, 26);
            this.txtConsultaR.TabIndex = 99;
            this.txtConsultaR.Text = "Digite Nombre del Usuario";
            this.txtConsultaR.TextChanged += new System.EventHandler(this.txtConsultaR_TextChanged);
            this.txtConsultaR.Enter += new System.EventHandler(this.txtConsultaR_Enter);
            this.txtConsultaR.Leave += new System.EventHandler(this.txtConsultaR_Leave);
            // 
            // btnSav
            // 
            this.btnSav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSav.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSav.Location = new System.Drawing.Point(744, 460);
            this.btnSav.Name = "btnSav";
            this.btnSav.Size = new System.Drawing.Size(98, 34);
            this.btnSav.TabIndex = 145;
            this.btnSav.Text = "Guardar";
            this.btnSav.ThemeName = "Office2013Light";
            this.btnSav.Click += new System.EventHandler(this.btnSav_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUpd.Location = new System.Drawing.Point(744, 460);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(98, 34);
            this.btnUpd.TabIndex = 146;
            this.btnUpd.Text = "Modificar";
            this.btnUpd.ThemeName = "Office2013Light";
            this.btnUpd.Visible = false;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnCanc
            // 
            this.btnCanc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCanc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCanc.Location = new System.Drawing.Point(870, 460);
            this.btnCanc.Name = "btnCanc";
            this.btnCanc.Size = new System.Drawing.Size(98, 34);
            this.btnCanc.TabIndex = 147;
            this.btnCanc.Text = "Cancelar";
            this.btnCanc.ThemeName = "Office2010Silver";
            this.btnCanc.Click += new System.EventHandler(this.btnCanc_Click);
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
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnEmpresa);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnDel);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnRoles);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnCanc);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnSav);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnUpd);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(987, 519);
            this.radScrollablePanel1.Size = new System.Drawing.Size(989, 521);
            this.radScrollablePanel1.TabIndex = 148;
            // 
            // btnEmpresa
            // 
            this.btnEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmpresa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEmpresa.Enabled = false;
            this.btnEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpresa.Image")));
            this.btnEmpresa.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmpresa.Location = new System.Drawing.Point(908, 324);
            this.btnEmpresa.Name = "btnEmpresa";
            this.btnEmpresa.Size = new System.Drawing.Size(60, 63);
            this.btnEmpresa.TabIndex = 149;
            this.btnEmpresa.Text = "   Roles de \r\nEmpresa";
            this.btnEmpresa.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmpresa.ThemeName = "Office2010Silver";
            this.btnEmpresa.Click += new System.EventHandler(this.btnEmpresa_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDel.Enabled = false;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnDel.Location = new System.Drawing.Point(752, 324);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(60, 63);
            this.btnDel.TabIndex = 146;
            this.btnDel.Text = "   Eliminar\r\nUsuario";
            this.btnDel.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDel.ThemeName = "Office2013Light";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRoles.Enabled = false;
            this.btnRoles.Image = ((System.Drawing.Image)(resources.GetObject("btnRoles.Image")));
            this.btnRoles.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnRoles.Location = new System.Drawing.Point(829, 324);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(60, 63);
            this.btnRoles.TabIndex = 148;
            this.btnRoles.Text = "   Roles de \r\nUsuario";
            this.btnRoles.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRoles.ThemeName = "Office2010Silver";
            this.btnRoles.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // frmUSer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1013, 545);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.radGridView5);
            this.Controls.Add(this.cbbStatus);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.cbbNivel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.radScrollablePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmUSer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion Usuarios";
            this.Load += new System.EventHandler(this.frmUSer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView5.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView5)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCanc)).EndInit();
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnEmpresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbStatus;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cbbNivel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNom;
        private Telerik.WinControls.UI.RadGridView radGridView5;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox txtConsultaR;
        private Telerik.WinControls.UI.RadButton btnSav;
        private Telerik.WinControls.UI.RadButton btnUpd;
        private Telerik.WinControls.UI.RadButton btnCanc;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.UI.RadButton btnDel;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private Telerik.WinControls.UI.RadButton btnRoles;
        private Telerik.WinControls.UI.RadButton btnEmpresa;
    }
}