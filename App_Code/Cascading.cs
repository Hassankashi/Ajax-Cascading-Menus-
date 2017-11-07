//' (c) Copyright Microsoft Corporation.
//' This source is subject to the Microsoft Public License.
//' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
//' All other rights reserved.
//'*-------------------------------*
//'*                               *
//'*      Mahsa Hassankashi        *
//'*     info@mahsakashi.com       *
//'*   http://www.mahsakashi.com   * 
//'*     kashi_mahsa@yahoo.com     * 
//'*                               *
//'*                               *
//'*-------------------------------*
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using AjaxControlToolkit;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Xml;

/// <summary>
/// Summary description for Cascading
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class Cascading : System.Web.Services.WebService {

    public Cascading () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
      public CascadingDropDownNameValue[] GetCountries(string knownCategoryValues , string category) 
    {
        //ADO.Net
        SqlConnection cn = new SqlConnection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string strCn = "data source=.;Initial Catalog=DB;Integrated Security=True";
        cn.ConnectionString = strCn;
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;

        cmd.CommandText = "select * from tblCountry";

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        catch
        {
        }
        finally
        {
            cn.Close();
        }
        dt = ds.Tables[0];

          List<CascadingDropDownNameValue> CountryValues =new List<CascadingDropDownNameValue>();
          
          foreach (DataRow row  in dt.Rows)
          {
              CountryValues.Add(new CascadingDropDownNameValue(row["Country"].ToString(), row["IDC"].ToString()));
          }

          return CountryValues.ToArray();
    }


    [WebMethod]
    public CascadingDropDownNameValue[] GetCities(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        //'ContainsKey("Country") is one of property in Ajaxcontroltoolkit
        int countryId;
         countryId = System.Convert.ToInt32(kv["Country"]);
      

        //ADO.Net
        SqlConnection cn = new SqlConnection();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string strCn = "data source=.;Initial Catalog=DB;Integrated Security=True";
        cn.ConnectionString = strCn;
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        //-----I Defined a parameter instead of passing value directly to prevent sql injection--------//
        cmd.CommandText = "select * from tblCity where CountryID=@myParameter Order by City";
        cmd.Parameters.AddWithValue("@myParameter", countryId.ToString());
      
        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        catch
        {
        }
        finally
        {
            cn.Close();
        }
        dt = ds.Tables[0];

        List<CascadingDropDownNameValue> CityValues = new List<CascadingDropDownNameValue>();
      


        foreach (DataRow row in dt.Rows)
        {
            CityValues.Add(new CascadingDropDownNameValue(row["City"].ToString(), row["ID"].ToString()));
        }

        return CityValues.ToArray();
    }
}

