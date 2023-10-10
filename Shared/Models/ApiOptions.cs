using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class ApiOptions
    {
        public const string ApiName = "ApiOptions";
        public int Id { get; set; }
        public string BaseAddress { get; set; }
    }
}
