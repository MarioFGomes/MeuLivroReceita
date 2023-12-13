﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade; 
public class Following: EntidadeBase 
{
    public Guid usuarioId { get; set; }
    public Guid seguidoId { get; set; }
    public Usuario usuario { get; set; }
    public Usuario seguido { get; set; }
}