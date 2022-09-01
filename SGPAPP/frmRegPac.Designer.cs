
namespace SGPAPP
{
    partial class frmRegPac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegPac));
            this.cbbSeguro = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmailC = new System.Windows.Forms.TextBox();
            this.txtCed = new System.Windows.Forms.MaskedTextBox();
            this.txtFecha = new System.Windows.Forms.MaskedTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.cbbRef = new System.Windows.Forms.ComboBox();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.chkCed = new System.Windows.Forms.CheckBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.rbM = new System.Windows.Forms.RadioButton();
            this.rbF = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.txtCel = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.cbbDoc = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnGuardar = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbSeguro
            // 
            this.cbbSeguro.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbSeguro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSeguro.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.cbbSeguro.ForeColor = System.Drawing.Color.DimGray;
            this.cbbSeguro.FormattingEnabled = true;
            this.cbbSeguro.Location = new System.Drawing.Point(3, 191);
            this.cbbSeguro.Name = "cbbSeguro";
            this.cbbSeguro.Size = new System.Drawing.Size(203, 27);
            this.cbbSeguro.TabIndex = 10;
            this.cbbSeguro.SelectedIndexChanged += new System.EventHandler(this.cbbSeguro_SelectedIndexChanged);
            this.cbbSeguro.Enter += new System.EventHandler(this.cbbSeguro_Enter);
            this.cbbSeguro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbSeguro_KeyPress);
            this.cbbSeguro.Leave += new System.EventHandler(this.cbbSeguro_Leave);
            this.cbbSeguro.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cbbSeguro_PreviewKeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(86, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "label6";
            this.label6.Visible = false;
            // 
            // txtEmailC
            // 
            this.txtEmailC.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtEmailC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmailC.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtEmailC.ForeColor = System.Drawing.Color.DimGray;
            this.txtEmailC.Location = new System.Drawing.Point(5, 102);
            this.txtEmailC.MaxLength = 50;
            this.txtEmailC.Name = "txtEmailC";
            this.txtEmailC.Size = new System.Drawing.Size(203, 26);
            this.txtEmailC.TabIndex = 7;
            this.txtEmailC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSeg_MouseClick);
            this.txtEmailC.TextChanged += new System.EventHandler(this.txtEmailC_TextChanged);
            this.txtEmailC.Enter += new System.EventHandler(this.txtEmailC_Enter);
            this.txtEmailC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmailC_KeyPress);
            this.txtEmailC.Leave += new System.EventHandler(this.txtEmailC_Leave);
            this.txtEmailC.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtEmailC_PreviewKeyDown);
            // 
            // txtCed
            // 
            this.txtCed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCed.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCed.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtCed.ForeColor = System.Drawing.Color.DimGray;
            this.txtCed.Location = new System.Drawing.Point(3, 57);
            this.txtCed.Name = "txtCed";
            this.txtCed.Size = new System.Drawing.Size(205, 26);
            this.txtCed.TabIndex = 4;
            this.txtCed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSeg_MouseClick);
            this.txtCed.Enter += new System.EventHandler(this.txtCed_Enter);
            this.txtCed.Leave += new System.EventHandler(this.txtCed_Leave);
            this.txtCed.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCed_PreviewKeyDown);
            // 
            // txtFecha
            // 
            this.txtFecha.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFecha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFecha.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtFecha.ForeColor = System.Drawing.Color.DimGray;
            this.txtFecha.Location = new System.Drawing.Point(3, 10);
            this.txtFecha.Mask = "00-00-0000";
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(203, 26);
            this.txtFecha.TabIndex = 5;
            this.txtFecha.ValidatingType = typeof(System.DateTime);
            this.txtFecha.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtFecha_MaskInputRejected);
            this.txtFecha.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtFecha_MouseClick);
            this.txtFecha.Enter += new System.EventHandler(this.txtFecha_Enter);
            this.txtFecha.Leave += new System.EventHandler(this.txtFecha_Leave);
            this.txtFecha.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtFecha_PreviewKeyDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Controls.Add(this.radButton3, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.radButton2, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.cbbRef, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.chkFecha, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkCed, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtFecha, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtEmailC, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.cbbSeguro, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtCed, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(614, 122);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.68953F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.44043F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.96751F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(240, 277);
            this.tableLayoutPanel2.TabIndex = 97;
            // 
            // radButton3
            // 
            this.radButton3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radButton3.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.radButton3.Image = ((System.Drawing.Image)(resources.GetObject("radButton3.Image")));
            this.radButton3.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton3.Location = new System.Drawing.Point(214, 193);
            this.radButton3.Name = "radButton3";
            this.radButton3.ShowItemToolTips = false;
            this.radButton3.Size = new System.Drawing.Size(23, 24);
            this.radButton3.TabIndex = 114;
            this.radButton3.ThemeName = "Office2013Light";
            this.radButton3.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // radButton2
            // 
            this.radButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radButton2.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.radButton2.Image = ((System.Drawing.Image)(resources.GetObject("radButton2.Image")));
            this.radButton2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton2.Location = new System.Drawing.Point(214, 240);
            this.radButton2.Name = "radButton2";
            this.radButton2.ShowItemToolTips = false;
            this.radButton2.Size = new System.Drawing.Size(23, 24);
            this.radButton2.TabIndex = 113;
            this.radButton2.ThemeName = "Office2013Light";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // cbbRef
            // 
            this.cbbRef.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbRef.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbRef.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.cbbRef.ForeColor = System.Drawing.Color.DimGray;
            this.cbbRef.FormattingEnabled = true;
            this.cbbRef.Location = new System.Drawing.Point(3, 239);
            this.cbbRef.Name = "cbbRef";
            this.cbbRef.Size = new System.Drawing.Size(203, 27);
            this.cbbRef.TabIndex = 114;
            // 
            // chkFecha
            // 
            this.chkFecha.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkFecha.AutoSize = true;
            this.chkFecha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFecha.Location = new System.Drawing.Point(214, 16);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(15, 14);
            this.chkFecha.TabIndex = 105;
            this.chkFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFecha.UseVisualStyleBackColor = false;
            this.chkFecha.CheckedChanged += new System.EventHandler(this.chkFecha_CheckedChanged);
            // 
            // chkCed
            // 
            this.chkCed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCed.AutoSize = true;
            this.chkCed.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkCed.Location = new System.Drawing.Point(214, 63);
            this.chkCed.Name = "chkCed";
            this.chkCed.Size = new System.Drawing.Size(23, 14);
            this.chkCed.TabIndex = 107;
            this.chkCed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCed.UseVisualStyleBackColor = false;
            this.chkCed.CheckedChanged += new System.EventHandler(this.chkCed_CheckedChanged);
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
            this.btnCerrar.Location = new System.Drawing.Point(797, 9);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.TabIndex = 100;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel8.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel8.Controls.Add(this.rbM, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.rbF, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(207, 88);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(215, 28);
            this.tableLayoutPanel8.TabIndex = 101;
            // 
            // rbM
            // 
            this.rbM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbM.AutoSize = true;
            this.rbM.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.rbM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbM.Location = new System.Drawing.Point(113, 4);
            this.rbM.Name = "rbM";
            this.rbM.Size = new System.Drawing.Size(90, 20);
            this.rbM.TabIndex = 2;
            this.rbM.TabStop = true;
            this.rbM.Text = "Masculino";
            this.rbM.UseVisualStyleBackColor = true;
            this.rbM.CheckedChanged += new System.EventHandler(this.rbM_CheckedChanged);
            this.rbM.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.rbM_PreviewKeyDown);
            // 
            // rbF
            // 
            this.rbF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbF.AutoSize = true;
            this.rbF.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.rbF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbF.Location = new System.Drawing.Point(7, 4);
            this.rbF.Name = "rbF";
            this.rbF.Size = new System.Drawing.Size(88, 20);
            this.rbF.TabIndex = 1;
            this.rbF.TabStop = true;
            this.rbF.Text = "Femenino";
            this.rbF.UseVisualStyleBackColor = true;
            this.rbF.CheckedChanged += new System.EventHandler(this.rbF_CheckedChanged);
            this.rbF.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.rbF_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(63, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 32);
            this.label2.TabIndex = 104;
            this.label2.Text = "Fecha de Nacimiento:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(456, 122);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.32852F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.52347F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.24549F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(152, 277);
            this.tableLayoutPanel4.TabIndex = 103;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(56, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 16);
            this.label7.TabIndex = 115;
            this.label7.Text = "Referido por:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(89, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 107;
            this.label9.Text = "Seguro:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(20, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 32);
            this.label11.TabIndex = 105;
            this.label11.Text = "Email Alterno(Opcional):";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(17, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 16);
            this.label13.TabIndex = 103;
            this.label13.Text = "Doc. de Identidad:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Location = new System.Drawing.Point(425, 122);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 6;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.6065F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.6065F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(25, 277);
            this.tableLayoutPanel5.TabIndex = 111;
            // 
            // txtDir
            // 
            this.txtDir.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDir.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtDir.ForeColor = System.Drawing.Color.DimGray;
            this.txtDir.Location = new System.Drawing.Point(3, 194);
            this.txtDir.MaxLength = 200;
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(209, 26);
            this.txtDir.TabIndex = 9;
            this.txtDir.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSeg_MouseClick);
            this.txtDir.Enter += new System.EventHandler(this.txtDir_Enter);
            this.txtDir.Leave += new System.EventHandler(this.txtDir_Leave);
            this.txtDir.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtDir_PreviewKeyDown);
            // 
            // txtCel
            // 
            this.txtCel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtCel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCel.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtCel.ForeColor = System.Drawing.Color.DimGray;
            this.txtCel.Location = new System.Drawing.Point(3, 148);
            this.txtCel.Mask = "(999) 000-0000";
            this.txtCel.Name = "txtCel";
            this.txtCel.Size = new System.Drawing.Size(209, 26);
            this.txtCel.TabIndex = 8;
            this.txtCel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSeg_MouseClick);
            this.txtCel.Enter += new System.EventHandler(this.txtCel_Enter);
            this.txtCel.Leave += new System.EventHandler(this.txtCel_Leave);
            this.txtCel.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCel_PreviewKeyDown);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmail.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtEmail.ForeColor = System.Drawing.Color.DimGray;
            this.txtEmail.Location = new System.Drawing.Point(3, 102);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(209, 26);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSeg_MouseClick);
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            this.txtEmail.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtEmail_PreviewKeyDown);
            // 
            // txtNom
            // 
            this.txtNom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNom.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtNom.ForeColor = System.Drawing.Color.DimGray;
            this.txtNom.Location = new System.Drawing.Point(3, 10);
            this.txtNom.MaxLength = 50;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(209, 26);
            this.txtNom.TabIndex = 3;
            this.txtNom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNom_MouseClick);
            this.txtNom.Enter += new System.EventHandler(this.txtNom_Enter);
            this.txtNom.Leave += new System.EventHandler(this.txtNom_Leave);
            this.txtNom.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtNom_PreviewKeyDown);
            // 
            // cbbDoc
            // 
            this.cbbDoc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbDoc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbDoc.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.cbbDoc.ForeColor = System.Drawing.Color.DimGray;
            this.cbbDoc.FormattingEnabled = true;
            this.cbbDoc.Items.AddRange(new object[] {
            "Cedula",
            "Pasaporte"});
            this.cbbDoc.Location = new System.Drawing.Point(3, 55);
            this.cbbDoc.Name = "cbbDoc";
            this.cbbDoc.Size = new System.Drawing.Size(203, 27);
            this.cbbDoc.TabIndex = 113;
            this.cbbDoc.SelectedIndexChanged += new System.EventHandler(this.cbbDoc_SelectedIndexChanged);
            this.cbbDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbDoc_KeyPress);
            this.cbbDoc.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cbbDoc_PreviewKeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cbbDoc, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDir, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(207, 122);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(215, 277);
            this.tableLayoutPanel1.TabIndex = 96;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 103;
            this.label1.Text = "Nombre del Paciente:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(125, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 105;
            this.label3.Text = "Email:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(74, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 16);
            this.label8.TabIndex = 108;
            this.label8.Text = "Tipo de Doc.:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(49, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 16);
            this.label4.TabIndex = 106;
            this.label4.Text = "No. de Contacto:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(98, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 107;
            this.label5.Text = "Direccion:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(31, 122);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(175, 277);
            this.tableLayoutPanel3.TabIndex = 102;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(614, 451);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(106, 41);
            this.btnGuardar.TabIndex = 112;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.ThemeName = "Office2013Light";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(741, 451);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 41);
            this.btnCancelar.TabIndex = 113;
            this.btnCancelar.Text = "Limpiar";
            this.btnCancelar.ThemeName = "Office2010Silver";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnCerrar);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(842, 503);
            this.radScrollablePanel1.Size = new System.Drawing.Size(844, 505);
            this.radScrollablePanel1.TabIndex = 114;
            // 
            // frmRegPac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(868, 529);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel8);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.radScrollablePanel1);
            this.Name = "frmRegPac";
            this.Text = "Registro de Pacientes";
            this.Load += new System.EventHandler(this.frmRegPac_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbSeguro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmailC;
        private System.Windows.Forms.MaskedTextBox txtCed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.MaskedTextBox txtFecha;
        internal System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.RadioButton rbM;
        private System.Windows.Forms.RadioButton rbF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkCed;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.MaskedTextBox txtCel;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.ComboBox cbbDoc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private System.Windows.Forms.ComboBox cbbRef;
        private System.Windows.Forms.Label label7;
        private Telerik.WinControls.UI.RadButton btnGuardar;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadButton btnCancelar;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
    }
}