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
    class Scene
    {

        public SpriteBatch SpriteBatch { get; private set; } 
        public List<Sprite> sprites;
        private List<SlidingBackground> backgrounds;
        public Vector3 pixelSize;
        public Vector2 position;
        public Vector3 size;
        public Scene(SpriteBatch sb)
        {
            this.SpriteBatch = sb; //cria um objecto na cena
            this.sprites = new List<Sprite>();
            this.backgrounds = new List<SlidingBackground>();
  
        }

        private Vector2 ImagePixelToVirtualWorld(int i, int j)
        {
            float x = i * size.X / (float)pixelSize.X;
            float y = j * size.Y / (float)pixelSize.Y;
            return new Vector2(position.X + x - (size.X * 0.5f),
                                                                 position.Y - y + (size.Y * 0.5f));
        }

        private Vector2 VirtualWorldPointToImagePixel(Vector2 p)
        {
            Vector2 delta = p - position;
            float i = delta.X * pixelSize.X / size.X; // regra de 3 simples
            float j = delta.Y * pixelSize.Y / size.Y;

            i += pixelSize.X * 0.5f;
            j = pixelSize.Y * 0.5f - j;

            return new Vector2(i, j);
        }

        public void AddSprite(Sprite s)
        {
            this.sprites.Add(s);
            s.SetScene(this);
        }

        public void AddBackground(SlidingBackground b)
        {
            this.backgrounds.Add(b);
            b.SetScene(this);
        }

        public void RemoveSprite(Sprite s)
        {
            this.sprites.Remove(s);
        }
        public void Update(GameTime gameTime)
        {
            foreach (var sprite in sprites.ToList())
            {
                sprite.Update(gameTime);
            }
        }
        public void Draw(GameTime gameTime)
        {
            if (sprites.Count > 0 || backgrounds.Count > 0)
            {
                this.SpriteBatch.Begin();
                //Desenhar os fundos
                foreach (var background in backgrounds)
                    background.Draw(gameTime);

                //Desenhar as sprites|
                foreach (var sprite in sprites)
                {
                    sprite.Draw(gameTime);
                }
                this.SpriteBatch.End();
            }
        }

      
        public void Dispose()
        {
            foreach (var sprite in sprites)
            {
                sprite.Dispose();
            }

            foreach (var background in backgrounds)
                background.Dispose();
        }

    }
}
