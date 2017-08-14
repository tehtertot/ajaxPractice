using ajaxNotesTest.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;

namespace ajaxNotesTest.Factory
{
    public class NoteFactory : IFactory<Note> {
        
        private readonly IOptions<MySqlOptions> MySqlConfig;

        public NoteFactory(IOptions<MySqlOptions> config) 
        {
            MySqlConfig = config;
        }

        internal IDbConnection Connection {
            get {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }

        public void Add(Note n) {
            using (IDbConnection dbConnection = Connection) {
                string query = "INSERT INTO note (title, description) VALUES (@Title, @Description);";
                dbConnection.Open();
                dbConnection.Execute(query, n);
            }
        }

        public List<Note> FindAll() {
            using (IDbConnection dbConnection = Connection) {
                string query = "SELECT * FROM note";
                dbConnection.Open();
                return dbConnection.Query<Note>(query).OrderBy(n => n.CreatedAt).ToList();
            }
        }
    }
}