namespace SGPAPP
{
    partial class frmAppmtns
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppmtns));
            this.dgb1 = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnNewDate = new System.Windows.Forms.Button();
            this.FechaActual = new System.Windows.Forms.Label();
            this.FechaAnterior = new System.Windows.Forms.LinkLabel();
            this.FechaSiguiente = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnDomi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgb1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgb1
            // 
            this.dgb1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgb1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgb1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgb1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgb1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgb1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgb1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar});
            this.dgb1.EnableHeadersVisualStyles = false;
            this.dgb1.GridColor = System.Drawing.Color.LightSkyBlue;
            this.dgb1.Location = new System.Drawing.Point(11, 86);
            this.dgb1.Margin = new System.Windows.Forms.Padding(2);
            this.dgb1.Name = "dgb1";
            this.dgb1.RowHeadersVisible = false;
            this.dgb1.RowHeadersWidth = 51;
            this.dgb1.RowTemplate.Height = 24;
            this.dgb1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgb1.Size = new System.Drawing.Size(544, 372);
            this.dgb1.TabIndex = 17;
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
            // monthCalendar1
            // 
            this.monthCalendar1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.monthCalendar1.Location = new System.Drawing.Point(569, 196);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 18;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // btnNewDate
            // 
            this.btnNewDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNewDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnNewDate.Enabled = false;
            this.btnNewDate.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnNewDate.FlatAppearance.BorderSize = 0;
            this.btnNewDate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnNewDate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnNewDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewDate.ForeColor = System.Drawing.Color.White;
            this.btnNewDate.Image = ((System.Drawing.Image)(resources.GetObject("btnNewDate.Image")));
            this.btnNewDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewDate.Location = new System.Drawing.Point(615, 144);
            this.btnNewDate.Name = "btnNewDate";
            this.btnNewDate.Size = new System.Drawing.Size(138, 40);
            this.btnNewDate.TabIndex = 19;
            this.btnNewDate.Text = "        Nueva Cita";
            this.btnNewDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewDate.UseVisualStyleBackColor = false;
            this.btnNewDate.Click += new System.EventHandler(this.btnNewDate_Click);
            // 
            // FechaActual
            // 
            this.FechaActual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FechaActual.AutoSize = true;
            this.FechaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.FechaActual.Location = new System.Drawing.Point(16, 5);
            this.FechaActual.Name = "FechaActual";
            this.FechaActual.Size = new System.Drawing.Size(288, 25);
            this.FechaActual.TabIndex = 20;
            this.FechaActual.Text = "Sabado 4, de Enero de 2020";
            this.FechaActual.Click += new System.EventHandler(this.FechaActual_Click);
            this.FechaActual.DoubleClick += new System.EventHandler(this.FechaActual_DoubleClick);
            // 
            // FechaAnterior
            // 
            this.FechaAnterior.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FechaAnterior.AutoSize = true;
            this.FechaAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaAnterior.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FechaAnterior.LinkColor = System.Drawing.Color.SteelBlue;
            this.FechaAnterior.Location = new System.Drawing.Point(3, 7);
            this.FechaAnterior.Name = "FechaAnterior";
            this.FechaAnterior.Size = new System.Drawing.Size(202, 16);
            this.FechaAnterior.TabIndex = 21;
            this.FechaAnterior.TabStop = true;
            this.FechaAnterior.Text = "<-- Viernes 3, de Enero 2020";
            this.FechaAnterior.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FechaAnterior_LinkClicked);
            // 
            // FechaSiguiente
            // 
            this.FechaSiguiente.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FechaSiguiente.AutoSize = true;
            this.FechaSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaSiguiente.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FechaSiguiente.LinkColor = System.Drawing.Color.SteelBlue;
            this.FechaSiguiente.Location = new System.Drawing.Point(330, 7);
            this.FechaSiguiente.Name = "FechaSiguiente";
            this.FechaSiguiente.Size = new System.Drawing.Size(211, 16);
            this.FechaSiguiente.TabIndex = 22;
            this.FechaSiguiente.TabStop = true;
            this.FechaSiguiente.Text = "Domingo 5, de Enero 2020 -->";
            this.FechaSiguiente.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FechaSiguiente_LinkClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.49321F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.50679F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 248F));
            this.tableLayoutPanel1.Controls.Add(this.FechaSiguiente, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.FechaAnterior, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 51);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 30);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.FechaActual, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(123, 9);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(320, 36);
            this.tableLayoutPanel2.TabIndex = 24;
            // 
            // dtp1
            // 
            this.dtp1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp1.CalendarForeColor = System.Drawing.Color.Indigo;
            this.dtp1.CalendarTitleForeColor = System.Drawing.Color.Indigo;
            this.dtp1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.dtp1.Location = new System.Drawing.Point(123, 9);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(347, 34);
            this.dtp1.TabIndex = 25;
            this.dtp1.Visible = false;
            this.dtp1.CloseUp += new System.EventHandler(this.dtp1_CloseUp);
            this.dtp1.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(594, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 40);
            this.button1.TabIndex = 26;
            this.button1.Text = "       Consulta de Citas";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
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
            this.btnCerrar.Location = new System.Drawing.Point(766, 6);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.TabIndex = 101;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnDomi
            // 
            this.btnDomi.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDomi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnDomi.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnDomi.FlatAppearance.BorderSize = 0;
            this.btnDomi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnDomi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnDomi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDomi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDomi.ForeColor = System.Drawing.Color.White;
            this.btnDomi.Image = ((System.Drawing.Image)(resources.GetObject("btnDomi.Image")));
            this.btnDomi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDomi.Location = new System.Drawing.Point(594, 72);
            this.btnDomi.Name = "btnDomi";
            this.btnDomi.Size = new System.Drawing.Size(180, 40);
            this.btnDomi.TabIndex = 102;
            this.btnDomi.Text = "       Citas a Domicilio";
            this.btnDomi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDomi.UseVisualStyleBackColor = false;
            this.btnDomi.Click += new System.EventHandler(this.btnDomi_Click);
            // 
            // frmAppmtns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(809, 476);
            this.Controls.Add(this.btnDomi);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnNewDate);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.dgb1);
            this.Controls.Add(this.dtp1);
            this.Name = "frmAppmtns";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de Citas";
            this.Load += new System.EventHandler(this.frmAppmtns_Load);
            this.DoubleClick += new System.EventHandler(this.frmAppmtns_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.dgb1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgb1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnNewDate;
        private System.Windows.Forms.Label FechaActual;
        private System.Windows.Forms.LinkLabel FechaAnterior;
        private System.Windows.Forms.LinkLabel FechaSiguiente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnDomi;
    }
}