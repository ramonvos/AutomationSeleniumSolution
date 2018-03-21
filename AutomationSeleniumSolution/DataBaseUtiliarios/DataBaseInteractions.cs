using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.DataBaseUtiliarios
{
    public class DataBaseInteractions
    {
        private SqlConnection getDBConnection()
        {
            string connectionString = null;
            if (ConfigurationManager.AppSettings["DBUrl"] == "bbssqlqa")
            {
                connectionString = "Data Source=" + ConfigurationManager.AppSettings["DBUrl"] + ",1433;" +
                                       "Initial Catalog=" + ConfigurationManager.AppSettings["DBCatalog"] + ";" +
                                       "User ID=" + ConfigurationManager.AppSettings["DBUser"] + "; " +
                                       "Password=" + ConfigurationManager.AppSettings["DBPassword"] + ";";
            }
            else if (ConfigurationManager.AppSettings["DBUrl"] == "bbssqlqa05")
            {
                connectionString = "Data Source=" + ConfigurationManager.AppSettings["DBUrl"] + ",1433;" +
                                         "Initial Catalog=" + ConfigurationManager.AppSettings["DBCatalog"] + ";" +
                                         "User ID=" + ConfigurationManager.AppSettings["DBUser"] + "; " +
                                         "Password=" + ConfigurationManager.AppSettings["DBPassword"] + ";";

            }
            else
            {
                connectionString = "Integrated Security=SSPI;Initial Catalog=SCAC;Data Source=BBSSQLQA;";
            }


            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        public void executaQuery(String query)
        {
            using (SqlCommand cmd = new SqlCommand(query, getDBConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["DBConnectionTimeout"]);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public void query_executaProcedure(String query, String[,] arrayDeParam)//String [,] arrayDeParam |int numberParam, |List<SqlParameter> sp
        {
            using (SqlCommand cmd = new SqlCommand(query, getDBConnection()))
            {
                try
                {
                    cmd.CommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["DBConnectionTimeout"]);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = query;
                    cmd.Parameters.Clear();
                    int i = 0;
                    while (i < arrayDeParam.GetLength(0))
                    {
                        cmd.Parameters.AddWithValue(arrayDeParam[i, 0], arrayDeParam[i, 1]);
                        i++;
                    }

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar executar a query." + e.GetBaseException());
                }
                finally
                {
                    try
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection.Close();
                    }
                    catch (Exception) { throw new Exception("Erro para fechar conexão."); }
                }
            }
        }
        public List<string> retornaDadosQuery(String query)
        {

            DataSet ds = new DataSet();
            List<string> lista = new List<string>();


            using (SqlCommand cmd = new SqlCommand(query, getDBConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["DBConnectionTimeout"]);
                cmd.Connection.Open();
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                ds.Tables.Add(table);
                cmd.Connection.Close();
            }




            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    lista.Add(ds.Tables[0].Rows[0][i].ToString());
                }
            }
            catch (Exception)
            {

                return null;
            }

            return lista;
        }

        public List<string> retornaListaDadosQuery(String query)
        {

            DataSet ds = new DataSet();
            List<string> lista = new List<string>();

            using (SqlCommand cmd = new SqlCommand(query, getDBConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["DBConnectionTimeout"]);
                cmd.Connection.Open();
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                ds.Tables.Add(table);
                cmd.Connection.Close();
            }

            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        lista.Add(ds.Tables[0].Rows[i][j].ToString());
                    }
                }

            }
            catch (Exception)
            {

                return null;
            }
            return lista;
        }
    }
}
