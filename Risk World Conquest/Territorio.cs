using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Risk_World_Conquest
{
    class Territorio
    {
        public string Nome;
        int Identificação_do_Jogador_que_o_possui;
        string Continente_a_que_pertence;
        public List<string> Nomes_Territórios_Vizinhos;

        public Territorio(string nome,string id_continente)
        {
            Nome = nome;
            Nomes_Territórios_Vizinhos = new List<string>();
            Identificação_do_Jogador_que_o_possui = -1;
            Continente_a_que_pertence = id_continente;
        }
    }
}
