using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelosCore.Mantenedores;
using NegocioCore.Mantenedores;

namespace apiPOO.Controllers
{
  
    [ApiController]
    public class ERAController : ControllerBase
    {
        ERA era = new ERA();
        ERABL eraBL = new ERABL();
        ErrorResponse error;
        [HttpPost]
        [Route("api/v1/ERA/nuevo")]
        public ActionResult Create(ERADTO o)
        {
            try
            {
                era.codigo = o.codigo;
                era.marca = o.marca;
                era.estado = o.estado;
                era.tipo = o.tipo;
                era.pertenece = o.pertenece;
                return Ok(eraBL.Create(era));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("api/v1/ERA/listar")]
        public ActionResult Listar()
        {
            try
            {               
                return Ok(convertList(eraBL.Get(era)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/ERA/buscarcodigo")]
        public ActionResult Buscarcodigo(int codigo)
        {
            try
            {   era.codigo = codigo;
                return Ok(convert(eraBL.GetById(era)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/ERA/buscarnombre")]
        public ActionResult BuscarNombre(string marca)
        {
            try
            {
                era.marca = marca;
                return Ok(convertList(eraBL.GetQuery(era)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpDelete]
        [Route("api/v1/ERA/eliminar")]
        public ActionResult Eliminar(ERADTO o)
        {
            try
            {
                era.codigo = o.codigo;
                return Ok(eraBL.Delete(era));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpPut]
        [Route("api/v1/ERA/actualizar")]
        public ActionResult Actualizar(ERADTO o)
        {
            try
            {
                era.codigo = o.codigo;
                era.marca = o.marca;
                era.estado = o.estado;
                era.tipo = o.tipo;
                return Ok(eraBL.Update(era));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        private List<ERADTO> convertList(List<ERA> lista)
        {
            List<ERADTO> list = new List<ERADTO>();
            foreach (var item in lista)
            {
                ERADTO el = new ERADTO(item.codigo, item.marca, item.estado,item.tipo,item.pertenece);
                list.Add(el);

            }
            return list;

        }
        private ERADTO convert(ERA item)
        {
            ERADTO obj = new ERADTO(item.codigo, item.marca, item.estado, item.tipo, item.pertenece);
            return obj;

        }
    }
}
