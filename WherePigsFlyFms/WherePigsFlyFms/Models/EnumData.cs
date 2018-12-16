using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WherePigsFlyFms.Models
{
    public class EnumData
    {
    }

    public enum PickListType
    {
        [Display(Name ="ANIMAL TYPE")]
        AnimalType,
        [Display(Name ="BREED")]
        Breed,
        [Display(Name ="STATE")]
        ST,
        [Display(Name ="VACCINATION")]
        VAC
    }
}