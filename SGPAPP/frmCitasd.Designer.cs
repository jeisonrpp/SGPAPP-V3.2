
namespace SGPAPP
{
    partial class frmCitasd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FechaActual = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FechaSiguiente = new System.Windows.Forms.LinkLabel();
            this.FechaAnterior = new System.Windows.Forms.LinkLabel();
            this.dgb1 = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgb1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.FechaActual, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(157, 15);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(320, 36);
            this.tableLayoutPanel2.TabIndex = 112;
            // 
            // FechaActual
            // 
            this.FechaActual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FechaActual.AutoSize = true;
            this.FechaActual.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.FechaActual.Location = new System.Drawing.Point(26, 4);
            this.FechaActual.Name = "FechaActual";
            this.FechaActual.Size = new System.Drawing.Size(268, 28);
            this.FechaActual.TabIndex = 20;
            this.FechaActual.Text = "Sabado 4, de Enero de 2020";
            this.FechaActual.Click += new System.EventHandler(this.FechaActual_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.49321F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.50679F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249F));
            this.tableLayoutPanel1.Controls.Add(this.FechaSiguiente, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.FechaAnterior, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 57);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(588, 30);
            this.tableLayoutPanel1.TabIndex = 111;
            // 
            // FechaSiguiente
            // 
            this.FechaSiguiente.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FechaSiguiente.AutoSize = true;
            this.FechaSiguiente.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaSiguiente.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FechaSiguiente.LinkColor = System.Drawing.Color.SteelBlue;
            this.FechaSiguiente.Location = new System.Drawing.Point(394, 6);
            this.FechaSiguiente.Name = "FechaSiguiente";
            this.FechaSiguiente.Size = new System.Drawing.Size(191, 17);
            this.FechaSiguiente.TabIndex = 22;
            this.FechaSiguiente.TabStop = true;
            this.FechaSiguiente.Text = "Domingo 5, de Enero 2020 -->";
            this.FechaSiguiente.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FechaSiguiente_LinkClicked);
            // 
            // FechaAnterior
            // 
            this.FechaAnterior.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FechaAnterior.AutoSize = true;
            this.FechaAnterior.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaAnterior.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FechaAnterior.LinkColor = System.Drawing.Color.SteelBlue;
            this.FechaAnterior.Location = new System.Drawing.Point(3, 6);
            this.FechaAnterior.Name = "FechaAnterior";
            this.FechaAnterior.Size = new System.Drawing.Size(179, 17);
            this.FechaAnterior.TabIndex = 21;
            this.FechaAnterior.TabStop = true;
            this.FechaAnterior.Text = "<-- Viernes 3, de Enero 2020";
            this.FechaAnterior.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FechaAnterior_LinkClicked);
            // 
            // dgb1
            // 
            this.dgb1.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.dgb1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgb1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgb1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgb1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgb1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgb1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar});
            this.dgb1.EnableHeadersVisualStyles = false;
            this.dgb1.GridColor = System.Drawing.Color.LightSkyBlue;
            this.dgb1.Location = new System.Drawing.Point(11, 98);
            this.dgb1.Margin = new System.Windows.Forms.Padding(2);
            this.dgb1.Name = "dgb1";
            this.dgb1.RowHeadersVisible = false;
            this.dgb1.RowHeadersWidth = 51;
            this.dgb1.RowTemplate.Height = 24;
            this.dgb1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgb1.Size = new System.Drawing.Size(615, 372);
            this.dgb1.TabIndex = 110;
            this.dgb1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgb1_CellContentClick);
            this.dgb1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgb1_CellPainting);
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dtp1
            // 
            this.dtp1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp1.CalendarForeColor = System.Drawing.Color.Indigo;
            this.dtp1.CalendarTitleForeColor = System.Drawing.Color.Indigo;
            this.dtp1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.dtp1.Location = new System.Drawing.Point(157, 15);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(347, 34);
            this.dtp1.TabIndex = 113;
            this.dtp1.Visible = false;
            this.dtp1.CloseUp += new System.EventHandler(this.dtp1_CloseUp);
            // 
            // frmCitasd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 476);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgb1);
            this.Controls.Add(this.dtp1);
            this.Name = "frmCitasd";
            this.Text = "Gestion de Citas a Domicilio";
            this.Load += new System.EventHandler(this.frmCitasd_Load);
            this.DoubleClick += new System.EventHandler(this.frmCitasd_DoubleClick);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgb1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label FechaActual;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel FechaSiguiente;
        private System.Windows.Forms.LinkLabel FechaAnterior;
        private System.Windows.Forms.DataGridView dgb1;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DateTimePicker dtp1;
    }
}