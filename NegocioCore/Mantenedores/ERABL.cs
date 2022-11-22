using ModelosCore;
using ModelosCore.Mantenedores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioCore.Mantenedores
{
    public class ERABL : ICrud<ERA>
    {
        ResponseExec resp = new ResponseExec();

        public ResponseExec Create(ERA o)
        {
            try
            {
                resp.error = !o.Data.execData("INSERT  INTO ERA(codigo, marca, estado, tipo, pertenece) VALUES('" + o.codigo + "','" + o.marca + "','" + o.estado + "','" + o.tipo + "','" + o.pertenece + "')");
                resp.mensaje = "Registro ingresado con éxito";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public ResponseExec Delete(ERA o)
        {
            try
            {
                resp.error = !o.Data.execData("DELETE FROM ERA WHERE codigo='" + o.codigo + "'");
                resp.mensaje = "Registro eliminado con éxito";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<ERA> Get(ERA o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM ERA"));
        }

        public ERA GetById(ERA o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM ERA WHERE codigo='" + o.codigo + "'")).FirstOrDefault();
        }

        public List<ERA> GetQuery(ERA o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM ERA WHERE marca='" + o.marca + "'"));
        }

        public ResponseExec Update(ERA o)
        {
            try
            {
                resp.error = !o.Data.execData("UPDATE ERA SET marca='" + o.marca + "', estado='" + o.estado + "', tipo='" + o.tipo + "', pertenece='" + o.pertenece + "', WHERE codigo='" + o.codigo + "'");
                resp.mensaje = "Datos actualizados con éxito";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }


        public List<ERA> convertToList(DataTable dt)
        {
            List<ERA> listado = new List<ERA>();

            foreach (DataRow item in dt.Rows)
            {
                ERA o = new ERA();
                o.codigo = int.Parse(item.ItemArray[0].ToString());
                o.marca = item.ItemArray[1].ToString();
                o.estado = item.ItemArray[2].ToString();
                o.tipo = item.ItemArray[3].ToString();
                o.pertenece = int.Parse(item.ItemArray[4].ToString());
                listado.Add(o);
            }

            return listado;
        }
    }
}
