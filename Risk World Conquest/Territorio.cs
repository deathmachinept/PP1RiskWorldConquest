using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Audio;

namespace Risk_World_Conquest
{
    class Territorio
    {
        public string Nome;
        public int índice;
        public int Infantaria_Presente;
        public int Identificação_do_Jogador_que_o_possui;
        string Continente_a_que_pertence;
        public Button botão;
        public List<string> Nomes_Territórios_Vizinhos;

        public Territorio(GraphicsDevice graphics,Texture2D textura_do_botão,string nome,string id_continente)
        {
            Nome = nome;
            Nomes_Territórios_Vizinhos = new List<string>();
            Identificação_do_Jogador_que_o_possui = -1;
            Infantaria_Presente = 0;
            Continente_a_que_pertence = id_continente;
            botão = new Button(graphics, textura_do_botão, new Vector2(0, 0));
        }

        public bool Está_Desocupado()
        {
            if (Identificação_do_Jogador_que_o_possui == -1 && Infantaria_Presente == 0)
                return true;
            else
                return false;
        }
    }
}
