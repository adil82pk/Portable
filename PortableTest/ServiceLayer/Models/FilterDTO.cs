using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models
{
    public class FilterDTO
    {
        public string Search { get; set; }
        public List<string> NewsPreferences { get; set; }
     
        //   public int? Page { get; set; } = 1;
     //   public int? PageSize { get; set; } = 20;
    }
}
