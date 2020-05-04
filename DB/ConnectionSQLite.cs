using System.Data.SQLite;
using Model;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DB
{
    public class ConnectionSQLite
    {
        private static SQLiteConnection sqliteConnection;

        private static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection(@"Data Source = c:\tmp\myclientedb.db");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void Add(Cliente cliente)
        {
            try
            {
                
            string sql = "INSERT INTO cliente (id, nome, idcidade) values (@Id, @Nome, @IdCidade)";

            using( var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Id", cliente.Id);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@IdCidade", cliente.Cidade.Id);
                cmd.ExecuteNonQuery();
            }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public static DataTable GetCidadeAll()
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "SELECT id, nome from cidade";
                da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetClienteAll()
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;

            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT cl.id, ");
            sb.Append("        cl.nome, ");
            sb.Append("        ci.nome cidade ");
            sb.Append("   FROM cliente cl, ");
            sb.Append("        cidade ci ");
            sb.Append("  WHERE cl.idcidade = ci.id ");

            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                da.Fill(dt);
            }
            return dt;
        } 
    }
}
