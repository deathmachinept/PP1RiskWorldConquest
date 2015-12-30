using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Risk_World_Conquest
{
    class Tabuleiro
    {
        public Territorio[] Territorios;

        public Tabuleiro() //Construtor do Tabuleiro, vai criar os territórios e definir os vizinhos destes
        {
            Territorios = new Territorio[42];
            //0-8 América do Norte
            Territorios[0] = new Territorio("Alaska", "América do Norte");
            Territorios[1] = new Territorio("Território Noroeste", "América do Norte");
            Territorios[2] = new Territorio("Alberta", "América do Norte");
            Territorios[3] = new Territorio("Estados Unidos Oeste", "América do Norte");
            Territorios[4] = new Territorio("Ontario", "América do Norte");
            Territorios[5] = new Territorio("Canadá Este", "América do Norte");
            Territorios[6] = new Territorio("Estados Unidos Este", "América do Norte");
            Territorios[7] = new Territorio("México", "América do Norte");
            Territorios[8] = new Territorio("Gronelândia", "América do Norte");
            //9-12 América do Sul
            Territorios[9] = new Territorio("Venezuela", "América do Sul");
            Territorios[10] = new Territorio("Brasil", "América do Sul");
            Territorios[11] = new Territorio("Peru", "América do Sul");
            Territorios[12] = new Territorio("Argentina", "América do Sul");
            //13-18 África
            Territorios[13] = new Territorio("Norte de África", "África");
            Territorios[14] = new Territorio("Egipto", "África");
            Territorios[15] = new Territorio("África do Este", "África");
            Territorios[16] = new Territorio("África Central", "África");
            Territorios[17] = new Territorio("África do Sul", "África");
            Territorios[18] = new Territorio("Madagáscar", "África");
            //19-25 Europa
            Territorios[19] = new Territorio("Europa Ocidental", "Europa");
            Territorios[20] = new Territorio("Grã-Bretanha", "Europa");
            Territorios[21] = new Territorio("Islândia", "Europa");
            Territorios[22] = new Territorio("Norte da Europa", "Europa");
            Territorios[23] = new Territorio("Sul da Europa", "Europa");
            Territorios[24] = new Territorio("Escandinávia", "Europa");
            Territorios[25] = new Territorio("Rússia", "Europa");
            //26-37 Ásia
            Territorios[26] = new Territorio("Médio-Oriente", "Ásia");
            Territorios[27] = new Territorio("Afeganistão", "Ásia");
            Territorios[28] = new Territorio("Ural", "Ásia");
            Territorios[29] = new Territorio("Sibéria", "Ásia");
            Territorios[30] = new Territorio("Yakutsk", "Ásia");
            Territorios[31] = new Territorio("Irkutsk", "Ásia");
            Territorios[32] = new Territorio("Mongólia", "Ásia");
            Territorios[33] = new Territorio("China", "Ásia");
            Territorios[34] = new Territorio("Índia", "Ásia");
            Territorios[35] = new Territorio("Sudeste Asiático", "Ásia");
            Territorios[36] = new Territorio("Kamchatka", "Ásia");
            Territorios[37] = new Territorio("Coreia", "Ásia");
            //38-41 Oceânia
            Territorios[38] = new Territorio("Indonésia", "Oceânia");
            Territorios[39] = new Territorio("Nova Guiné", "Oceânia");
            Territorios[40] = new Territorio("Austrália Oeste", "Oceânia");
            Territorios[41] = new Territorio("Austrália Este", "Oceânia");

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
    }
}
