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
    class Tabuleiro
    {
        public Territorio[] Territorios;

        public Tabuleiro(GraphicsDevice graphics,Texture2D Textura_Botões) //Construtor do Tabuleiro, vai criar os territórios, definir os vizinhos destes e assinalar as cores do jogador que os possui (cinzento significa que não tem dono)
        {
            Territorios = new Territorio[42];
            //0-8 América do Norte
            Territorios[0] = new Territorio(graphics,Textura_Botões, "Alaska", "América do Norte");
            Territorios[0].botão.Posição = new Vector2(100, 100);
            Territorios[1] = new Territorio(graphics, Textura_Botões, "Território Noroeste", "América do Norte");
            Territorios[1].botão.Posição = new Vector2(204, 102);
            Territorios[2] = new Territorio(graphics, Textura_Botões, "Alberta", "América do Norte");
            Territorios[2].botão.Posição = new Vector2(209, 164);
            Territorios[3] = new Territorio(graphics, Textura_Botões, "Estados Unidos Oeste", "América do Norte");
            Territorios[3].botão.Posição = new Vector2(210, 244);
            Territorios[4] = new Territorio(graphics, Textura_Botões, "Ontario", "América do Norte");
            Territorios[4].botão.Posição = new Vector2(285, 175);
            Territorios[5] = new Territorio(graphics, Textura_Botões, "Canadá Este", "América do Norte");
            Territorios[5].botão.Posição = new Vector2(383, 176);
            Territorios[6] = new Territorio(graphics, Textura_Botões, "Estados Unidos Este", "América do Norte");
            Territorios[6].botão.Posição = new Vector2(308, 270);
            Territorios[7] = new Territorio(graphics, Textura_Botões, "México", "América do Norte");
            Territorios[7].botão.Posição = new Vector2(225, 329);
            Territorios[8] = new Territorio(graphics, Textura_Botões, "Gronelândia", "América do Norte");
            Territorios[8].botão.Posição = new Vector2(468, 65);
            //9-12 América do Sul
            Territorios[9] = new Territorio(graphics, Textura_Botões, "Venezuela", "América do Sul");
            Territorios[9].botão.Posição = new Vector2(313, 400);
            Territorios[10] = new Territorio(graphics, Textura_Botões, "Brasil", "América do Sul");
            Territorios[10].botão.Posição = new Vector2(410,470);
            Territorios[11] = new Territorio(graphics, Textura_Botões, "Peru", "América do Sul");
            Territorios[11].botão.Posição = new Vector2(335,495);
            Territorios[12] = new Territorio(graphics, Textura_Botões, "Argentina", "América do Sul");
            Territorios[12].botão.Posição = new Vector2(340, 570);
            //13-18 África
            Territorios[13] = new Territorio(graphics, Textura_Botões, "Norte de África", "África");
            Territorios[13].botão.Posição = new Vector2(620,440);
            Territorios[14] = new Territorio(graphics, Textura_Botões, "Egipto", "África");
            Territorios[14].botão.Posição = new Vector2(720,415);
            Territorios[15] = new Territorio(graphics, Textura_Botões, "África do Este", "África");
            Territorios[15].botão.Posição = new Vector2(805,510);
            Territorios[16] = new Territorio(graphics, Textura_Botões, "África Central", "África");
            Territorios[16].botão.Posição = new Vector2(725,535);
            Territorios[17] = new Territorio(graphics, Textura_Botões, "África do Sul", "África");
            Territorios[17].botão.Posição = new Vector2(735,635);
            Territorios[18] = new Territorio(graphics, Textura_Botões, "Madagáscar", "África");
            Territorios[18].botão.Posição = new Vector2(853,630);
            //19-25 Europa
            Territorios[19] = new Territorio(graphics, Textura_Botões, "Europa Ocidental", "Europa");
            Territorios[19].botão.Posição = new Vector2(565,335);
            Territorios[20] = new Territorio(graphics, Textura_Botões, "Grã-Bretanha", "Europa");
            Territorios[20].botão.Posição = new Vector2(567,238);
            Territorios[21] = new Territorio(graphics, Textura_Botões, "Islândia", "Europa");
            Territorios[21].botão.Posição = new Vector2(568,140);
            Territorios[22] = new Territorio(graphics, Textura_Botões, "Norte da Europa", "Europa");
            Territorios[22].botão.Posição = new Vector2(670,240);
            Territorios[23] = new Territorio(graphics, Textura_Botões, "Sul da Europa", "Europa");
            Territorios[23].botão.Posição = new Vector2(683,290);
            Territorios[24] = new Territorio(graphics, Textura_Botões, "Escandinávia", "Europa");
            Territorios[24].botão.Posição = new Vector2(658,150);
            Territorios[25] = new Territorio(graphics, Textura_Botões, "Rússia", "Europa");
            Territorios[25].botão.Posição = new Vector2(790,195);
            //26-37 Ásia
            Territorios[26] = new Territorio(graphics, Textura_Botões, "Médio-Oriente", "Ásia");
            Territorios[26].botão.Posição = new Vector2(820,380);
            Territorios[27] = new Territorio(graphics, Textura_Botões, "Afeganistão", "Ásia");
            Territorios[27].botão.Posição = new Vector2(900,266);
            Territorios[28] = new Territorio(graphics, Textura_Botões, "Ural", "Ásia");
            Territorios[28].botão.Posição = new Vector2(920,160);
            Territorios[29] = new Territorio(graphics, Textura_Botões, "Sibéria", "Ásia");
            Territorios[29].botão.Posição = new Vector2(990,130);
            Territorios[30] = new Territorio(graphics, Textura_Botões, "Yakutsk", "Ásia");
            Territorios[30].botão.Posição = new Vector2(1090,94);
            Territorios[31] = new Territorio(graphics, Textura_Botões, "Irkutsk", "Ásia");
            Territorios[31].botão.Posição = new Vector2(1075,176);
            Territorios[32] = new Territorio(graphics, Textura_Botões, "Mongólia", "Ásia");
            Territorios[32].botão.Posição = new Vector2(1080,253);
            Territorios[33] = new Territorio(graphics, Textura_Botões, "China", "Ásia");
            Territorios[33].botão.Posição = new Vector2(1050,320);
            Territorios[34] = new Territorio(graphics, Textura_Botões, "Índia", "Ásia");
            Territorios[34].botão.Posição = new Vector2(975,375);
            Territorios[35] = new Territorio(graphics, Textura_Botões, "Sudeste Asiático", "Ásia");
            Territorios[35].botão.Posição = new Vector2(1080,404);
            Territorios[36] = new Territorio(graphics, Textura_Botões, "Kamchatka", "Ásia");
            Territorios[36].botão.Posição = new Vector2(1192,89);
            Territorios[37] = new Territorio(graphics, Textura_Botões, "Coreia", "Ásia");
            Territorios[37].botão.Posição = new Vector2(1225,260);
            //38-41 Oceânia
            Territorios[38] = new Territorio(graphics, Textura_Botões, "Indonésia", "Oceânia");
            Territorios[38].botão.Posição = new Vector2(1108,520);
            Territorios[39] = new Territorio(graphics, Textura_Botões, "Nova Guiné", "Oceânia");
            Territorios[39].botão.Posição = new Vector2(1220,496);
            Territorios[40] = new Territorio(graphics, Textura_Botões, "Austrália Oeste", "Oceânia");
            Territorios[40].botão.Posição = new Vector2(1155,627);
            Territorios[41] = new Territorio(graphics, Textura_Botões, "Austrália Este", "Oceânia");
            Territorios[41].botão.Posição = new Vector2(1271,621);
            
            Territorios[0].Nomes_Territórios_Vizinhos.Add("Território Noroeste");
            Territorios[0].Nomes_Territórios_Vizinhos.Add("Alberta");
            Territorios[0].Nomes_Territórios_Vizinhos.Add("Kamchatka");

            Territorios[1].Nomes_Territórios_Vizinhos.Add("Alberta");
            Territorios[1].Nomes_Territórios_Vizinhos.Add("Alaska");
            Territorios[1].Nomes_Territórios_Vizinhos.Add("Ontario");
            Territorios[1].Nomes_Territórios_Vizinhos.Add("Gronelândia");

            Territorios[2].Nomes_Territórios_Vizinhos.Add("Alaska");
            Territorios[2].Nomes_Territórios_Vizinhos.Add("Território Noroeste");
            Territorios[2].Nomes_Territórios_Vizinhos.Add("Ontario");
            Territorios[2].Nomes_Territórios_Vizinhos.Add("Estados Unidos Oeste");

            Territorios[3].Nomes_Territórios_Vizinhos.Add("Alberta");
            Territorios[3].Nomes_Territórios_Vizinhos.Add("Estados Unidos Este");
            Territorios[3].Nomes_Territórios_Vizinhos.Add("México");

            Territorios[4].Nomes_Territórios_Vizinhos.Add("Alberta");
            Territorios[4].Nomes_Territórios_Vizinhos.Add("Território Noroeste");
            Territorios[4].Nomes_Territórios_Vizinhos.Add("Estados Unidos Este");
            Territorios[4].Nomes_Territórios_Vizinhos.Add("Estados Unidos Oeste");
            Territorios[4].Nomes_Territórios_Vizinhos.Add("Canadá Este");
            Territorios[4].Nomes_Territórios_Vizinhos.Add("Gronelândia");

            Territorios[5].Nomes_Territórios_Vizinhos.Add("Gronelândia");
            Territorios[5].Nomes_Territórios_Vizinhos.Add("Ontario");
            Territorios[5].Nomes_Territórios_Vizinhos.Add("Estados Unidos Este");

            Territorios[6].Nomes_Territórios_Vizinhos.Add("Ontario");
            Territorios[6].Nomes_Territórios_Vizinhos.Add("Estados Unidos Oeste");
            Territorios[6].Nomes_Territórios_Vizinhos.Add("México");
            Territorios[6].Nomes_Territórios_Vizinhos.Add("Canadá Este");

            Territorios[7].Nomes_Territórios_Vizinhos.Add("Estados Unidos Oeste");
            Territorios[7].Nomes_Territórios_Vizinhos.Add("Estados Unidos Este");
            Territorios[7].Nomes_Territórios_Vizinhos.Add("Venezuela");

            Territorios[8].Nomes_Territórios_Vizinhos.Add("Canadá Este");
            Territorios[8].Nomes_Territórios_Vizinhos.Add("Ontario");
            Territorios[8].Nomes_Territórios_Vizinhos.Add("Território Noroeste");
            Territorios[8].Nomes_Territórios_Vizinhos.Add("Islândia");

            Territorios[9].Nomes_Territórios_Vizinhos.Add("México");
            Territorios[9].Nomes_Territórios_Vizinhos.Add("Brasil");
            Territorios[9].Nomes_Territórios_Vizinhos.Add("Peru");

            Territorios[10].Nomes_Territórios_Vizinhos.Add("Venezuela");
            Territorios[10].Nomes_Territórios_Vizinhos.Add("Norte de África");
            Territorios[10].Nomes_Territórios_Vizinhos.Add("Peru");
            Territorios[10].Nomes_Territórios_Vizinhos.Add("Argentina");

            Territorios[11].Nomes_Territórios_Vizinhos.Add("Venezuela");
            Territorios[11].Nomes_Territórios_Vizinhos.Add("Brasil");
            Territorios[11].Nomes_Territórios_Vizinhos.Add("Argentina");

            Territorios[12].Nomes_Territórios_Vizinhos.Add("Peru");
            Territorios[12].Nomes_Territórios_Vizinhos.Add("Brasil");

            Territorios[13].Nomes_Territórios_Vizinhos.Add("Egipto");
            Territorios[13].Nomes_Territórios_Vizinhos.Add("Europa Ocidental");
            Territorios[13].Nomes_Territórios_Vizinhos.Add("África do Este");
            Territorios[13].Nomes_Territórios_Vizinhos.Add("África Central");

            Territorios[14].Nomes_Territórios_Vizinhos.Add("Sul da Europa");
            Territorios[14].Nomes_Territórios_Vizinhos.Add("Norte de África");
            Territorios[14].Nomes_Territórios_Vizinhos.Add("África do Este");
            Territorios[14].Nomes_Territórios_Vizinhos.Add("Médio-Oriente");

            Territorios[15].Nomes_Territórios_Vizinhos.Add("Egipto");
            Territorios[15].Nomes_Territórios_Vizinhos.Add("Norte de África");
            Territorios[15].Nomes_Territórios_Vizinhos.Add("Médio-Oriente");
            Territorios[15].Nomes_Territórios_Vizinhos.Add("África Central");
            Territorios[15].Nomes_Territórios_Vizinhos.Add("Madagáscar");
            Territorios[15].Nomes_Territórios_Vizinhos.Add("África do Sul");

            Territorios[16].Nomes_Territórios_Vizinhos.Add("Norte de África");
            Territorios[16].Nomes_Territórios_Vizinhos.Add("África do Este");
            Territorios[16].Nomes_Territórios_Vizinhos.Add("África do Sul");

            Territorios[17].Nomes_Territórios_Vizinhos.Add("África Central");
            Territorios[17].Nomes_Territórios_Vizinhos.Add("África do Este");
            Territorios[17].Nomes_Territórios_Vizinhos.Add("Madagáscar");

            Territorios[18].Nomes_Territórios_Vizinhos.Add("África do Este");
            Territorios[18].Nomes_Territórios_Vizinhos.Add("África do Sul");

            Territorios[19].Nomes_Territórios_Vizinhos.Add("Europa Ocidental");
            Territorios[19].Nomes_Territórios_Vizinhos.Add("Grã-Bretanha");
            Territorios[19].Nomes_Territórios_Vizinhos.Add("Sul da Europa");
            Territorios[19].Nomes_Territórios_Vizinhos.Add("Norte da Europa");
            Territorios[19].Nomes_Territórios_Vizinhos.Add("Norte de África");

            Territorios[20].Nomes_Territórios_Vizinhos.Add("Islândia");
            Territorios[20].Nomes_Territórios_Vizinhos.Add("Escandinávia");
            Territorios[20].Nomes_Territórios_Vizinhos.Add("Norte da Europa");
            Territorios[20].Nomes_Territórios_Vizinhos.Add("Europa Ocidental");

            Territorios[21].Nomes_Territórios_Vizinhos.Add("Gronelândia");
            Territorios[21].Nomes_Territórios_Vizinhos.Add("Escandinávia");
            Territorios[21].Nomes_Territórios_Vizinhos.Add("Grã-Bretanha");

            Territorios[22].Nomes_Territórios_Vizinhos.Add("Grã-Bretanha");
            Territorios[22].Nomes_Territórios_Vizinhos.Add("Escandinávia");
            Territorios[22].Nomes_Territórios_Vizinhos.Add("Rússia");
            Territorios[22].Nomes_Territórios_Vizinhos.Add("Sul da Europa");
            Territorios[22].Nomes_Territórios_Vizinhos.Add("Europa Ocidental");

            Territorios[23].Nomes_Territórios_Vizinhos.Add("Europa Ocidental");
            Territorios[23].Nomes_Territórios_Vizinhos.Add("Norte da Europa");
            Territorios[23].Nomes_Territórios_Vizinhos.Add("Rússia");
            Territorios[23].Nomes_Territórios_Vizinhos.Add("Médio-Oriente");

            Territorios[24].Nomes_Territórios_Vizinhos.Add("Grã-Bretanha");
            Territorios[24].Nomes_Territórios_Vizinhos.Add("Norte da Europa");
            Territorios[24].Nomes_Territórios_Vizinhos.Add("Rússia");
            Territorios[24].Nomes_Territórios_Vizinhos.Add("Islândia");

            Territorios[25].Nomes_Territórios_Vizinhos.Add("Escandinávia");
            Territorios[25].Nomes_Territórios_Vizinhos.Add("Norte da Europa");
            Territorios[25].Nomes_Territórios_Vizinhos.Add("Sul da Europa");
            Territorios[25].Nomes_Territórios_Vizinhos.Add("Médio-Oriente");
            Territorios[25].Nomes_Territórios_Vizinhos.Add("Afeganistão");
            Territorios[25].Nomes_Territórios_Vizinhos.Add("Ural");

            Territorios[26].Nomes_Territórios_Vizinhos.Add("África do Este");
            Territorios[26].Nomes_Territórios_Vizinhos.Add("Egipto");
            Territorios[26].Nomes_Territórios_Vizinhos.Add("Sul da Europa");
            Territorios[26].Nomes_Territórios_Vizinhos.Add("Rússia");
            Territorios[26].Nomes_Territórios_Vizinhos.Add("Afeganistão");
            Territorios[26].Nomes_Territórios_Vizinhos.Add("Índia");

            Territorios[27].Nomes_Territórios_Vizinhos.Add("Médio-Oriente");
            Territorios[27].Nomes_Territórios_Vizinhos.Add("Rússia");
            Territorios[27].Nomes_Territórios_Vizinhos.Add("Ural");
            Territorios[27].Nomes_Territórios_Vizinhos.Add("China");
            Territorios[27].Nomes_Territórios_Vizinhos.Add("Índia");

            Territorios[28].Nomes_Territórios_Vizinhos.Add("Afeganistão");
            Territorios[28].Nomes_Territórios_Vizinhos.Add("Rússia");
            Territorios[28].Nomes_Territórios_Vizinhos.Add("Sibéria");
            Territorios[28].Nomes_Territórios_Vizinhos.Add("China");

            Territorios[29].Nomes_Territórios_Vizinhos.Add("China");
            Territorios[29].Nomes_Territórios_Vizinhos.Add("Ural");
            Territorios[29].Nomes_Territórios_Vizinhos.Add("Yakutsk");
            Territorios[29].Nomes_Territórios_Vizinhos.Add("Irkutsk");
            Territorios[29].Nomes_Territórios_Vizinhos.Add("Mongólia");

            Territorios[30].Nomes_Territórios_Vizinhos.Add("Sibéria");
            Territorios[30].Nomes_Territórios_Vizinhos.Add("Irkutsk");
            Territorios[30].Nomes_Territórios_Vizinhos.Add("Kamchatka");

            Territorios[31].Nomes_Territórios_Vizinhos.Add("Mongólia");
            Territorios[31].Nomes_Territórios_Vizinhos.Add("Sibéria");
            Territorios[31].Nomes_Territórios_Vizinhos.Add("Yakutsk");
            Territorios[31].Nomes_Territórios_Vizinhos.Add("Kamchatka");

            Territorios[32].Nomes_Territórios_Vizinhos.Add("Coreia");
            Territorios[32].Nomes_Territórios_Vizinhos.Add("China");
            Territorios[32].Nomes_Territórios_Vizinhos.Add("Sibéria");
            Territorios[32].Nomes_Territórios_Vizinhos.Add("Irkutsk");
            Territorios[32].Nomes_Territórios_Vizinhos.Add("Kamchatka");

            Territorios[33].Nomes_Territórios_Vizinhos.Add("Sudeste Asiático");
            Territorios[33].Nomes_Territórios_Vizinhos.Add("Índia");
            Territorios[33].Nomes_Territórios_Vizinhos.Add("Afeganistão");
            Territorios[33].Nomes_Territórios_Vizinhos.Add("Ural");
            Territorios[33].Nomes_Territórios_Vizinhos.Add("Sibéria");
            Territorios[33].Nomes_Territórios_Vizinhos.Add("Mongólia");

            Territorios[34].Nomes_Territórios_Vizinhos.Add("Sudeste Asiático");
            Territorios[34].Nomes_Territórios_Vizinhos.Add("China");
            Territorios[34].Nomes_Territórios_Vizinhos.Add("Afeganistão");
            Territorios[34].Nomes_Territórios_Vizinhos.Add("Médio-Oriente");

            Territorios[35].Nomes_Territórios_Vizinhos.Add("Indonésia");
            Territorios[35].Nomes_Territórios_Vizinhos.Add("Índia");
            Territorios[35].Nomes_Territórios_Vizinhos.Add("China");

            Territorios[36].Nomes_Territórios_Vizinhos.Add("Alaska");
            Territorios[36].Nomes_Territórios_Vizinhos.Add("Coreia");
            Territorios[36].Nomes_Territórios_Vizinhos.Add("Mongólia");
            Territorios[36].Nomes_Territórios_Vizinhos.Add("Irkutsk");
            Territorios[36].Nomes_Territórios_Vizinhos.Add("Yakutsk");

            Territorios[37].Nomes_Territórios_Vizinhos.Add("Mongólia");
            Territorios[37].Nomes_Territórios_Vizinhos.Add("Kamchatka");

            Territorios[38].Nomes_Territórios_Vizinhos.Add("Sudeste Asiático");
            Territorios[38].Nomes_Territórios_Vizinhos.Add("Nova Guiné");
            Territorios[38].Nomes_Territórios_Vizinhos.Add("Austrália Oeste");

            Territorios[39].Nomes_Territórios_Vizinhos.Add("Indonésia");
            Territorios[39].Nomes_Territórios_Vizinhos.Add("Austrália Oeste");
            Territorios[39].Nomes_Territórios_Vizinhos.Add("Austrália Este");

            Territorios[40].Nomes_Territórios_Vizinhos.Add("Indonésia");
            Territorios[40].Nomes_Territórios_Vizinhos.Add("Austrália Este");
            Territorios[40].Nomes_Territórios_Vizinhos.Add("Nova Guiné");

            Territorios[41].Nomes_Territórios_Vizinhos.Add("Austrália Oeste");
            Territorios[41].Nomes_Territórios_Vizinhos.Add("Nova Guiné");
        }

        public bool Está_Na_Vizinhança(Territorio t1, Territorio t2) //Vai verificar se o território t2 está na vizinhança do t1
        {
            bool resultado = false;
            foreach (string vizinho in t1.Nomes_Territórios_Vizinhos)
            {
                if (vizinho == t2.Nome)
                    resultado = true;
            }
            return resultado;
        }

        public bool Os_Territórios_Estão_Todos_Ocupados()
        {
            bool pelo_menos_um_livre=false;
            for(int i=0;i<Territorios.Length;i++)
            {
                if(Territorios[i].Identificação_do_Jogador_que_o_possui==-1 && Territorios[i].Infantaria_Presente==0)
                {
                    pelo_menos_um_livre = true;
                }
            }
            return pelo_menos_um_livre;
        }
    }
}
