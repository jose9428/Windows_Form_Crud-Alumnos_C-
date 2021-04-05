﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormCrudArrayNotas.models
{
    class Alumno
    {
        public static int cuenta = 1;
        public int codigo { get; set; }
        public string nombres { get; set; }
        public int nota1 { get; set; }
        public int nota2 { get; set; }

        public double notaFinal 
        {
            get {
                return (nota1 + nota2) / 2.0;
            }
        }
        public string mensaje 
        {
            get {
                return notaFinal >= 12 ? "Aprobo" : "No Aprobo";
            }
        }

        public void Asignar() {
            this.codigo = cuenta++;
        }
    }
}
