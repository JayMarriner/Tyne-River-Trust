using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jengine
{
    class Button : GameObject
    {
        int height;
        int width;

        public Button(int height, int width, Vector2 position, Color color, Texture2D tex)
        {
            this.height = height;
            this.width = width;
            this.position = position;
            this.color = color;
            this.sprite = tex;
            spriteRectangle = new Rectangle(0, 0, width, height);
        }

        public void Initialize()
        {
        }

        public override void Update()
        { 
        }
    }
}
