using System.Data.SqlClient;
using System.Data;
using TallerAPI.Models;
using TallerAPI.Repository.Interface;

namespace TallerAPI.Repository.DAO
{
    public class RepuestoDAO : IRepuesto
    {
        private readonly string cadena;
        public RepuestoDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .Build().GetConnectionString("cn");
        }


        public Repuesto buscarRepuesto(int id)
        {
            Repuesto resultado = null;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_BUSCARREPUESTOXID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDE", id);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                resultado = new Repuesto()
                {
                    ide_rep = int.Parse(dr[0].ToString()),
                    nom_rep = dr[1].ToString(),
                    sto_rep = int.Parse(dr[2].ToString()),
                    pre_rep = double.Parse(dr[3].ToString())
                    
                };
            }
            cn.Close();
            return resultado;
        }

        public IEnumerable<Repuesto> listadoRepuestos()
        {
            List<Repuesto> aRepuesto = new List<Repuesto>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_LISTADOREPUESTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aRepuesto.Add(new Repuesto() {
                    ide_rep = int.Parse(dr[0].ToString()),
                    nom_rep = dr[1].ToString(),
                    sto_rep = int.Parse(dr[2].ToString()),
                    pre_rep = double.Parse(dr[3].ToString())
                    
                });             
            }
            cn.Close();
            return aRepuesto;
        }
    

        public string modificaRepuesto(Repuesto obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
               SqlCommand cmd = new SqlCommand("SP_MERGEREPUESTO", cn);
               cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDE", obj.ide_rep);
                cmd.Parameters.AddWithValue("@NOM", obj.nom_rep);
                cmd.Parameters.AddWithValue("@STO", obj.sto_rep);
                cmd.Parameters.AddWithValue("@PRE", obj.pre_rep);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Repuesto ha sido actualizado correctamente";
            }
            catch (Exception ex)
            {
            mensaje = "Error al actualizar " + ex.Message;
            }
            cn.Close();
            return mensaje;
        }

        public string nuevoRepuesto(Repuesto obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGEREPUESTO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDE", obj.ide_rep);
                cmd.Parameters.AddWithValue("@NOM", obj.nom_rep);
                cmd.Parameters.AddWithValue("@STO", obj.sto_rep);
                cmd.Parameters.AddWithValue("@PRE", obj.pre_rep);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Repuesto ha sido registrado correctamente";
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
