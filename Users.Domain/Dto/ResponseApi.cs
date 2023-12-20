using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Domain.Dto
{
    public class ResponseApi
    {
        public bool IsSuccess { get;set; }
        public string Messague { get;set; }
        public object Result { get; set; }
    }
}
