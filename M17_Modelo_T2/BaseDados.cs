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
        public bool executaComando(string sql, List<SqlParameter> parametros,SqlTransaction transacao)
        {
            try
            {
                SqlCommand comando = new SqlCommand(sql, ligacaoBD);
                comando.Parameters.AddRange(parametros.ToArray());
                comando.Transaction = transacao;
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
                new SqlParameter() {ParameterName="@data",SqlDbType=System.Data.SqlDbType.Date,Value=data },
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value=id }
            };
            //executar
            bool erro = executaComando(sql, parametros);
            return erro;
        }
        #endregion
        #region Produto
        //adicionar produto
        public int adicionarProduto(string descricao,decimal preco,float quantidade)
        {
            string sql = "INSERT INTO Produto(descricao,preco,quantidade) ";
            sql += " VALUES (@descricao,@preco,@quantidade); SELECT cast(scope_identity() as int);";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@descricao",SqlDbType=System.Data.SqlDbType.VarChar,Value=descricao },
                new SqlParameter() {ParameterName="@preco",SqlDbType=System.Data.SqlDbType.Decimal,Value=preco },
                new SqlParameter() {ParameterName="@quantidade",SqlDbType=System.Data.SqlDbType.Float,Value=quantidade }
            };
            //executar
            SqlCommand comando = new SqlCommand(sql,ligacaoBD);
            comando.Parameters.AddRange(parametros.ToArray());
            int id = (int)comando.ExecuteScalar();
            comando.Dispose();
            return id;
        }
        public bool removerProduto(int id)
        {
            string sql = "DELETE FROM Produto WHERE id=@id";

            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value=id }
            };
            //executar
            bool erro = executaComando(sql, parametros);
            return erro;
        }
        public void atualizarProduto(int id,string descricao, decimal preco, float quantidade)
        {
            string sql = "UPDATE Produto SET descricao=@descricao, preco=@preco, ";
            sql += " quantidade=@quantidade WHERE id=@id";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@descricao",SqlDbType=System.Data.SqlDbType.VarChar,Value=descricao },
                new SqlParameter() {ParameterName="@preco",SqlDbType=System.Data.SqlDbType.Decimal,Value=preco },
                new SqlParameter() {ParameterName="@quantidade",SqlDbType=System.Data.SqlDbType.Float,Value=quantidade },
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value=id }
            };
            //executar
            executaComando(sql, parametros);
            return;
        }
        #endregion
        #region venda
       
        public bool adicionarVenda(int idcliente,int idproduto,decimal preco,float quant, DateTime data)
        {
            SqlTransaction transacao = ligacaoBD.BeginTransaction();
            try {
                string sql = "INSERT INTO Venda(id_cliente,id_produto,preco_venda,quantidade,data_venda) ";
                sql += " VALUES (@idcliente,@idproduto,@preco,@quantidade,@data)";
                //parametros
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@idcliente",SqlDbType=SqlDbType.Int,Value=idcliente },
                    new SqlParameter() {ParameterName="@idproduto",SqlDbType=SqlDbType.Int,Value=idproduto },
                    new SqlParameter() {ParameterName="@preco",SqlDbType=SqlDbType.Decimal,Value=preco },
                    new SqlParameter() {ParameterName="@quantidade",SqlDbType=SqlDbType.Float,Value=quant },
                    new SqlParameter() {ParameterName="@data",SqlDbType=SqlDbType.Date,Value=data }
                };
                //executar
                executaComando(sql, parametros,transacao);
                //atualizar quantidade em stock
                sql = "UPDATE produto SET quantidade=quantidade-@quantidade WHERE id=@id";
                parametros.Clear();
                parametros = new List<SqlParameter>()
                {
                     new SqlParameter() {ParameterName="@quantidade",SqlDbType=SqlDbType.Float,Value=quant },
                      new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=idproduto }
                };
                executaComando(sql, parametros, transacao);
                transacao.Commit();
            }
            catch(Exception erro)
            {
                transacao.Rollback();
                return false;
            }
            return true;
        }
        #endregion
        #region utilizador
        public bool adicionarUtilizador(string nome,string password,int perfil)
        {
            string sql = "INSERT INTO utilizador(nome,palavra_passe,perfil) ";
            sql += "VALUES (@nome,HASHBYTES('SHA1',@password),@perfil)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value=nome },
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value=password },
                new SqlParameter() {ParameterName="@perfil",SqlDbType=SqlDbType.Int,Value=perfil }
            };
            return executaComando(sql, parametros);
        }
        #endregion
    }
}