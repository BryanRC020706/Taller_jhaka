using System.Data.SqlClient;
using System.Data;
using TallerAPI.Models;
using TallerAPI.Repository.Interface;

namespace TallerAPI.Repository.DAO
{
    public class ServicioDAO : IServicio
    {
        private readonly string? cadena;
        public ServicioDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .Build().GetConnectionString("cn");
        }


        public Servicio buscarServicio(int id)
        {
            Servicio resultado = null;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_BUSCARSERVICIOXID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDE", id);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                 resultado   =new Servicio()
                {
                    ide_ser = int.Parse(dr[0].ToString()),
                    nom_ser = dr[1].ToString(),
                    pre_ser = double.Parse(dr[2].ToString()),
                };
            }
            cn.Close();
            return resultado;
        }

        public IEnumerable<Servicio> listadoServicios()
        {
            List<Servicio> aServicio = new List<Servicio>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_LISTADOSERVICIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aServicio.Add(new Servicio()
                {
                    ide_ser = int.Parse(dr[0].ToString()),
                    nom_ser = dr[1].ToString(),
                    pre_ser = double.Parse(dr[2].ToString()),
                });
            }
            cn.Close();
            return aServicio;
        }

        public string modificaServicio(Servicio obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGESERVICIO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ide", obj.ide_ser);
                cmd.Parameters.AddWithValue("@nom", obj.nom_ser);
                cmd.Parameters.AddWithValue("@pre", obj.pre_ser);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Servicio ha sido actualizado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar " + ex.Message;
            }
            cn.Close();
            return mensaje;
        }

        public string nuevoServicio(Servicio obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGESERVICIO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ide", obj.ide_ser);
                cmd.Parameters.AddWithValue("@nom", obj.nom_ser);
                cmd.Parameters.AddWithValue("@pre", obj.pre_ser);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Servicio ha sido registrado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar " + ex.Message;
            }
            cn.Close();
            return mensaje;
        }
    }
}
