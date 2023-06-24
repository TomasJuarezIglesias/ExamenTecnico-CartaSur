using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ExamenTecnicoDBConnection
    {
        SqlConnection _Connection;

        // Ctor para que no se permitan instancias con new.
        private ExamenTecnicoDBConnection()
        {   
            _Connection = new SqlConnection("Data Source=localhost; Initial Catalog=ExamenTecnicoDB; Integrated Security=True");
        }

        // Singleton
        private static ExamenTecnicoDBConnection? _instance = null;

        public static ExamenTecnicoDBConnection GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExamenTecnicoDBConnection();
                }

                return _instance;
            }
        }

        private void AbrirConexion()
        {
            _Connection.Open();
        }

        private void CerrarConexion()
        {
            _Connection.Close();
        }

        // Metodo que permite la ejecucion de Stored Procedure de tipo lectura y devuelve una datatable con lo obtenido
        public DataTable Leer(string sp, SqlParameter[]? parameters)
        {
            AbrirConexion();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = new SqlCommand();
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.SelectCommand.CommandText = sp;

            if (parameters != null) 
            {
                sqlDataAdapter.SelectCommand.Parameters.AddRange(parameters);
            }

            sqlDataAdapter.SelectCommand.Connection = _Connection;

            sqlDataAdapter.Fill(dataTable);

            CerrarConexion();
            return dataTable;
        }


        

    }
}
