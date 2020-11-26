using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jengine
{
    class GameObject
    {
        protected Texture2D sprite;
        protected Vector2 position;
        protected Vector2 origin;
        protected Rectangle spriteRectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, spriteRectangle, Color.White, 0.0f, origin, 1.0f, SpriteEffects.None, 0.0f);
        }

        public virtual void Update()
        {
        }
    }
}
