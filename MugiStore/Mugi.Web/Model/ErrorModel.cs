
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class ErrorModel
    {
        public ErrorModel(string id,string message)
        {
            this.Id = id;
            this.Message = message;
        }

        public string Id { get; set; }
        public string Message { get; set; }
    }
}
