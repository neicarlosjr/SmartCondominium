
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace SmartCondominium.Models
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Login { get; set; }
        public virtual String Password { get; set; }
        public virtual String CaminhoFoto { get; set; }
        public virtual byte[] Foto { get; set; }
        public virtual String Email { get; set; }
        public virtual bool Adm { get; set; }
        public virtual bool Edita { get; set; }
        public virtual bool Pcp { get; set; }
        public virtual string CodVendedor { get; set; }
        [NotMapped]
        public virtual HttpPostedFileBase Perfil { get; set; }
    }
}