using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for  addressDAO
/// </summary>
public class SupportDocDAO : DAO_SupportDoc_Interface
{
    public SupportDocDAO()
	{	}

    public bool isFound(string userName, string title)
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
            sqlCmd.CommandText = "select userName from supportDoc where userName = '" + userName + "' AND title = '" + title + "'";

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

    public SupportDocDTO find(string userName, string title)
    {
        SupportDocDTO info = new SupportDocDTO();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from supportDoc where userName = '" + userName + "' AND title = '" + title + "'";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {

                    info.userName = rdr["userName"].ToString();
                    info.title = rdr["title"].ToString();
                    info.description = rdr["description"].ToString();
                    info.content = (byte[])rdr["content"];
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

    public bool removeByUserId(string userName, string title)
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
            sqlCmd.CommandText = "deleteSupportDoc";
            sqlCmd.Parameters.Add(new SqlParameter("userName", userName));
            sqlCmd.Parameters.Add(new SqlParameter("title", title));


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

    public List<SupportDocDTO> findAll()
    {
        SupportDocDTO info = null;
        List<SupportDocDTO> infos = new List<SupportDocDTO>();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from supportDoc";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    info = new SupportDocDTO();
                    info.userName = rdr["userName"].ToString();
                    info.title = rdr["title"].ToString();
                    info.description = rdr["description"].ToString();
                    info.content = (byte[])rdr["content"];

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

    public bool presist(SupportDocDTO entity)
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
            sqlCmd.CommandText = "insertSupportDoc";
            sqlCmd.Parameters.Add(new SqlParameter("title", entity.title));
            sqlCmd.Parameters.Add(new SqlParameter("userName", entity.userName));
            sqlCmd.Parameters.Add(new SqlParameter("description", entity.description));
            sqlCmd.Parameters.Add(new SqlParameter("content", entity.content));

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

    public bool merge(SupportDocDTO entity)
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
            sqlCmd.CommandText = "updateSupportDoc";
            sqlCmd.Parameters.Add(new SqlParameter("userName", entity.userName));
            sqlCmd.Parameters.Add(new SqlParameter("title", entity.title));
            sqlCmd.Parameters.Add(new SqlParameter("description", entity.description));
            sqlCmd.Parameters.Add(new SqlParameter("content", entity.content));

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

    public bool remove(SupportDocDTO entity)
    {
        return this.removeByUserId(entity.userName, entity.title);
    }
}