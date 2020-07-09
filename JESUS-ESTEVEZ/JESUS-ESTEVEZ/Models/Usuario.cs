using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JESUS_ESTEVEZ.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "El campo nombre es requerido.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo genero es requerido.")]
        public Genre Genero { get; set; }
        [Required(ErrorMessage = "El campo cedula es requerido.")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "El campo fecha de nacimiento es requerido.")]
        public DateTime Nacimiento { get; set; }
        [Required(ErrorMessage = "Este campo departamento es requerido.")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "El campo cargo es requerido.")]
        public string Cargo { get; set; }
        [Required(ErrorMessage = "El campo supervisor es requerido.")]
        public string Supervisor { get; set; }
        public Departamento Department { get; set; }

        public class UsuarioMapper
        {
            public UsuarioMapper(EntityTypeBuilder<Usuario> mapper) 
            {
                mapper.HasKey(u => u.Cedula);
                mapper.Property(u => u.Nombre).HasColumnName("Nombre");
                mapper.Property(u => u.Genero).HasColumnName("Genero");
                mapper.Property(u => u.Nacimiento).HasColumnName("Nacimiento");
                mapper.Property(u => u.DepartmentId).HasColumnName("DepartamentoId");
                mapper.Property(u => u.Cargo).HasColumnName("Cargo");
                mapper.Property(u => u.Supervisor).HasColumnName("Supervisor");
                mapper.HasOne(u => u.Department);
            }
        }
    }
        
    public enum Genre
    {
        M, 
        F
    }
}
