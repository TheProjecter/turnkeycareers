using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for  ContactInfoDAO
/// </summary>
public class ContactInfoDAO : DAO_ContactInfo_Interface
{
    public ContactInfoDAO()
	{
	}

    public bool isFound(string userName, string contactType)
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
            sqlCmd.CommandText = "select userName from ContactInfo where userName = '" + userName + "' AND contactType = '" + contactType + "'";

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

    public ContactInfoDTO find(string userName, string contactType)
    {
        ContactInfoDTO info = new ContactInfoDTO();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from ContactInfo where userName = '" + userName + "' AND contactType = '" + contactType + "'";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    info.userName = rdr["userName"].ToString();
                    info.contactType = rdr["contactType"].ToString();
                    info.data = rdr["data"].ToString();
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

    public bool removeByUserId(string userName, string contactType)
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
            sqlCmd.CommandText = "deleteContactInfo";
            sqlCmd.Parameters.Add(new SqlParameter("userName", userName));
            sqlCmd.Parameters.Add(new SqlParameter("contactType", contactType));


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

    public List<ContactInfoDTO> findAll()
    {
        ContactInfoDTO info = null;
        List<ContactInfoDTO> infos = new List<ContactInfoDTO>();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from ContactInfo";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    info = new ContactInfoDTO();
                    info.userName = rdr["userName"].ToString();
                    info.contactType = rdr["contactType"].ToString();
                    info.data = rdr["data"].ToString();

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

    public bool presist(ContactInfoDTO entity)
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
            sqlCmd.CommandText = "insertContactInfo";
            sqlCmd.Parameters.Add(new SqlParameter("userName", entity.userName));
            sqlCmd.Parameters.Add(new SqlParameter("contactType", entity.contactType));
            sqlCmd.Parameters.Add(new SqlParameter("data", entity.data));

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

    public bool merge(ContactInfoDTO entity)
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
            sqlCmd.CommandText = "updateContactInfo";
            sqlCmd.Parameters.Add(new SqlParameter("userName", entity.userName));
            sqlCmd.Parameters.Add(new SqlParameter("contactType", entity.contactType));
            sqlCmd.Parameters.Add(new SqlParameter("data", entity.data));

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

    public bool remove(ContactInfoDTO entity)
    {
        return this.removeByUserId(entity.userName, entity.contactType);
    }
}