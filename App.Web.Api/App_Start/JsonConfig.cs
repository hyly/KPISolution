using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace App.Web.Api.App_Start
{
    public class JsonConfig
    {
        public static void RegisterJson()
        {
            // Currently we can only assume that dates coming out of the database are 
            // LOCAL timezone because the PN App server/DB server requires that either
            // the DB has the same timezone as the app server or that we use an offset 'hack'
            // so we need to format dates and times with the local offset when sending to the client
            // so that they are displayed in the same form on the browser (which is sensitive to
            // local time zones).
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
            jsonSettings.DateTimeZoneHandling = DateTimeZoneHandling.Unspecified;
            jsonSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            jsonSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = jsonSettings;
        }
    }
}