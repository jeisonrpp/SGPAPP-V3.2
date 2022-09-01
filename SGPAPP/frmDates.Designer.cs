namespace SGPAPP
{
    partial class frmDates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDates));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FechaActual = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPac = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIndic = new System.Windows.Forms.TextBox();
            this.txtSeguro = new System.Windows.Forms.TextBox();
            this.cbbTipo = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnIndicacion = new System.Windows.Forms.Button();
            this.btnSeguro = new System.Windows.Forms.Button();
            this.txtLess = new System.Windows.Forms.Button();
            this.txtmore = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.FechaActual, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(95, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(320, 36);
            this.tableLayoutPanel2.TabIndex = 25;
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
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Indigo;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.Location = new System.Drawing.Point(425, 100);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(35, 33);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSav_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(41, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 19);
            this.label6.TabIndex = 144;
            this.label6.Text = "Cargar Seguro:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(54, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 19);
            this.label4.TabIndex = 77;
            this.label4.Text = "Tipo de Cita:";
            // 
            // txtHora
            // 
            this.txtHora.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtHora.Enabled = false;
            this.txtHora.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.txtHora.Location = new System.Drawing.Point(156, 143);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(123, 26);
            this.txtHora.TabIndex = 144;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(100, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 19);
            this.label3.TabIndex = 76;
            this.label3.Text = "Hora:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(77, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 72;
            this.label1.Text = "Paciente:";
            // 
            // txtPac
            // 
            this.txtPac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPac.Enabled = false;
            this.txtPac.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtPac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.txtPac.Location = new System.Drawing.Point(156, 104);
            this.txtPac.Name = "txtPac";
            this.txtPac.Size = new System.Drawing.Size(263, 26);
            this.txtPac.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(54, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 75;
            this.label2.Text = "Comentario:";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.txtComment.Location = new System.Drawing.Point(156, 257);
            this.txtComment.MaxLength = 200;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(263, 57);
            this.txtComment.TabIndex = 4;
            this.txtComment.Text = "";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(20, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 19);
            this.label5.TabIndex = 77;
            this.label5.Text = "Cargar Indicacion:";
            // 
            // txtIndic
            // 
            this.txtIndic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIndic.Enabled = false;
            this.txtIndic.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtIndic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.txtIndic.Location = new System.Drawing.Point(156, 220);
            this.txtIndic.Name = "txtIndic";
            this.txtIndic.Size = new System.Drawing.Size(263, 26);
            this.txtIndic.TabIndex = 144;
            this.txtIndic.Text = "empty";
            // 
            // txtSeguro
            // 
            this.txtSeguro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeguro.Enabled = false;
            this.txtSeguro.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtSeguro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.txtSeguro.Location = new System.Drawing.Point(156, 182);
            this.txtSeguro.Name = "txtSeguro";
            this.txtSeguro.Size = new System.Drawing.Size(263, 26);
            this.txtSeguro.TabIndex = 144;
            this.txtSeguro.Text = "empty";
            // 
            // cbbTipo
            // 
            this.cbbTipo.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.cbbTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.cbbTipo.FormattingEnabled = true;
            this.cbbTipo.Items.AddRange(new object[] {
            "Seleccione el Tipo",
            "Presencial",
            "Domicilio"});
            this.cbbTipo.Location = new System.Drawing.Point(156, 67);
            this.cbbTipo.Name = "cbbTipo";
            this.cbbTipo.Size = new System.Drawing.Size(263, 27);
            this.cbbTipo.TabIndex = 145;
            this.cbbTipo.SelectedIndexChanged += new System.EventHandler(this.cbbTipo_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(199, 327);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 71);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = " Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // btnIndicacion
            // 
            this.btnIndicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIndicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnIndicacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnIndicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIndicacion.ForeColor = System.Drawing.Color.White;
            this.btnIndicacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIndicacion.Location = new System.Drawing.Point(426, 218);
            this.btnIndicacion.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnIndicacion.Name = "btnIndicacion";
            this.btnIndicacion.Size = new System.Drawing.Size(30, 33);
            this.btnIndicacion.TabIndex = 143;
            this.btnIndicacion.Text = "....";
            this.btnIndicacion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIndicacion.UseVisualStyleBackColor = false;
            this.btnIndicacion.Click += new System.EventHandler(this.btnIndicacion_Click);
            // 
            // btnSeguro
            // 
            this.btnSeguro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeguro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnSeguro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnSeguro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeguro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeguro.ForeColor = System.Drawing.Color.White;
            this.btnSeguro.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeguro.Location = new System.Drawing.Point(425, 179);
            this.btnSeguro.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnSeguro.Name = "btnSeguro";
            this.btnSeguro.Size = new System.Drawing.Size(30, 33);
            this.btnSeguro.TabIndex = 142;
            this.btnSeguro.Text = "....";
            this.btnSeguro.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeguro.UseVisualStyleBackColor = false;
            this.btnSeguro.Click += new System.EventHandler(this.btnSeguro_Click);
            // 
            // txtLess
            // 
            this.txtLess.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.txtLess.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.txtLess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtLess.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLess.ForeColor = System.Drawing.Color.White;
            this.txtLess.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.txtLess.Location = new System.Drawing.Point(322, 139);
            this.txtLess.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtLess.Name = "txtLess";
            this.txtLess.Size = new System.Drawing.Size(30, 33);
            this.txtLess.TabIndex = 146;
            this.txtLess.Text = "-";
            this.txtLess.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.txtLess.UseVisualStyleBackColor = false;
            this.txtLess.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtmore
            // 
            this.txtmore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtmore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.txtmore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.txtmore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtmore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmore.ForeColor = System.Drawing.Color.White;
            this.txtmore.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.txtmore.Location = new System.Drawing.Point(289, 139);
            this.txtmore.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtmore.Name = "txtmore";
            this.txtmore.Size = new System.Drawing.Size(30, 33);
            this.txtmore.TabIndex = 145;
            this.txtmore.Text = "+";
            this.txtmore.UseVisualStyleBackColor = false;
            this.txtmore.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(512, 410);
            this.Controls.Add(this.txtPac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHora);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLess);
            this.Controls.Add(this.txtmore);
            this.Controls.Add(this.cbbTipo);
            this.Controls.Add(this.btnIndicacion);
            this.Controls.Add(this.btnSeguro);
            this.Controls.Add(this.txtSeguro);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtIndic);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de Citas";
            this.Load += new System.EventHandler(this.frmDates_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtComment;
        public System.Windows.Forms.Label FechaActual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtIndic;
        private System.Windows.Forms.TextBox txtSeguro;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btnIndicacion;
        private System.Windows.Forms.Button btnSeguro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbTipo;
        public System.Windows.Forms.TextBox txtPac;
        public System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Button txtLess;
        private System.Windows.Forms.Button txtmore;
    }
}