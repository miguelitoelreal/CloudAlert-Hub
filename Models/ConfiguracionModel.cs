namespace trabajo_de_SF2.Models;

public class ProveedorCloud
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? IconoUrl { get; set; }
    public string? Estado { get; set; }
    public string? ColorEstado { get; set; }
    public string? ClaveAcceso { get; set; }
    public string? TokenSecretoDisfrazado { get; set; }
    public string? TipoDato { get; set; }
    public string? ValorTipoDato { get; set; }
}

public class GrupoRespuesta
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Correo { get; set; }
    public string? Icono { get; set; }
}

public class ReglaMotor
{
    public int Id { get; set; }
    public string? Condicion { get; set; }
    public string? Descripccion { get; set; }
    public string? Accion { get; set; }
}

public class ConfiguracionPageModel
{
    public List<ProveedorCloud>? Proveedores { get; set; }
    public List<GrupoRespuesta>? Grupos { get; set; }
    public List<ReglaMotor>? Reglas { get; set; }
    public string? GrupoSeleccionadoManual { get; set; }
    public string? ResumenManual { get; set; }
}
