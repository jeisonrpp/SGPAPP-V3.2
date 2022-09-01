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
    public partial class frmOperativos : Form
    {
        public frmOperativos()
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
            if (Application.OpenForms["frmPacE"] == null)
            {
                btnPacient.BackColor = Color.Gainsboro;
                //More Codes
            }
            if (Application.OpenForms["frmConsultaO"] == null)
            {
                btnConsulta.BackColor = Color.Gainsboro;
                //More Codes
            }
            if (Application.OpenForms["frmResultsO"] == null)
            {
                btnResult.BackColor = Color.Gainsboro;
                //More Codes
            }
            if (Application.OpenForms["frmPruebasO"] == null)
            {
                btnPruebas.BackColor = Color.Gainsboro;
                //More Codes
            }
            if (Application.OpenForms["frmEditO"] == null)
            {
                btnEmpresa.BackColor = Color.Gainsboro;
                //More Codes
            }
        }
        private void frmOperativos_Load(object sender, EventArgs e)
        {

        }

        private void btnPacient_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Registro") || UserCache.Nivel == "Admin")
            {
                if (btnConsulta.BackColor != Color.Gainsboro)
                {
                    Resulta = MessageBox.Show("La Consulta de Resultados esta abierta, desea cerrarla para abrir el registro de empresas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Resulta == DialogResult.Yes)
                    {
                        frmConsultaO obj = (frmConsultaO)Application.OpenForms["frmConsultaO"];
                        obj.Close();
                    }
                    else
                    {
                        return;
                    }

                }
                else if (btnResult.BackColor != Color.Gainsboro)
                {
                    Resulta = MessageBox.Show("La Gestion de Resultados esta abierta, desea cerrarla para abrir el registro de empresas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Resulta == DialogResult.Yes)
                    {
                        frmResultsO obj = (frmResultsO)Application.OpenForms["frmResultsO"];
                        obj.Close();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (btnPruebas.BackColor != Color.Gainsboro)
                {
                    Resulta = MessageBox.Show("La Gestion de Pruebas esta abierta, desea cerrarla para abrir el registro de empresas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Resulta == DialogResult.Yes)
                    {
                        frmPruebasO obj = (frmPruebasO)Application.OpenForms["frmPruebasO"];
                        obj.Close();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (btnEmpresa.BackColor != Color.Gainsboro)
                {
                    Resulta = MessageBox.Show("La Modificacion de Empresas esta abierta, desea cerrarla para abrir el registro de empresas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Resulta == DialogResult.Yes)
                    {
                        frmEditO obj = (frmEditO)Application.OpenForms["frmEditO"];
                        obj.Close();
                    }
                    else
                    {
                        return;
                    }
                }

                openFormOnPanel<frmPacE>();
                btnPacient.BackColor = Color.Silver;



            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    private void button4_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Consulta de Resultados Empresa") || UserCache.Nivel == "Admin")
            {
                if (btnResult.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("La Gestion de Resultados esta abierta, desea cerrarla para abrir la Consulta de Resultados?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmResultsO obj = (frmResultsO)Application.OpenForms["frmResultsO"];
                    obj.Close();
                }
                else
                {
                    return;
                }
            }
            else if (btnPruebas.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("La Gestion de Pruebas esta abierta, desea cerrarla para abrir la Consulta de Resultados?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmPruebasO obj = (frmPruebasO)Application.OpenForms["frmPruebasO"];
                    obj.Close();
                }
                else
                {
                    return;
                }
            }
            else if (btnEmpresa.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("La Modificacion de Empresas esta abierta, desea cerrarla para abrir la Consulta de Resultados?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmEditO obj = (frmEditO)Application.OpenForms["frmEditO"];
                    obj.Close();
                }
                else
                {
                    return;
                }
            }
            else if (btnPacient.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("El Registro de Empresas esta abierto, desea cerrarla para abrir la Consulta de Resultados?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmPacE obj = (frmPacE)Application.OpenForms["frmPacE"];
                    obj.Close();
                }
                else
                {
                    return;
                }
            }

            openFormOnPanel<frmConsultaO>();
            btnConsulta.BackColor = Color.Silver;
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Gestion de Resultados Empresa") || UserCache.Nivel == "Admin")
            {
                if (btnConsulta.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("La Consulta de Resultados esta abierta, desea cerrarla para abrir la Gestion de Resultados?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmConsultaO obj = (frmConsultaO)Application.OpenForms["frmConsultaO"];
                    obj.Close();
                }
                else
                {
                    return;
                }

            }
            else if (btnPruebas.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("La Gestion de Pruebas esta abierta, desea cerrarla para abrir la Gestion de Resultados?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmPruebasO obj = (frmPruebasO)Application.OpenForms["frmPruebasO"];
                    obj.Close();
                }
                else
                {
                    return;
                }
            }
            else if (btnEmpresa.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("La Modificacion de Empresas esta abierta, desea cerrarla para abrir la Gestion de Resultados?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmEditO obj = (frmEditO)Application.OpenForms["frmEditO"];
                    obj.Close();
                }
                else
                {
                    return;
                }
            }
            else if (btnPacient.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("El Registro de Empresas esta abierto, desea cerrarla para abrir la Gestion de Resultados?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmPacE obj = (frmPacE)Application.OpenForms["frmPacE"];
                    obj.Close();
                }
                else
                {
                    return;
                }
            }
            openFormOnPanel<frmResultsO>();
            btnResult.BackColor = Color.Silver;
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Modificacion") || UserCache.Nivel == "Admin")
            {
                if (btnConsulta.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("La Consulta de Resultados esta abierta, desea cerrarla para abrir la Modificacion de Empresas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmConsultaO obj = (frmConsultaO)Application.OpenForms["frmConsultaO"];
                    obj.Close();
                }
                else
                {
                    return;
                }

            }
            else if (btnResult.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("La Gestion de Resultados esta abierta, desea cerrarla para abrir la Modificacion de Empresas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmResultsO obj = (frmResultsO)Application.OpenForms["frmResultsO"];
                    obj.Close();
                }
                else
                {
                    return;
                }
            }
            else if (btnPruebas.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("La Gestion de Pruebas esta abierta, desea cerrarla para abrir la Modificacion de Empresas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmPruebasO obj = (frmPruebasO)Application.OpenForms["frmPruebasO"];
                    obj.Close();
                }
                else
                {
                    return;
                }
            }
            else if (btnPacient.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("El Registro de Empresas esta abierto, desea cerrarla para abrir la Modificacion de Empresas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmPacE obj = (frmPacE)Application.OpenForms["frmPacE"];
                    obj.Close();
                }
                else
                {
                    return;
                }
            }

            openFormOnPanel<frmEditO>();
            btnEmpresa.BackColor = Color.Silver;
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void btnPruebas_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Gestion de Pruebas Empresa") || UserCache.Nivel == "Admin")
            {
                if (btnConsulta.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("La Consulta de Resultados esta abierta, desea cerrarla para abrir la Gestion de Pruebas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmConsultaO obj = (frmConsultaO)Application.OpenForms["frmConsultaO"];
                    obj.Close();
                }
                else
                {
                    return;
                }

            }
            else if (btnResult.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("La Gestion de Resultados esta abierta, desea cerrarla para abrir la Gestion de Pruebas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmResultsO obj = (frmResultsO)Application.OpenForms["frmResultsO"];
                    obj.Close();
                }
                else
                {
                    return;
                }
            }
            else if (btnEmpresa.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("La Modificacion de Empresas esta abierta, desea cerrarla para abrir la Gestion de Pruebas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmEditO obj = (frmEditO)Application.OpenForms["frmEditO"];
                    obj.Close();
                }
                else
                {
                    return;
                }
            }
            else if (btnPacient.BackColor != Color.Gainsboro)
            {
                Resulta = MessageBox.Show("El Registro de Empresas esta abierto, desea cerrarla para abrir la Gestion de Pruebas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resulta == DialogResult.Yes)
                {
                    frmPacE obj = (frmPacE)Application.OpenForms["frmPacE"];
                    obj.Close();
                }
                else
                {
                    return;
                }
            }

            openFormOnPanel<frmPruebasO>();
            btnPruebas.BackColor = Color.Silver;
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
