﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Domains
{
    public class Raca
    {
        // CRUD
        public int IdRaca { get; set; }
        public string Descricao { get; set; }
        public int IdTipoPet { get; set; }
    }
}