using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for  EmploymentDAO
/// </summary>
public class EmploymentDAO : DAO_Employment_Interface
{
    public EmploymentDAO()
	{}

    public bool isFound(string userName, DateTime startDate)
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
            sqlCmd.CommandText = "select userName from Employment where userName = '" + userName + "' AND startDate = '" + startDate + "'";

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

    public EmploymentDTO find(string userName, DateTime startDate)
    {
        EmploymentDTO info = new EmploymentDTO();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from Employment where userName = '" + userName + "' AND startDate = '" + startDate + "'";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {

                    info.userName = rdr["userName"].ToString();
                    info.title = rdr["title"].ToString();
                    info.company = rdr["company"].ToString();
                    info.industry = rdr["industry"].ToString();
                    info.town = rdr["town"].ToString();
                    info.province = rdr["province"].ToString();
                    info.country = rdr["country"].ToString();
                    info.empType = rdr["empType"].ToString();
                    info.currentEmployer = rdr["currentEmployer"].ToString();
                    info.gross = Double .Parse(rdr["gross"].ToString() );
                    info.startDate = DateTime.Parse( rdr["startDate"].ToString() );
                    info.endDate = DateTime.Parse(rdr["endDate"].ToString() );
                    info.responsibilities = rdr["responsibilities"].ToString();
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

    public bool removeByUserId(string userName, DateTime startDate)
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
            sqlCmd.CommandText = "deleteEmployment";
            sqlCmd.Parameters.Add(new SqlParameter("userName", userName));
            sqlCmd.Parameters.Add(new SqlParameter("startDate", startDate));


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

    public List<EmploymentDTO> findAll()
    {
        EmploymentDTO info = null;
        List<EmploymentDTO> infos = new List<EmploymentDTO>();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from Employment";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    info = new EmploymentDTO();
                    info.userName = rdr["userName"].ToString();
                    info.title = rdr["title"].ToString();
                    info.company = rdr["company"].ToString();
                    info.industry = rdr["industry"].ToString();
                    info.town = rdr["town"].ToString();
                    info.province = rdr["province"].ToString();
                    info.country = rdr["country"].ToString();
                    info.empType = rdr["empType"].ToString();
                    info.currentEmployer = rdr["currentEmployer"].ToString();
                    info.gross = Double.Parse(rdr["gross"].ToString());
                    info.startDate = DateTime.Parse(rdr["startDate"].ToString());
                    info.endDate = DateTime.Parse(rdr["endDate"].ToString());
                    info.responsibilities = rdr["responsibilities"].ToString();

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

    public bool presist(EmploymentDTO entity)
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
            sqlCmd.CommandText = "insertEmployment";
            sqlCmd.Parameters.Add(new SqlParameter("userName", entity.userName));
            sqlCmd.Parameters.Add(new SqlParameter("title", entity.title));
            sqlCmd.Parameters.Add(new SqlParameter("company", entity.company));
            sqlCmd.Parameters.Add(new SqlParameter("industry", entity.industry));
            sqlCmd.Parameters.Add(new SqlParameter("town", entity.town));
            sqlCmd.Parameters.Add(new SqlParameter("province", entity.province));
            sqlCmd.Parameters.Add(new SqlParameter("country", entity.country));
            sqlCmd.Parameters.Add(new SqlParameter("empType", entity.empType));
            sqlCmd.Parameters.Add(new SqlParameter("currentEmployer", entity.currentEmployer));
            sqlCmd.Parameters.Add(new SqlParameter("gross", entity.gross));
            sqlCmd.Parameters.Add(new SqlParameter("startDate", entity.startDate));
            sqlCmd.Parameters.Add(new SqlParameter("endDate", entity.endDate));
            sqlCmd.Parameters.Add(new SqlParameter("responsibilities", entity.responsibilities));

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

    public bool merge(EmploymentDTO entity)
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
            sqlCmd.CommandText = "updateEmployment";
            sqlCmd.Parameters.Add(new SqlParameter("userName", entity.userName));
            sqlCmd.Parameters.Add(new SqlParameter("title", entity.title));
            sqlCmd.Parameters.Add(new SqlParameter("company", entity.company));
            sqlCmd.Parameters.Add(new SqlParameter("industry", entity.industry));
            sqlCmd.Parameters.Add(new SqlParameter("town", entity.town));
            sqlCmd.Parameters.Add(new SqlParameter("province", entity.province));
            sqlCmd.Parameters.Add(new SqlParameter("country", entity.country));
            sqlCmd.Parameters.Add(new SqlParameter("empType", entity.empType));
            sqlCmd.Parameters.Add(new SqlParameter("currentEmployer", entity.currentEmployer));
            sqlCmd.Parameters.Add(new SqlParameter("gross", entity.gross));
            sqlCmd.Parameters.Add(new SqlParameter("startDate", entity.startDate));
            sqlCmd.Parameters.Add(new SqlParameter("endDate", entity.endDate));
            sqlCmd.Parameters.Add(new SqlParameter("responsibilities", entity.responsibilities));

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

    public bool remove(EmploymentDTO entity)
    {
        return this.removeByUserId(entity.userName, entity.startDate);
    }
}