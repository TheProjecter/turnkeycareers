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
public class AddressDAO : DAO_Address_Interface
{

    public bool isFound(string userName, string addressType)
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
                sqlCmd.CommandText = "select userName from Address where userName = '" + userName + "' AND addressType = '" + addressType + "'";

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

    public AddressDTO find(string userName, string addressType)
    {
        AddressDTO add = new AddressDTO();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from Address where userName = '" + userName + "' AND addressType = '" + addressType + "'";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    add.userName = rdr["userName"].ToString();
                    add.addressType = rdr["addressType"].ToString();
                    add.unitNumber = int.Parse(rdr["unitNumber"].ToString());
                    add.street = rdr["street"].ToString();
                    add.suburb = rdr["suburb"].ToString();
                    add.town = rdr["town"].ToString();
                    add.province = rdr["province"].ToString();
                    add.country = rdr["country"].ToString();
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
        return add;
    }

    public bool removeByUserId(string userName, string addressType)
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
            sqlCmd.CommandText = "deleteAddress";
            sqlCmd.Parameters.Add(new SqlParameter("userName", userName));
            sqlCmd.Parameters.Add(new SqlParameter("addressType", addressType));


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

    public List<AddressDTO> findAll()
    {
        AddressDTO address = null;
        List<AddressDTO> addresses = new List<AddressDTO>();
        SqlConnection oConn = new SqlConnection();
        SqlCommand sqlCmd = null;

        try
        {
            oConn.ConnectionString = ConfigurationManager.AppSettings["conn"];
            oConn.Open();

            sqlCmd = oConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from Address";

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    address = new AddressDTO();
                    address.userName = rdr["userName"].ToString();
                    address.addressType = rdr["addressType"].ToString();
                    address.unitNumber = int.Parse(rdr["unitNumber"].ToString());
                    address.street = rdr["street"].ToString();
                    address.suburb = rdr["suburb"].ToString();
                    address.town = rdr["town"].ToString();
                    address.province = rdr["province"].ToString();
                    address.country = rdr["country"].ToString();

                    addresses.Add(address);
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
        return addresses;
    }

    public bool presist(AddressDTO entity)
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
            sqlCmd.CommandText = "insertAddress";
            sqlCmd.Parameters.Add(new SqlParameter("userName", entity.userName));
            sqlCmd.Parameters.Add(new SqlParameter("addressType", entity.addressType));
            sqlCmd.Parameters.Add(new SqlParameter("unitNumber", entity.unitNumber));
            sqlCmd.Parameters.Add(new SqlParameter("street", entity.street));
            sqlCmd.Parameters.Add(new SqlParameter("suburb", entity.suburb));
            sqlCmd.Parameters.Add(new SqlParameter("town", entity.town));
            sqlCmd.Parameters.Add(new SqlParameter("province", entity.province));
            sqlCmd.Parameters.Add(new SqlParameter("country", entity.country));

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

    public bool merge(AddressDTO entity)
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
            sqlCmd.CommandText = "updateAddress";
            sqlCmd.Parameters.Add(new SqlParameter("userName", entity.userName));
            sqlCmd.Parameters.Add(new SqlParameter("addressType", entity.addressType));
            sqlCmd.Parameters.Add(new SqlParameter("unitNumber", entity.unitNumber));
            sqlCmd.Parameters.Add(new SqlParameter("street", entity.street));
            sqlCmd.Parameters.Add(new SqlParameter("suburb", entity.suburb));
            sqlCmd.Parameters.Add(new SqlParameter("town", entity.town));
            sqlCmd.Parameters.Add(new SqlParameter("province", entity.province));
            sqlCmd.Parameters.Add(new SqlParameter("country", entity.country));

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

    public bool remove(AddressDTO entity)
    {
        return this.removeByUserId(entity.userName,entity.addressType);
    }
}