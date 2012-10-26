using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for  addressDAO
/// </summary>
public class VacancyKillerQuestionDAO : DAO_VacancyKillerQuestion_Interface
{
    public VacancyKillerQuestionDAO()
	{}

    public bool isFound(string vacancyNumber, string question)
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
            sqlCmd.CommandText = "select vacancyNumber from VacancyKillerQuestion where vacancyNumber = '" + vacancyNumber + "' AND question = '" + question + "'";

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

    public VacancyKillerQuestionDTO find(string vacancyNumber, string question)
    {
        VacancyKillerQuestionDTO info = new VacancyKillerQuestionDTO();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from VacancyKillerQuestion where vacancyNumber = '" + vacancyNumber + "' AND question = '" + question + "'";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    info.vacancyNumber = rdr["vacancyNumber"].ToString();
                    info.question = rdr["question"].ToString();
                    info.answer = rdr["answer"].ToString();
                   
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

    public bool removeByUserId(string vacancyNumber, string question)
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
            sqlCmd.CommandText = "deleteVacancyKillerQuestion";
            sqlCmd.Parameters.Add(new SqlParameter("vacancyNumber", vacancyNumber));
            sqlCmd.Parameters.Add(new SqlParameter("question", question));


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

    public List<VacancyKillerQuestionDTO> findAll()
    {
        VacancyKillerQuestionDTO info = null;
        List<VacancyKillerQuestionDTO> infos = new List<VacancyKillerQuestionDTO>();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from VacancyKillerQuestion";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    info = new VacancyKillerQuestionDTO();
                    info.vacancyNumber = rdr["vacancyNumber"].ToString();
                    info.question = rdr["question"].ToString();
                    info.answer = rdr["answer"].ToString();

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

    public bool presist(VacancyKillerQuestionDTO entity)
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
            sqlCmd.CommandText = "insertVacancyKillerQuestion";
            sqlCmd.Parameters.Add(new SqlParameter("vacancyNumber", entity.vacancyNumber));
            sqlCmd.Parameters.Add(new SqlParameter("question", entity.question));
            sqlCmd.Parameters.Add(new SqlParameter("answer", entity.answer));

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

    public bool merge(VacancyKillerQuestionDTO entity)
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
            sqlCmd.CommandText = "updateVacancyKillerQuestion";
            sqlCmd.Parameters.Add(new SqlParameter("vacancyNumber", entity.vacancyNumber));
            sqlCmd.Parameters.Add(new SqlParameter("question", entity.question));
            sqlCmd.Parameters.Add(new SqlParameter("answer", entity.answer));

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

    public bool remove(VacancyKillerQuestionDTO entity)
    {
        return this.removeByUserId(entity.vacancyNumber, entity.question);
    }
}