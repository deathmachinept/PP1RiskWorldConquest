using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Risk_World_Conquest
{
    class Jogador
    {
        int Numero_de_Infantaria_Guardada;
        int Identificação;
        int Número_de_Continentes_Possuídos;
        Territorio[] Estados_Possuídos;

        public Jogador(int identificação,int numero_de_jogadores)
        {
            Identificação = identificação;
            Número_de_Continentes_Possuídos = 0;
            Estados_Possuídos = new Territorio[42];

            if (numero_de_jogadores == 3)
                Numero_de_Infantaria_Guardada = 35;
            else
            {
                if (numero_de_jogadores == 4)
                    Numero_de_Infantaria_Guardada = 30;
                else
                {
                    if (numero_de_jogadores == 5)
                        Numero_de_Infantaria_Guardada = 25;
                    else
                    {
                        if (numero_de_jogadores == 6)
                            Numero_de_Infantaria_Guardada = 20;
                    }
                }
            }
        }

        public bool Verificar_se_o_Estado_lhe_Pertence(Territorio territorio,Tabuleiro board)
        {
            foreach(Territorio est in board.Territorios)
            {
                if (territorio == est)
                    return true;
            }
            return false;
        }
    }
}
