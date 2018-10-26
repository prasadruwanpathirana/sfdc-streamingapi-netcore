using System;
using System.Collections.Generic;
using System.Text;

namespace StreamingAPI_Core
{
    class Constants
    {
        public static string USERNAME = "REPLACE WITH YOUR USERNAME";
        public static string PASSWORD = "REPLACE WITH YOUR PASSWORD";
        public static string TOKEN = "REPLACE WITH YOUR SECURITY TOKEN";
        public static string CONSUMER_KEY = "REPLACE WITH YOUR CONNECTED APP CONSUMER KEY";
        public static string CONSUMER_SECRET = "REPLACE WITH YOUR CONNECTED APP CONSUMER SECRET";
        public static string TOKEN_REQUEST_ENDPOINTURL = "https://login.salesforce.com/services/oauth2/token";
        public static string TOKEN_REQUEST_QUERYURL = "/services/data/v43.0/query?q=select+Id+,name+from+account+limit+10";
    
    }
}
