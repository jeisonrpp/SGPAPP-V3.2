namespace SGPAPP
{
    partial class frmAddPruebas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddPruebas));
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.btnSav = new Telerik.WinControls.UI.RadButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTiempo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrueba = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.btnEliminar = new Telerik.WinControls.UI.RadButton();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMax2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMin1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUnd2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkbox = new Telerik.WinControls.UI.RadCheckBox();
            this.cbbTipo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkbox)).BeginInit();
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
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.cbbTipo);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.chkbox);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.txtUnd2);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label11);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.txtMax2);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label8);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.txtMin1);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label9);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.txtResult);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label6);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnEliminar);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnAdd);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radGridView1);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.txtMax);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label5);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.txtMin);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label4);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.txtUnidad);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label3);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.txtPrueba);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label2);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.txtTiempo);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label1);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label7);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnSav);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(828, 507);
            this.radScrollablePanel1.Size = new System.Drawing.Size(830, 509);
            this.radScrollablePanel1.TabIndex = 1;
            // 
            // btnSav
            // 
            this.btnSav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSav.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSav.Location = new System.Drawing.Point(345, 466);
            this.btnSav.Name = "btnSav";
            this.btnSav.Size = new System.Drawing.Size(98, 34);
            this.btnSav.TabIndex = 150;
            this.btnSav.Text = "Guardar";
            this.btnSav.ThemeName = "Office2013Light";
            this.btnSav.Click += new System.EventHandler(this.btnSav_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(17, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 16);
            this.label7.TabIndex = 153;
            this.label7.Text = "Tipo de Prueba:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTiempo
            // 
            this.txtTiempo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTiempo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTiempo.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtTiempo.ForeColor = System.Drawing.Color.DimGray;
            this.txtTiempo.Location = new System.Drawing.Point(148, 101);
            this.txtTiempo.MaxLength = 50;
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(209, 26);
            this.txtTiempo.TabIndex = 154;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(61, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 155;
            this.label1.Text = "Tiempo:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPrueba
            // 
            this.txtPrueba.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPrueba.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPrueba.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtPrueba.ForeColor = System.Drawing.Color.DimGray;
            this.txtPrueba.Location = new System.Drawing.Point(557, 65);
            this.txtPrueba.MaxLength = 50;
            this.txtPrueba.Name = "txtPrueba";
            this.txtPrueba.Size = new System.Drawing.Size(209, 26);
            this.txtPrueba.TabIndex = 156;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(418, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 16);
            this.label2.TabIndex = 157;
            this.label2.Text = "Nombre de Prueba:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUnidad
            // 
            this.txtUnidad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUnidad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUnidad.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtUnidad.ForeColor = System.Drawing.Color.DimGray;
            this.txtUnidad.Location = new System.Drawing.Point(557, 101);
            this.txtUnidad.MaxLength = 50;
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.Size = new System.Drawing.Size(209, 26);
            this.txtUnidad.TabIndex = 158;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(418, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 159;
            this.label3.Text = "Unidad de Medida:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMin
            // 
            this.txtMin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMin.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtMin.ForeColor = System.Drawing.Color.DimGray;
            this.txtMin.Location = new System.Drawing.Point(163, 145);
            this.txtMin.MaxLength = 50;
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(63, 26);
            this.txtMin.TabIndex = 160;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(61, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 161;
            this.label4.Text = "Valor Minimo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMax
            // 
            this.txtMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMax.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMax.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtMax.ForeColor = System.Drawing.Color.DimGray;
            this.txtMax.Location = new System.Drawing.Point(340, 145);
            this.txtMax.MaxLength = 50;
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(63, 26);
            this.txtMax.TabIndex = 162;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(235, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 163;
            this.label5.Text = "Valor Maximo:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radGridView1
            // 
            this.radGridView1.Location = new System.Drawing.Point(32, 288);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(726, 164);
            this.radGridView1.TabIndex = 164;
            this.radGridView1.ThemeName = "Office2013Light";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(769, 315);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(46, 45);
            this.btnAdd.TabIndex = 147;
            this.btnAdd.ThemeName = "Office2013Light";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEliminar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEliminar.Location = new System.Drawing.Point(769, 389);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(46, 45);
            this.btnEliminar.TabIndex = 148;
            this.btnEliminar.ThemeName = "Office2013Light";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtResult.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtResult.ForeColor = System.Drawing.Color.DimGray;
            this.txtResult.Location = new System.Drawing.Point(124, 253);
            this.txtResult.MaxLength = 50;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(134, 26);
            this.txtResult.TabIndex = 165;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(41, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 166;
            this.label6.Text = "Resultado:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMax2
            // 
            this.txtMax2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMax2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMax2.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtMax2.ForeColor = System.Drawing.Color.DimGray;
            this.txtMax2.Location = new System.Drawing.Point(515, 253);
            this.txtMax2.MaxLength = 50;
            this.txtMax2.Name = "txtMax2";
            this.txtMax2.Size = new System.Drawing.Size(63, 26);
            this.txtMax2.TabIndex = 169;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(432, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 16);
            this.label8.TabIndex = 170;
            this.label8.Text = "Valor Max:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMin1
            // 
            this.txtMin1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMin1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMin1.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtMin1.ForeColor = System.Drawing.Color.DimGray;
            this.txtMin1.Location = new System.Drawing.Point(349, 253);
            this.txtMin1.MaxLength = 50;
            this.txtMin1.Name = "txtMin1";
            this.txtMin1.Size = new System.Drawing.Size(63, 26);
            this.txtMin1.TabIndex = 167;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(275, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 16);
            this.label9.TabIndex = 168;
            this.label9.Text = "Valor Min:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUnd2
            // 
            this.txtUnd2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUnd2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUnd2.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtUnd2.ForeColor = System.Drawing.Color.DimGray;
            this.txtUnd2.Location = new System.Drawing.Point(663, 253);
            this.txtUnd2.MaxLength = 50;
            this.txtUnd2.Name = "txtUnd2";
            this.txtUnd2.Size = new System.Drawing.Size(95, 26);
            this.txtUnd2.TabIndex = 171;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(589, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 16);
            this.label11.TabIndex = 172;
            this.label11.Text = "Unidad:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkbox
            // 
            this.chkbox.Location = new System.Drawing.Point(44, 19);
            this.chkbox.Name = "chkbox";
            this.chkbox.Size = new System.Drawing.Size(98, 18);
            this.chkbox.TabIndex = 173;
            this.chkbox.Text = "Prueba Especial";
            this.chkbox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkbox_ToggleStateChanged);
            // 
            // cbbTipo
            // 
            this.cbbTipo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbTipo.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.cbbTipo.FormattingEnabled = true;
            this.cbbTipo.Location = new System.Drawing.Point(148, 65);
            this.cbbTipo.Name = "cbbTipo";
            this.cbbTipo.Size = new System.Drawing.Size(209, 27);
            this.cbbTipo.TabIndex = 174;
            // 
            // frmAddPruebas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(854, 533);
            this.Controls.Add(this.radScrollablePanel1);
            this.Name = "frmAddPruebas";
            this.Text = "frmAddPruebas";
            this.Load += new System.EventHandler(this.frmAddPruebas_Load);
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel1.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private Telerik.WinControls.UI.RadButton btnSav;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrueba;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTiempo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUnd2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMax2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMin1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadButton btnEliminar;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadCheckBox chkbox;
        private System.Windows.Forms.ComboBox cbbTipo;
    }
}