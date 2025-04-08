using System;
using System.Collections.Generic;

namespace DeliciaSoft.Models;

public partial class ProductoPersonalizado
{
    public int IdProductoPersonalizado { get; set; }

    public string? Producto { get; set; }

    public decimal? Cantidad { get; set; }

    public string? Descripcion { get; set; }

    public string? Imagen { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetalleProduccion> DetalleProduccions { get; set; } = new List<DetalleProduccion>();
}
