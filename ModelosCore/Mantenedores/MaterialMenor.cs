using DataCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ModelosCore.Mantenedores
{
    public class MaterialMenor : IDataEntity
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public int cantidad { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }

        public MaterialMenor()
        {
            Data = new data();
            parametros = new List<Parametros>();    
        }
    }
}
