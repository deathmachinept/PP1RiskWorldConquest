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
    /// <summary>
     /// Regras resumidas
        /// O tabuleiro é dividido em 42 partes :  gronelandia ,America do norte, e central em 9 partes;4 a ameriaca do sul;europa e russia ocidental em 7 partes;
        /// Asia e restante russia em 12 partes;Africa em 6 partes; Filipinas e Oceania em 4 partes;
        /// 1º selecionar o nº de jogadores , min vai ser 3 cada um escolhe uma cor ou e atribuida automaticamente;
        /// 2ªdistribuir as unidades dos exercitos dos jogadores pelos territorios em qualqer continente(se forem 3 serao 35 para cada um, para 4 30 unidades, para 5 25 unidades e para 6 20 unidades
        /// 3ªO exrcito e composto por as seguintes unidades:infantaria, cavalaria e artilharia;
        /// 4 ª1 exercito corresponde a 1 infantaria qe pode chegar ate 4; 
        ///5ª 5 elementos do exercito de infantaria correspondem a 1 cavalaria;
        /// 6ª 5 elementos de cavalaria corrposndem a 1 artilharia;
        ///7ª No começo do jogo o jogador qe tirar o maior nº começa a distribuir as unidades pelo mapa
        ///8ª No final de os exercitos serem distribuidos , o jogador pode optar por invadir os territorios em qe os seus exercitos façam fronteira
        /// ou de reforçar os seus territorios 
        /// 9ªRegras de combate: depois de selecionar o seu exercito e o terreno qe qer invadir , as duas forças terao de lutar ate os exercitos de uma das forças 
        /// ficarem a 0. pudendo depois ocupar , caso ganhe, com as forças restantes.
        ///10º Os combates serao atraves de lancamento do dado. o qe tiver maior nº ganhe o combate e elimina uma unidade do exercito.
        ///11º Reforçar territorios:no minimo o jogador no final do seu turno recebe sempre 3 exercitos. 9 terr.  a 11 terr. pode receber 3 exer. ,14 terr. 4 exer. ,15 terr. 5 exer. e por assim fora
        /// 12º Cada territorio tem de ter pelo menos uma unidade
        /// 13 ºGanha qem conquistar tds os territorios no mapa
    /// This is the main type for your game.
    /// </summary>
    
    public class Game1 : Game
    {
        //Variáveis do Monogame
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont gametxt,button_text;
        Random r=new Random();
        int width;
        int height;
        //Variáveis do Menu
        Texture2D mainMenu;
        Rectangle mainMenuRec;
        //Variáveis do Jogo
        int jogador_actual;
        bool o_jogador_actual_escolheu = false;
        Texture2D button;
        Tabuleiro tabuleiro;
        int Número_Inicial_de_Jogadores=3;
        int vencedor=0;
        Jogador[] Jogadores=new Jogador[6];
        //Variáveis da fase de Setup
        bool já_foi_sorteado_o_primeiro = false;
        //Variáveis da fase de Drafting
        bool já_foi_dada_a_infantaria = false;
        //Variáveis da fase de Ataque
        Territorio território_atacante, território_defensor;
        bool escolheu_atacante=false;
        bool escolheu_defensor=false;
        bool escolheu_numero_de_infantaria_a_deslocar = false;
        bool atacante_ganhou = false;
        int infantaria_a_ser_deslocada = 1;
        //Variáveis da fase de Reforço
        bool escolheu_início=false;
        bool escolheu_destino=false;
        int infantaria_a_mover = 0;
        Territorio tInicial, tDestino;

        enum GameState
        {
            MainMenu,
            Options,
            Setup,
            Playing,
            Drafting,
            Attacking,
            Reinforcing,
            GameOver,
        }
        GameState CurrentGameState = GameState.MainMenu;
        //Botões do Menu:
        cButton btnPlay;
        Button add,sub,confirmar,proximo;
        //Botões do Ataque:
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            width = 1366;
            height = 768;
            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Camara.SetGraphicsDeviceManager(graphics);
            Camara.SetTarget(Vector2.Zero);
            Camara.SetWorldWidth(7);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            button = Content.Load<Texture2D>("Button");
            btnPlay = new cButton(Content.Load<Texture2D>("risklogo"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(350, 300));
            add = new Button(GraphicsDevice,Content.Load<Texture2D>("mais"),new Vector2(1100,300));
            sub = new Button(GraphicsDevice,Content.Load<Texture2D>("menos"),new Vector2(1100,350));
            confirmar = new Button(GraphicsDevice,Content.Load<Texture2D>("confirmar"),new Vector2(-100,-100));
            proximo = new Button(GraphicsDevice,Content.Load<Texture2D>("proximo"),new Vector2(-100,-100));

            gametxt = Content.Load<SpriteFont>("GameText");
            button_text = Content.Load<SpriteFont>("Numeros_Mapa");
            tabuleiro = new Tabuleiro(GraphicsDevice,button);
            mainMenu = Content.Load<Texture2D>("800x600");
            mainMenuRec = new Rectangle((int)((width / 2) - (mainMenu.Width / 2)), (int)((height / 2) - (mainMenu.Height / 2)), 800, 600);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mouse = Mouse.GetState();
            if (CurrentGameState == GameState.MainMenu)
            {
                if (btnPlay.isClicked == true) CurrentGameState = GameState.Setup;
                btnPlay.Update(mouse);

                add.Update(mouse,gameTime);
                sub.Update(mouse,gameTime);

                if (add.Foi_Clicado && Número_Inicial_de_Jogadores < 6)
                    Número_Inicial_de_Jogadores++;
                if (sub.Foi_Clicado && Número_Inicial_de_Jogadores > 3)
                    Número_Inicial_de_Jogadores--;
            }
            if (CurrentGameState == GameState.Setup)
            {
                if (!já_foi_sorteado_o_primeiro)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (i <= Número_Inicial_de_Jogadores)
                            Jogadores[i] = new Jogador(i + 1, Número_Inicial_de_Jogadores);
                        else
                            Jogadores[i] = new Jogador();
                    }
                    for (int i = 0; i < Número_Inicial_de_Jogadores; i++)
                    {
                        Jogadores[i].sorteio_inicial = r.Next(1, 7);
                    }
                    Jogadores[0].Cor = Color.Red;
                    Jogadores[1].Cor = Color.Blue;
                    Jogadores[2].Cor = Color.Green;
                    Jogadores[3].Cor = Color.Orange;
                    Jogadores[4].Cor = Color.Black;
                    Jogadores[5].Cor = Color.Cyan;
                    //Vão ser rolados os dados para cada jogador para escolher o primeiro a colocar os soldados
                    int maior_numero_saido = 0, jogador_com_maior_numero = -1;
                    for (int i = 0; i < Número_Inicial_de_Jogadores; i++)
                    {
                        if (Jogadores[i].sorteio_inicial > maior_numero_saido)
                        {
                            jogador_com_maior_numero = i;
                            maior_numero_saido = Jogadores[i].sorteio_inicial;
                        }
                    }
                    //Os Jogadores irão ocupar os vários continentes
                    jogador_actual = jogador_com_maior_numero;
                    já_foi_sorteado_o_primeiro = true;
                }


                //Enquanto os territórios não estiverem ocupados e os jogadores ainda tiverem infantaria
                if(!tabuleiro.Os_Territórios_Estão_Todos_Ocupados()||!Todos_os_Jogadores_Estão_Sem_Infantaria())
                {
                    if (!o_jogador_actual_escolheu)
                    {
                        for (int t = 0; t < 42; t++)
                        {
                            tabuleiro.Territorios[t].botão.Update(mouse, gameTime);
                            if (tabuleiro.Territorios[t].botão.Foi_Clicado)
                            {
                                //Se o território estiver desocupado
                                if (tabuleiro.Territorios[t].Está_Desocupado()&&!Jogadores[jogador_actual].Ficou_Sem_Infantaria())
                                {
                                    Jogadores[jogador_actual].Tomar_Posse_de_Território(tabuleiro.Territorios[t]);
                                }
                                else
                                {//Se não estiver mas se o jogador o possuir
                                    if (Jogadores[jogador_actual].Verificar_se_o_Estado_lhe_Pertence(tabuleiro.Territorios[t]) && !Jogadores[jogador_actual].Ficou_Sem_Infantaria())
                                    {
                                        Jogadores[jogador_actual].Reforçar_Território(tabuleiro.Territorios[t]);
                                    }
                                }
                                o_jogador_actual_escolheu = true;
                            }
                        }
                    }
                    else
                    {
                        //Se o jogador que está a inserir já escolheu...
                        //...então se este é o "último jogador", o jogador 0 (jogador 1) é o seguinte
                        if (jogador_actual == (Número_Inicial_de_Jogadores - 1))
                        {
                            jogador_actual = 0;
                        }
                        else
                        {
                            jogador_actual++;
                        }
                        o_jogador_actual_escolheu = false;
                    }
                }
                else
                {
                    //Inseridos todas as unidades de infantaria e conquistados os continentes, começa-se o jogo com o primeiro jogador na fase de drafting
                    jogador_actual = 0;
                    o_jogador_actual_escolheu = false;
                    CurrentGameState = GameState.Drafting;
                }
                //CurrentGameState = GameState.Drafting;
            }
            if (CurrentGameState == GameState.Drafting)
            {
                //Para o caso do jogador actual já ter perdido
                while(Jogadores[jogador_actual].Perdeu)
                {
                    if (jogador_actual == Número_Inicial_de_Jogadores)
                        jogador_actual = 0;
                    else
                        jogador_actual++;
                }
                //Aqui vão-se gerar os números de infantaria de cada jogador com base no número de continentes possuídos
                if (!já_foi_dada_a_infantaria)
                {
                    Jogadores[jogador_actual].Número_de_Infantaria_Guardada += Jogadores[jogador_actual].Contar_Territórios() + r.Next(1, 10);
                    já_foi_dada_a_infantaria = true;
                }
                    for (int t = 0; t < 42; t++)
                    {
                        tabuleiro.Territorios[t].botão.Update(mouse, gameTime);
                        if (tabuleiro.Territorios[t].botão.Foi_Clicado)
                        {
                            if (Jogadores[jogador_actual].Verificar_se_o_Estado_lhe_Pertence(tabuleiro.Territorios[t]) && Jogadores[jogador_actual].Número_de_Infantaria_Guardada > 0)
                            {
                                tabuleiro.Territorios[t].Infantaria_Presente++;
                                Jogadores[jogador_actual].Número_de_Infantaria_Guardada--;
                            }
                        }
                    }
                    if (Jogadores[jogador_actual].Ficou_Sem_Infantaria())
                    {
                        já_foi_dada_a_infantaria = false;
                        CurrentGameState = GameState.Attacking;
                    }
            }
            if (CurrentGameState == GameState.Attacking)
            {
                //Os "dados" são "lançados"
                for (int i = 0; i < Número_Inicial_de_Jogadores; i++)
                {
                    Jogadores[i].Lançar_Dados();
                }
                if (!escolheu_atacante || !escolheu_defensor)
                {
                    //Neste "for" serve para ler os cliques do rato e saber se está a escolher o atacante e o que vai ser atacado
                    for (int t = 0; t < 42; t++)
                    {
                        tabuleiro.Territorios[t].botão.Update(mouse, gameTime);
                        if (tabuleiro.Territorios[t].botão.Foi_Clicado)
                        {
                            if (!escolheu_atacante && Jogadores[jogador_actual].Verificar_se_o_Estado_lhe_Pertence(tabuleiro.Territorios[t]) && tabuleiro.Territorios[t].Infantaria_Presente > 1)
                            {
                                território_atacante = tabuleiro.Territorios[t];
                                escolheu_atacante = true;
                            }
                            if (escolheu_atacante && !escolheu_defensor && !Jogadores[jogador_actual].Verificar_se_o_Estado_lhe_Pertence(tabuleiro.Territorios[t]))
                            {
                                território_defensor = tabuleiro.Territorios[t];
                                //Este método vai dar tempo para o jogador actual ler a informação.
                                Esperar(gameTime, 2000);
                                escolheu_defensor = true;
                            }
                        }
                    }
                }

                //Para o caso do atacante ter ganho
                if (atacante_ganhou && !escolheu_numero_de_infantaria_a_deslocar)
                {
                    add.Update(mouse, gameTime);
                    sub.Update(mouse, gameTime);
                    confirmar.Update(mouse, gameTime);
                    if (add.Foi_Clicado && infantaria_a_ser_deslocada < (território_atacante.Infantaria_Presente - 1))
                    {
                        infantaria_a_ser_deslocada++;
                    }
                    if (sub.Foi_Clicado && infantaria_a_ser_deslocada > 0)
                    {
                        infantaria_a_ser_deslocada--;
                    }
                    if (confirmar.Foi_Clicado)
                    {
                        território_atacante.Infantaria_Presente -= infantaria_a_ser_deslocada;
                        tabuleiro.Territorios[infantaria_a_ser_deslocada] = território_atacante;

                        território_defensor.Infantaria_Presente = 0;
                        território_defensor.Infantaria_Presente += infantaria_a_ser_deslocada;
                        Jogadores[território_defensor.Identificação_do_Jogador_que_o_possui].Territórios_Possuídos[território_defensor.índice] = 0;

                        território_defensor.Identificação_do_Jogador_que_o_possui = jogador_actual;
                        Jogadores[território_defensor.Identificação_do_Jogador_que_o_possui].Territórios_Possuídos[território_defensor.índice] = 1;
                        território_defensor.botão.Cor_Texto = Jogadores[território_defensor.Identificação_do_Jogador_que_o_possui].Cor;
                        tabuleiro.Territorios[território_defensor.índice] = território_defensor;


                        escolheu_numero_de_infantaria_a_deslocar = true;
                        atacante_ganhou = false;
                    }
                }
                if (escolheu_atacante && escolheu_defensor)
                {
                    //Para o caso de todas as condições de ataque se reunirem
                    if (Pode_Atacar())
                    {
                        if (território_atacante.Infantaria_Presente > 2)
                        {
                            if (território_defensor.Infantaria_Presente >= 2)
                            {
                                //Se o primeiro dado do atacante for maior que o do defensor
                                if (Jogadores[jogador_actual].Dados[0] > Jogadores[território_defensor.Identificação_do_Jogador_que_o_possui].Dados[0])
                                {
                                    //O defensor perde infantaria
                                    território_defensor.Infantaria_Presente--;
                                    //O território no array original é actualizado
                                    tabuleiro.Territorios[território_defensor.índice] = território_defensor;
                                }
                                else
                                {
                                    //Senão
                                    //O atacante perde infantaria
                                    território_atacante.Infantaria_Presente--;
                                    //O território no array original é actualizado
                                    tabuleiro.Territorios[território_atacante.índice] = território_atacante;
                                }
                                if (Jogadores[jogador_actual].Dados[1] > Jogadores[território_defensor.Identificação_do_Jogador_que_o_possui].Dados[1])
                                {
                                    //O defensor perde infantaria
                                    território_defensor.Infantaria_Presente--;
                                    //O território no array original é actualizado
                                    tabuleiro.Territorios[território_defensor.índice] = território_defensor;
                                }
                                else
                                {
                                    //Senão
                                    //O atacante perde infantaria
                                    território_atacante.Infantaria_Presente--;
                                    //O território no array original é actualizado
                                    tabuleiro.Territorios[território_atacante.índice] = território_atacante;
                                }
                            }
                            else
                            {
                                //Se o primeiro dado do atacante for maior que o do defensor
                                if (Jogadores[jogador_actual].Dados[0] > Jogadores[território_defensor.Identificação_do_Jogador_que_o_possui].Dados[0])
                                {
                                    //O defensor perde infantaria(para 0)
                                    território_defensor.Infantaria_Presente--;
                                    //O território no array original é actualizado
                                    tabuleiro.Territorios[território_defensor.índice] = território_defensor;
                                }
                                else
                                {
                                    //Senão
                                    //O atacante perde infantaria
                                    território_atacante.Infantaria_Presente--;
                                    //O território no array original é actualizado
                                    tabuleiro.Territorios[território_atacante.índice] = território_atacante;
                                }
                            }
                        }
                        else
                        {
                            if (território_defensor.Infantaria_Presente >= 2)
                            {
                                //Se o primeiro dado do atacante for maior que o do defensor
                                if (Jogadores[jogador_actual].Dados[0] > Jogadores[território_defensor.Identificação_do_Jogador_que_o_possui].Dados[0])
                                {
                                    //O defensor perde infantaria
                                    território_defensor.Infantaria_Presente--;
                                    //O território no array original é actualizado
                                    tabuleiro.Territorios[território_defensor.índice] = território_defensor;
                                }
                                else
                                {
                                    //Senão
                                    //O atacante perde infantaria
                                    território_atacante.Infantaria_Presente--;
                                    //O território no array original é actualizado
                                    tabuleiro.Territorios[território_atacante.índice] = território_atacante;
                                }
                                if (Jogadores[jogador_actual].Dados[1] > Jogadores[território_defensor.Identificação_do_Jogador_que_o_possui].Dados[1])
                                {
                                    //O defensor perde infantaria
                                    território_defensor.Infantaria_Presente--;
                                    //O território no array original é actualizado
                                    tabuleiro.Territorios[território_defensor.índice] = território_defensor;
                                }
                                else
                                {
                                    //Senão
                                    //O atacante perde infantaria
                                    território_atacante.Infantaria_Presente--;
                                    //O território no array original é actualizado
                                    tabuleiro.Territorios[território_atacante.índice] = território_atacante;
                                }
                            }
                            else
                            {
                                //Se o primeiro dado do atacante for maior que o do defensor
                                if (Jogadores[jogador_actual].Dados[0] > Jogadores[território_defensor.Identificação_do_Jogador_que_o_possui].Dados[0])
                                {
                                    //O defensor perde infantaria(para 0)
                                    território_defensor.Infantaria_Presente--;
                                    //O território no array original é actualizado
                                    tabuleiro.Territorios[território_defensor.índice] = território_defensor;
                                }
                                else
                                {
                                    //Senão
                                    //O atacante perde infantaria
                                    território_atacante.Infantaria_Presente--;
                                    //O território no array original é actualizado
                                    tabuleiro.Territorios[território_atacante.índice] = território_atacante;
                                }
                            }
                        }
                        //Para o caso de todos os defensores terem sido destruídos aka o atacante ter ganho a batalha
                        if (território_defensor.Infantaria_Presente <= 0)
                        {
                            atacante_ganhou = true;
                            escolheu_numero_de_infantaria_a_deslocar = false;
                        }
                        escolheu_atacante = false;
                        escolheu_defensor = false;
                    }
                }
                proximo.Update(mouse,gameTime);
                if(proximo.Foi_Clicado)
                {
                    if (Há_Vencedor())
                        CurrentGameState = GameState.GameOver;
                    else
                    {
                        CurrentGameState = GameState.Reinforcing;
                        infantaria_a_ser_deslocada = 1;
                        escolheu_atacante = escolheu_defensor = escolheu_numero_de_infantaria_a_deslocar = atacante_ganhou = false;
                    }
                }
            }
            if (CurrentGameState == GameState.Reinforcing)
            {
                if(!escolheu_início || !escolheu_destino)
                {
                    for(int t=0;t<42;t++)
                    {
                        tabuleiro.Territorios[t].botão.Update(mouse,gameTime);
                        if(tabuleiro.Territorios[t].botão.Foi_Clicado)
                        {
                            if (!escolheu_início && Jogadores[jogador_actual].Verificar_se_o_Estado_lhe_Pertence(tabuleiro.Territorios[t]))
                            {
                                tInicial = tabuleiro.Territorios[t];
                                escolheu_início = true;
                            }
                            else
                            {
                                if (!escolheu_destino && escolheu_início && Jogadores[jogador_actual].Verificar_se_o_Estado_lhe_Pertence(tabuleiro.Territorios[t]))
                                {
                                    tDestino = tabuleiro.Territorios[t];
                                    escolheu_destino = true;
                                }
                            }
                        }
                    }
                }
                if(escolheu_início && escolheu_destino)
                {
                    add.Update(mouse,gameTime);
                    sub.Update(mouse,gameTime);
                    confirmar.Update(mouse,gameTime);
                    if(add.Foi_Clicado && infantaria_a_mover<=(tInicial.Infantaria_Presente-1))
                    {
                        infantaria_a_mover++;
                    }
                    if(sub.Foi_Clicado && infantaria_a_mover>0)
                    {
                        infantaria_a_mover--;
                    }
                    if(confirmar.Foi_Clicado)
                    {
                        tInicial.Infantaria_Presente -= infantaria_a_mover;
                        tabuleiro.Territorios[tInicial.índice] = tInicial;

                        tDestino.Infantaria_Presente += infantaria_a_mover;
                        tabuleiro.Territorios[tDestino.índice] = tDestino;

                        infantaria_a_mover = 0;
                        escolheu_início = false;
                        escolheu_destino = false;

                        if (jogador_actual == (Número_Inicial_de_Jogadores - 1))
                            jogador_actual = 0;
                        else
                            jogador_actual++;

                        CurrentGameState = GameState.Drafting;
                    }
                }
            }
            // Verificar a cada ciclo cada jogador para ver se algum perdeu(APENAS DEPOIS DE OS JOGADORES SEREM CRIADOS NO MAIN MENU)
            if (CurrentGameState != GameState.MainMenu)
            {
                for (int a = 0; a < Número_Inicial_de_Jogadores; a++)
                {
                   Jogadores[a].Verificar_se_Perdeu();
                    if (!Jogadores[a].Perdeu)
                        Jogadores[a].Lançar_Dados();
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);

            // TODO: Add your drawing code here
            if (CurrentGameState == GameState.MainMenu)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(mainMenu, mainMenuRec, Color.White);
                
                //spriteBatch.Draw(Content.Load<Texture2D>bntWIII)
                btnPlay.Draw(spriteBatch);
                add.Draw(spriteBatch);
                sub.Draw(spriteBatch);

                spriteBatch.DrawString(gametxt, "Jogadores:", new Vector2(1100, 250), Color.White);
                spriteBatch.DrawString(gametxt, Número_Inicial_de_Jogadores.ToString(), new Vector2(1100, 275), Color.White);

                spriteBatch.End();
            }
            if (CurrentGameState == GameState.Setup)
            {
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Begin();
                //Desenhar o mapa
                spriteBatch.Draw(Content.Load<Texture2D>("Mapa"),new Vector2(0,0));
                
                //Desenhar os botões dos países
                for (int i = 0; i < tabuleiro.Territorios.Length;i++)
                {
                    tabuleiro.Territorios[i].botão.Draw_Botão_Território(spriteBatch);
                    spriteBatch.DrawString(button_text, tabuleiro.Territorios[i].Infantaria_Presente.ToString(), tabuleiro.Territorios[i].botão.Posição,tabuleiro.Territorios[i].botão.Cor_Texto);
                }
                spriteBatch.DrawString(gametxt, "Posicionar Unidades", new Vector2(600, 0), Color.Black);
                spriteBatch.DrawString(gametxt, "Jogador actual " + (jogador_actual + 1).ToString(), new Vector2(0, 0), Jogadores[jogador_actual].Cor);
                spriteBatch.DrawString(gametxt, "Infantaria Restante " + Jogadores[jogador_actual].Número_de_Infantaria_Guardada.ToString(), new Vector2(0, 15), Jogadores[jogador_actual].Cor);
                spriteBatch.End();
            }
            if (CurrentGameState == GameState.Drafting)
            {
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Begin();
                //Desenhar o mapa
                spriteBatch.Draw(Content.Load<Texture2D>("Mapa"), new Vector2(0, 0));

                //Desenhar os botões dos países
                for (int i = 0; i < tabuleiro.Territorios.Length; i++)
                {
                    tabuleiro.Territorios[i].botão.Draw_Botão_Território(spriteBatch);
                    spriteBatch.DrawString(button_text, tabuleiro.Territorios[i].Infantaria_Presente.ToString(), tabuleiro.Territorios[i].botão.Posição, tabuleiro.Territorios[i].botão.Cor_Texto);
                }

                spriteBatch.DrawString(gametxt, "Posicionar Novas Unidades", new Vector2(600, 0), Color.Black);
                spriteBatch.DrawString(gametxt, "Jogador actual " + (jogador_actual + 1).ToString(), new Vector2(0, 0), Jogadores[jogador_actual].Cor);
                spriteBatch.DrawString(gametxt, "Infantaria Restante " + Jogadores[jogador_actual].Número_de_Infantaria_Guardada.ToString(), new Vector2(0, 15), Jogadores[jogador_actual].Cor);

                spriteBatch.End();
            }
            if (CurrentGameState == GameState.Attacking)
            {
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Begin();
                //Desenhar o mapa
                spriteBatch.Draw(Content.Load<Texture2D>("Mapa"), new Vector2(0, 0));

                //Desenhar os botões dos países
                for (int i = 0; i < tabuleiro.Territorios.Length; i++)
                {
                    tabuleiro.Territorios[i].botão.Draw_Botão_Território(spriteBatch);
                    spriteBatch.DrawString(button_text, tabuleiro.Territorios[i].Infantaria_Presente.ToString(), tabuleiro.Territorios[i].botão.Posição, tabuleiro.Territorios[i].botão.Cor_Texto);
                }

                spriteBatch.DrawString(gametxt, "Atacar", new Vector2(600, 0), Color.Black);
                spriteBatch.DrawString(gametxt, "Jogador actual " + (jogador_actual + 1).ToString(), new Vector2(0, 0), Jogadores[jogador_actual].Cor);
                
                if(escolheu_atacante==true)
                    spriteBatch.DrawString(gametxt, "Territorio a atacar " + território_atacante.Nome, new Vector2(0, 16), Jogadores[jogador_actual].Cor);
                if(escolheu_defensor==true)
                    spriteBatch.DrawString(gametxt, "Territorio defensor " + território_defensor.Nome, new Vector2(0, 32), Jogadores[território_defensor.Identificação_do_Jogador_que_o_possui].Cor);

                if (atacante_ganhou && !escolheu_numero_de_infantaria_a_deslocar)
                {
                    spriteBatch.DrawString(gametxt,"Quantas unidades serao destacadas",new Vector2(25,500),Color.Black);
                    spriteBatch.DrawString(gametxt, infantaria_a_ser_deslocada.ToString(), new Vector2(25,516), Color.Black);
                    add.Posição = new Vector2(25,540);
                    sub.Posição = new Vector2(25,590);
                    add.Draw(spriteBatch);
                    sub.Draw(spriteBatch);
                    confirmar.Draw(spriteBatch);
                }

                confirmar.Posição = new Vector2(75, 557);
                proximo.Posição = new Vector2(1300, 700);
                proximo.Draw(spriteBatch);

                spriteBatch.End();
            }
            if (CurrentGameState == GameState.Reinforcing)
            {
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Begin();
                //Desenhar o mapa
                spriteBatch.Draw(Content.Load<Texture2D>("Mapa"), new Vector2(0, 0));

                //Desenhar os botões dos países
                for (int i = 0; i < tabuleiro.Territorios.Length; i++)
                {
                    tabuleiro.Territorios[i].botão.Draw_Botão_Território(spriteBatch);
                    spriteBatch.DrawString(button_text, tabuleiro.Territorios[i].Infantaria_Presente.ToString(), tabuleiro.Territorios[i].botão.Posição, tabuleiro.Territorios[i].botão.Cor_Texto);
                }
                spriteBatch.DrawString(gametxt, "Reforcar", new Vector2(600, 0), Color.Black);
                spriteBatch.DrawString(gametxt, "Jogador actual " + (jogador_actual + 1).ToString(), new Vector2(0, 0), Jogadores[jogador_actual].Cor);

                if (escolheu_início == true)
                    spriteBatch.DrawString(gametxt, "Territorio de onde partem  " + tInicial.Nome, new Vector2(0, 16), Jogadores[jogador_actual].Cor);
                if (escolheu_destino == true)
                    spriteBatch.DrawString(gametxt, "Territorio para onde vao " + tDestino.Nome, new Vector2(0, 32), Jogadores[jogador_actual].Cor);

                if(escolheu_início && escolheu_destino)
                {
                    spriteBatch.DrawString(gametxt, "Quantas unidades serao movidas", new Vector2(25, 500), Color.Black);
                    spriteBatch.DrawString(gametxt,infantaria_a_mover.ToString(), new Vector2(25, 516), Color.Black);
                    add.Posição = new Vector2(25, 540);
                    sub.Posição = new Vector2(25, 590);
                    add.Draw(spriteBatch);
                    sub.Draw(spriteBatch);
                    confirmar.Draw(spriteBatch);
                }
                spriteBatch.End();
            }
            if (CurrentGameState == GameState.GameOver)
            {
                Get_Vencedor();
                spriteBatch.Begin();
                spriteBatch.DrawString(button_text,"Ganha o Jogador "+vencedor.ToString(),new Vector2(600,300),Color.White);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        private bool Todos_os_Jogadores_Estão_Sem_Infantaria()
        {
            bool tudo_sem_infantaria=true;
            for(int i=0;i<Número_Inicial_de_Jogadores;i++)
            {
                if(!Jogadores[i].Ficou_Sem_Infantaria())
                {
                    tudo_sem_infantaria = false;
                }
            }
            return tudo_sem_infantaria;
        }

        private bool Há_Vencedor()
        {
            int jogadores_activos = 0;
            for(int i=0;i<Número_Inicial_de_Jogadores;i++)
            {
                if(!Jogadores[i].Perdeu)
                {
                    jogadores_activos++;
                }
            }
            if (jogadores_activos > 1)
                return false;
            else
                return true;
        }

        private void Get_Vencedor()
        {
            for(int i=0;i<Número_Inicial_de_Jogadores;i++)
            {
                if (!Jogadores[i].Perdeu)
                    vencedor = i+1;
            }
        }

        private bool Pode_Atacar()
        {
            if (território_atacante.Infantaria_Presente > 1 && tabuleiro.Está_Na_Vizinhança(território_atacante, território_defensor) && escolheu_atacante && escolheu_defensor)
                return true;
            else
                return false;
        }

        private void Reforçar()
        {
            tInicial.Infantaria_Presente -= infantaria_a_mover;
            tabuleiro.Territorios[tInicial.índice] = tInicial;

            tDestino.Infantaria_Presente += infantaria_a_mover;
            tabuleiro.Territorios[tDestino.índice] = tDestino;
        }

        private void Esperar(GameTime gtime,float Millissegundos)
        {
            float tempo_passado = 0;
            while(tempo_passado<Millissegundos)
            {
                tempo_passado += gtime.ElapsedGameTime.Milliseconds;
            }
        }
    }
}
