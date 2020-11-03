using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ToDoItemApi.Model.Configuration
{
    public sealed class GetOptions
    {
        public bool CaseSensitive { get; set; }

        [Required]
        public string FilterCriteria { get; set; }

        //public PagingOptions PagingOptions { get; set; }
    }
}
