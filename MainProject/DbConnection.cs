using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Npgsql;

namespace MainProject
{
    public class DbConnection
    {
        NpgsqlConnection conn;
        NpgsqlCommand getProviderListDB;
        NpgsqlCommand addProviderDB;
        NpgsqlCommand updProviderDB;
        NpgsqlCommand delProviderDB;
        NpgsqlCommand getManagerListDB;
        public DbConnection(){ }
        
        public void AddProvider(Provider provider)
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=2891;Database=kop;");
            addProviderDB = new NpgsqlCommand("INSERT INTO providers (name, phoneNumber, managerID) VALUES (@n, @p, @m)", conn);
            conn.Open();
            addProviderDB.Parameters.AddWithValue("n", provider.name);
            addProviderDB.Parameters.AddWithValue("p", provider.phoneNumber);
            addProviderDB.Parameters.AddWithValue("m", provider.managerId);
            addProviderDB.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdProvider(Provider provider)
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=2891;Database=kop;");
            updProviderDB = new NpgsqlCommand("UPDATE providers SET name = @n, phoneNumber = @p, managerID = @m WHERE \"id\" = @id", conn);
            conn.Open();
            updProviderDB.Parameters.AddWithValue("n", provider.name);
            updProviderDB.Parameters.AddWithValue("p", provider.phoneNumber);
            updProviderDB.Parameters.AddWithValue("m", provider.managerId);
            updProviderDB.Parameters.AddWithValue("id", provider.id);
            updProviderDB.ExecuteReader().Close();
            conn.Close();
        }

        public void DelProvider(Provider provider)
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=2891;Database=kop;");
            delProviderDB = new NpgsqlCommand("DELETE FROM providers WHERE \"id\"=@id", conn);
            conn.Open();
            delProviderDB.Parameters.AddWithValue("id", provider.id);
            delProviderDB.ExecuteReader().Close();
            conn.Close();
        }

        public List<Provider> getProviderList()
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=2891;Database=kop;");
            getProviderListDB = new NpgsqlCommand("SELECT * FROM providers", conn);
            conn.Open();
            var reader = getProviderListDB.ExecuteReader();
            var result = new List<Provider>();
            while (reader.Read())
            {
                result.Add(new Provider { id = (int)reader[0], name = (string)reader[1], phoneNumber = (string)reader[2], managerId = (int)reader[3] });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public List<Manager> getManagerList()
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=2891;Database=kop;");
            getManagerListDB = new NpgsqlCommand("SELECT * FROM managers", conn);
            conn.Open();
            var reader = getManagerListDB.ExecuteReader();
            var result = new List<Manager>();
            while (reader.Read())
            {
                result.Add(new Manager { id = (int)reader[0], name = (string)reader[1] });
            }
            reader.Close();
            conn.Close();
            return result;
        }
    }
}
