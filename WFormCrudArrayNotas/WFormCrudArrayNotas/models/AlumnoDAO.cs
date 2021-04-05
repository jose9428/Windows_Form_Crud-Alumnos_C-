using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormCrudArrayNotas.models
{
    class AlumnoDAO
    {
        List<Alumno> lista;

        public AlumnoDAO(){
            lista = new List<Alumno>();
            lista.Add(new Alumno { nombres = "Juan Alberto", nota1 = 12, nota2 = 15, codigo = Alumno.cuenta++ }); ;
            lista.Add(new Alumno { nombres = "Maria Carbajal", nota1 = 6, nota2 = 15, codigo = Alumno.cuenta++ });
        }

        public void Adicionar(Alumno a) {
            lista.Add(a);
        }

        public List<Alumno> Listar() {
            return lista;
        }

        public void Modificar(Alumno a , int indice) {
            lista[indice] = a;
        }

        public void Eliminar(int indice) {
            lista.RemoveAt(indice);
        }
    }
}
