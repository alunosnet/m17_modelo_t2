using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace M17_Modelo_T2
{
    public class BaseDados
    {
        string strLigacao;
        SqlConnection ligacaoBD;
        //construtor
        public BaseDados()
        {
            strLigacao = ConfigurationManager.ConnectionStrings["sql"].ToString();
            ligacaoBD = new SqlConnection(strLigacao);
            try
            {
                ligacaoBD.Open();
            }catch(Exception erro)
            {
                Console.Write("Erro: " + erro.Message);
            }
        }
        //destrutor
        ~BaseDados()
        {
            try
            {
                ligacaoBD.Close();
                ligacaoBD.Dispose();
            }catch(Exception erro)
            {
                Console.Write("Erro: " + erro.Message);
            }
        }
        #region Funções genéricas
        //devolve consulta
        public DataTable devolveConsulta(string sql)
        {
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            DataTable registos = new DataTable();
            SqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            comando.Dispose();
            return registos;
        }
        public DataTable devolveConsulta(string sql,List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            DataTable registos = new DataTable();
            comando.Parameters.AddRange(parametros.ToArray());
            SqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            comando.Dispose();
            return registos;
        }
        //executar comando
        public bool executaComando(string sql)
        {
            try {
                SqlCommand comando = new SqlCommand(sql, ligacaoBD);
                comando.ExecuteNonQuery();
                comando.Dispose();
            }catch(Exception erro)
            {
                Console.Write(erro.Message);
                return false;
            }
            return true;
        }
        public bool executaComando(string sql,List<SqlParameter> parametros)
        {
            try
            {
                SqlCommand comando = new SqlCommand(sql, ligacaoBD);
                comando.Parameters.AddRange(parametros.ToArray());
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception erro)
            {
                Console.Write(erro.Message);
                return false;
            }
            return true;
        }
        #endregion
        #region Cliente
        //adicionar cliente
        public bool adicionarCliente(string nome,string morada,string cp,string email,DateTime data)
        {
            string sql = "INSERT INTO Cliente(nome,morada,cp,email,data_nascimento) ";
            sql += " VALUES (@nome,@morada,@cp,@email,@data)";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=System.Data.SqlDbType.VarChar,Value=nome },
                new SqlParameter() {ParameterName="@morada",SqlDbType=System.Data.SqlDbType.VarChar,Value=morada },
                new SqlParameter() {ParameterName="@cp",SqlDbType=System.Data.SqlDbType.VarChar,Value=cp },
                new SqlParameter() {ParameterName="@email",SqlDbType=System.Data.SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@data",SqlDbType=System.Data.SqlDbType.Date,Value=data }
            };
            //executar
            bool erro = executaComando(sql, parametros);
            return erro;
        }
        public bool removerCliente(int id)
        {
            string sql = "DELETE FROM Cliente WHERE id=@id ";
            
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value=id }
            };
            //executar
            bool erro = executaComando(sql, parametros);
            return erro;
        }
        public bool atualizarCliente(int id,string nome, string morada, string cp, string email, DateTime data)
        {
            string sql = "UPDATE Cliente SET nome=@nome,morada=@morada,cp=@cp, ";
            sql += " email=@email,data_nascimento=@data WHERE id=@id";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=System.Data.SqlDbType.VarChar,Value=nome },
                new SqlParameter() {ParameterName="@morada",SqlDbType=System.Data.SqlDbType.VarChar,Value=morada },
                new SqlParameter() {ParameterName="@cp",SqlDbType=System.Data.SqlDbType.VarChar,Value=cp },
                new SqlParameter() {ParameterName="@email",SqlDbType=System.Data.SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@data",SqlDbType=System.Data.SqlDbType.Date,Value=data }
            };
            //executar
            bool erro = executaComando(sql, parametros);
            return erro;
        }
        
        #endregion
    }
}