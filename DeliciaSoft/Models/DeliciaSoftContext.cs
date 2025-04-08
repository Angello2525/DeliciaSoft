using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DeliciaSoft.Models;

public partial class DeliciaSoftContext : DbContext
{
    public DeliciaSoftContext()
    {
    }

    public DeliciaSoftContext(DbContextOptions<DeliciaSoftContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaInsumo> CategoriaInsumos { get; set; }

    public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<DetalleProduccion> DetalleProduccions { get; set; }

    public virtual DbSet<DetalleProductoGeneral> DetalleProductoGenerals { get; set; }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<EstadoProduccion> EstadoProduccions { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PersonaJuridica> PersonaJuridicas { get; set; }

    public virtual DbSet<PersonaNatural> PersonaNaturals { get; set; }

    public virtual DbSet<Produccion> Produccions { get; set; }

    public virtual DbSet<ProduccionEstado> ProduccionEstados { get; set; }

    public virtual DbSet<ProductoCompra> ProductoCompras { get; set; }

    public virtual DbSet<ProductoGeneral> ProductoGenerals { get; set; }

    public virtual DbSet<ProductoPersonalizado> ProductoPersonalizados { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-Q9SMJM6\\MSSQLSERVER01;Initial Catalog=DeliciaSoft;integrated security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaInsumo>(entity =>
        {
            entity.HasKey(e => e.IdCategoriaInsumos).HasName("PK__Categori__85A0A3B3776D297A");

            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.NombreCategoria).HasMaxLength(100);
        });

        modelBuilder.Entity<CategoriaProducto>(entity =>
        {
            entity.HasKey(e => e.IdCategoriaProducto).HasName("PK__Categori__8A4F21C30A359931");

            entity.ToTable("CategoriaProducto");

            entity.Property(e => e.DescripcionProducto).HasMaxLength(300);
            entity.Property(e => e.NombreCategoria).HasMaxLength(100);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D594664223E67599");

            entity.ToTable("Cliente");

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Barrio).HasMaxLength(100);
            entity.Property(e => e.Celular).HasMaxLength(20);
            entity.Property(e => e.Ciudad).HasMaxLength(100);
            entity.Property(e => e.Contrasena).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.NumeroDocumento).HasMaxLength(50);
            entity.Property(e => e.TipoDocumento).HasMaxLength(50);
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__Compra__0A5CDB5CD08FB3CE");

            entity.ToTable("Compra");

            entity.Property(e => e.Iva).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.MetodoPago).HasMaxLength(100);
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__Compra__IdProvee__48CFD27E");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DetalleC__E43646A5ACD87217");

