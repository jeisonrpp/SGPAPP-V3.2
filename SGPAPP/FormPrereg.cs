using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGPAPP
{
    public partial class FormPrereg : Form
    {
        public FormPrereg()
        {
            InitializeComponent();
        }

        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        DialogResult Resulta;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelcontenedor.Region = region;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void openFormOnPanel<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca el formulario en la colecion.
            //si el formulario/instancia no existe/crea           
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(closedForm);
            }

            else
            {
                //si la Formulario / instancia existe, lo traemos a frente
                formulario.BringToFront();
            }
        }
        private void closedForm(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["frmPreReg"] == null)
            {
                btnID.BackColor = Color.Gainsboro;
                //More Codes
            }
            if (Application.OpenForms["frmPregistro"] == null)
            {
                btnPacientes.BackColor = Color.Gainsboro;
                //More Codes
            }
            if (Application.OpenForms["frmConsultaPi"] == null)
            {
                btnConsultas.BackColor = Color.Gainsboro;
                //More Codes
            }
        }
        private void FormPrereg_Load(object sender, EventArgs e)
        {

        }

        private void btnID_Click(object sender, EventArgs e)
        {
            if (btnPacientes.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("Existe otro menu abierto,  desea cerrarlo para abrir el esta opcion?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmPregistro obj = (frmPregistro)Application.OpenForms["frmPregistro"];
                    obj.Close();
                }
                else
                {
                    return;
                }

            }
            if (btnConsultas.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("Existe otro menu abierto,  desea cerrarlo para abrir el esta opcion?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmConsultaPI obj = (frmConsultaPI)Application.OpenForms["frmConsultaPI"];
                    obj.Close();
                }
                else
                {
                    return;
                }

            }
            openFormOnPanel<frmPreReg>();
            btnID.BackColor = Color.Silver;
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            if (btnID.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("Existe otro menu abierto, desea cerrarlo para abrir el esta opcion?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmPreReg obj = (frmPreReg)Application.OpenForms["frmPreReg"];
                    obj.Close();
                }
                else
                {
                    return;
                }

            }
            if (btnConsultas.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("Existe otro menu abierto,  desea cerrarlo para abrir el esta opcion?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmConsultaPI obj = (frmConsultaPI)Application.OpenForms["frmConsultaPI"];
                    obj.Close();
                }
                else
                {
                    return;
                }

            }
            openFormOnPanel<frmPregistro>();
            btnPacientes.BackColor = Color.Silver;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnID.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("Existe otro menu abierto, desea cerrarlo para abrir el esta opcion?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmPreReg obj = (frmPreReg)Application.OpenForms["frmPreReg"];
                    obj.Close();
                }
                else
                {
                    return;
                }

            }
            if (btnPacientes.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("Existe otro menu abierto,  desea cerrarlo para abrir el esta opcion?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmPregistro obj = (frmPregistro)Application.OpenForms["frmPregistro"];
                    obj.Close();
                }
                else
                {
                    return;
                }

            }
            openFormOnPanel<frmConsultaPI>();
            btnConsultas.BackColor = Color.Silver;
        }
    }
}
