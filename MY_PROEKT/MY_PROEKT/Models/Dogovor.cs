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
  
     [Table("Dogovor")] 
    public partial class Dogovor
    {
          [Key]
        public int Id { get; set; }
         
         [Display(Name = "Номер договора")]
        public string Nomer { get; set; }

          [Display(Name = "Дата договора")]
         [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
         
          public DateTime Data { get; set; }

         [Display(Name = "Имя клиента")]
        public int? UserId { get; set; }

        [Display(Name = "Название услуги")]
         public int? UslugaId { get; set; }

        [Display(Name = "Период заключения договора")]
         public string Period { get; set; }

          [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]

        [Display(Name = "Имя агента")]
        public string AgentFio{ get; set; }

         [Display(Name = "Сумма договора")]
         public decimal Summa { get; set; }


         public virtual Usluga usluga1 { get; set; }
         public virtual UserProfile user1 { get; set; }
    }
}
