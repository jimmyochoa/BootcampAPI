using Newtonsoft.Json;
using System.Collections.Generic;

namespace Proyecto.DTOs
{
    public class JokesApiDto
    {
        public List<string> MyArray { get; set; }
    }

    public class JokesApiRandom
    {
        public List<string> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }

    public class Result
    {
        public List<string> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }

    public class JokesApiQuery
    {
        public int total { get; set; }
        public List<Result> result { get; set; }
    }
}