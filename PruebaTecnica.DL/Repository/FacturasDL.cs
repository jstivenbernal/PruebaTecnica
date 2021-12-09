using Oracle.ManagedDataAccess.Client;
using PruebaTecnica.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.DL.Repository
{
    public class FacturasDL : IFacturasDL
    {
        private string conexionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl.json.com)));User Id=JEISSONBERNAL;Password=Abc123;";

        public async Task<IList<FacturasResponse>> GetListFacturasAsync()
        {
            var result = await GetListDataFacturasAsync();
            return result;
        }

        public async Task<FacturasResponse> GetFacturaByIdAsync(int Id)
        {
            var result = await GetDataFacturaByIdAsync(Id);
            return result;
        }

        public async Task<bool> InsertFacturaAsync(FacturasRequest factura)
        {
            bool result = await GetDataInsertFacturaAsync(factura);
            return result;
        }

        public async Task<IList<FacturasResponse>> GetListDataFacturasAsync()
        {
            string connectionString = conexionString;
            OracleConnection oracleConnection = null;
            IList<FacturasResponse> facturas = new List<FacturasResponse>();
            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "SELECT * FROM Facturas";

                        DbDataReader reader = await cmd.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            FacturasResponse _facturas = new FacturasResponse();
                            _facturas.IdFactura = await reader.IsDBNullAsync(0) ? 0 : reader.GetInt32(0);
                            _facturas.NumeroFactura = await reader.IsDBNullAsync(1) ? null : reader.GetString(1);
                            _facturas.Fecha = await reader.IsDBNullAsync(2) ? new DateTime() : reader.GetDateTime(2);
                            _facturas.TipoDePago = await reader.IsDBNullAsync(3) ? null : reader.GetString(3);
                            _facturas.DocumentoCliente = await reader.IsDBNullAsync(4) ? null : reader.GetString(4);
                            _facturas.NombreCliente = await reader.IsDBNullAsync(5) ? null : reader.GetString(5);
                            _facturas.SubTotal = await reader.IsDBNullAsync(6) ? 0 : reader.GetFloat(6);
                            _facturas.Descuento = await reader.IsDBNullAsync(7) ? 0 : reader.GetFloat(7);
                            _facturas.Iva = await reader.IsDBNullAsync(8) ? 0 : reader.GetFloat(8);
                            _facturas.TotalDescuento = await reader.IsDBNullAsync(9) ? 0 : reader.GetFloat(9);
                            _facturas.TotalImpuesto = await reader.IsDBNullAsync(10) ? 0 : reader.GetFloat(10);
                            _facturas.Total = await reader.IsDBNullAsync(11) ? 0 : reader.GetFloat(11);
                            facturas.Add(_facturas);
                        }
                        await reader.DisposeAsync();
                        return facturas;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (oracleConnection != null)
                {
                    oracleConnection.Close();
                }
            }
        }

        public async Task<FacturasResponse> GetDataFacturaByIdAsync(int Id)
        {
            string connectionString = conexionString;
            OracleConnection oracleConnection = null;
            FacturasResponse factura = new FacturasResponse();
            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "SELECT * FROM Facturas where IdFactura=" + Id;

                        DbDataReader reader = await cmd.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            factura.IdFactura = await reader.IsDBNullAsync(0) ? 0 : reader.GetInt32(0);
                            factura.NumeroFactura = await reader.IsDBNullAsync(1) ? null : reader.GetString(1);
                            factura.Fecha = await reader.IsDBNullAsync(2) ? new DateTime() : reader.GetDateTime(2);
                            factura.TipoDePago = await reader.IsDBNullAsync(3) ? null : reader.GetString(3);
                            factura.DocumentoCliente = await reader.IsDBNullAsync(4) ? null : reader.GetString(4);
                            factura.NombreCliente = await reader.IsDBNullAsync(5) ? null : reader.GetString(5);
                            factura.SubTotal = await reader.IsDBNullAsync(6) ? 0 : reader.GetFloat(6);
                            factura.Descuento = await reader.IsDBNullAsync(7) ? 0 : reader.GetFloat(7);
                            factura.Iva = await reader.IsDBNullAsync(8) ? 0 : reader.GetFloat(8);
                            factura.TotalDescuento = await reader.IsDBNullAsync(9) ? 0 : reader.GetFloat(9);
                            factura.TotalImpuesto = await reader.IsDBNullAsync(10) ? 0 : reader.GetFloat(10);
                            factura.Total = await reader.IsDBNullAsync(11) ? 0 : reader.GetFloat(11);
                        }
                        await reader.DisposeAsync();
                        return factura;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (oracleConnection != null)
                {
                    oracleConnection.Close();
                }
            }
        }

        public async Task<bool> GetDataInsertFacturaAsync(FacturasRequest factura)
        {
            string connectionString = conexionString;
            OracleConnection oracleConnection = null;
            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "INSERT INTO FACTURAS (NUMEROFACTURA, FECHA, TIPODEPAGO, DOCUMENTOCLIENTE, NOMBRECLIENTE, SUBTOTAL, DESCUENTO, IVA, TOTALDESCUENTO, TOTALIMPUESTO, TOTAL) " +
                            "VALUES('"+ factura.NumeroFac +"', TO_DATE('"+ factura.FechaFac.ToString("dd/MM/yyyy") +"', 'YYYY-MM-DD HH24:MI:SS'), '"+ factura.TipoDePagoFac +"', '"+ factura.DocumentoClienteFac +"', '"+ factura.NombreClienteFac +"', '"+ factura.SubTotalFac +"', '"+ factura.DescuentoFac +"'," +
                            "'"+ factura.IvaFac +"', '"+ factura.TotalDescuentoFac +"', '" + factura.TotalImpuestoFac + "', '" + factura.TotalFac + "')";

                        DbDataReader reader = await cmd.ExecuteReaderAsync();

                        if (reader.RecordsAffected == 0) return false;

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (oracleConnection != null)
                {
                    oracleConnection.Close();
                }
            }
        }
    }
}
