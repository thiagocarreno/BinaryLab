using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Geotargeting;

namespace GeoTargeting.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Location();
            }
        }

        private void Location()
        {
            // Full path to GeoLiteCity.dat file
            string FullDBPath = Server.MapPath("App_Data/GeoLiteCity.dat");
            // Visitor's IP address
            string VisitorIP = Request.ServerVariables["REMOTE_ADDR"];

            // Create objects needed for geo targeting
            Geotargeting.LookupService ls = new Geotargeting.LookupService(FullDBPath, Geotargeting.LookupService.GEOIP_STANDARD);
            Geotargeting.Location visitorLocation = ls.getLocation(VisitorIP);

            // Get geo targeting data 
            Response.Write("Your IP Address: " + VisitorIP + "<br />");
            Response.Write("Your country: " + visitorLocation.countryName + "<br />");
            Response.Write("Your country code: " + visitorLocation.countryCode + "<br />");
            Response.Write("Your region: " + visitorLocation.region + "<br />");
            Response.Write("Your city: " + visitorLocation.city + "<br />");
            Response.Write("Your postal code: " + visitorLocation.postalCode + "<br />");
            Response.Write("Area code: " + visitorLocation.area_code + "<br />");
            Response.Write("dma: " + visitorLocation.dma_code + "<br />");
            Response.Write("Latitude: " + visitorLocation.latitude + "<br />");
            Response.Write("Longitude: " + visitorLocation.longitude + "<br />");
        }
    }
}