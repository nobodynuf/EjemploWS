using CapaAAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for Usuario
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Usuario : System.Web.Services.WebService
{

    public Usuario()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public void Add(decimal rutUsuario)
    {
        using (Entities e = new Entities())
        {
            try
            {
                e.USUARIO.Add(new USUARIO()
                {
                    RUT = rutUsuario
                });
                e.SaveChanges();
            }
            catch (Exception)
            {
                return;
            }
        }
    }

    [WebMethod]
    public List<USUARIO> Read()
    {
        using (Entities e = new Entities())
        {
            IQueryable<USUARIO> userList = from usuario in e.USUARIO
                                           select usuario;
            if (userList.Count() != 0)
            {
                return userList.ToList();
            }
        }
        return null;
    }
}
