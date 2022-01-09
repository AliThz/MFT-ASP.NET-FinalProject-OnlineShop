using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopProject.WebApi.Middlewares.ApiExceptionHandler
{
    public class ApiError
    {
        public string Id { get; set; }
        public short Status { get; set; }
        public string Code { get; set; }
        public string Links { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}
