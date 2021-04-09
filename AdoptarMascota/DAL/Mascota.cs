using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdoptarMascota.DAL
{
    public class Mascota
    {
        private SqlConnection conn;
        private void connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["MascotaConn"].ToString();
            conn = new SqlConnection(conString);
        }

        public bool AgregarMascota(Models.Mascota mascota)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AgregarMascota", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nombre", mascota.Nombre);
            cmd.Parameters.AddWithValue("@Edad", mascota.Edad);
            cmd.Parameters.AddWithValue("@Descrip", mascota.Descrip);
            cmd.Parameters.AddWithValue("@Email", mascota.CorreoContacto);
            cmd.Parameters.AddWithValue("@Adoptado", 0);

            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Models.Mascota> ListarMascotas()
        {
            connection();
            List<Models.Mascota> mascotas = new List<Models.Mascota>();

            SqlCommand command = new SqlCommand("ListarMascotas", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            conn.Open();
            sda.Fill(dataTable);
            conn.Close();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                mascotas.Add(
                    new Models.Mascota
                    {
                        Nombre = Convert.ToString(dataRow["nombre"]),
                        Edad = Convert.ToString(dataRow["edad"]),
                        Descrip = Convert.ToString(dataRow["descrip"]),
                        CorreoContacto = Convert.ToString(dataRow["email"]),
                        Adoptado = Convert.ToBoolean(dataRow["adoptado"])
                    }
                    );
            }
            return mascotas;
        }
    }
}