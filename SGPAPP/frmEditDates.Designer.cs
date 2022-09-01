namespace SGPAPP
{
    partial class frmEditDates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditDates));
            this.txtHora = new System.Windows.Forms.TextBox();
            this.cbbTipo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPac = new System.Windows.Forms.TextBox();
            this.cbbStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIndic = new System.Windows.Forms.TextBox();
            this.txtSeguro = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FechaActual = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.btnseg = new System.Windows.Forms.Button();
            this.btnIndic = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.txtLess = new System.Windows.Forms.Button();
            this.txtmore = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHora
            // 
            this.txtHora.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtHora.Enabled = false;
            this.txtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.ForeColor = System.Drawing.Color.Gray;
            this.txtHora.Location = new System.Drawing.Point(172, 97);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(123, 24);
            this.txtHora.TabIndex = 145;
            // 
            // cbbTipo
            // 
            this.cbbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipo.ForeColor = System.Drawing.Color.Gray;
            this.cbbTipo.FormattingEnabled = true;
            this.cbbTipo.Items.AddRange(new object[] {
            "Seleccione el Tipo",
            "Presencial",
            "Domicilio"});
            this.cbbTipo.Location = new System.Drawing.Point(172, 135);
            this.cbbTipo.Name = "cbbTipo";
            this.cbbTipo.Size = new System.Drawing.Size(262, 26);
            this.cbbTipo.TabIndex = 147;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.label8.Location = new System.Drawing.Point(40, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 16);
            this.label8.TabIndex = 146;
            this.label8.Text = "Tipo de Cita:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.label7.Location = new System.Drawing.Point(27, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 16);
            this.label7.TabIndex = 147;
            this.label7.Text = "Cargar Seguro:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.label3.Location = new System.Drawing.Point(83, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 76;
            this.label3.Text = "Hora:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.label1.Location = new System.Drawing.Point(63, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 72;
            this.label1.Text = "Paciente:";
            // 
            // txtPac
            // 
            this.txtPac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPac.Enabled = false;
            this.txtPac.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPac.ForeColor = System.Drawing.Color.Gray;
            this.txtPac.Location = new System.Drawing.Point(172, 62);
            this.txtPac.Name = "txtPac";
            this.txtPac.Size = new System.Drawing.Size(262, 24);
            this.txtPac.TabIndex = 2;
            // 
            // cbbStatus
            // 
            this.cbbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.Items.AddRange(new object[] {
            "Programada",
            "Cancelada"});
            this.cbbStatus.Location = new System.Drawing.Point(172, 342);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(262, 24);
            this.cbbStatus.TabIndex = 79;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.label4.Location = new System.Drawing.Point(75, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 79;
            this.label4.Text = "Estado:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.label2.Location = new System.Drawing.Point(48, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 75;
            this.label2.Text = "Comentario:";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.ForeColor = System.Drawing.Color.Gray;
            this.txtComment.Location = new System.Drawing.Point(172, 252);
            this.txtComment.MaxLength = 200;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(262, 77);
            this.txtComment.TabIndex = 4;
            this.txtComment.Text = "";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.label5.Location = new System.Drawing.Point(11, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 16);
            this.label5.TabIndex = 145;
            this.label5.Text = "Cargar Indicacion:";
            // 
            // txtIndic
            // 
            this.txtIndic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIndic.Enabled = false;
            this.txtIndic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndic.ForeColor = System.Drawing.Color.Gray;
            this.txtIndic.Location = new System.Drawing.Point(172, 212);
            this.txtIndic.Name = "txtIndic";
            this.txtIndic.Size = new System.Drawing.Size(262, 24);
            this.txtIndic.TabIndex = 147;
            // 
            // txtSeguro
            // 
            this.txtSeguro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeguro.Enabled = false;
            this.txtSeguro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeguro.ForeColor = System.Drawing.Color.Gray;
            this.txtSeguro.Location = new System.Drawing.Point(172, 173);
            this.txtSeguro.Name = "txtSeguro";
            this.txtSeguro.Size = new System.Drawing.Size(262, 24);
            this.txtSeguro.TabIndex = 148;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.FechaActual, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(74, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(320, 36);
            this.tableLayoutPanel2.TabIndex = 76;
            // 
            // FechaActual
            // 
            this.FechaActual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FechaActual.AutoSize = true;
            this.FechaActual.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaActual.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FechaActual.Location = new System.Drawing.Point(26, 4);
            this.FechaActual.Name = "FechaActual";
            this.FechaActual.Size = new System.Drawing.Size(268, 28);
            this.FechaActual.TabIndex = 20;
            this.FechaActual.Text = "Sabado 4, de Enero de 2020";
            this.FechaActual.DoubleClick += new System.EventHandler(this.FechaActual_DoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(212, 375);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 72);
            this.btnSave.TabIndex = 78;
            this.btnSave.Text = "Modificar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtp1
            // 
            this.dtp1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp1.CalendarForeColor = System.Drawing.Color.SteelBlue;
            this.dtp1.CalendarTitleForeColor = System.Drawing.Color.Indigo;
            this.dtp1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.dtp1.Location = new System.Drawing.Point(74, 12);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(347, 34);
            this.dtp1.TabIndex = 79;
            this.dtp1.Visible = false;
            this.dtp1.CloseUp += new System.EventHandler(this.dtp1_CloseUp);
            // 
            // btnseg
            // 
            this.btnseg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnseg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnseg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnseg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnseg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnseg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnseg.ForeColor = System.Drawing.Color.White;
            this.btnseg.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnseg.Location = new System.Drawing.Point(441, 168);
            this.btnseg.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnseg.Name = "btnseg";
            this.btnseg.Size = new System.Drawing.Size(30, 33);
            this.btnseg.TabIndex = 142;
            this.btnseg.Text = "....";
            this.btnseg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnseg.UseVisualStyleBackColor = false;
            this.btnseg.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIndic
            // 
            this.btnIndic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIndic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnIndic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnIndic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnIndic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIndic.ForeColor = System.Drawing.Color.White;
            this.btnIndic.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIndic.Location = new System.Drawing.Point(441, 206);
            this.btnIndic.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnIndic.Name = "btnIndic";
            this.btnIndic.Size = new System.Drawing.Size(30, 34);
            this.btnIndic.TabIndex = 143;
            this.btnIndic.Text = "....";
            this.btnIndic.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIndic.UseVisualStyleBackColor = false;
            this.btnIndic.Click += new System.EventHandler(this.btnIndic_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // txtLess
            // 
            this.txtLess.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.txtLess.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.txtLess.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.txtLess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtLess.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLess.ForeColor = System.Drawing.Color.White;
            this.txtLess.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.txtLess.Location = new System.Drawing.Point(340, 94);
            this.txtLess.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtLess.Name = "txtLess";
            this.txtLess.Size = new System.Drawing.Size(30, 33);
            this.txtLess.TabIndex = 148;
            this.txtLess.Text = "-";
            this.txtLess.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.txtLess.UseVisualStyleBackColor = false;
            this.txtLess.Click += new System.EventHandler(this.txtLess_Click);
            // 
            // txtmore
            // 
            this.txtmore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtmore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.txtmore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.txtmore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.txtmore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtmore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmore.ForeColor = System.Drawing.Color.White;
            this.txtmore.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.txtmore.Location = new System.Drawing.Point(305, 94);
            this.txtmore.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtmore.Name = "txtmore";
            this.txtmore.Size = new System.Drawing.Size(30, 33);
            this.txtmore.TabIndex = 147;
            this.txtmore.Text = "+";
            this.txtmore.UseVisualStyleBackColor = false;
            this.txtmore.Click += new System.EventHandler(this.txtmore_Click);
            // 
            // frmEditDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 454);
            this.Controls.Add(this.cbbStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbTipo);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHora);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIndic);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLess);
            this.Controls.Add(this.txtmore);
            this.Controls.Add(this.txtSeguro);
            this.Controls.Add(this.btnIndic);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnseg);
            this.Controls.Add(this.txtPac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.dtp1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmEditDates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Citas";
            this.Load += new System.EventHandler(this.frmEditDates_Load);
            this.DoubleClick += new System.EventHandler(this.frmEditDates_DoubleClick);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtComment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Label FechaActual;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbStatus;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.TextBox txtIndic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSeguro;
        private System.Windows.Forms.Button btnseg;
        private System.Windows.Forms.Button btnIndic;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbTipo;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Button txtLess;
        private System.Windows.Forms.Button txtmore;
    }
}