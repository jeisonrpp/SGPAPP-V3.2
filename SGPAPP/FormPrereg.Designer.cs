
namespace SGPAPP
{
    partial class FormPrereg
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
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnID = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelcontenedor = new System.Windows.Forms.Panel();
            this.panelformularios = new System.Windows.Forms.Panel();
            this.btnConsultas = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPacientes
            // 
            this.btnPacientes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btnPacientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPacientes.ForeColor = System.Drawing.Color.Black;
            this.btnPacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPacientes.Location = new System.Drawing.Point(403, 2);
            this.btnPacientes.Margin = new System.Windows.Forms.Padding(2);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(126, 53);
            this.btnPacientes.TabIndex = 15;
            this.btnPacientes.Text = "Registrar Pacientes";
            this.btnPacientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnID
            // 
            this.btnID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnID.FlatAppearance.BorderSize = 0;
            this.btnID.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btnID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnID.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnID.ForeColor = System.Drawing.Color.Black;
            this.btnID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnID.Location = new System.Drawing.Point(273, 2);
            this.btnID.Margin = new System.Windows.Forms.Padding(2);
            this.btnID.Name = "btnID";
            this.btnID.Size = new System.Drawing.Size(126, 53);
            this.btnID.TabIndex = 15;
            this.btnID.Text = "Generar ID";
            this.btnID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnID.UseVisualStyleBackColor = true;
            this.btnID.Click += new System.EventHandler(this.btnID_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Ebrima", 12F);
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.Location = new System.Drawing.Point(866, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.TabIndex = 122;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnConsultas);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnID);
            this.panel1.Controls.Add(this.btnPacientes);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(913, 53);
            this.panel1.TabIndex = 1;
            // 
            // panelcontenedor
            // 
            this.panelcontenedor.BackColor = System.Drawing.Color.White;
            this.panelcontenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelcontenedor.Location = new System.Drawing.Point(0, 0);
            this.panelcontenedor.Name = "panelcontenedor";
            this.panelcontenedor.Size = new System.Drawing.Size(913, 666);
            this.panelcontenedor.TabIndex = 7;
            // 
            // panelformularios
            // 
            this.panelformularios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelformularios.BackColor = System.Drawing.Color.White;
            this.panelformularios.Location = new System.Drawing.Point(0, 50);
            this.panelformularios.Margin = new System.Windows.Forms.Padding(2);
            this.panelformularios.Name = "panelformularios";
            this.panelformularios.Size = new System.Drawing.Size(913, 613);
            this.panelformularios.TabIndex = 8;
            // 
            // btnConsultas
            // 
            this.btnConsultas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConsultas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultas.FlatAppearance.BorderSize = 0;
            this.btnConsultas.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btnConsultas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnConsultas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultas.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultas.ForeColor = System.Drawing.Color.Black;
            this.btnConsultas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultas.Location = new System.Drawing.Point(533, 1);
            this.btnConsultas.Margin = new System.Windows.Forms.Padding(2);
            this.btnConsultas.Name = "btnConsultas";
            this.btnConsultas.Size = new System.Drawing.Size(126, 53);
            this.btnConsultas.TabIndex = 16;
            this.btnConsultas.Text = "Consultas Pre-ID";
            this.btnConsultas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultas.UseVisualStyleBackColor = true;
            this.btnConsultas.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormPrereg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 666);
            this.Controls.Add(this.panelformularios);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelcontenedor);
            this.Name = "FormPrereg";
            this.Text = "FormPrereg";
            this.Load += new System.EventHandler(this.FormPrereg_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnPacientes;
        internal System.Windows.Forms.Button btnID;
        internal System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelcontenedor;
        private System.Windows.Forms.Panel panelformularios;
        internal System.Windows.Forms.Button btnConsultas;
    }
}