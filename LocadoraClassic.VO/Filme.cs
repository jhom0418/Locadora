using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraClassic.VO
{
    public class Filme
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string duracao { get; set; }
        public string sinopse { get;set; }
        public bool locado { get; set; }

        public Filme()
        {
        }

        public Filme(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public Filme(int id, string nome, string duracao, string sinopse, bool locado)
        {
            this.id = id;
            this.nome = nome;
            this.duracao = duracao;
            this.sinopse = sinopse;
            this.locado = locado;
        }
    }
}
