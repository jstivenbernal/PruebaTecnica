using PruebaTecnica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;

namespace PruebaTecnica.DL.Repository
{
    public class ProductosDL : IProductosDL
    {
        private string conexionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl.json.com)));User Id=JEISSONBERNAL;Password=Abc123;";
        public async Task<IList<ProductosResponse>> GetListProductoAsync()
        {
            IList<ProductosResponse> result = null;
            result = await GetListDataProductosAsync();
            return result;
        }

        public async Task<ProductosResponse> GetProductoByIdAsync(int Id)
        {
            ProductosResponse result = new ProductosResponse();
            result = await GetDataProductoByIdAsync(Id);
            return result;
        }
        public async Task<bool> InsertProductoAsync(ProductosRequest producto)
        {
            bool result = await GetDataInsertProductoAsync(producto);
            return result;
        }

        public async Task<IList<ProductosResponse>> GetListDataProductosAsync()
        {
            string connectionString = conexionString;
            OracleConnection oracleConnection = null;
            IList<ProductosResponse> productos = new List<ProductosResponse>();
            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "SELECT * FROM Productos";

                        DbDataReader reader = await cmd.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            ProductosResponse _producto = new ProductosResponse();
                            _producto.IdProducto = await reader.IsDBNullAsync(0) ? 0 : reader.GetInt32(0);
                            _producto.Producto = await reader.IsDBNullAsync(1) ? null : reader.GetString(1);
                            productos.Add(_producto);
                        }
                        await reader.DisposeAsync();
                        return productos;
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

        public async Task<ProductosResponse> GetDataProductoByIdAsync(int Id)
        {
            string connectionString = conexionString;
            OracleConnection oracleConnection = null;
            ProductosResponse producto = new ProductosResponse();
            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "SELECT * FROM Productos where IdProducto=" + Id;

                        DbDataReader reader = await cmd.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            producto.IdProducto = await reader.IsDBNullAsync(0) ? 0 : reader.GetInt32(0);
                            producto.Producto = await reader.IsDBNullAsync(1) ? null : reader.GetString(1);
                        }
                        await reader.DisposeAsync();
                        return producto;
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

        public async Task<bool> GetDataInsertProductoAsync(ProductosRequest producto)
        {
            string connectionString = conexionString;
            OracleConnection oracleConnection = null;
            ProductosResponse productoResponse = new ProductosResponse();
            try
            {
                using (oracleConnection = new OracleConnection(connectionString))
                {
                    oracleConnection.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = oracleConnection;
                        cmd.CommandText = "INSERT INTO PRODUCTOS (PRODUCTO) VALUES ('" + producto.Nombre + "')";

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
