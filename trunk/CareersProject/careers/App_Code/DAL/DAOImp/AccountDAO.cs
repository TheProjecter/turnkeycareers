using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;



    public class AccountDAO : DAO_Account_Interface
    {
        
        public AccountDAO()
        {


        }

        public bool isFound(string userName)
        {
            SqlConnection oConn = new SqlConnection();
            SqlCommand sqlCmd = null;
            bool found = false;

            try
            {
                oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
                oConn.Open();

                sqlCmd = oConn.CreateCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select userName from account where userName = '" + userName +"'";

                SqlDataReader rdr = sqlCmd.ExecuteReader();

                if (rdr.HasRows)
                    found = true;

            }
            catch 
            {}
            finally
            {
                if (sqlCmd != null)
                {
                    sqlCmd = null;
                }
                if (oConn != null)
                {
                    if (oConn.State.Equals(ConnectionState.Open))
                    {
                        oConn.Close();
                    }
                    oConn = null;
                }
            }
            return found;
        }

        /*public AccountDTO find(string userName)
        {
       

            AccountDTO acc = new AccountDTO();
            acc.userName = obj.userName;
            acc.password = obj.password;
            acc.status = obj.status;
            acc.accountType = obj.accountType;
            return acc;
        }


        public List<AccountDTO> findAll()
        {
        
            AccountDTO acc = null;
            List<AccountDTO> accounts = new List<AccountDTO>();
            foreach(Account obj in objs)
            {
                acc = new AccountDTO();
                acc.userName = obj.userName;
                acc.password = obj.password;
                acc.status = obj.status;
                acc.accountType = obj.accountType;

                accounts.Add(acc);
            }
            return accounts;
        }

        public bool presist(AccountDTO entityDTO)
        {
            try
            {
                ctx.insertAccount(entityDTO.userName,
                                    entityDTO.password,
                                    entityDTO.status,
                                    entityDTO.accountType);
            }
            catch (Exception)
            {
            }
            return 
        }
   
        public  merge(AccountDTO entityDTO)
        {
                ctx.updateAccount(entityDTO.userName,
                                    entityDTO.password,
                                    entityDTO.status,
                                    entityDTO.accountType);

        }

        public bool remove(AccountDTO entity)
        {
            return this.removeByUserId(entity.userName);
        }

        public bool removeByUserId(string userName)
        {
        
            try
            {
                ctx.deleteAccount(userName);
            
            }
            catch (Exception)
            {
           
            }
            return 
        
        }
        */


        public AccountDTO find(string userName)
        {
            AccountDTO acc = new AccountDTO();
            SqlConnection oConn = new SqlConnection();
            SqlCommand sqlCmd = null;

            try
            {
                oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
                oConn.Open();

                sqlCmd = oConn.CreateCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select * from account where userName = '" + userName + "'";

                SqlDataReader rdr = sqlCmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        acc.userName = rdr["userName"].ToString();
                        acc.password = rdr["password"].ToString();
                        acc.status = rdr["status"].ToString();
                        acc.accountType = rdr["accountType"].ToString();
                    }
                }

            }
            catch
            { }
            finally
            {
                if (sqlCmd != null)
                {
                    sqlCmd = null;
                }
                if (oConn != null)
                {
                    if (oConn.State.Equals(ConnectionState.Open))
                    {
                        oConn.Close();
                    }
                    oConn = null;
                }
            }
            return acc;
        }

        public bool removeByUserId(string username)
        {
            bool success = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand sqlCmd = null;

            try
            {
                oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
                oConn.Open();

                sqlCmd = oConn.CreateCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "deleteAccount";
                sqlCmd.Parameters.Add(new SqlParameter("userName", username));


                SqlDataReader rdr = sqlCmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    { } //Read all
                }
                rdr.Close();

                if (rdr.RecordsAffected > 0)
                    success = true;
            }
            catch { }
            finally
            {
                if (sqlCmd != null)
                {
                    sqlCmd = null;
                }
                if (oConn != null)
                {
                    if (oConn.State.Equals(ConnectionState.Open))
                    {
                        oConn.Close();
                    }
                    oConn = null;
                }
            }
            return success;
        }

        public List<AccountDTO> findAll()
        {
            AccountDTO acc = null;
            List<AccountDTO> accounts = new List<AccountDTO>();
            SqlConnection oConn = new SqlConnection();
            SqlCommand sqlCmd = null;

            try
            {
                oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
                oConn.Open();

                sqlCmd = oConn.CreateCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select * from account";

                SqlDataReader rdr = sqlCmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        acc = new AccountDTO();
                        acc.userName = rdr["userName"].ToString();
                        acc.password = rdr["password"].ToString();
                        acc.status = rdr["status"].ToString();
                        acc.accountType = rdr["accountType"].ToString();

                        accounts.Add(acc);
                    }
                }

            }
            catch
            { }
            finally
            {
                if (sqlCmd != null)
                {
                    sqlCmd = null;
                }
                if (oConn != null)
                {
                    if (oConn.State.Equals(ConnectionState.Open))
                    {
                        oConn.Close();
                    }
                    oConn = null;
                }
            }
            return accounts;
        }

        public bool presist(AccountDTO entity)
        {
 
            bool success = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand sqlCmd = null;

            try
            {
                oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
                oConn.Open();

                sqlCmd = oConn.CreateCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "insertAccount";
                sqlCmd.Parameters.Add(new SqlParameter("userName", entity.userName));
                sqlCmd.Parameters.Add(new SqlParameter("password", entity.password));
                sqlCmd.Parameters.Add(new SqlParameter("status", entity.status));
                sqlCmd.Parameters.Add(new SqlParameter("accountType", entity.accountType));

                SqlDataReader rdr = sqlCmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {} //Read all
                }
                rdr.Close();

                if (rdr.RecordsAffected > 0)
                    success = true;
            }
            catch { }
            finally
            {
                if (sqlCmd != null)
                {
                    sqlCmd = null;
                }
                if (oConn != null)
                {
                    if (oConn.State.Equals(ConnectionState.Open))
                    {
                        oConn.Close();
                    }
                    oConn = null;
                }
            }
            return success;
        }

        public bool merge(AccountDTO entity)
        {
            bool success = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand sqlCmd = null;

            try
            {
                oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
                oConn.Open();

                sqlCmd = oConn.CreateCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "updateAccount";
                sqlCmd.Parameters.Add(new SqlParameter("userName", entity.userName));
                sqlCmd.Parameters.Add(new SqlParameter("password", entity.password));
                sqlCmd.Parameters.Add(new SqlParameter("status", entity.status));
                sqlCmd.Parameters.Add(new SqlParameter("accountType", entity.accountType));

                SqlDataReader rdr = sqlCmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    { } //Read all
                }
                rdr.Close();

                if (rdr.RecordsAffected > 0)
                    success = true;
            }
            catch { }
            finally
            {
                if (sqlCmd != null)
                {
                    sqlCmd = null;
                }
                if (oConn != null)
                {
                    if (oConn.State.Equals(ConnectionState.Open))
                    {
                        oConn.Close();
                    }
                    oConn = null;
                }
            }
            return success;
        }

        public bool remove(AccountDTO entity)
        {
            return this.removeByUserId(entity.userName);
        }
    }

