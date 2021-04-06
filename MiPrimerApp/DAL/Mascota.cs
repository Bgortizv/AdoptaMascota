using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MiPrimerApp.DAL
{
    public class Mascota
    {
        private SqlConnection con;
        private void connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["MascotaConn"].ToString();
            con = new SqlConnection(conString);
        }

        public bool AgregarMascota(Models.Mascota mascota)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AgregarMascota", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", mascota.nombre);
            cmd.Parameters.AddWithValue("@edad", mascota.Edad);
            cmd.Parameters.AddWithValue("@descrip", mascota.Descrip);
            cmd.Parameters.AddWithValue("@email", mascota.EmailContacto);
            cmd.Parameters.AddWithValue("@adoptado", 0);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public List<Models.Mascota> ObtenerMascotas()
        {
            connection();
            List<Models.Mascota> mascotas = new List<Models.Mascota>();

            SqlCommand cmd = new SqlCommand("SeleccionarMascota", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sda.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows) 
            {
                mascotas.Add(
                     new Models.Mascota
                     { 
                        nombre = Convert.ToString(dr["nombre"]),
                        Edad = Convert.ToString(dr["edad"]),
                        Descrip = Convert.ToString(dr["descrip"]),
                        EmailContacto = Convert.ToString(dr["email"]),
                        Adoptada = Convert.ToBoolean(dr["adoptado"])
                     });
            }

            return mascotas;
        }


    }
}