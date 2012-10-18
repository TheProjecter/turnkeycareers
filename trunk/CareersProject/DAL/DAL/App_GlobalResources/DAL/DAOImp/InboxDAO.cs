using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for  InboxDAO
/// </summary>
public class InboxDAO : DAO_Inbox_Interface
{
    public InboxDAO()
	{	}


    public bool isFound(string userName, string vacancyNumber)
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
            sqlCmd.CommandText = "select userName from Inbox where userName = '" + userName + "' AND vacancyNumber = " + vacancyNumber;

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
                found = true;

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
        return found;
    }

    public InboxDTO find(string userName, string vacancyNumber)
    {
        InboxDTO info = new InboxDTO();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from Inbox where userName = '" + userName + "' AND vacancyNumber = " + vacancyNumber;

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    info.userName = rdr["userName"].ToString();
                    info.vacancyNumber = rdr["vacancyNumber"].ToString();
                    info.date = DateTime.Parse(rdr["date"].ToString() );
                    info.unread = rdr["unread"].ToString();
                    info.message = rdr["message"].ToString();
                    info.status = rdr["status"].ToString();
                    
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
        return info;
    }

    public bool removeByUserId(string userName, string vacancyNumber)
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
            sqlCmd.CommandText = "deleteInbox";
            sqlCmd.Parameters.Add(new SqlParameter("userName", userName));
            sqlCmd.Parameters.Add(new SqlParameter("vacancyNumber", vacancyNumber));


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

    public List<InboxDTO> findAll()
    {
        InboxDTO info = null;
        List<InboxDTO> infos = new List<InboxDTO>();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from Inbox";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    info = new InboxDTO();
                    info.userName = rdr["userName"].ToString();
                    info.vacancyNumber = rdr["vacancyNumber"].ToString();
                    info.date = DateTime.Parse(rdr["date"].ToString());
                    info.unread = rdr["unread"].ToString();
                    info.message = rdr["message"].ToString();
                    info.status = rdr["status"].ToString();

                    infos.Add(info);
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
        return infos;
    }

    public bool presist(InboxDTO entity)
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
            sqlCmd.CommandText = "insertInbox";
            sqlCmd.Parameters.Add(new SqlParameter("userName", entity.userName));
            sqlCmd.Parameters.Add(new SqlParameter("vacancyNumber", entity.vacancyNumber));
            sqlCmd.Parameters.Add(new SqlParameter("date", entity.date));
            sqlCmd.Parameters.Add(new SqlParameter("unread", entity.unread));
            sqlCmd.Parameters.Add(new SqlParameter("message", entity.message));
            sqlCmd.Parameters.Add(new SqlParameter("status", entity.status));

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

    public bool merge(InboxDTO entity)
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
            sqlCmd.CommandText = "updateInbox";
            sqlCmd.Parameters.Add(new SqlParameter("userName", entity.userName));
            sqlCmd.Parameters.Add(new SqlParameter("vacancyNumber", entity.vacancyNumber));
            sqlCmd.Parameters.Add(new SqlParameter("date", entity.date));
            sqlCmd.Parameters.Add(new SqlParameter("unread", entity.unread));
            sqlCmd.Parameters.Add(new SqlParameter("message", entity.message));
            sqlCmd.Parameters.Add(new SqlParameter("status", entity.status));


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

    public bool remove(InboxDTO entity)
    {
        return this.removeByUserId(entity.userName, entity.vacancyNumber);
    }
}