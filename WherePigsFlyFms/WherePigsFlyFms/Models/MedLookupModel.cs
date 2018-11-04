using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WherePigsFlyFms.Models
{
    [Table("Lookup")]
    public class MedLookupModel
    {
        [Key]
        public int LookupId { get; set; }
        public string Description { get; set; }
    }
}