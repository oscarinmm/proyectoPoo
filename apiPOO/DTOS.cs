namespace apiPOO
{
 
    
        public record MaterialMayorDTO(int codigo, string nombre, string marca, string modelo, string estado);
        public record ERADTO(int codigo, string marca, string estado, string tipo, int pertenece);
}
