﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGPAPP
{
    public partial class frmReferidos : Form
    {
        public frmReferidos()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        String MSG;
        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNom.Text == "")
                {
                    MessageBox.Show("Debe completar los campos faltantes");
                }
                else
                {
                    using (var con = new SqlConnection(conect))
                    {
                        con.Open();
                        cmd = new SqlCommand("", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spInsertaReferidos";
                        cmd.Parameters.Add(new SqlParameter("@ref", SqlDbType.VarChar)).Value = txtNom.Text;
                        cmd.Parameters.Add(new SqlParameter("@desc", SqlDbType.VarChar)).Value = txtDesc.Text;
                        cmd.Parameters.Add(new SqlParameter("@Msg", SqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MSG = cmd.Parameters["@Msg"].Value.ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error:" + ex.ToString());
                        }
                        finally
                        {
                            con.Close();
                        }
                        if (MSG == "Este referido ya esta registrado")
                        {
                            MessageBox.Show(MSG, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (MSG == "Referido Guardado Correctamente")
                        {                      
                            MessageBox.Show("Referido Guardado Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            Logs log = new Logs();
                            log.Accion = "Referidor: " + txtNom.Text + " Guardado";
                            log.Form = "Registro de Referidor";
                            log.SaveLog();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
        }
    }
}
