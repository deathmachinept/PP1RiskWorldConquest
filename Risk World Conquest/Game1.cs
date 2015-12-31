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
        Texture2D button;
        Tabuleiro tabuleiro;
        int Número_de_Jogadores=3;
        Jogador[] Jogadores=new Jogador[6];
        enum GameState
        {
            MainMenu,
            Options,
            Setup,
            Drafting,
            Attacking,
            Reinforcing,
        }
        GameState CurrentGameState = GameState.MainMenu;
        //Botões do Menu:
        cButton btnPlay;
        Button add,sub;
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

                if (add.Foi_Clicado && Número_de_Jogadores < 6)
                    Número_de_Jogadores++;
                if (sub.Foi_Clicado && Número_de_Jogadores > 3)
                    Número_de_Jogadores--;
            }
            if (CurrentGameState == GameState.Setup)
            {
                for(int i=0;i<6;i++)
                {
                    if (i <= Número_de_Jogadores)
                        Jogadores[i] = new Jogador(i + 1, Número_de_Jogadores);
                    else
                        Jogadores[i] = new Jogador();
                }
                    Jogadores[0].Cor = Color.Red;
                    Jogadores[1].Cor = Color.Blue;
                    Jogadores[2].Cor = Color.Green;
                    Jogadores[3].Cor = Color.Yellow;
                    Jogadores[4].Cor = Color.Black;
                    Jogadores[5].Cor = Color.White;
                //Vão ser rolados os dados para cada jogador para escolher o primeiro a colocar os soldados
                int maior_numero_saido=0,jogador_com_maior_numero=-1;
                for (int i = 0; i < Número_de_Jogadores;i++)
                {
                    if(maior_numero_saido<r.Next(1,7))
                    {
                        jogador_com_maior_numero=i;
                    }
                }
                //Os Jogadores irão ocupar os vários continentes
                int jogador_que_esta_a_inserir = jogador_com_maior_numero;
                while(!tabuleiro.Os_Territórios_Estão_Todos_Ocupados())
                {

                }
                //CurrentGameState = GameState.Drafting;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            //Console.WriteLine((int)((width / 2) / 2));
            //Console.WriteLine((int)((height / 2) / 2));

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
                spriteBatch.DrawString(gametxt, Número_de_Jogadores.ToString(), new Vector2(1100, 275), Color.White);

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
                    tabuleiro.Territorios[i].botão.Draw(spriteBatch);
                    spriteBatch.DrawString(button_text, tabuleiro.Territorios[i].Infantaria_Presente.ToString(), tabuleiro.Territorios[i].botão.Posição,tabuleiro.Territorios[i].botão.Cor);
                }

                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}
