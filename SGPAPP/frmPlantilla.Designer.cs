
namespace SGPAPP
{
    partial class frmPlantilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlantilla));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnDialog = new System.Windows.Forms.Button();
            this.btnSavep = new System.Windows.Forms.Button();
            this.txtPlantilla = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.oFD1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbPrueba = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.Consult = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnOpen.Enabled = false;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpen.Location = new System.Drawing.Point(246, 375);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(65, 52);
            this.btnOpen.TabIndex = 151;
            this.btnOpen.Text = "Abrir";
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnDialog
            // 
            this.btnDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDialog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDialog.ForeColor = System.Drawing.Color.White;
            this.btnDialog.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDialog.Location = new System.Drawing.Point(342, 64);
            this.btnDialog.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnDialog.Name = "btnDialog";
            this.btnDialog.Size = new System.Drawing.Size(30, 34);
            this.btnDialog.TabIndex = 150;
            this.btnDialog.Text = "....";
            this.btnDialog.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDialog.UseVisualStyleBackColor = false;
            this.btnDialog.Click += new System.EventHandler(this.btnDialog_Click);
            // 
            // btnSavep
            // 
            this.btnSavep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.btnSavep.Enabled = false;
            this.btnSavep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavep.ForeColor = System.Drawing.Color.White;
            this.btnSavep.Image = ((System.Drawing.Image)(resources.GetObject("btnSavep.Image")));
            this.btnSavep.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSavep.Location = new System.Drawing.Point(330, 375);
            this.btnSavep.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnSavep.Name = "btnSavep";
            this.btnSavep.Size = new System.Drawing.Size(65, 52);
            this.btnSavep.TabIndex = 149;
            this.btnSavep.Text = "Guardar";
            this.btnSavep.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSavep.UseVisualStyleBackColor = false;
            this.btnSavep.Click += new System.EventHandler(this.btnSavep_Click);
            // 
            // txtPlantilla
            // 
            this.txtPlantilla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlantilla.Enabled = false;
            this.txtPlantilla.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtPlantilla.ForeColor = System.Drawing.Color.Gray;
            this.txtPlantilla.Location = new System.Drawing.Point(120, 68);
            this.txtPlantilla.Name = "txtPlantilla";
            this.txtPlantilla.Size = new System.Drawing.Size(218, 26);
            this.txtPlantilla.TabIndex = 147;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(46, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 16);
            this.label18.TabIndex = 148;
            this.label18.Text = "Plantilla:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // oFD1
            // 
            this.oFD1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbbPrueba);
            this.groupBox1.Controls.Add(this.btnDialog);
            this.groupBox1.Controls.Add(this.txtPlantilla);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 127);
            this.groupBox1.TabIndex = 156;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Plantilla";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(46, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 157;
            this.label1.Text = "Prueba:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbbPrueba
            // 
            this.cbbPrueba.FormattingEnabled = true;
            this.cbbPrueba.Location = new System.Drawing.Point(120, 28);
            this.cbbPrueba.Name = "cbbPrueba";
            this.cbbPrueba.Size = new System.Drawing.Size(218, 21);
            this.cbbPrueba.TabIndex = 157;
            this.cbbPrueba.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbPrueba_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Consult});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.FilterAndSortEnabled = true;
            this.dataGridView1.Location = new System.Drawing.Point(13, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.Size = new System.Drawing.Size(382, 194);
            this.dataGridView1.TabIndex = 165;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // Consult
            // 
            this.Consult.HeaderText = "Abrir";
            this.Consult.MinimumWidth = 22;
            this.Consult.Name = "Consult";
            this.Consult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // frmPlantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(407, 447);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSavep);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmPlantilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion Plantilla";
            this.Load += new System.EventHandler(this.frmPlantilla_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnDialog;
        private System.Windows.Forms.Button btnSavep;
        private System.Windows.Forms.TextBox txtPlantilla;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.OpenFileDialog oFD1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbPrueba;
        private Zuby.ADGV.AdvancedDataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn Consult;
    }
}