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
        [Display(Name ="STATE")]
        ST,
        [Display(Name ="VACCINATION")]
        VAC
    }

    public enum SearchSelectionType
    {
        [Display(Name ="NAME")]
        name,
        [Display(Name = "TAG NUMBER")]
        tagnumber,
        [Display(Name = "BREED")]
        breed,
        [Display(Name = "TYPE")]
        type
    }
}