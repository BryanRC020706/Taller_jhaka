using System.Data.SqlClient;
using System.Data;
using TallerAPI.Models;
using TallerAPI.Repository.Interface;

namespace TallerAPI.Repository.DAO
{
    public class SolicitudDAO : ISolicitud
    {
        private readonly string? cadena;
        public SolicitudDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .Build().GetConnectionString("cn");
        }

        public Solicitud buscarSolicitud(int id)
        {
            Solicitud aSolicitud = null;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_BUSCARSOLICITUDXID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDE", id);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                aSolicitud = new Solicitud()
                {
                    ide_sol = int.Parse(dr[0].ToString()),
                    ide_veh = int.Parse(dr[1].ToString()),
                    fec_sol = DateTime.Parse(dr[2].ToString()),
                    est_sol = dr[3].ToString(),
                    des_sol = dr[4].ToString()
                };
            }
            cn.Close();
            return aSolicitud;
        }

        public IEnumerable<Solicitud> listadoSolicitud()
        {
            List<Solicitud> aSolicitud = new List<Solicitud>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_LISTASOLICITUD", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aSolicitud.Add(new Solicitud()
                {
                    ide_sol = int.Parse(dr[0].ToString()),
                    ide_veh = int.Parse(dr[1].ToString()),
                    fec_sol = DateTime.Parse(dr[2].ToString()),
                    est_sol = dr[3].ToString(),
                    des_sol = dr[4].ToString()
                });
            }
            cn.Close();
            return aSolicitud;
        }

        public string modificaSolicitud(Solicitud obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGESOLICITUD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ide", obj.ide_sol);
                cmd.Parameters.AddWithValue("@veh", obj.ide_veh);
                cmd.Parameters.AddWithValue("@fec", obj.fec_sol);
                cmd.Parameters.AddWithValue("@est", obj.est_sol);
                cmd.Parameters.AddWithValue("@des", obj.des_sol);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Solicitud ha sido actualizado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar " + ex.Message;
            }
            cn.Close();
            return mensaje;
        }

        public string nuevaSolicitud(Solicitud obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGESOLICITUD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ide", obj.ide_sol);
                cmd.Parameters.AddWithValue("@veh", obj.ide_veh);
                cmd.Parameters.AddWithValue("@fec", obj.fec_sol);
                cmd.Parameters.AddWithValue("@est", obj.est_sol);
                cmd.Parameters.AddWithValue("@des", obj.des_sol);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Solicitud ha sido registrado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al Solicitud " + ex.Message;
            }
            cn.Close();
            return mensaje;
        }
    }
}
