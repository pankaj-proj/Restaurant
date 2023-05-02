using static Mango.Web.SD;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Web.Models
{
    public class ApiRequest
    {
        public APIType apiType { get; set; } = APIType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

    }
}
