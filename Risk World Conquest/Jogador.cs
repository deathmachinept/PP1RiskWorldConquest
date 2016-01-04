using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Risk_World_Conquest
{
    class Jogador
    {
        public bool Perdeu;
        int Numero_de_Infantaria_Guardada;
        int Identificação;
        int Número_de_Continentes_Possuídos;
        int[] Dados=new int[3];
        Territorio[] Estados_Possuídos;
        Random r=new Random();

        //Para os Jogadores que vão jogar
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
        //Para o caso de ser um Jogador que esteja não vá jogar
        public Jogador()
        {
            Perdeu = true;
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

        public void Lançar_Dados()
        {
            //Gerar os valores
            Dados[0] = r.Next(1, 7);
            Dados[1] = r.Next(1, 7);
            Dados[2] = r.Next(1, 7);
            //Ordenar do maior para o mais pequeno
            while (Dados[2] > Dados[0] || Dados[2] > Dados[1] || Dados[1] > Dados[0])
            {
                int actual = Dados[0];
                if (Dados[1] >= Dados[0])
                {
                    Dados[0] = Dados[1];
                    Dados[1] = actual;
                }
                if (Dados[2] >= Dados[0])
                {
                    Dados[0] = Dados[2];
                    Dados[2] = actual;
                }
                actual = Dados[1];
                if (Dados[2] >= Dados[1])
                {
                    Dados[1] = Dados[2];
                    Dados[2] = actual;
                }
            }
        }
    }
}
