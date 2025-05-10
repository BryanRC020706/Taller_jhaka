using System.Data.SqlClient;
using System.Data;
using TallerAPI.Models;
using TallerAPI.Repository.Interface;

namespace TallerAPI.Repository.DAO
{
    public class CotizacionDAO : ICotizacion
    {
        private readonly string cadena;
        public CotizacionDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .Build().GetConnectionString("cn");
        }


        public CotizacionO buscarCotizacion(int id)
        {
            CotizacionO cotizacion = null;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_BUSCARCOTIZACIONXID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDE", id);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cotizacion = new CotizacionO()
                {
                    ide_cot = int.Parse(dr[0].ToString()),
                    fec_cot = DateTime.Parse(dr[1].ToString()),
                    ide_veh = int.Parse(dr[2].ToString())
                };

            }
            cn.Close();
            return cotizacion;
        }

        public IEnumerable<Cotizacion> listadoCotizaciones()
        {
            List<Cotizacion> aCotizaciones = new List<Cotizacion>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_LISTADOCOTIZACION", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aCotizaciones.Add(new Cotizacion()
                {
                    ide_cot = int.Parse(dr[0].ToString()),
                    fec_cot = DateTime.Parse(dr[1].ToString()),
                    nom_veh = dr[2].ToString(),
                    nom_cli = dr[3].ToString()
                });
            }
            cn.Close();
            return aCotizaciones;
        }

        public string modificaCotizacion(CotizacionO obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGECOTIZACION", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDE", obj.ide_cot);
                cmd.Parameters.AddWithValue("@VEH", obj.ide_veh);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Cotizacion ha sido actualizado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar " + ex.Message;
            }
            cn.Close();
            return mensaje;

        }

        public string nuevaCotizacion(CotizacionO obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGECOTIZACION", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDE", obj.ide_cot);
                cmd.Parameters.AddWithValue("@VEH", obj.ide_veh);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Cotizacion ha sido registrado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar " + ex.Message;
            }
            cn.Close();
            return mensaje;
        }



        public string agregarRepuesto(DetalleRepuesto obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_AGREGARREPUESTO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDE_COT", obj.IDE_COT);
                cmd.Parameters.AddWithValue("@IDE_REP", obj.IDE_REP);
                cmd.Parameters.AddWithValue("@CAN_DET", obj.CAN_DET);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Repuesto agregado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al agregar repuesto: " + ex.Message;
            }
            cn.Close();
            return mensaje;
        }

        public IEnumerable<DetalleRepuestoLista> listadoDetellaRepuesto(int id)
        {
            List<DetalleRepuestoLista> detalleRepuestos = new List<DetalleRepuestoLista>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_LISTARDETALLEREPUESTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDE", id);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                detalleRepuestos.Add(new DetalleRepuestoLista()
                {
                    DET_REP = int.Parse(dr[0].ToString()),
                    IDE_REP = int.Parse(dr[1].ToString()),
                    NOM_REP = dr[2].ToString(),
                    CAN_DET = int.Parse(dr[3].ToString()),
                    PRE_REP = double.Parse(dr[4].ToString()),
                    STO_DET = double.Parse(dr[5].ToString()),
                });
            }
            cn.Close();
            return detalleRepuestos;
        }

        public string agregarServicio(DetalleServicio obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_AGREGARSERVICIO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDE_COT", obj.IDE_COT);
                cmd.Parameters.AddWithValue("@IDE_SER", obj.IDE_SER);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Servicio agregado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al agregar servicio: " + ex.Message;
            }
            cn.Close();
            return mensaje;
        }


        public IEnumerable<DetalleServicioLista> listadoDetalleServicio(int id)
        {
            List<DetalleServicioLista> detalleServicios = new List<DetalleServicioLista>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_LISTARDETALLESERVICIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDE", id);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                detalleServicios.Add(new DetalleServicioLista()

                {
                    DET_SER = int.Parse(dr[0].ToString()),
                    IDE_SER = int.Parse(dr[1].ToString()),
                    NOM_SER = dr[2].ToString(),
                    PRE_SER = double.Parse(dr[3].ToString())
                });
            }
            cn.Close();
            return detalleServicios;
        }


        public string eliminarDetalleRepuesto(int id)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ELIMINARDETALLEREPUESTO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDE", id);
                int n = cmd.ExecuteNonQuery();
                mensaje = "Se elimino correctamente";

            }
            catch (Exception ex)
            {
                mensaje = "Error al eliminar: " + ex.Message;
            }
            return mensaje;
        }
        public string eliminarDetallesServicio(int id)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ELIMINARDETALLESERVICIO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDE", id);
                int n = cmd.ExecuteNonQuery();
                mensaje = "Se elimino correctamente";

            }
            catch (Exception ex)
            {
                mensaje = "Error al eliminar: " + ex.Message;
            }
            return mensaje;
        }
    }
}
