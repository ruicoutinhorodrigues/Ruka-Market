using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ruka_Market.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        [StringLength(30, ErrorMessage = "A {0} deverá ter entre {2} e {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Deve inserir uma {0}")]
        [Display(Name = "Descrição do produto")]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Tem de inserir um {0}")]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Tem de inserir uma {0}")]
        [Display(Name = "Quantidade")]
        public float Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}