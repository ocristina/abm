using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Xml;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/", Name ="ABM Test Web Service")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    const string QUERY_COMMAND = "/InputDocument/DeclarationList/Declaration[@Command = 'DEFAULT']";
    const string QUERY_SITE_ID = "/InputDocument/DeclarationList/Declaration/DeclarationHeader/SiteID";

    const int STRUCT_OK = 0;
    const int ERR_INVALID_COMM = -1;
    const int ERR_INVALID_SITE = -2;
    const int ERR_OTHER = -3;

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public int CheckDeclarationList(string inputDoc)
    {
        XmlDocument xmlDocument = new XmlDocument();
        XmlNode root,declaration,siteId;

        try
        {
            xmlDocument.LoadXml(inputDoc);
        }
        catch (XmlException xception)
        {
            return ERR_OTHER;  // Parsing exception (not valid XML?)
        }

        root = xmlDocument.DocumentElement;
        if (root.Name != "InputDocument")
            return ERR_OTHER; // Root Element <> InputDocument

        if ((root.ChildNodes.Count != 1) || (root.ChildNodes[0].Name != "DeclarationList"))
            return ERR_OTHER;     // First child <> Declaration List


        declaration = root.SelectSingleNode(QUERY_COMMAND);
        if (declaration == null)
        {
            return ERR_INVALID_COMM;
        }
        siteId = root.SelectSingleNode(QUERY_SITE_ID);
        if (siteId.InnerText != "DUB")
            return ERR_INVALID_SITE;
        return STRUCT_OK;
    }



}
