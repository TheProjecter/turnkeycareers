using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for  HigherEducationDAO
/// </summary>
public class HigherEducationDAO : DAO_HigherEducation_Interface
{
    public HigherEducationDAO()
	{}

    public bool isFound(string userName, string major)
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
            sqlCmd.CommandText = "select userName from HigherEducation where userName = '" + userName + "' AND major = '" + major + "'";

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

    public HigherEducationDTO find(string userName, string major)
    {
        HigherEducationDTO info = new HigherEducationDTO();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from HigherEducation where userName = '" + userName + "' AND major = '" + major + "'";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    info.userName = rdr["userName"].ToString();
                    info.institution = rdr["institution"].ToString();
                    info.town = rdr["town"].ToString();
                    info.province = rdr["province"].ToString();
                    info.country = rdr["country"].ToString();
                    info.educationType = rdr["educationType"].ToString();
                    info.major = rdr["major"].ToString();
                    info.industry = rdr["industry"].ToString();
                    info.length = rdr["length"].ToString();
                    info.nqf = rdr["nqf"].ToString();
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

    public bool removeByUserId(string userName, string major)
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
            sqlCmd.CommandText = "deleteHigherEducation";
            sqlCmd.Parameters.Add(new SqlParameter("userName", userName));
            sqlCmd.Parameters.Add(new SqlParameter("major", major));


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

    public List<HigherEducationDTO> findAll()
    {
        HigherEducationDTO info = null;
        List<HigherEducationDTO> infos = new List<HigherEducationDTO>();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from HigherEducation";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    info = new HigherEducationDTO();
                    info.userName = rdr["userName"].ToString();
                    info.institution = rdr["institution"].ToString();
                    info.town = rdr["town"].ToString();
                    info.province = rdr["province"].ToString();
                    info.country = rdr["country"].ToString();
                    info.educationType = rdr["educationType"].ToString();
                    info.major = rdr["major"].ToString();
                    info.industry = rdr["industry"].ToString();
                    info.length = rdr["length"].ToString();
                    info.nqf = rdr["nqf"].ToString();

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

    public bool presist(HigherEducationDTO entity)
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
            sqlCmd.CommandText = "insertHigherEducation";
            sqlCmd.Parameters.Add(new SqlParameter("userName", entity.userName));
            sqlCmd.Parameters.Add(new SqlParameter("institution", entity.institution));
            sqlCmd.Parameters.Add(new SqlParameter("town", entity.town));
            sqlCmd.Parameters.Add(new SqlParameter("province", entity.province));
            sqlCmd.Parameters.Add(new SqlParameter("country", entity.country));
            sqlCmd.Parameters.Add(new SqlParameter("educationType", entity.educationType));
            sqlCmd.Parameters.Add(new SqlParameter("major", entity.major));
            sqlCmd.Parameters.Add(new SqlParameter("industry", entity.industry));
            sqlCmd.Parameters.Add(new SqlParameter("length", entity.length));
            sqlCmd.Parameters.Add(new SqlParameter("nqf", entity.nqf));

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

    public bool merge(HigherEducationDTO entity)
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
            sqlCmd.CommandText = "updateHigherEducation";
            sqlCmd.Parameters.Add(new SqlParameter("userName", entity.userName));
            sqlCmd.Parameters.Add(new SqlParameter("institution", entity.institution));
            sqlCmd.Parameters.Add(new SqlParameter("town", entity.town));
            sqlCmd.Parameters.Add(new SqlParameter("province", entity.province));
            sqlCmd.Parameters.Add(new SqlParameter("country", entity.country));
            sqlCmd.Parameters.Add(new SqlParameter("educationType", entity.educationType));
            sqlCmd.Parameters.Add(new SqlParameter("major", entity.major));
            sqlCmd.Parameters.Add(new SqlParameter("industry", entity.industry));
            sqlCmd.Parameters.Add(new SqlParameter("length", entity.length));
            sqlCmd.Parameters.Add(new SqlParameter("nqf", entity.nqf));

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

    public bool remove(HigherEducationDTO entity)
    {
        return this.removeByUserId(entity.userName, entity.major);
    }
}