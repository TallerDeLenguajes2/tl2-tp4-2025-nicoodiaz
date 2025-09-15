using ApiWeb;

namespace ApiWeb;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;


    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.telefono = telefono;
        this.direccion = direccion;
    }

    public int Id { get => id; }
    public string Nombre { get => nombre; }
    public string Direccion { get => direccion; }
    public string Telefono { get => telefono; }


} 