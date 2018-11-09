using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WherePigsFlyFms.Models
{
    [Table("Attachments")]
    public class AttachmentModel
    {
        [Key]
        public int AttachmentId { get; set; }
        public string AttachmentType { get; set; }
        public string FileName { get; set; }
        public string BaseData { get; set; }

        public int FK_Animal_Id { get; set; }
        [ForeignKey("FK_Animal_Id")]
        public Animals Animal { get; set; }
    }
}
