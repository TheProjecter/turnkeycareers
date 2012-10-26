using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for AccountDAO
/// </summary>
public class VacancyDAO : DAO_Vacancy_Interface
{
    public VacancyDAO()
	{	}


    public bool isFound(string vacancyNumber)
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
            sqlCmd.CommandText = "select vacancyNumber from vacancy where vacancyNumber = '" + vacancyNumber + "'";

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

    public VacancyDTO find(string vacancyNumber)
    {
        VacancyDTO info = new VacancyDTO();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from vacancyNumber where vacancyNumber = '" + vacancyNumber + "'";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    info.vacancyNumber = rdr["vacancyNumber"].ToString();
                    info.viewStatus = rdr["viewStatus"].ToString();
                    info.title = rdr["title"].ToString();
                    info.description = rdr["description"].ToString();
                    info.department = rdr["department"].ToString();
                    info.site = rdr["site"].ToString();
                    info.startDate = DateTime.Parse(rdr["startDate"].ToString() );
                    info.endDate = DateTime.Parse(rdr["endDate"].ToString() );
                    info.viewCount = int.Parse(rdr["viewCount"].ToString() );
                    info.viewStatus = rdr["status"].ToString();
                    info.manager = rdr["manager"].ToString();
                    info.recruiter = rdr["recruiter"].ToString();
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

    public bool removeByUserId(string vacancyNumber)
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
            sqlCmd.CommandText = "deleteVacancy";
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

    public List<VacancyDTO> findAll()
    {
        VacancyDTO info = null;
        List<VacancyDTO> infos = new List<VacancyDTO>();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from Vacancy";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    info = new VacancyDTO();
                    info.vacancyNumber = rdr["vacancyNumber"].ToString();
                    info.viewStatus = rdr["viewStatus"].ToString();
                    info.title = rdr["title"].ToString();
                    info.description = rdr["description"].ToString();
                    info.department = rdr["department"].ToString();
                    info.site = rdr["site"].ToString();
                    info.startDate = DateTime.Parse(rdr["startDate"].ToString());
                    info.endDate = DateTime.Parse(rdr["endDate"].ToString());
                    info.viewCount = int.Parse(rdr["viewCount"].ToString());
                    info.viewStatus = rdr["status"].ToString();
                    info.manager = rdr["manager"].ToString();
                    info.recruiter = rdr["recruiter"].ToString();

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

    public bool presist(VacancyDTO entity)
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
            sqlCmd.CommandText = "insertVacancy";
            sqlCmd.Parameters.Add(new SqlParameter("vacancyNumber", entity.vacancyNumber));
            sqlCmd.Parameters.Add(new SqlParameter("viewStatus", entity.viewStatus));
            sqlCmd.Parameters.Add(new SqlParameter("title", entity.title));
            sqlCmd.Parameters.Add(new SqlParameter("description", entity.description));
            sqlCmd.Parameters.Add(new SqlParameter("department", entity.department));
            sqlCmd.Parameters.Add(new SqlParameter("site", entity.site));
            sqlCmd.Parameters.Add(new SqlParameter("startDate", entity.startDate));
            sqlCmd.Parameters.Add(new SqlParameter("endDate", entity.endDate));
            sqlCmd.Parameters.Add(new SqlParameter("viewCount", entity.viewCount));
            sqlCmd.Parameters.Add(new SqlParameter("status", entity.status));
            sqlCmd.Parameters.Add(new SqlParameter("manager", entity.manager));
            sqlCmd.Parameters.Add(new SqlParameter("recruiter", entity.recruiter));

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

    public bool merge(VacancyDTO entity)
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
            sqlCmd.CommandText = "updateVacancy";
            sqlCmd.Parameters.Add(new SqlParameter("vacancyNumber", entity.vacancyNumber));
            sqlCmd.Parameters.Add(new SqlParameter("viewStatus", entity.viewStatus));
            sqlCmd.Parameters.Add(new SqlParameter("title", entity.title));
            sqlCmd.Parameters.Add(new SqlParameter("description", entity.description));
            sqlCmd.Parameters.Add(new SqlParameter("department", entity.department));
            sqlCmd.Parameters.Add(new SqlParameter("site", entity.site));
            sqlCmd.Parameters.Add(new SqlParameter("startDate", entity.startDate));
            sqlCmd.Parameters.Add(new SqlParameter("endDate", entity.endDate));
            sqlCmd.Parameters.Add(new SqlParameter("viewCount", entity.viewCount));
            sqlCmd.Parameters.Add(new SqlParameter("status", entity.status));
            sqlCmd.Parameters.Add(new SqlParameter("manager", entity.manager));
            sqlCmd.Parameters.Add(new SqlParameter("recruiter", entity.recruiter));

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

    public bool remove(VacancyDTO entity)
    {
        return this.removeByUserId(entity.vacancyNumber);
    }
}