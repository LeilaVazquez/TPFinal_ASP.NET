﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Categoria
    {

        public int Id { get; set; }

        public string Descrip { get; set; }

        public override string ToString()
        {
            return Descrip;
        }
    }
}
