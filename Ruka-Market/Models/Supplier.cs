using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ruka_Market.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "Tem de introduzir um {0} para o Fornecedor")]
        [StringLength(30, ErrorMessage ="O campo {0} deverá conter entre {2} e {1} caracteres", MinimumLength = 3)]
        [Display(Name="Nome do fornecedor")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Tem de introduzir um {0} para o Fornecedor")]
        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nome do contacto")]
        public string ContactFirstName { get; set; }

        [Required(ErrorMessage = "Tem de introduzir um {0} para o Fornecedor")]
        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Apelido do Contacto")]
        public string ContactLastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage ="Tem de introduzir um {0}")]
        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} caracteres", MinimumLength = 9)]
        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Tem de introduzir uma {0}")]
        [StringLength(100, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} caracteres", MinimumLength = 20)]
        [Display(Name = "Morada")]
        public string Address { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
    }
}