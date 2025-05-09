using TALLER_JHAKA_API.Models;
using TALLER_JHAKA_API.Repository.Interface;
using System.Data.SqlClient;
using System.Data;

namespace TALLER_JHAKA_API.Repository.DAO
{
    public class ClienteDAO : ICliente
    {
        private readonly string ? cadena;
        public ClienteDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .Build().GetConnectionString("cn");
        }

        public ClienteO buscarCliente(int id)
        {
            ClienteO aClientes = null;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_BUSCARCLIENTEXID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDE", id);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                aClientes = new ClienteO()
                {
                    ide_cli = int.Parse(dr[0].ToString()),
                    nom_cli = dr[1].ToString(),
                    ape_cli = dr[2].ToString(),
                    dni_cli = int.Parse(dr[3].ToString()),
                    tel_cli = int.Parse(dr[4].ToString()),
                    dir_cli = dr[5].ToString()
                };
            }
            cn.Close();
            return aClientes;
        }

        public IEnumerable<Cliente> listadoClientes()
        {
            List<Cliente> aClientes = new List<Cliente>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_LISTACLIENTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aClientes.Add(new Cliente()
                {
                    ide_cli = int.Parse(dr[0].ToString()),
                    nom_cli = dr[1].ToString(),
                    dni_cli = int.Parse(dr[2].ToString()),
                    tel_cli = int.Parse(dr[3].ToString()),
                    dir_cli = dr[4].ToString()
                });
            }
            cn.Close();
            return aClientes;
        }

        public string modificaCliente(ClienteO obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGECLIENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ide", obj.ide_cli);
                cmd.Parameters.AddWithValue("@nom", obj.nom_cli);
                cmd.Parameters.AddWithValue("@ape", obj.ape_cli);
                cmd.Parameters.AddWithValue("@dni", obj.dni_cli);
                cmd.Parameters.AddWithValue("@tel", obj.tel_cli);
                cmd.Parameters.AddWithValue("@dir", obj.dir_cli);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Cliente ha sido actualizado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar " + ex.Message;
            }
            cn.Close();
            return mensaje;
        }

        public string nuevoCliente(ClienteO obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGECLIENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ide", obj.ide_cli);
                cmd.Parameters.AddWithValue("@nom", obj.nom_cli);
                cmd.Parameters.AddWithValue("@ape", obj.ape_cli);
                cmd.Parameters.AddWithValue("@dni", obj.dni_cli);
                cmd.Parameters.AddWithValue("@tel", obj.tel_cli);
                cmd.Parameters.AddWithValue("@dir", obj.dir_cli);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Cliente ha sido registrado correctamente";
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
