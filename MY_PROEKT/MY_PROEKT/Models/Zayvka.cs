using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using MY_PROEKT.Models;
using System.Data;



namespace MY_PROEKT.Models
{
    [Table("Zayvka")] 
    public partial class Zayvka
    {
         [Key]
        public int ZayvkaID { get; set; }
        
                    [Display(Name = "Дата заявки")]
             [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Datazayvka { get; set; }

          [Display(Name = "Наименование")]
        public int? UslugaId { get; set; }
       
        [Display(Name = "Статус")]
        public string Status { get; set; }

         [Display(Name = "Статус")]
        public int? UserId { get; set; }
        public virtual Usluga usluga { get; set; }
        public virtual UserProfile userp { get; set; }
    }
}