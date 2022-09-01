
namespace SGPAPP
{
    partial class frmReferidos
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
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.btnGuardar = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDesc.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtDesc.ForeColor = System.Drawing.Color.DimGray;
            this.txtDesc.Location = new System.Drawing.Point(133, 93);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(209, 26);
            this.txtDesc.TabIndex = 111;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(24, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 112;
            this.label2.Text = "Descripcion:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNom
            // 
            this.txtNom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNom.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtNom.ForeColor = System.Drawing.Color.DimGray;
            this.txtNom.Location = new System.Drawing.Point(133, 45);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(209, 26);
            this.txtNom.TabIndex = 109;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(45, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 110;
            this.label1.Text = "Nombre:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.BackColor = System.Drawing.Color.White;
            this.radScrollablePanel1.Location = new System.Drawing.Point(12, 14);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnGuardar);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label2);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label1);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(347, 184);
            this.radScrollablePanel1.Size = new System.Drawing.Size(349, 186);
            this.radScrollablePanel1.TabIndex = 114;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(223, 127);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(106, 41);
            this.btnGuardar.TabIndex = 114;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.ThemeName = "Office2013Light";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmReferidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(373, 212);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.radScrollablePanel1);
            this.Name = "frmReferidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Referidores";
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel1.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private Telerik.WinControls.UI.RadButton btnGuardar;
    }
}