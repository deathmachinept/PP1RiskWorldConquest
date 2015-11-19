using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
