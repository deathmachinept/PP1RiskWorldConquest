using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace Risk_World_Conquest
{
    class Button
    {
        Texture2D Textura;
        public Vector2 Posição;
        //Cor a dar para as letras
        public Color Cor_Texto=Color.Gray;
        Rectangle boundingBox;
        GraphicsDevice gdevice;

        public bool Foi_Clicado;
        public bool Está_Por_Cima;
        public float Tempo_Esperado=0;

        public Button(GraphicsDevice graphics,Texture2D textura,Vector2 pos)
        {
            this.Textura = textura;
            this.Posição = pos;
            this.gdevice = graphics;
        }

        public void Update(MouseState mouseState,GameTime time)
        {
            boundingBox = new Rectangle((int)Posição.X,(int)Posição.Y,Textura.Width,Textura.Height);
            Rectangle mousepos=new Rectangle((int)mouseState.Position.X,(int)mouseState.Position.Y,1,1);
            
            if (boundingBox.Intersects(mousepos))
                Está_Por_Cima = true;
            else
                Está_Por_Cima = false;

            if (Está_Por_Cima && mouseState.LeftButton == ButtonState.Pressed && Tempo_Esperado>=250)
            {
                Foi_Clicado = true;
                Tempo_Esperado = 0;
            }
            else
                Foi_Clicado=false;
            Tempo_Esperado += time.ElapsedGameTime.Milliseconds;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.Textura,this.boundingBox,Color.White);
        }

        public void Draw_Botão_Território(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.Textura, this.boundingBox, new Color(Color.White,0));
        }
    }
}