            entity.ToTable("DetalleCompra");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnidadMedida).HasMaxLength(50);

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdCompra)
                .HasConstraintName("FK__DetalleCo__IdCom__4D94879B");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DetalleCo__IdPro__4E88ABD4");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetallePedido).HasName("PK__DetalleP__48AFFD9536559D81");

            entity.ToTable("DetallePedido");

            entity.Property(e => e.Iva).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__DetallePe__IdPed__5629CD9C");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DetallePe__IdPro__571DF1D5");
        });

        modelBuilder.Entity<DetalleProduccion>(entity =>
        {
            entity.HasKey(e => e.IdDetalleProduccion).HasName("PK__DetalleP__2BD8C21E1E60AFF9");

            entity.ToTable("DetalleProduccion");

            entity.Property(e => e.CantidadProducto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProductoGeneralNavigation).WithMany(p => p.DetalleProduccions)
                .HasForeignKey(d => d.IdProductoGeneral)
                .HasConstraintName("FK__DetallePr__IdPro__72C60C4A");

            entity.HasOne(d => d.IdProductoPersonalizadoNavigation).WithMany(p => p.DetalleProduccions)
                .HasForeignKey(d => d.IdProductoPersonalizado)
                .HasConstraintName("FK__DetallePr__IdPro__73BA3083");
        });

        modelBuilder.Entity<DetalleProductoGeneral>(entity =>
        {
            entity.HasKey(e => e.IdDetalleGeneral).HasName("PK__DetalleP__9662848868832B68");

            entity.ToTable("DetalleProductoGeneral");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnidadMedida).HasMaxLength(50);

            entity.HasOne(d => d.IdProductoGeneralNavigation).WithMany(p => p.DetalleProductoGenerals)
                .HasForeignKey(d => d.IdProductoGeneral)
                .HasConstraintName("FK__DetallePr__IdPro__693CA210");
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__DetalleV__AAA5CEC26A7173AE");

            entity.Property(e => e.Iva).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DetalleVe__IdPro__5DCAEF64");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__DetalleVe__IdVen__5CD6CB2B");
        });

        modelBuilder.Entity<EstadoProduccion>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__EstadoPr__FBB0EDC1B5E00916");

            entity.ToTable("EstadoProduccion");

            entity.Property(e => e.NombreEstado).HasMaxLength(100);
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.IdInsumo).HasName("PK__Insumos__F378A2AF42B0EBA8");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Imagen).HasMaxLength(200);
            entity.Property(e => e.Marca).HasMaxLength(100);
            entity.Property(e => e.NombreInsumo).HasMaxLength(100);
            entity.Property(e => e.UnidadMedida).HasMaxLength(50);

            entity.HasOne(d => d.IdCategoriaInsumosNavigation).WithMany(p => p.Insumos)
                .HasForeignKey(d => d.IdCategoriaInsumos)
                .HasConstraintName("FK__Insumos__IdCateg__3E52440B");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedido__9D335DC3ED9A4274");

            entity.ToTable("Pedido");

            entity.Property(e => e.MetodoPago).HasMaxLength(100);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Pedido__IdClient__534D60F1");
        });

        modelBuilder.Entity<PersonaJuridica>(entity =>
        {
            entity.HasKey(e => e.IdProveedorJuridico).HasName("PK__PersonaJ__A732D0C49DA2F879");

            entity.ToTable("PersonaJuridica");

            entity.Property(e => e.NitEmpresa).HasMaxLength(100);
            entity.Property(e => e.NombreEmpresa).HasMaxLength(200);

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.PersonaJuridicas)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__PersonaJu__IdPro__4316F928");
        });

        modelBuilder.Entity<PersonaNatural>(entity =>
        {
            entity.HasKey(e => e.IdProveedorNatural).HasName("PK__PersonaN__426448FA0B7A5B90");

            entity.ToTable("PersonaNatural");

            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Documento).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.PersonaNaturals)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__PersonaNa__IdPro__45F365D3");
        });

        modelBuilder.Entity<Produccion>(entity =>
        {
            entity.HasKey(e => e.IdProduccion).HasName("PK__Producci__3137BD835260B380");

            entity.ToTable("Produccion");

            entity.Property(e => e.NumeroPedido).HasMaxLength(100);
            entity.Property(e => e.ProductoAelaborar)
                .HasMaxLength(100)
                .HasColumnName("ProductoAElaborar");
        });

        modelBuilder.Entity<ProduccionEstado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Produccion_Estado");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany()
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Produccio__IdEst__6FE99F9F");

            entity.HasOne(d => d.IdProduccionNavigation).WithMany()
                .HasForeignKey(d => d.IdProduccion)
                .HasConstraintName("FK__Produccio__IdPro__6EF57B66");
        });

        modelBuilder.Entity<ProductoCompra>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210D9E9DC8E");

            entity.ToTable("ProductoCompra");

            entity.Property(e => e.NombreProducto).HasMaxLength(100);
            entity.Property(e => e.UnidadMedida).HasMaxLength(50);
        });

        modelBuilder.Entity<ProductoGeneral>(entity =>
        {
            entity.HasKey(e => e.IdProductoGeneral).HasName("PK__Producto__C28F19FB179E7CC7");

            entity.ToTable("ProductoGeneral");

            entity.Property(e => e.CantidadProducto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Imagen).HasMaxLength(200);
            entity.Property(e => e.NombreProducto).HasMaxLength(100);
            entity.Property(e => e.PrecioProducto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCategoriaProductoNavigation).WithMany(p => p.ProductoGenerals)
                .HasForeignKey(d => d.IdCategoriaProducto)
                .HasConstraintName("FK__ProductoG__IdCat__66603565");
        });

        modelBuilder.Entity<ProductoPersonalizado>(entity =>
        {
            entity.HasKey(e => e.IdProductoPersonalizado).HasName("PK__Producto__48F77C23BD4473D1");

            entity.ToTable("ProductoPersonalizado");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion).HasMaxLength(300);
            entity.Property(e => e.Imagen).HasMaxLength(200);
            entity.Property(e => e.Producto).HasMaxLength(100);
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__E8B631AF412A8266");

            entity.ToTable("Proveedor");

            entity.Property(e => e.Celular).HasMaxLength(20);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.TipoProveedor).HasMaxLength(50);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584C21E3EE16");

            entity.ToTable("Rol");

            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Rol1)
                .HasMaxLength(50)
                .HasColumnName("Rol");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.IdSede).HasName("PK__Sede__A7780DFF91E10DF7");

            entity.ToTable("Sede");

            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Horarios).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF97A8DE6FFA");

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Barrio).HasMaxLength(100);
            entity.Property(e => e.Celular).HasMaxLength(20);
            entity.Property(e => e.Ciudad).HasMaxLength(100);
            entity.Property(e => e.Contrasena).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.NumeroDocumento).HasMaxLength(50);
            entity.Property(e => e.TipoDocumento).HasMaxLength(50);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuarios__IdRol__398D8EEE");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Venta__BC1240BD238DAF01");

            entity.Property(e => e.MetodoPago).HasMaxLength(100);
            entity.Property(e => e.Sede).HasMaxLength(100);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Venta__IdCliente__59FA5E80");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
