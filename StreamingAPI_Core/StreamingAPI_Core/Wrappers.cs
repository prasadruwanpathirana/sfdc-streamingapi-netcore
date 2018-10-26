using System;
using System.Collections.Generic;
using System.Text;

namespace StreamingAPI_Core
{
    public class AuthResponse
    {
        public string access_token { get; set; }
        public string instance_url { get; set; }
        public string id { get; set; }
        public string token_type { get; set; }
        public string issued_at { get; set; }
        public string signature { get; set; }
    }
    public class Rootobject
    {
        public Data data { get; set; }
        public string channel { get; set; }
    }

    public class Data
    {
        public Event _event { get; set; }
        public Sobject sobject { get; set; }
    }

    public class Event
    {
        public DateTime createdDate { get; set; }
        public int replayId { get; set; }
        public string type { get; set; }
    }

    public class Sobject
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
