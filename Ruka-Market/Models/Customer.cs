﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ruka_Market.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage ="Tem de inserir um {0}")]
        [Display(Name = "Primeiro Nome")]
        public string FirstName { get; set; }

        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Tem de inserir um {0}")]
        [Display(Name = "Apelido")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Tem de inserir um {0}")]
        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} digitos", MinimumLength = 9)]
        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Tem de inserir um {0}")]
        [StringLength(100, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} digitos", MinimumLength = 3)]
        [Display(Name = "Morada")]
        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Tem de inserir um {0}")]
        [StringLength(20, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} digitos", MinimumLength = 5)]
        [Display(Name = "Nº Documento")]
        public string Document { get; set; }

        public int DocumentTypeID { get; set; }

        public virtual DocumentType DocumentType { get; set; }
    }
}