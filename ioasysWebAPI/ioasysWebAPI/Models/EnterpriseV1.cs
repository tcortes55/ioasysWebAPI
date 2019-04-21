using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ioasysWebAPI.Models
{
    /// <summary>
    /// COMENTÁRIO:
    /// 
    /// Um dos requisitos da tarefa é possibilitar o versionamento da API.
    /// Optei por utilizar o sufixo V{version} para os modelos, por exemplo EnterpriseV1,
    /// e mapeá-los para a tabela correspondente no DB utilizando a anotação Table.
    /// </summary>
    [Table("enterprises")]
    public class EnterpriseV1
    {
        public int id { get; set; }
        public string email_enterprise { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string linkedin { get; set; }
        public string phone { get; set; }
        public bool own_enterprise { get; set; }
        public string enterprise_name { get; set; }
        public string photo { get; set; }
        public string description { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public int value { get; set; }
        public int share_price { get; set; }

        // COMENTÁRIO:
        // Há uma foreign key relacionando as tabelas de empresas (enterprises) e de tipos de empresas (enterprise_types)
        [ForeignKey("enterprise_type")]
        [Column("enterprise_type")]
        public int enterprise_typeID { get; set; }
        public virtual EnterpriseTypeV1 enterprise_type { get; set; }
    }
}