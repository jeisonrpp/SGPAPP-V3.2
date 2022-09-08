using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime;
using System.Runtime.InteropServices;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace SGPAPP
{
    //PRUEBA GUARDAR SIN CONEXION!!!!!
    public partial class frmPacE : Telerik.WinControls.UI.RadForm
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;

        public frmPacE()
        {
            InitializeComponent();
            
      
        }
        Logs log = new Logs();
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        String Sexo;
        DateTime Fecha = DateTime.Now;
        SqlDataReader rdr = null;
        String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        String cambiada1;
        String cambiada2;
        SqlCommand cmd = null;
        String PacienteId;
        String Nombre;
        String Ced ="";
        String contraseniaAleatoria;
        String pass;
        String Fechan;     
        String ID;
        String Pac;
        public String Tipop;
        public String Prueba;
        public String Metodo;
        public String Time;
        String CED ="";
        bool Pruebas = false;
        bool Pnew = false;
        int LotID;
        int PrID;
        String Resultado;
        String CT;
        String Resultado2;
        String CT2;
        String PacienteNom;
        String Age;
        String Mail;
        String Dir;
        String Tipo;
        String Fecham;
        bool Citas;
        String HoraMuestra;
        int EmpresaID;
        private void frmPacE_Load(object sender, EventArgs e)
        {
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            txtEmpresa.Select();
            cbbDoc.SelectedIndex = 0;
            Fechadehoy();
            cargacbbSeg();
            GridViewCommandColumn commandColumn4 = new GridViewCommandColumn();
            commandColumn4.Name = "commandColumn4";
            commandColumn4.UseDefaultText = true;
            commandColumn4.Image = (Image)(new Bitmap(Properties.Resources.icons8_delete_35, new Size(25, 25)));
            commandColumn4.ImageAlignment = ContentAlignment.MiddleCenter;
        
            commandColumn4.FieldName = "select";
            commandColumn4.HeaderText = "Eliminar";
            radGridView1.MasterTemplate.Columns.Add(commandColumn4);
            radGridView1.CommandCellClick += new CommandCellClickEventHandler(radGridView1_CommandCellClick);

            //tabControl1.TabPages.Remove(tabPage5);
        }

        private void radGridView1_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = radGridView1.CurrentCell.RowIndex;

                Nombre = this.radGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                Ced = this.radGridView1.Rows[rowIndex].Cells[1].Value.ToString();

                if (this.radGridView1.Rows.Count > 0)
                {
                    radGridView1.Rows.RemoveAt(this.radGridView1.SelectedRows[0].Index);
                }

                if (dgbAdd.RowCount >= 1)
                {
                    for (int i = 0; i < dgbAdd.RowCount; i++)
                    {
                        if (Convert.ToString(dgbAdd.Rows[i].Cells["Column5"].Value) == Nombre && Convert.ToString(dgbAdd.Rows[i].Cells["Column6"].Value) == Ced)
                        {
                            dgbAdd.Rows.Remove(dgbAdd.Rows[i]);
                        }

                    }
                }
                if (dgbUpd.RowCount >= 1)
                {
                    for (int i = 0; i < dgbUpd.RowCount; i++)
                    {
                        if (Convert.ToString(dgbUpd.Rows[i].Cells["Columnp"].Value) == Nombre && Convert.ToString(dgbUpd.Rows[i].Cells["Columnc"].Value) == Ced)
                        {
                            dgbUpd.Rows.Remove(dgbUpd.Rows[i]);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione el registro que desea eliminar de la lista.");
            }
        }

        private void txtEmpresa_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtDir.Focus();
            }
        }

        private void txtDir_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtEmail.Focus();
            }
        }

        private void txtEmail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtCel.Focus();
            }
        }

        private void txtCel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtNom.Focus();
            }
        }

        private void txtNom_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                cbbDoc.Focus();
            }
        }

        private void cbbDoc_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtCed.Focus();
            }
        }

        private void txtCed_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtFecha.Focus();
            }
        }

        private void txtFecha_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                cbbSeguro.Focus();
            }
        }

        private void cbbSeguro_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                rbF.Focus();
            }
        }

        private void rbF_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                rbM.Focus();
            }
        }

        private void rbM_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                btnAd.Focus();
            }
        }

        private void btnAdd_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                btnSave.Focus();
            }
        }

        private void btnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtEmpresa.Focus();
            }
        }
        public void GeneraCed()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                { 
                if (CED == "")
                {

                        CED = PacienteId;
                        CED = Convert.ToString(int.Parse(CED) + 1);
                        Random rced = new Random();
                        string nums = "000000000000000000000000000000";
                        int Longitud = nums.Length;
                        int longi = CED.Length;
                        char caracter;
                        int longitudCed = 11 - longi;
                        Ced = string.Empty;
                        for (int i = 0; i < longitudCed; i++)
                        {
                            caracter = nums[rced.Next(Longitud)];
                            Ced += caracter.ToString();

                        }
                        Ced = Ced + CED;
                        string result = string.Format("{0:000-0000000-0}", int.Parse(Ced));
                        Ced = result;
                   
                }
                else
                {
                    CED = Convert.ToString(int.Parse(CED) + 1);
                    Random rced = new Random();
                    string nums = "000000000000000000000000000000";
                    int Longitud = nums.Length;
                    int longi = CED.Length;
                    char caracter;
                    int longitudCed = 11 - longi;
                    Ced = string.Empty;
                    for (int i = 0; i < longitudCed; i++)
                    {
                        caracter = nums[rced.Next(Longitud)];
                        Ced += caracter.ToString();

                    }
                    Ced = Ced + CED;
                    string result = string.Format("{0:000-0000000-0}", int.Parse(Ced));
                    Ced = result;
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
           
    }
        public void AddPac()
        {
            bool existe = false;

            if (radGridView1.RowCount >= 1)
            {
                for (int i = 0; i < radGridView1.RowCount; i++)
                {
                    if (Convert.ToString(radGridView1.Rows[i].Cells["Column1"].Value) == txtCed.Text && txtCed.Text != "No Aplica")

                    {
                        MessageBox.Show("Este Paciente ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        existe = true;
                        break;

                    }
                    else
                    {
                        existe = false;
                    }
                }
            }
            if (existe == false)
            {
                if (Pnew == true)
                {                   
                    radGridView1.Rows.Add(txtNom.Text, txtCed.Text, txtFecha.Text, cbbSeguro.Text, Sexo, txtEmail2.Text);
                    dgbUpd.Rows.Add(txtNom.Text, txtCed.Text, txtFecha.Text, cbbSeguro.Text, Sexo);
                    Pnew = false;
                }
                else
                {
                    dgbAdd.Rows.Add(txtNom.Text, txtCed.Text, txtFecha.Text, cbbSeguro.Text, Sexo, txtEmail2.Text);
                    radGridView1.Rows.Add(txtNom.Text, txtCed.Text, txtFecha.Text, cbbSeguro.Text, Sexo, txtEmail2.Text);

                }
            }
        }

       
        public void InsertaEmpresa()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertaEmpresas";
                cmd.Parameters.Add(new SqlParameter("@pEmpresa", SqlDbType.VarChar)).Value = txtEmpresa.Text;
                cmd.Parameters.Add(new SqlParameter("@pDir", SqlDbType.VarChar)).Value = txtDir.Text;
                cmd.Parameters.Add(new SqlParameter("@pEmail", SqlDbType.VarChar)).Value = txtEmail.Text;
                cmd.Parameters.Add(new SqlParameter("@pCel", SqlDbType.VarChar)).Value = txtCel.Text;
                cmd.Parameters.Add(new SqlParameter("@empruebaid", SqlDbType.VarChar)).Value = DBNull.Value;
                cmd.Parameters.Add(new SqlParameter("@Pruebas", SqlDbType.Bit)).Value = false;
                cmd.Parameters.Add(new SqlParameter("@Resultados", SqlDbType.Bit)).Value = false;
                cmd.Parameters.Add(new SqlParameter("@pFechareg", SqlDbType.VarChar)).Value = cambiada2;

                try
                {
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
                    con.Close();
                    return;
                }              
   
                    log.Accion = "Empresa: " + txtEmpresa.Text + " Creada";
                    log.Form = "Creacion de Empresas";
                    log.SaveLog();
               
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void cargacbbSeg()
        {
            using (var con = new SqlConnection(conect))
            {

                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("spGetSeguros", con);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();
                sqlData.Fill(table);
                cbbSeguro.DataSource = table;
                cbbSeguro.ValueMember = "Seguros";
                cbbSeguro.Text = "Seleccione el Seguro";
                con.Close();
             
   
            }
        }
        public void conviertefecha()
        {
            try
            {
                DateTime fecha1;
                if (Fechan == "No Aplica")
                {
                    cambiada1 = "1900-01-01";
                }
               else if (Fechan == null)
                {
                    fecha1 = Fecha;


                    String day = fecha1.Day.ToString();
                    String mes = fecha1.Month.ToString();
                    String year = fecha1.Year.ToString();

                    if (int.Parse(day) <= 9)
                    {
                        day = "0" + day;
                    }
                    if (int.Parse(mes) <= 9)
                    {
                        mes = "0" + mes;
                    }

                    cambiada1 = year + "-" + mes + "-" + day;
                }    
                else
                {
                    fecha1 = DateTime.ParseExact(Fechan, "dd-MM-yyyy", null);


                    String day = fecha1.Day.ToString();
                    String mes = fecha1.Month.ToString();
                    String year = fecha1.Year.ToString();

                    if (int.Parse(day) <= 9)
                    {
                        day = "0" + day;
                    }
                    if (int.Parse(mes) <= 9)
                    {
                        mes = "0" + mes;
                    }

                    cambiada1 = year + "-" + mes + "-" + day;
                    contraseniaAleatoria = day + mes + year;
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }
        public void Fechadehoy()
        {
            try
            {
                DateTime fecha2;


                fecha2 = Fecha;

                String day = fecha2.Day.ToString();
                String mes = fecha2.Month.ToString();
                String year = fecha2.Year.ToString();

                cambiada2 = year + "-" + mes + "-" + day;

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }
      

     
    
    
      


        private void rbF_CheckedChanged(object sender, EventArgs e)
        {
            if (rbF.Checked == true)
            {
                rbM.Checked = false;
                Sexo = "Femenino";
            }
        }

        private void rbM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbM.Checked == true)
            {
                rbF.Checked = false;
                Sexo = "Masculino";
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }

        private void chkCed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCed.Checked == true)
            {
                txtCed.Mask = "";
                txtCed.Text = "No Aplica";
                txtCed.Enabled = false;
            }
            else
            {
                txtCed.Text = "";
                txtCed.Enabled = true;
            }
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFecha.Checked == true)
            {
                txtFecha.Mask = "";
                txtFecha.Text = "No Aplica";
                txtFecha.Enabled = false;
            }
            else
            {
                txtFecha.Mask = "00-00-0000";
                txtFecha.Text = "";
                txtFecha.Enabled = true;
            }
        }

        private void cbbDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDoc.Text == "Cedula")
            {
                txtCed.Mask = "000-0000000-0";
            }
            else
            {
                txtCed.Mask = "";
            }
        }

        private void cbbDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
          
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
          
        }
        private void btnSav_Click(object sender, EventArgs e)
        {

          
        }

        private void txtConsulta_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtConsulta_Enter(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

           
        }
        public void GetDataR()
        {


          

        }

     

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }
        public void AddResults()
        {
           
        }
      

        private void btndel_Click(object sender, EventArgs e)
        {
          
        }
      
        private void button6_Click(object sender, EventArgs e)
        {

          
        }
      
       
     
    
     
     
      

      

        private void txtConsultaR_Leave(object sender, EventArgs e)
        {
          
        }

        private void txtConsultaR_Enter(object sender, EventArgs e)
        {
          
        }

        private void dataGridView8_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void advancedDataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }
     

        

        private void advancedDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
 
        }

        private void advancedDataGridView1_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
 
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void advancedDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

     
        

        private void advancedDataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
      
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
          
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


           
            }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = radGridView1.CurrentCell.RowIndex;

                Nombre = this.radGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                Ced = this.radGridView1.Rows[rowIndex].Cells[1].Value.ToString();

                if (this.radGridView1.Rows.Count > 0)
                {
                    radGridView1.Rows.RemoveAt(this.radGridView1.SelectedRows[0].Index);
                }

                if (dgbAdd.RowCount >= 1)
                {
                    for (int i = 0; i < dgbAdd.RowCount; i++)
                    {
                        if (Convert.ToString(dgbAdd.Rows[i].Cells["Column5"].Value) == Nombre && Convert.ToString(dgbAdd.Rows[i].Cells["Column6"].Value) == Ced)
                        {
                            dgbAdd.Rows.Remove(dgbAdd.Rows[i]);
                        }

                    }
                }
                if (dgbUpd.RowCount >= 1)
                {
                    for (int i = 0; i < dgbUpd.RowCount; i++)
                    {
                        if (Convert.ToString(dgbUpd.Rows[i].Cells["Columnp"].Value) == Nombre && Convert.ToString(dgbUpd.Rows[i].Cells["Columnc"].Value) == Ced)
                        {
                            dgbUpd.Rows.Remove(dgbUpd.Rows[i]);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione el registro que desea eliminar de la lista.");
            }
        }

        private void txtEmpresa_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

         
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

           
        }

        void btnImagenradGridView2click_Click(object sender, EventArgs e)
        {
            
        }

        private void radGridView2_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.IsSelected)
            {
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = System.Drawing.Color.LightBlue;
                e.RowElement.DrawFill = true;
            }
            else
            {
                e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
            }
        }

        private void radGridView2_CellClick(object sender, GridViewCellEventArgs e)
        {
            object cellValue = e.Row.Cells[0].Value;
        }

        private void radGridView2_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.Name == "Column1")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.BackColor = System.Drawing.Color.WhiteSmoke;

                GridImageCellElement imgCell = e.CellElement as GridImageCellElement;

                if (imgCell != null)
                {
                    imgCell.Image = Properties.Resources.icons8_checkmark_16;


                    try
                    {
                        imgCell.Click -= btnImagenradGridView2click_Click;
                    }
                    catch
                    {

                    }

                    imgCell.Click += btnImagenradGridView2click_Click;
                }
            }
        }

        private void radGridView5_Click(object sender, EventArgs e)
        {

        }      
        void btnImagenradGridView5click_Click(object sender, EventArgs e)
        {
           
        }

        private void radGridView5_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.IsSelected)
            {
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = System.Drawing.Color.LightBlue;
                e.RowElement.DrawFill = true;
            }
            else
            {
                e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
            }
        }

        private void radGridView5_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.Name == "Column1")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.BackColor = System.Drawing.Color.WhiteSmoke;

                GridImageCellElement imgCell = e.CellElement as GridImageCellElement;

                if (imgCell != null)
                {
                    imgCell.Image = Properties.Resources.icons8_checkmark_16;


                    try
                    {
                        imgCell.Click -= btnImagenradGridView5click_Click;
                    }
                    catch
                    {

                    }

                    imgCell.Click += btnImagenradGridView5click_Click;
                }
            }
        }
        void btnImagenclickradGridView6_Click(object sender, EventArgs e)
        {
            
        }

        private void radGridView6_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.Name == "Column1")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.BackColor = System.Drawing.Color.WhiteSmoke;

                GridImageCellElement imgCell = e.CellElement as GridImageCellElement;

                if (imgCell != null)
                {
                    imgCell.Image = Properties.Resources.icons8_checkmark_16;


                    try
                    {
                        imgCell.Click -= btnImagenclickradGridView6_Click;
                    }
                    catch
                    {

                    }

                    imgCell.Click += btnImagenclickradGridView6_Click;
                }
            }
        }

        private void radGridView6_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.IsSelected)
            {
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = System.Drawing.Color.LightBlue;
                e.RowElement.DrawFill = true;
            }
            else
            {
                e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
            }
        }
  
        void radGridView5_CommandCellClick(object sender, EventArgs e)
        {
          
        }
        void radGridView2_CommandCellClick(object sender, EventArgs e)
        {
         
        }
        void radGridView6_CommandCellClick(object sender, EventArgs e)
        {
           
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {
                if (radGridView1.RowCount >= 1)
                {
                   
                    DialogResult resulta = MessageBox.Show("Esta de seguro que desea guardar la empresa: " + txtEmpresa.Text + "?", "Guardar Empresa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resulta == DialogResult.Yes)
                    {
                        LotID = 0;
                        conviertefecha();
                        InsertaEmpresa();
                        InsertLot();

                        using (var con = new SqlConnection(conect))
                        {                           
                                foreach (DataGridViewRow row in dgbAdd.Rows)

                                {
                                    Nombre = (string)row.Cells["Column5"].Value;
                                    Ced = (string)row.Cells["Column6"].Value;
                                    Fechan = (string)row.Cells["Column7"].Value;
                                    contraseniaAleatoria = "";
                                    conviertefecha();

                                    con.Open();
                                    cmd = new SqlCommand("", con);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "spInsertPacientes";
                                    cmd.Parameters.Add(new SqlParameter("@pNom", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["Column5"].Value);
                                    cmd.Parameters.Add(new SqlParameter("@pCed", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["Column6"].Value);
                                    cmd.Parameters.Add(new SqlParameter("@pSex", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["Column9"].Value);
                                    cmd.Parameters.Add(new SqlParameter("@pFecha", SqlDbType.VarChar)).Value = cambiada1;
                                    cmd.Parameters.Add(new SqlParameter("@pDir", SqlDbType.VarChar)).Value = txtDir.Text;
                                    cmd.Parameters.Add(new SqlParameter("@pCel", SqlDbType.VarChar)).Value = txtCel.Text;
                                    if (Convert.ToString(row.Cells["Email"].Value).Length > 0)
                                    {
                                        cmd.Parameters.Add(new SqlParameter("@pEmail", SqlDbType.VarChar)).Value = txtEmail.Text;
                                    }
                                    else
                                    {
                                        cmd.Parameters.Add(new SqlParameter("@pEmail", SqlDbType.VarChar)).Value = DBNull.Value;
                                    }
                              
                                    cmd.Parameters.Add(new SqlParameter("@pemail2", SqlDbType.VarChar)).Value = DBNull.Value;
                                    cmd.Parameters.Add(new SqlParameter("@pSeguro", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["Column8"].Value);
                                    cmd.Parameters.Add(new SqlParameter("@pFechareg", SqlDbType.Date)).Value = cambiada2;
                                    cmd.Parameters.Add(new SqlParameter("@pReferidor", SqlDbType.VarChar)).Value = DBNull.Value;
                                    cmd.Parameters.Add(new SqlParameter("@pEmpresa", SqlDbType.VarChar)).Value = txtEmpresa.Text;
                                    cmd.Parameters.Add(new SqlParameter("@plotid", SqlDbType.VarChar)).Value = LotID;

                                    cmd.Parameters.Add(new SqlParameter("@pid", SqlDbType.Int)).Direction = ParameterDirection.Output;
                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                    con.Close();
                                    PacienteId = cmd.Parameters["@pid"].Value.ToString();
                                        GeneraCred();
                                    Logs log = new Logs();
                                    log.Accion = "Paciente: " + Nombre + " Registrado en Empresa: " + txtEmpresa.Text + "";
                                    log.Form = "Registro de Pacientes: Empresas";
                                    log.SaveLog();
                                }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error:" + ex.ToString());                                       
                                        return;
                                    }
                                    

                                    
                                }
                           
                        }
                        if (dgbUpd.RowCount >= 1)
                        {
                            using (var con = new SqlConnection(conect))
                            {
                             
                                    foreach (DataGridViewRow row in dgbUpd.Rows)
                                    {
                                    SqlCommand cmd = null;
                                    con.Open();
                                  
                                        Nombre = (string)row.Cells["Columnp"].Value;
                                        Ced = (string)row.Cells["Columnc"].Value;

                                        cmd = new SqlCommand("", con);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.CommandText = "spAgregaPacientesaEmpresas";
                                        cmd.Parameters.Add(new SqlParameter("@pNom", SqlDbType.VarChar)).Value = Nombre;
                                        cmd.Parameters.Add(new SqlParameter("@pCed", SqlDbType.VarChar)).Value = Ced;
                                        cmd.Parameters.Add(new SqlParameter("@pSex", SqlDbType.VarChar)).Value = txtEmpresa.Text;

                                        try
                                        {
                                            cmd.ExecuteNonQuery();


                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error:" + ex.ToString());

                                            return;
                                        }
                                        finally
                                        {
                                            
                                            log.Accion = "Paciente: " + Nombre + " Agregado a Empresa: " + txtEmpresa.Text + "";
                                            log.Form = "Guardado de Empresas";
                                            log.SaveLog();

                                            con.Close();

                                        }
                                    }
                              
                            }
                        }

                        log.Accion = "Lote: "+LotID+" Generado";
                        log.Form = "Guardado de Empresas";
                        log.SaveLog();

                        MessageBox.Show("Pacientes Guardados Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        radGridView1.Rows.Clear();
                        dgbUpd.Rows.Clear();
                        dgbDelete.Rows.Clear();
                        dgbAdd.Rows.Clear();
                        txtNom.Text = "";
                        txtCed.Text = "";
                        txtFecha.Text = "";
                        txtEmail2.Text = "";
                        rbF.Checked = false;
                        rbM.Checked = false;
                        chkCed.Checked = false;
                        chkFecha.Checked = false;
                        btnSave.Enabled = false;
                        txtEmpresa.Enabled = true;
                        txtDir.Enabled = true;
                        txtCel.Enabled = true;
                        txtEmail.Enabled = true;
                        txtEmpresa.Text = "";
                        txtDir.Text = "";
                        txtCel.Text = "";
                        txtEmail.Text = "";
                        if (cbbDoc.Text == "Cedula")
                        {
                            txtCed.Mask = "000-0000000-0";
                        }
                        else
                        {
                            txtCed.Mask = "";
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void InsertLot()
        {
            using (var con = new SqlConnection(conect))
            {               
                    con.Open();
                    cmd = new SqlCommand("", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spInsertaLotes";
                    cmd.Parameters.Add(new SqlParameter("@lotEmpresa", SqlDbType.VarChar)).Value = txtEmpresa.Text;
                    cmd.Parameters.Add(new SqlParameter("@lotPruebas", SqlDbType.Bit)).Value = false;
                    cmd.Parameters.Add(new SqlParameter("@lotResultados", SqlDbType.Bit)).Value = false;
                    cmd.Parameters.Add(new SqlParameter("@lotFechaReg", SqlDbType.Date)).Value = cambiada2;
                    cmd.Parameters.Add(new SqlParameter("@lotUsuario", SqlDbType.VarChar)).Value = UserCache.Usuario;
                    cmd.Parameters.Add(new SqlParameter("@lotpruebaid", SqlDbType.Int)).Value = DBNull.Value;


                    cmd.Parameters.Add(new SqlParameter("@lotid", SqlDbType.Int)).Direction = ParameterDirection.Output;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        LotID = (int)cmd.Parameters["@lotid"].Value;
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.ToString());
                        con.Close();
                        return;
                    }  
            }
        }
        public void GeneraCred()
        {
            if (Ced == "No Aplica")
            {
                GeneraCed();
            }           

            if (contraseniaAleatoria == "")
            {
                Random rdn = new Random();
                string caracteres = "1234567890";
                int longitud = caracteres.Length;
                char letra;
                int longitudContrasenia = 8;
                contraseniaAleatoria = string.Empty;
                for (int i = 0; i < longitudContrasenia; i++)
                {
                    letra = caracteres[rdn.Next(longitud)];
                    contraseniaAleatoria += letra.ToString();
                }
            }


            pass = clsEncrypt.GetSHA256(contraseniaAleatoria);


            using (var con = new SqlConnection(conect))
            {
                con.Open();
                cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGeneraCredenciales";
                cmd.Parameters.Add(new SqlParameter("@pid", SqlDbType.VarChar)).Value = PacienteId;
                cmd.Parameters.Add(new SqlParameter("@Ced", SqlDbType.VarChar)).Value = Ced;
                cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar)).Value = pass;

                cmd.ExecuteNonQuery();

                con.Close();

            }

        }

        private void radScrollablePanel1_Click(object sender, EventArgs e)
        {

        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            frmSeguros seg = new frmSeguros();
            seg.ShowDialog();
            if (seg.DialogResult == DialogResult.OK)
            {
                cargacbbSeg();
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {
                frmConsultad cd = new frmConsultad();
                cd.ShowDialog();
                if (cd.DialogResult == DialogResult.Yes)
                {
                    if (cd.Empresap.Length > 0 && cd.Empresap != "null")
                    {
                        DialogResult resulta = MessageBox.Show("Este paciente ya esta asociado a la empresa " + cd.Empresap + ", esta seguro que desea agregarlo?", "Cargar Paciente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resulta == DialogResult.Yes)
                        {
                            txtNom.Text = cd.PacienteNom;
                            txtCed.Mask = "";
                            txtCed.Text = cd.Cedula;
                            cbbSeguro.Text = cd.Seguro;
                            txtFecha.Mask = "";
                            txtFecha.Text = cd.Fechan;
                            txtEmail2.Text = cd.Email;
                            if (cd.Sexo == "Masculino")
                            {
                                rbM.Checked = true;
                            }
                            else
                            {
                                rbF.Checked = true;
                            }
                            Pnew = true;
                        }


                    }
                    else
                    {
                        txtNom.Text = cd.PacienteNom;
                        txtCed.Mask = "";
                        txtCed.Text = cd.Cedula;
                        cbbSeguro.Text = cd.Seguro;
                        txtFecha.Mask = "";
                        txtFecha.Text = cd.Fechan;
                        txtEmail2.Text = cd.Email;

                        if (cd.Sexo == "Masculino")
                        {
                            rbM.Checked = true;
                        }
                        else
                        {
                            rbF.Checked = true;
                        }
                        Pnew = true;
                    }
                    txtNom.Enabled = false;
                    txtCed.Enabled = false;
                    cbbSeguro.Enabled = false;
                    txtFecha.Enabled = false;
                    txtEmail2.Enabled = false;
                    rbM.Enabled = false;
                    rbF.Enabled = false;
                    cbbDoc.Enabled = false;
                    chkCed.Enabled = false;
                    chkFecha.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAd_Click(object sender, EventArgs e)
        {
            if (txtEmpresa.Text == "" || txtDir.Text == "" || txtEmail.Text == "" || txtCel.Text == "" || txtFecha.MaskCompleted == false)
            {
                MessageBox.Show("Debe completar los campos faltantes de la empresa o el paciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (rbF.Checked == false && rbM.Checked == false)
            {
                MessageBox.Show("Debe seleccionar el sexo del paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (radGridView1.Rows.Count < 70)
                {
                    String email = txtEmail.Text;
                    if (Regex.IsMatch(email, expresion))
                    {
                        if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                        {
                            using (var con = new SqlConnection(conect))
                            {
                                String MSG1 = null;
                                String MSG2 = null;

                                con.Open();
                                cmd = new SqlCommand("", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "spvalidapacempresas";
                                cmd.Parameters.Add(new SqlParameter("@Empresa", SqlDbType.VarChar)).Value = txtEmpresa.Text;
                                cmd.Parameters.Add(new SqlParameter("@pCed", SqlDbType.VarChar)).Value = txtCed.Text;
                                cmd.Parameters.Add(new SqlParameter("@Msg1", SqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(new SqlParameter("@Msg2", SqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MSG1 = cmd.Parameters["@Msg1"].Value.ToString();
                                    MSG2 = cmd.Parameters["@Msg2"].Value.ToString();

                                    if (MSG1 == "Esta empresa ya se encuentra registrada") {
                                        MessageBox.Show(MSG1, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;

                                    }
                                    if (MSG2 == "Este Paciente ya se encuentra esta registrado") {

                                        MessageBox.Show(MSG2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    con.Close();


                                    if (MSG1.Length < 1 && MSG2.Length < 1)
                                    {
                                    if (txtNom.Text.Length > 0)
                                    {
                                        String email2 = txtEmail.Text;
                                        string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                                        if (Regex.IsMatch(email2, expresion))
                                        {
                                            if (Regex.Replace(email2, expresion, String.Empty).Length == 0)
                                            {
                                                AddPac();
                                                txtNom.Text = "";
                                                txtCed.Text = "";
                                                txtFecha.Text = "";
                                                rbF.Checked = false;
                                                rbM.Checked = false;
                                                btnSave.Enabled = true;
                                                txtEmpresa.Enabled = false;
                                                txtDir.Enabled = false;
                                                txtCel.Enabled = false;
                                                txtEmail.Enabled = false;
                                                chkCed.Checked = false;
                                                chkFecha.Checked = false;
                                                cbbDoc.SelectedIndex = 0;
                                                txtCed.Mask = "000-0000000-0";
                                                txtFecha.Mask = "00-00-0000";
                                                txtFecha.Text = "";
                                                txtEmail2.Text = "";
                                                txtNom.Enabled = true;
                                                txtCed.Enabled = true;
                                                cbbSeguro.Enabled = true;
                                                txtFecha.Enabled = true;
                                                txtEmail2.Enabled = true;
                                                rbM.Enabled = true;
                                                rbF.Enabled = true;
                                                cbbDoc.Enabled = true;
                                                chkCed.Enabled = true;
                                                chkFecha.Enabled = true;
                                                con.Close();
                                            }
                                        }
                                    }
                                }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error:" + ex.ToString());
                                }
                                finally
                                {
                                    con.Close();
                                }
                            


                        }
                    }

                    else
                        {
                            MessageBox.Show("El email ingresado no es valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El email ingresado no es valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    MessageBox.Show("Ha alcanzado el limite de pacientes por empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
