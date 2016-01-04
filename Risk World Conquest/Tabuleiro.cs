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

        public int[] Valores_dos_Continentes;

        public Tabuleiro(GraphicsDevice graphics,Texture2D Textura_Botões) //Construtor do Tabuleiro, vai criar os territórios, definir os vizinhos destes e assinalar as cores do jogador que os possui (cinzento significa que não tem dono)
        {
            Valores_dos_Continentes = new int[6];
            Territorios = new Territorio[42];
            //0-8 América do Norte
            Territorios[0] = new Territorio(graphics,Textura_Botões, "Alaska", "América do Norte");
            Territorios[0].botão.Posição = new Vector2(100, 100);
            Territorios[1] = new Territorio(graphics, Textura_Botões, "Territorio Noroeste", "América do Norte");
            Territorios[1].botão.Posição = new Vector2(204, 102);
            Territorios[2] = new Territorio(graphics, Textura_Botões, "Alberta", "América do Norte");
            Territorios[2].botão.Posição = new Vector2(209, 164);
            Territorios[3] = new Territorio(graphics, Textura_Botões, "Estados Unidos Oeste", "América do Norte");
            Territorios[3].botão.Posição = new Vector2(210, 244);
            Territorios[4] = new Territorio(graphics, Textura_Botões, "Ontario", "América do Norte");
            Territorios[4].botão.Posição = new Vector2(285, 175);
            Territorios[5] = new Territorio(graphics, Textura_Botões, "Canada Este", "América do Norte");
            Territorios[5].botão.Posição = new Vector2(383, 176);
            Territorios[6] = new Territorio(graphics, Textura_Botões, "Estados Unidos Este", "América do Norte");
            Territorios[6].botão.Posição = new Vector2(308, 270);
            Territorios[7] = new Territorio(graphics, Textura_Botões, "Mexico", "América do Norte");
            Territorios[7].botão.Posição = new Vector2(225, 329);
            Territorios[8] = new Territorio(graphics, Textura_Botões, "Gronelandia", "América do Norte");
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
            Territorios[13] = new Territorio(graphics, Textura_Botões, "Norte de Africa", "África");
            Territorios[13].botão.Posição = new Vector2(620,440);
            Territorios[14] = new Territorio(graphics, Textura_Botões, "Egipto", "África");
            Territorios[14].botão.Posição = new Vector2(720,415);
            Territorios[15] = new Territorio(graphics, Textura_Botões, "Africa do Este", "África");
            Territorios[15].botão.Posição = new Vector2(805,510);
            Territorios[16] = new Territorio(graphics, Textura_Botões, "Africa Central", "África");
            Territorios[16].botão.Posição = new Vector2(725,535);
            Territorios[17] = new Territorio(graphics, Textura_Botões, "Africa do Sul", "África");
            Territorios[17].botão.Posição = new Vector2(735,635);
            Territorios[18] = new Territorio(graphics, Textura_Botões, "Madagascar", "África");
            Territorios[18].botão.Posição = new Vector2(853,630);
            //19-25 Europa
            Territorios[19] = new Territorio(graphics, Textura_Botões, "Europa Ocidental", "Europa");
            Territorios[19].botão.Posição = new Vector2(565,335);
            Territorios[20] = new Territorio(graphics, Textura_Botões, "Gra-Bretanha", "Europa");
            Territorios[20].botão.Posição = new Vector2(567,238);
            Territorios[21] = new Territorio(graphics, Textura_Botões, "Islandia", "Europa");
            Territorios[21].botão.Posição = new Vector2(568,140);
            Territorios[22] = new Territorio(graphics, Textura_Botões, "Norte da Europa", "Europa");
            Territorios[22].botão.Posição = new Vector2(670,240);
            Territorios[23] = new Territorio(graphics, Textura_Botões, "Sul da Europa", "Europa");
            Territorios[23].botão.Posição = new Vector2(683,290);
            Territorios[24] = new Territorio(graphics, Textura_Botões, "Escandinavia", "Europa");
            Territorios[24].botão.Posição = new Vector2(658,150);
            Territorios[25] = new Territorio(graphics, Textura_Botões, "Russia", "Europa");
            Territorios[25].botão.Posição = new Vector2(790,195);
            //26-37 Ásia
            Territorios[26] = new Territorio(graphics, Textura_Botões, "Medio-Oriente", "Ásia");
            Territorios[26].botão.Posição = new Vector2(820,380);
            Territorios[27] = new Territorio(graphics, Textura_Botões, "Afeganistao", "Ásia");
            Territorios[27].botão.Posição = new Vector2(900,266);
            Territorios[28] = new Territorio(graphics, Textura_Botões, "Ural", "Ásia");
            Territorios[28].botão.Posição = new Vector2(920,160);
            Territorios[29] = new Territorio(graphics, Textura_Botões, "Siberia", "Ásia");
            Territorios[29].botão.Posição = new Vector2(990,130);
            Territorios[30] = new Territorio(graphics, Textura_Botões, "Yakutsk", "Ásia");
            Territorios[30].botão.Posição = new Vector2(1090,94);
            Territorios[31] = new Territorio(graphics, Textura_Botões, "Irkutsk", "Ásia");
            Territorios[31].botão.Posição = new Vector2(1075,176);
            Territorios[32] = new Territorio(graphics, Textura_Botões, "Mongolia", "Ásia");
            Territorios[32].botão.Posição = new Vector2(1080,253);
            Territorios[33] = new Territorio(graphics, Textura_Botões, "China", "Ásia");
            Territorios[33].botão.Posição = new Vector2(1050,320);
            Territorios[34] = new Territorio(graphics, Textura_Botões, "India", "Ásia");
            Territorios[34].botão.Posição = new Vector2(975,375);
            Territorios[35] = new Territorio(graphics, Textura_Botões, "Sudeste Asiatico", "Ásia");
            Territorios[35].botão.Posição = new Vector2(1080,404);
            Territorios[36] = new Territorio(graphics, Textura_Botões, "Kamchatka", "Ásia");
            Territorios[36].botão.Posição = new Vector2(1192,89);
            Territorios[37] = new Territorio(graphics, Textura_Botões, "Coreia", "Ásia");
            Territorios[37].botão.Posição = new Vector2(1225,260);
            //38-41 Oceânia
            Territorios[38] = new Territorio(graphics, Textura_Botões, "Indonesia", "Oceânia");
            Territorios[38].botão.Posição = new Vector2(1108,520);
            Territorios[39] = new Territorio(graphics, Textura_Botões, "Nova Guine", "Oceânia");
            Territorios[39].botão.Posição = new Vector2(1220,496);
            Territorios[40] = new Territorio(graphics, Textura_Botões, "Australia Oeste", "Oceânia");
            Territorios[40].botão.Posição = new Vector2(1155,627);
            Territorios[41] = new Territorio(graphics, Textura_Botões, "Australia Este", "Oceânia");
            Territorios[41].botão.Posição = new Vector2(1271,621);
            
            Territorios[0].Nomes_Territórios_Vizinhos.Add("Territorio Noroeste");
            Territorios[0].Nomes_Territórios_Vizinhos.Add("Alberta");
            Territorios[0].Nomes_Territórios_Vizinhos.Add("Kamchatka");

            Territorios[1].Nomes_Territórios_Vizinhos.Add("Alberta");
            Territorios[1].Nomes_Territórios_Vizinhos.Add("Alaska");
            Territorios[1].Nomes_Territórios_Vizinhos.Add("Ontario");
            Territorios[1].Nomes_Territórios_Vizinhos.Add("Gronelandia");

            Territorios[2].Nomes_Territórios_Vizinhos.Add("Alaska");
            Territorios[2].Nomes_Territórios_Vizinhos.Add("Territorio Noroeste");
            Territorios[2].Nomes_Territórios_Vizinhos.Add("Ontario");
            Territorios[2].Nomes_Territórios_Vizinhos.Add("Estados Unidos Oeste");

            Territorios[3].Nomes_Territórios_Vizinhos.Add("Alberta");
            Territorios[3].Nomes_Territórios_Vizinhos.Add("Estados Unidos Este");
            Territorios[3].Nomes_Territórios_Vizinhos.Add("Mexico");

            Territorios[4].Nomes_Territórios_Vizinhos.Add("Alberta");
            Territorios[4].Nomes_Territórios_Vizinhos.Add("Territorio Noroeste");
            Territorios[4].Nomes_Territórios_Vizinhos.Add("Estados Unidos Este");
            Territorios[4].Nomes_Territórios_Vizinhos.Add("Estados Unidos Oeste");
            Territorios[4].Nomes_Territórios_Vizinhos.Add("Canada Este");
            Territorios[4].Nomes_Territórios_Vizinhos.Add("Gronelandia");

            Territorios[5].Nomes_Territórios_Vizinhos.Add("Gronelandia");
            Territorios[5].Nomes_Territórios_Vizinhos.Add("Ontario");
            Territorios[5].Nomes_Territórios_Vizinhos.Add("Estados Unidos Este");

            Territorios[6].Nomes_Territórios_Vizinhos.Add("Ontario");
            Territorios[6].Nomes_Territórios_Vizinhos.Add("Estados Unidos Oeste");
            Territorios[6].Nomes_Territórios_Vizinhos.Add("Mexico");
            Territorios[6].Nomes_Territórios_Vizinhos.Add("Canada Este");

            Territorios[7].Nomes_Territórios_Vizinhos.Add("Estados Unidos Oeste");
            Territorios[7].Nomes_Territórios_Vizinhos.Add("Estados Unidos Este");
            Territorios[7].Nomes_Territórios_Vizinhos.Add("Venezuela");

            Territorios[8].Nomes_Territórios_Vizinhos.Add("Canada Este");
            Territorios[8].Nomes_Territórios_Vizinhos.Add("Ontario");
            Territorios[8].Nomes_Territórios_Vizinhos.Add("Territorio Noroeste");
            Territorios[8].Nomes_Territórios_Vizinhos.Add("Islandia");

            Territorios[9].Nomes_Territórios_Vizinhos.Add("Mexico");
            Territorios[9].Nomes_Territórios_Vizinhos.Add("Brasil");
            Territorios[9].Nomes_Territórios_Vizinhos.Add("Peru");

            Territorios[10].Nomes_Territórios_Vizinhos.Add("Venezuela");
            Territorios[10].Nomes_Territórios_Vizinhos.Add("Norte de Africa");
            Territorios[10].Nomes_Territórios_Vizinhos.Add("Peru");
            Territorios[10].Nomes_Territórios_Vizinhos.Add("Argentina");

            Territorios[11].Nomes_Territórios_Vizinhos.Add("Venezuela");
            Territorios[11].Nomes_Territórios_Vizinhos.Add("Brasil");
            Territorios[11].Nomes_Territórios_Vizinhos.Add("Argentina");

            Territorios[12].Nomes_Territórios_Vizinhos.Add("Peru");
            Territorios[12].Nomes_Territórios_Vizinhos.Add("Brasil");

            Territorios[13].Nomes_Territórios_Vizinhos.Add("Egipto");
            Territorios[13].Nomes_Territórios_Vizinhos.Add("Europa Ocidental");
            Territorios[13].Nomes_Territórios_Vizinhos.Add("Africa do Este");
            Territorios[13].Nomes_Territórios_Vizinhos.Add("Africa Central");

            Territorios[14].Nomes_Territórios_Vizinhos.Add("Sul da Europa");
            Territorios[14].Nomes_Territórios_Vizinhos.Add("Norte de Africa");
            Territorios[14].Nomes_Territórios_Vizinhos.Add("Africa do Este");
            Territorios[14].Nomes_Territórios_Vizinhos.Add("Medio-Oriente");

            Territorios[15].Nomes_Territórios_Vizinhos.Add("Egipto");
            Territorios[15].Nomes_Territórios_Vizinhos.Add("Norte de Africa");
            Territorios[15].Nomes_Territórios_Vizinhos.Add("Medio-Oriente");
            Territorios[15].Nomes_Territórios_Vizinhos.Add("Africa Central");
            Territorios[15].Nomes_Territórios_Vizinhos.Add("Madagascar");
            Territorios[15].Nomes_Territórios_Vizinhos.Add("Africa do Sul");

            Territorios[16].Nomes_Territórios_Vizinhos.Add("Norte de Africa");
            Territorios[16].Nomes_Territórios_Vizinhos.Add("Africa do Este");
            Territorios[16].Nomes_Territórios_Vizinhos.Add("Africa do Sul");

            Territorios[17].Nomes_Territórios_Vizinhos.Add("Africa Central");
            Territorios[17].Nomes_Territórios_Vizinhos.Add("Africa do Este");
            Territorios[17].Nomes_Territórios_Vizinhos.Add("Madagascar");

            Territorios[18].Nomes_Territórios_Vizinhos.Add("Africa do Este");
            Territorios[18].Nomes_Territórios_Vizinhos.Add("Africa do Sul");

            Territorios[19].Nomes_Territórios_Vizinhos.Add("Europa Ocidental");
            Territorios[19].Nomes_Territórios_Vizinhos.Add("Gra-Bretanha");
            Territorios[19].Nomes_Territórios_Vizinhos.Add("Sul da Europa");
            Territorios[19].Nomes_Territórios_Vizinhos.Add("Norte da Europa");
            Territorios[19].Nomes_Territórios_Vizinhos.Add("Norte de Africa");

            Territorios[20].Nomes_Territórios_Vizinhos.Add("Islandia");
            Territorios[20].Nomes_Territórios_Vizinhos.Add("Escandinavia");
            Territorios[20].Nomes_Territórios_Vizinhos.Add("Norte da Europa");
            Territorios[20].Nomes_Territórios_Vizinhos.Add("Europa Ocidental");

            Territorios[21].Nomes_Territórios_Vizinhos.Add("Gronelandia");
            Territorios[21].Nomes_Territórios_Vizinhos.Add("Escandinavia");
            Territorios[21].Nomes_Territórios_Vizinhos.Add("Gra-Bretanha");

            Territorios[22].Nomes_Territórios_Vizinhos.Add("Gra-Bretanha");
            Territorios[22].Nomes_Territórios_Vizinhos.Add("Escandinavia");
            Territorios[22].Nomes_Territórios_Vizinhos.Add("Russia");
            Territorios[22].Nomes_Territórios_Vizinhos.Add("Sul da Europa");
            Territorios[22].Nomes_Territórios_Vizinhos.Add("Europa Ocidental");

            Territorios[23].Nomes_Territórios_Vizinhos.Add("Europa Ocidental");
            Territorios[23].Nomes_Territórios_Vizinhos.Add("Norte da Europa");
            Territorios[23].Nomes_Territórios_Vizinhos.Add("Russia");
            Territorios[23].Nomes_Territórios_Vizinhos.Add("Medio-Oriente");

            Territorios[24].Nomes_Territórios_Vizinhos.Add("Gra-Bretanha");
            Territorios[24].Nomes_Territórios_Vizinhos.Add("Norte da Europa");
            Territorios[24].Nomes_Territórios_Vizinhos.Add("Russia");
            Territorios[24].Nomes_Territórios_Vizinhos.Add("Islandia");

            Territorios[25].Nomes_Territórios_Vizinhos.Add("Escandinavia");
            Territorios[25].Nomes_Territórios_Vizinhos.Add("Norte da Europa");
            Territorios[25].Nomes_Territórios_Vizinhos.Add("Sul da Europa");
            Territorios[25].Nomes_Territórios_Vizinhos.Add("Medio-Oriente");
            Territorios[25].Nomes_Territórios_Vizinhos.Add("Afeganistao");
            Territorios[25].Nomes_Territórios_Vizinhos.Add("Ural");

            Territorios[26].Nomes_Territórios_Vizinhos.Add("Africa do Este");
            Territorios[26].Nomes_Territórios_Vizinhos.Add("Egipto");
            Territorios[26].Nomes_Territórios_Vizinhos.Add("Sul da Europa");
            Territorios[26].Nomes_Territórios_Vizinhos.Add("Russia");
            Territorios[26].Nomes_Territórios_Vizinhos.Add("Afeganistao");
            Territorios[26].Nomes_Territórios_Vizinhos.Add("India");

            Territorios[27].Nomes_Territórios_Vizinhos.Add("Medio-Oriente");
            Territorios[27].Nomes_Territórios_Vizinhos.Add("Russia");
            Territorios[27].Nomes_Territórios_Vizinhos.Add("Ural");
            Territorios[27].Nomes_Territórios_Vizinhos.Add("China");
            Territorios[27].Nomes_Territórios_Vizinhos.Add("India");

            Territorios[28].Nomes_Territórios_Vizinhos.Add("Afeganistao");
            Territorios[28].Nomes_Territórios_Vizinhos.Add("Russia");
            Territorios[28].Nomes_Territórios_Vizinhos.Add("Siberia");
            Territorios[28].Nomes_Territórios_Vizinhos.Add("China");

            Territorios[29].Nomes_Territórios_Vizinhos.Add("China");
            Territorios[29].Nomes_Territórios_Vizinhos.Add("Ural");
            Territorios[29].Nomes_Territórios_Vizinhos.Add("Yakutsk");
            Territorios[29].Nomes_Territórios_Vizinhos.Add("Irkutsk");
            Territorios[29].Nomes_Territórios_Vizinhos.Add("Mongolia");

            Territorios[30].Nomes_Territórios_Vizinhos.Add("Siberia");
            Territorios[30].Nomes_Territórios_Vizinhos.Add("Irkutsk");
            Territorios[30].Nomes_Territórios_Vizinhos.Add("Kamchatka");

            Territorios[31].Nomes_Territórios_Vizinhos.Add("Mongolia");
            Territorios[31].Nomes_Territórios_Vizinhos.Add("Siberia");
            Territorios[31].Nomes_Territórios_Vizinhos.Add("Yakutsk");
            Territorios[31].Nomes_Territórios_Vizinhos.Add("Kamchatka");

            Territorios[32].Nomes_Territórios_Vizinhos.Add("Coreia");
            Territorios[32].Nomes_Territórios_Vizinhos.Add("China");
            Territorios[32].Nomes_Territórios_Vizinhos.Add("Siberia");
            Territorios[32].Nomes_Territórios_Vizinhos.Add("Irkutsk");
            Territorios[32].Nomes_Territórios_Vizinhos.Add("Kamchatka");

            Territorios[33].Nomes_Territórios_Vizinhos.Add("Sudeste Asiatico");
            Territorios[33].Nomes_Territórios_Vizinhos.Add("India");
            Territorios[33].Nomes_Territórios_Vizinhos.Add("Afeganistao");
            Territorios[33].Nomes_Territórios_Vizinhos.Add("Ural");
            Territorios[33].Nomes_Territórios_Vizinhos.Add("Siberia");
            Territorios[33].Nomes_Territórios_Vizinhos.Add("Mongolia");

            Territorios[34].Nomes_Territórios_Vizinhos.Add("Sudeste Asiatico");
            Territorios[34].Nomes_Territórios_Vizinhos.Add("China");
            Territorios[34].Nomes_Territórios_Vizinhos.Add("Afeganistao");
            Territorios[34].Nomes_Territórios_Vizinhos.Add("Medio-Oriente");

            Territorios[35].Nomes_Territórios_Vizinhos.Add("Indonesia");
            Territorios[35].Nomes_Territórios_Vizinhos.Add("India");
            Territorios[35].Nomes_Territórios_Vizinhos.Add("China");

            Territorios[36].Nomes_Territórios_Vizinhos.Add("Alaska");
            Territorios[36].Nomes_Territórios_Vizinhos.Add("Coreia");
            Territorios[36].Nomes_Territórios_Vizinhos.Add("Mongolia");
            Territorios[36].Nomes_Territórios_Vizinhos.Add("Irkutsk");
            Territorios[36].Nomes_Territórios_Vizinhos.Add("Yakutsk");

            Territorios[37].Nomes_Territórios_Vizinhos.Add("Mongolia");
            Territorios[37].Nomes_Territórios_Vizinhos.Add("Kamchatka");

            Territorios[38].Nomes_Territórios_Vizinhos.Add("Sudeste Asiatico");
            Territorios[38].Nomes_Territórios_Vizinhos.Add("Nova Guine");
            Territorios[38].Nomes_Territórios_Vizinhos.Add("Australia Oeste");

            Territorios[39].Nomes_Territórios_Vizinhos.Add("Indonesia");
            Territorios[39].Nomes_Territórios_Vizinhos.Add("Australia Oeste");
            Territorios[39].Nomes_Territórios_Vizinhos.Add("Australia Este");

            Territorios[40].Nomes_Territórios_Vizinhos.Add("Indonesia");
            Territorios[40].Nomes_Territórios_Vizinhos.Add("Australia Este");
            Territorios[40].Nomes_Territórios_Vizinhos.Add("Nova Guine");

            Territorios[41].Nomes_Territórios_Vizinhos.Add("Australia Oeste");
            Territorios[41].Nomes_Territórios_Vizinhos.Add("Nova Guine");

            //América do Norte
            Valores_dos_Continentes[0] = 5;
            //América do Sul
            Valores_dos_Continentes[1] = 2;
            //Europa
            Valores_dos_Continentes[2] = 5;
            //África
            Valores_dos_Continentes[3] = 3;
            //Ásia
            Valores_dos_Continentes[4] = 7;
            //Oceânia
            Valores_dos_Continentes[5] = 2;

            for(int ind=0;ind<42;ind++)
            {
                Territorios[ind].índice = ind;
            }
        }

        public bool Está_Na_Vizinhança(Territorio atacante, Territorio defensor) //Vai verificar se o território t2 está na vizinhança do t1
        {
            bool resultado = false;
            foreach (string vizinho in atacante.Nomes_Territórios_Vizinhos)
            {
                if (vizinho == defensor.Nome)
                    resultado = true;
            }
            return resultado;
        }

        public bool Os_Territórios_Estão_Todos_Ocupados()
        {
            bool tudo_ocupado=true;
            for(int i=0;i<Territorios.Length;i++)
            {
                if(Territorios[i].Está_Desocupado())
                {
                    tudo_ocupado = false;
                }
            }
            return tudo_ocupado;
        }
    }
}
