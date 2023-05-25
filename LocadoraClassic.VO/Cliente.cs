using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraClassic.VO
{
    public class Cliente
    {
        public int id {  get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }

        public Cliente()
        {
        }

        public Cliente(int id, string nome, string endereco, string telefone, string cpf, string rg)
        {
            this.id = id;
            this.nome = nome;
            this.endereco = endereco;
            this.telefone = telefone;
            this.cpf = cpf;
            this.rg = rg;
        }

        public Cliente(int id)
        {
            this.id = id;
        }


    }
    
}
