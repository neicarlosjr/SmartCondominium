using SmartCondominium.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCondominium.Mapping

{
    public class UsuarioMapping : ClassMap<Usuario>
    {

        public UsuarioMapping()
        {
            Table("SCUSR");
            Id(u => u.Id).GeneratedBy.Increment().Column("USR_ID");
            Map(u => u.Nome).Index("SCUSR03").Column("USR_NOME");
            Map(u => u.Login).Index("SCUSR01").Column("USR_LOGIN");
            Map(u => u.Password).Column("USR_PSW");
            Map(u => u.Email).Index("SCUSR02").Column("USR_EMAIL");
            Map(u => u.Adm).Column("URS_ADM");
            Map(u => u.Edita).Column("USR_EDITA");
            Map(u => u.Pcp).Column("USR_PCP");
            Map(u => u.Foto).Column("USR_LOGIN");
            Map(u => u.CaminhoFoto).Column("USR_URL");
            Map(u => u.CodVendedor).Index("SCUSR04").Column("USR_CODVEN ");
        }



    }
}