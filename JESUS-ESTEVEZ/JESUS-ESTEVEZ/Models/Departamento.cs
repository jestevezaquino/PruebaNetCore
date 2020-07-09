using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JESUS_ESTEVEZ.Models
{
    public class Departamento
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public class DepartamentoMapper
        {
            public DepartamentoMapper(EntityTypeBuilder<Departamento> mapper)
            {
                mapper.HasKey(d => d.Codigo);
                mapper.Property(d => d.Nombre).HasColumnName("Nombre");
            }
        }
    }
}
