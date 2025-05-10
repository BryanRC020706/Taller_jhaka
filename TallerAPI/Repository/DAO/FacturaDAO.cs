using System.Data.SqlClient;
using System.Data;
using TallerAPI.Models;
using TallerAPI.Repository.Interface;

namespace TallerAPI.Repository.DAO
{
    public class FacturaDAO : IFactura
    {
        private readonly string cadena;
        public FacturaDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .Build().GetConnectionString("cn");
        }

        public string nuevaFactura(FacturaIngresar obj)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGEFACTURA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDE_COT", obj.ide_cot);
                int n = cmd.ExecuteNonQuery();
                mensaje = n + " Factura ha sido registrado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar " + ex.Message;
            }
            cn.Close();
            return mensaje;
        }
        public Factura buscarFactura(int id) {
            Factura resultado = null;
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_DETALLESFACTURA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDE", id);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                resultado = new Factura()
                {
                    ide_fac = int.Parse(dr[0].ToString()),
                    ide_cot = int.Parse(dr[1].ToString()),
                    fec_fac = DateTime.Parse(dr[2].ToString()),
                    tot_fac = double.Parse(dr[3].ToString())
                };
            }
            cn.Close();
            return resultado;
        }

        public IEnumerable<Factura> listarFactura()
        {
            List<Factura> facturas = new List<Factura>();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SP_LISTADOFACTURA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                facturas.Add(new Factura()
                {
                    ide_fac = int.Parse(dr[0].ToString()),
                    ide_cot = int.Parse(dr[1].ToString()),
                    fec_fac = DateTime.Parse(dr[2].ToString()),
                    tot_fac = double.Parse(dr[3].ToString()),

                });
            }
            cn.Close();
            return facturas;
        }
    }
}
