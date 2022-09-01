
namespace SGPAPP
{
    partial class frmResultse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResultse));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.btnMail = new Telerik.WinControls.UI.RadButton();
            this.btnEx = new Telerik.WinControls.UI.RadButton();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.tableLayoutPanel9);
            this.groupBox2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(30, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 63);
            this.groupBox2.TabIndex = 137;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consultar";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.txtConsulta, 0, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(9, 19);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(242, 37);
            this.tableLayoutPanel9.TabIndex = 117;
            // 
            // txtConsulta
            // 
            this.txtConsulta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtConsulta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtConsulta.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtConsulta.ForeColor = System.Drawing.Color.DimGray;
            this.txtConsulta.Location = new System.Drawing.Point(2, 5);
            this.txtConsulta.Margin = new System.Windows.Forms.Padding(2);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(233, 26);
            this.txtConsulta.TabIndex = 99;
            this.txtConsulta.Text = "Digite nombre o cedula";
            this.txtConsulta.TextChanged += new System.EventHandler(this.txtConsulta_TextChanged);
            this.txtConsulta.Enter += new System.EventHandler(this.txtConsulta_Enter);
            this.txtConsulta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsulta_KeyPress);
            this.txtConsulta.Leave += new System.EventHandler(this.txtConsulta_Leave);
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.Location = new System.Drawing.Point(30, 99);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(841, 410);
            this.radGridView1.TabIndex = 140;
            this.radGridView1.ThemeName = "Office2013Light";
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radScrollablePanel1.BackColor = System.Drawing.Color.White;
            this.radScrollablePanel1.Location = new System.Drawing.Point(13, 13);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnMail);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnEx);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(878, 506);
            this.radScrollablePanel1.Size = new System.Drawing.Size(880, 508);
            this.radScrollablePanel1.TabIndex = 141;
            // 
            // btnMail
            // 
            this.btnMail.Image = ((System.Drawing.Image)(resources.GetObject("btnMail.Image")));
            this.btnMail.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnMail.Location = new System.Drawing.Point(345, 19);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(77, 62);
            this.btnMail.TabIndex = 140;
            this.btnMail.Text = "     Reenviar  \r\nEmpresa";
            this.btnMail.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMail.ThemeName = "Office2013Light";
            this.btnMail.Click += new System.EventHandler(this.btnMail_Click);
            // 
            // btnEx
            // 
            this.btnEx.Image = ((System.Drawing.Image)(resources.GetObject("btnEx.Image")));
            this.btnEx.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnEx.Location = new System.Drawing.Point(281, 25);
            this.btnEx.Name = "btnEx";
            this.btnEx.Size = new System.Drawing.Size(58, 51);
            this.btnEx.TabIndex = 139;
            this.btnEx.Text = "Exportar";
            this.btnEx.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEx.ThemeName = "Office2013Light";
            this.btnEx.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // frmResultse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(905, 532);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.radScrollablePanel1);
            this.Name = "frmResultse";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Resultados";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.frmResultse_Load);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TextBox txtConsulta;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private Telerik.WinControls.UI.RadButton btnMail;
        private Telerik.WinControls.UI.RadButton btnEx;
    }
}
