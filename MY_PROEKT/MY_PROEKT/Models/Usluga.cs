using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using MY_PROEKT.Models;

namespace MY_PROEKT.Models
{
            [Table("Usluga")] 
        public partial class Usluga
        {
            [Key]
        public int UslugaID { get; set; }
       
                [Display(Name = "Наименование услуги")]
        public string Name { get; set; }

                 [Display(Name = "Описание")]
        public string Description { get; set; }

                [Display(Name = "Стоимость услуги за год")]
        public decimal Price { get; set; }

        public virtual ICollection<Zayvka> zav { get; set; }
        public virtual ICollection<Dogovor> dog { get; set; }
       
    }
}