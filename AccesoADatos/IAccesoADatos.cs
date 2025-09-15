using ApiWeb;

public interface IAccesoADatos
{
    public Cadeteria CrearCadeteria(string rutaArchivoCadeteria);
    public List<Cadete> CargarCadete(string rutaArchivoCadete);
}