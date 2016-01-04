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
    class Sprite
    {

        protected Texture2D image;
        Rectangle rectangle;
        protected ContentManager cManager;
        public string name;
        public Vector2 position;
        protected float rotation;
        protected Vector2 size;
        public Vector2 origem;
        public Vector2 centroRot;
        protected Vector2 pixelSize;
        protected Scene scene;
        protected Color mTintColor; 


       // protected Scene scene;

        public Sprite(ContentManager contents,String assetName,Texture2D newTexture, Rectangle newRectangle)
        {
            this.cManager = contents;

            this.rectangle = newRectangle;
            this.position = Vector2.Zero;
            this.rotation = 0f;
            this.name = assetName;
            this.size = new Vector2(1f, (float)image.Height / (float)image.Width);
            this.origem = new Vector2(pixelSize.X / 2, pixelSize.Y / 2);
            this.pixelSize = new Vector2(image.Width, image.Height);
            this.image = contents.Load<Texture2D>(assetName);
            mTintColor = Color.White;

        }


        public virtual void Scale(float scale)
        {
            this.size *= scale;
        }
        public virtual void SetScene(Scene s)
        {
            this.scene = s;
        }
        public Sprite Scl(float scale)
        {
            this.Scale(scale);
            return this;
        }

        public void LookAt(Vector2 p)
        {
            this.rotation = (float)Math.Atan2(p.X, p.Y);
        }
        public virtual void Draw(GameTime gameTime)
        {
            Rectangle pos = Camara.WorldSize2PixelRectangle(this.position, this.size); //? this.position posição da sprite no mundo virtual, tamanho da sprite no mundo virtual size 
            // pos a posição da sprite na camera, mundo começa a desenhar/coordenadas no canto inferior esquerdo
            // retorna o tamanho da sprite em pixeis camera
            // scene.SpriteBatch.Draw(this.image, pos, Color.White);
            scene.SpriteBatch.Draw(this.image, pos, source, mTintColor, //Adds a sprite to a batch of sprites for rendering using the specified texture,  
            this.rotation, this.origem,// O centro da sprite position, source rectangle, color, rotation, origin, scale, effects and layer.
            SpriteEffects.None, 0);
        }

        public virtual void SetRotation(float r)
        {
            this.rotation = r;
        }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Dispose()
        {
            this.image.Dispose();
        }
        public virtual void Destroy()
        {
            this.scene.RemoveSprite(this);
        }
        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }
        public Sprite At(Vector2 p)
        {
            this.SetPosition(p);
            return this;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
