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
        [Display(Name ="List Type")]
        public string ListType { get; set; }
        public string Text { get; set; }
        [Display(Name ="Is Deleted")]
        public bool IsDeleted { get; set; }
    }
}