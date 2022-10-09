
namespace SGPAPP
{
    partial class frmTipoMax
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoMax));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbbMetodo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbPrueba = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbTipo = new System.Windows.Forms.ComboBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSav = new Telerik.WinControls.UI.RadButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSav)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.8453F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.1547F));
            this.tableLayoutPanel1.Controls.Add(this.cbbMetodo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbbPrueba, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbbTipo, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(21, 48);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(362, 96);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // cbbMetodo
            // 
            this.cbbMetodo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbMetodo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbMetodo.Enabled = false;
            this.cbbMetodo.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMetodo.ForeColor = System.Drawing.Color.DimGray;
            this.cbbMetodo.FormattingEnabled = true;
            this.cbbMetodo.Items.AddRange(new object[] {
            "Consulta Web",
            "Impreso"});
            this.cbbMetodo.Location = new System.Drawing.Point(139, 67);
            this.cbbMetodo.Name = "cbbMetodo";
            this.cbbMetodo.Size = new System.Drawing.Size(208, 27);
            this.cbbMetodo.TabIndex = 31;
            this.cbbMetodo.Visible = false;
            this.cbbMetodo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbPrueba_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(71, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "Metodo:";
            this.label5.Visible = false;
            // 
            // cbbPrueba
            // 
            this.cbbPrueba.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbPrueba.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbPrueba.Enabled = false;
            this.cbbPrueba.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPrueba.ForeColor = System.Drawing.Color.DimGray;
            this.cbbPrueba.FormattingEnabled = true;
            this.cbbPrueba.Location = new System.Drawing.Point(139, 35);
            this.cbbPrueba.Name = "cbbPrueba";
            this.cbbPrueba.Size = new System.Drawing.Size(208, 27);
            this.cbbPrueba.TabIndex = 18;
            this.cbbPrueba.DropDown += new System.EventHandler(this.cbbPrueba_DropDown_1);
            this.cbbPrueba.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbPrueba_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(75, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Prueba:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tipo de Prueba:";
            // 
            // cbbTipo
            // 
            this.cbbTipo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbTipo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbTipo.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipo.ForeColor = System.Drawing.Color.DimGray;
            this.cbbTipo.FormattingEnabled = true;
            this.cbbTipo.Location = new System.Drawing.Point(139, 3);
            this.cbbTipo.Name = "cbbTipo";
            this.cbbTipo.Size = new System.Drawing.Size(208, 27);
            this.cbbTipo.TabIndex = 15;
            this.cbbTipo.DropDown += new System.EventHandler(this.cbbTipo_DropDown);
            this.cbbTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTipo_KeyPress);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.White;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Ebrima", 12F);
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.Location = new System.Drawing.Point(364, 5);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.TabIndex = 102;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSav
            // 
            this.btnSav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSav.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSav.Image = ((System.Drawing.Image)(resources.GetObject("btnSav.Image")));
            this.btnSav.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSav.Location = new System.Drawing.Point(162, 168);
            this.btnSav.Name = "btnSav";
            this.btnSav.Size = new System.Drawing.Size(98, 34);
            this.btnSav.TabIndex = 146;
            this.btnSav.Text = "   Procesar";
            this.btnSav.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSav.ThemeName = "Office2013Light";
            this.btnSav.Click += new System.EventHandler(this.btnSav_Click);
            // 
            // frmTipoMax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(405, 217);
            this.ControlBox = false;
            this.Controls.Add(this.btnSav);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTipoMax";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTipoMax";
            this.Load += new System.EventHandler(this.frmTipoMax_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSav)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbbMetodo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbPrueba;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbTipo;
        internal System.Windows.Forms.Button btnCerrar;
        private Telerik.WinControls.UI.RadButton btnSav;
    }
}