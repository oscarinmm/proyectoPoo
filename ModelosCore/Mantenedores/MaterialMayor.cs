using DataCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosCore.Mantenedores
{
    public class MaterialMayor : IDataEntity
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string estado { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }

        public MaterialMayor()
        {
            Data = new data();
            parametros = new List<Parametros>();
        }
    }
}
