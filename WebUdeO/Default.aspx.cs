using BLUdeo.Class;
using Modelos.Persona;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUdeO
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btnGetData_Click(object sender, EventArgs e)
        {
            var bl = new Persona();
            Collection<PersonaModel> persona =  bl.GetPersonaByID();
            gvData.DataSource = persona;
            gvData.DataBind();
        }
    }
}