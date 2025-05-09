using System.Data;
using System.Data.SqlClient;
using TALLER_JHAKA_API.Models;
using TALLER_JHAKA_API.Repository.Interface;

namespace TALLER_JHAKA_API.Repository.DAO
{
    public class VehiculoDAO : iVehiculo
    {
        private readonly string? cadena;
        public VehiculoDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .Build().GetConnectionString("cn");
        }

        public VehiculoO buscarVehiculo(int id)
        {
            VehiculoO aVehiculo = null;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_BUSCARVEHICULOXID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDE", id);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                aVehiculo = new VehiculoO()
                {
                    ide_veh = int.Parse(dr[0].ToString()),
                    ide_cli = int.Parse(dr[1].ToString()),
                    mar_veh = dr[2].ToString(),
                    mod_veh = dr[3].ToString(),
                    pla_veh = dr[4].ToString()
                };
            }
            cn.Close();
            return aVehiculo;
        }

        public IEnumerable<Vehiculo> listadoVehiculos()
        {
            List<Vehiculo> aVehiculos = new List<Vehiculo>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_LISTAVEHICULO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aVehiculos.Add(new Vehiculo()
                {
                    ide_veh = int.Parse(dr[0].ToString()),
                    nom_cli = dr[1].ToString(),
                    mar_veh = dr[2].ToString(),
                    mod_veh = dr[3].ToString(),
                    pla_veh = dr[4].ToString()
                });
            }
            cn.Close();
            return aVehiculos;
        }

        public string modificaVehiculo(VehiculoO obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGEVEHICULO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ide", obj.ide_veh);
                cmd.Parameters.AddWithValue("@cli", obj.ide_cli);
                cmd.Parameters.AddWithValue("@mar", obj.mar_veh);
                cmd.Parameters.AddWithValue("@mod", obj.mod_veh);
                cmd.Parameters.AddWithValue("@pla", obj.pla_veh);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Vehiculo ha sido actualizado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar " + ex.Message;
            }
            cn.Close();
            return mensaje;
        }


        public string nuevoVehiculo(VehiculoO obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGEVEHICULO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ide", obj.ide_veh);
                cmd.Parameters.AddWithValue("@cli", obj.ide_cli);
                cmd.Parameters.AddWithValue("@mar", obj.mar_veh);
                cmd.Parameters.AddWithValue("@mod", obj.mod_veh);
                cmd.Parameters.AddWithValue("@pla", obj.pla_veh);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Vehiculo ha sido registrado correctamente";
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
