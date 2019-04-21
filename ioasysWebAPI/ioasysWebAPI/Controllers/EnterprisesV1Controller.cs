using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ioasysWebAPI.Models;

namespace ioasysWebAPI.Controllers
{
    public class EnterprisesV1Controller : ApiController
    {
        private EnterpriseModel db = new EnterpriseModel();

        // COMENTÁRIO:
        // Optei por utilizar a anotação Route para definir as rotas utilizadas para as diferentes requests.
        // Também utilizo o método .Select() para assegurar que estou retornando exatamente as mesmas propriedades do exemplo disponibilizado
        [Route("api/v1/enterprises")]
        public IHttpActionResult Get()
        {
            return Ok(new { enterprises = db.enterprises.ToList().Select(x => new {
                    x.id,
                    x.email_enterprise,
                    x.facebook,
                    x.twitter,
                    x.linkedin,
                    x.phone,
                    x.own_enterprise,
                    x.enterprise_name,
                    x.photo,
                    x.description,
                    x.city,
                    x.country,
                    x.value,
                    x.share_price,
                    x.enterprise_type
                })
            });
        }
        
        [Route("api/v1/enterprises")]
        public IHttpActionResult Get(int? enterprise_types)
        {
            var enterpriseByFilter = db.enterprises.Where(x => x.enterprise_type.id == enterprise_types).ToList();

            if (enterpriseByFilter == null)
            {
                return NotFound();
            }

            return Ok(new { enterprises = enterpriseByFilter.Select(x => new {
                    x.id,
                    x.email_enterprise,
                    x.facebook,
                    x.twitter,
                    x.linkedin,
                    x.phone,
                    x.own_enterprise,
                    x.enterprise_name,
                    x.photo,
                    x.description,
                    x.city,
                    x.country,
                    x.value,
                    x.share_price,
                    x.enterprise_type
                })
            });
        }
        
        [Route("api/v1/enterprises")]
        public IHttpActionResult Get(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                return Ok(new { enterprises = db.enterprises.Where(x => x.enterprise_name.ToLower().Contains(name.ToLower())).Select(x => new {
                        x.id,
                        x.email_enterprise,
                        x.facebook,
                        x.twitter,
                        x.linkedin,
                        x.phone,
                        x.own_enterprise,
                        x.enterprise_name,
                        x.photo,
                        x.description,
                        x.city,
                        x.country,
                        x.value,
                        x.share_price,
                        x.enterprise_type
                    })
                });
            }
            else
            {
                return Ok(new { enterprises = db.enterprises.ToList().Select(x => new {
                        x.id,
                        x.email_enterprise,
                        x.facebook,
                        x.twitter,
                        x.linkedin,
                        x.phone,
                        x.own_enterprise,
                        x.enterprise_name,
                        x.photo,
                        x.description,
                        x.city,
                        x.country,
                        x.value,
                        x.share_price,
                        x.enterprise_type
                    })
                });
            }

        }
        
        [Route("api/v1/enterprises")]
        public IHttpActionResult Get(int? enterprise_types, string name)
        {
            var enterpriseByFilter = db.enterprises.Where(x => x.enterprise_type.id == enterprise_types).ToList();

            if (!String.IsNullOrEmpty(name))
            {
                enterpriseByFilter = enterpriseByFilter.Where(x => x.enterprise_name.ToLower().Contains(name.ToLower())).ToList();
            }

            if (enterpriseByFilter == null)
            {
                return NotFound();
            }

            return Ok(new { enterprises = enterpriseByFilter.Select(x => new {
                    x.id,
                    x.email_enterprise,
                    x.facebook,
                    x.twitter,
                    x.linkedin,
                    x.phone,
                    x.own_enterprise,
                    x.enterprise_name,
                    x.photo,
                    x.description,
                    x.city,
                    x.country,
                    x.value,
                    x.share_price,
                    x.enterprise_type
                })
            });
        }
        
        [Route("api/v1/enterprises/{id}")]
        public IHttpActionResult Get(int id)
        {
            var enterpriseById = db.enterprises.FirstOrDefault(x => x.id == id);

            if (enterpriseById == null)
            {
                return NotFound();
            }

            return Ok(new { enterprise = new {
                    enterpriseById.id,
                    enterpriseById.email_enterprise,
                    enterpriseById.facebook,
                    enterpriseById.twitter,
                    enterpriseById.linkedin,
                    enterpriseById.phone,
                    enterpriseById.own_enterprise,
                    enterpriseById.enterprise_name,
                    enterpriseById.photo,
                    enterpriseById.description,
                    enterpriseById.city,
                    enterpriseById.country,
                    enterpriseById.value,
                    enterpriseById.share_price,
                    enterpriseById.enterprise_type
                }, success = true });
        }


        // COMENTÁRIO:
        // Apesar de este não ser um requisito, criei também um método POST para inserir novas empresas.
        // Este método serviu para testar o modelo que criei. Testei inserindo um objeto JSON com estrutura
        // semelhante ao exemplo disponibilizado, com duas diferenças: o objeto a ser inserid deve conter
        // apenas o ID do enterprise_type (em vez do objeto), e não deve conter o seu próprio ID (que é
        // gerado automaticamente ao ser inserido no banco de dados)
        [ResponseType(typeof(EnterpriseV1))]
        [Route("api/v1/enterprises/new")]
        public IHttpActionResult PostEnterpriseV1(EnterpriseV1 enterpriseV1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.enterprises.Add(enterpriseV1);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = enterpriseV1.id }, enterpriseV1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnterpriseV1Exists(int id)
        {
            return db.enterprises.Count(e => e.id == id) > 0;
        }
    }
}