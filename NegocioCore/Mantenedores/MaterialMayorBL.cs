using ModelosCore.Mantenedores;
using ModelosCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NegocioCore.Mantenedores
{
    public class MaterialMayorBL : ICrud<MaterialMayor>
    {
        ResponseExec resp = new ResponseExec();

        public ResponseExec Create(MaterialMayor o)
        {
            try
            {
                resp.error = !o.Data.execData("INSERT  INTO MaterialMayor(codigo, nombre, marca, modelo, estado) VALUES('" + o.codigo + "','" + o.nombre + "','" + o.marca + "','" + o.modelo + "','" + o.estado + "')");
                resp.mensaje = "Registro ingresado con éxito";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public ResponseExec Delete(MaterialMayor o)
        {
            try
            {
                resp.error = !o.Data.execData("DELETE FROM MaterialMayor WHERE codigo='" + o.codigo + "'");
                resp.mensaje = "Registro eliminado con éxito";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<MaterialMayor> Get(MaterialMayor o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM MaterialMayor"));
        }

        public MaterialMayor GetById(MaterialMayor o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM MaterialMayor WHERE codigo='" + o.codigo + "'")).FirstOrDefault();
        }

        public List<MaterialMayor> GetQuery(MaterialMayor o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM MaterialMayor WHERE nombre='" + o.nombre + "'"));
        }

        public ResponseExec Update(MaterialMayor o)
        {
            try
            {
                resp.error = !o.Data.execData("UPDATE MaterialMayor SET nombre='" + o.nombre + "', marca='" + o.marca + "', modelo='" + o.modelo + "', estado='" + o.estado + "', WHERE codigo='" + o.codigo + "'");
                resp.mensaje = "Datos actualizados con éxito";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }


        public List<MaterialMayor> convertToList(DataTable dt)
        {
            List<MaterialMayor> listado = new List<MaterialMayor>();

            foreach (DataRow item in dt.Rows)
            {
                MaterialMayor o = new MaterialMayor();
                o.codigo = int.Parse(item.ItemArray[0].ToString());
                o.nombre = item.ItemArray[1].ToString();
                o.marca = item.ItemArray[2].ToString();
                o.modelo = item.ItemArray[3].ToString();
                o.estado = item.ItemArray[4].ToString();
                listado.Add(o);
            }

            return listado;
        }
    }
}

