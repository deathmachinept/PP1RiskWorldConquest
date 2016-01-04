using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Audio;

namespace Risk_World_Conquest
{
    class Jogador
    {
        public bool Perdeu;
        public int Número_de_Infantaria_Guardada;
        int Identificação;
        public Color Cor;
        //Isto vai servir para averiguar o facto do jogador com maior número de identificação ser sempre o escolhido.
        public int sorteio_inicial;
        int Número_de_Continentes_Possuídos;
        public int[] Dados=new int[3];
        public short[] Territórios_Possuídos;
        Random r=new Random();

        //Para os Jogadores que vão jogar
        public Jogador(int identificação,int numero_de_jogadores)
        {
            Identificação = identificação;
            Número_de_Continentes_Possuídos = 0;
            Territórios_Possuídos = new short[42];
            sorteio_inicial = r.Next(1, 7);
            for (int l = 0; l < 42;l++)
            {
                Territórios_Possuídos[l] = 0;
            }
            if (numero_de_jogadores == 2)
                Número_de_Infantaria_Guardada = 40;
            else
            {
                if (numero_de_jogadores == 3)
                    Número_de_Infantaria_Guardada = 35;
                else
                {
                    if (numero_de_jogadores == 4)
                        Número_de_Infantaria_Guardada = 30;
                    else
                    {
                        if (numero_de_jogadores == 5)
                            Número_de_Infantaria_Guardada = 25;
                        else
                        {
                            if (numero_de_jogadores == 6)
                                Número_de_Infantaria_Guardada = 20;
                        }
                    }
                }
            }
        }
        //Para o caso de ser um Jogador que esteja não vá jogar
        public Jogador()
        {
            Perdeu = true;
        }

        public bool Verificar_se_o_Estado_lhe_Pertence(Territorio territorio)
        {
            if (Territórios_Possuídos[territorio.índice] == 1)
                return true;
            else
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

        //Este médodo vai ser usado para tomar posse de um território vazio (Para a fase de Setup)
        public void Tomar_Posse_de_Território(Territorio territorio_a_tomar_posse)
        {
            territorio_a_tomar_posse.Identificação_do_Jogador_que_o_possui = Identificação;
            territorio_a_tomar_posse.botão.Cor_Texto = this.Cor;
            territorio_a_tomar_posse.Infantaria_Presente = 1;
            Territórios_Possuídos[territorio_a_tomar_posse.índice] = 1;
            Número_de_Infantaria_Guardada--;
        }

        public void Reforçar_Território(Territorio t)
        {
            t.Infantaria_Presente++;
            Número_de_Infantaria_Guardada--;
        }

        public bool Ficou_Sem_Infantaria()
        {
            if (Número_de_Infantaria_Guardada == 0)
                return true;
            else
                return false;
        }

        public void Verificar_se_Perdeu()
        {
            bool não_encontrou_nenhum_seu=true;
            for(int i=0;i<42;i++)
            {
                if (Territórios_Possuídos[i] == 1)
                    não_encontrou_nenhum_seu = false;
            }
            this.Perdeu = não_encontrou_nenhum_seu;
        }

        public int Contar_Territórios()
        {
            int c=0;
            for(int i=0;i<42;i++)
            {
                if (Territórios_Possuídos[i] == 1)
                    c++;
            }
            return c;
        }
    }
}
