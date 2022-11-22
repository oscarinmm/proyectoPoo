using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelosCore.Mantenedores;
using NegocioCore.Mantenedores;

namespace apiPOO.Controllers
{
  
    [ApiController]
    public class materialmayorController : ControllerBase
    {
        MaterialMayor MaterialMayor = new MaterialMayor();
        MaterialMayorBL MaterialMayorBL = new MaterialMayorBL();
        ErrorResponse error;
        [HttpPost]
        [Route("api/v1/MaterialMayor/nuevo")]
        public ActionResult Create(MaterialMayorDTO o)
        {
            try
            {
                MaterialMayor.codigo = o.codigo;
                MaterialMayor.nombre = o.nombre;
                MaterialMayor.marca = o.marca;
                MaterialMayor.modelo = o.modelo;
                MaterialMayor.estado = o.estado;
                return Ok(MaterialMayorBL.Create(MaterialMayor));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("api/v1/MaterialMayor/listar")]
        public ActionResult Listar()
        {
            try
            {               
                return Ok(convertList(MaterialMayorBL.Get(MaterialMayor)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/MaterialMayor/buscarcodigo")]
        public ActionResult Buscarcodigo(int codigo)
        {
            try
            {   MaterialMayor.codigo = codigo;
                return Ok(convert(MaterialMayorBL.GetById(MaterialMayor)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/MaterialMayor/buscarnombre")]
        public ActionResult BuscarNombre(string nombre)
        {
            try
            {
                MaterialMayor.nombre = nombre;
                return Ok(convertList(MaterialMayorBL.GetQuery(MaterialMayor)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpDelete]
        [Route("api/v1/MaterialMayor/eliminar")]
        public ActionResult Eliminar(MaterialMayorDTO o)
        {
            try
            {
                MaterialMayor.codigo = o.codigo;
                return Ok(MaterialMayorBL.Delete(MaterialMayor));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpPut]
        [Route("api/v1/MaterialMayor/actualizar")]
        public ActionResult Actualizar(MaterialMayorDTO o)
        {
            try
            {
                MaterialMayor.codigo = o.codigo;
                MaterialMayor.nombre = o.nombre;
                MaterialMayor.marca = o.marca;
                MaterialMayor.modelo = o.modelo;
                MaterialMayor.estado = o.estado;
                return Ok(MaterialMayorBL.Update(MaterialMayor));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        private List<MaterialMayorDTO> convertList(List<MaterialMayor> lista)
        {
            List<MaterialMayorDTO> list = new List<MaterialMayorDTO>();
            foreach (var item in lista)
            {
                MaterialMayorDTO el = new MaterialMayorDTO(item.codigo, item.nombre, item.marca, item.modelo, item.estado);
                list.Add(el);

            }
            return list;

        }
        private MaterialMayorDTO convert(MaterialMayor item)
        {
            MaterialMayorDTO obj = new MaterialMayorDTO(item.codigo, item.nombre, item.marca, item.modelo, item.estado);
            return obj;

        }
    }
}
