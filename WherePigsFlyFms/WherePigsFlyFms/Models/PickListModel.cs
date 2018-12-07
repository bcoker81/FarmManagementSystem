using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WherePigsFlyFms.Models
{
    [Table("PickLists")]
    public class PickListModel
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }
        public string ListType { get; set; }
        public string Text { get; set; }
        public bool IsDeleted { get; set; }
    }
}