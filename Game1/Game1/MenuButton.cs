using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jengine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class MenuButton : Button
    {
        public MenuButton(int height, int width, Vector2 position, Texture2D tex, int posInList, int listTotal, SpriteFont text, String name)
        {
            this.height = height;
            this.width = width;
            this.position = position;
            this.sprite = tex;
            spriteRectangle = new Rectangle(0, 0, width, height);
            this.posInList = posInList;
            this.listTotal = listTotal;
            this.text = text;
            this.name = name;
        }

        public override void Function()
        {
            switch (currentPos)
            {
                case 1:
                    return;
                case 2:
                    return;
                case 3:
                    return;
            }
        }
    }
}
