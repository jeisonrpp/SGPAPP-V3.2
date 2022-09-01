
namespace SGPAPP
{
    partial class frmResultsO
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
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.pdocname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radGridView5 = new Telerik.WinControls.UI.RadGridView();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtConsultaR = new System.Windows.Forms.TextBox();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView5.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pdocname,
            this.paid});
            this.dataGridView4.Location = new System.Drawing.Point(954, 51);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(10, 11);
            this.dataGridView4.TabIndex = 138;
            this.dataGridView4.Visible = false;
            // 
            // pdocname
            // 
            this.pdocname.HeaderText = "DocName";
            this.pdocname.Name = "pdocname";
            // 
            // paid
            // 
            this.paid.HeaderText = "PacId";
            this.paid.Name = "paid";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.radGridView5);
            this.groupBox4.Controls.Add(this.dataGridView5);
            this.groupBox4.Controls.Add(this.tableLayoutPanel5);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.groupBox4.Location = new System.Drawing.Point(26, 30);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(922, 599);
            this.groupBox4.TabIndex = 136;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pruebas Pendientes";
            // 
            // radGridView5
            // 
            this.radGridView5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView5.Location = new System.Drawing.Point(7, 67);
            // 
            // 
            // 
            this.radGridView5.MasterTemplate.AllowAddNewRow = false;
            this.radGridView5.MasterTemplate.AllowDeleteRow = false;
            this.radGridView5.MasterTemplate.AllowEditRow = false;
            this.radGridView5.MasterTemplate.EnableFiltering = true;
            this.radGridView5.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.radGridView5.Name = "radGridView5";
            this.radGridView5.Size = new System.Drawing.Size(907, 526);
            this.radGridView5.TabIndex = 141;
            this.radGridView5.ThemeName = "Office2013Light";
            // 
            // dataGridView5
            // 
            this.dataGridView5.AllowUserToAddRows = false;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(404, 25);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(513, 36);
            this.dataGridView5.TabIndex = 124;
            this.dataGridView5.Visible = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.txtConsultaR, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(7, 28);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(269, 34);
            this.tableLayoutPanel5.TabIndex = 117;
            // 
            // txtConsultaR
            // 
            this.txtConsultaR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtConsultaR.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtConsultaR.ForeColor = System.Drawing.Color.Silver;
            this.txtConsultaR.Location = new System.Drawing.Point(2, 4);
            this.txtConsultaR.Margin = new System.Windows.Forms.Padding(2);
            this.txtConsultaR.Name = "txtConsultaR";
            this.txtConsultaR.Size = new System.Drawing.Size(265, 26);
            this.txtConsultaR.TabIndex = 99;
            this.txtConsultaR.Text = "Digite Nombre de la Empresa";
            this.txtConsultaR.TextChanged += new System.EventHandler(this.txtConsultaR_TextChanged);
            this.txtConsultaR.Enter += new System.EventHandler(this.txtConsultaR_Enter);
            this.txtConsultaR.Leave += new System.EventHandler(this.txtConsultaR_Leave);
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
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(950, 627);
            this.radScrollablePanel1.Size = new System.Drawing.Size(952, 629);
            this.radScrollablePanel1.TabIndex = 139;
            // 
            // frmResultsO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(976, 653);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.radScrollablePanel1);
            this.Name = "frmResultsO";
            this.Text = "frmResultsO";
            this.Load += new System.EventHandler(this.frmResultsO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView5.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn pdocname;
        private System.Windows.Forms.DataGridViewTextBoxColumn paid;
        private System.Windows.Forms.GroupBox groupBox4;
        private Telerik.WinControls.UI.RadGridView radGridView5;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox txtConsultaR;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
    }
}