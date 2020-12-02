using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jengine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class MenuButton : Button
    {
        bool quit;

        public bool getQuit
        {
            get
            {
                return quit;
            }
            set
            {
                quit = value;
            }
        }

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

        public void Function()
        {
            KeyboardState keyInput = Keyboard.GetState();
            if (keyInput.IsKeyDown(Keys.Space))
            {
                switch (currentPos)
                {
                    case 1:
                        Game1.gameState = Game1.State.Play;
                        Game1.stateSwitch = true;
                        //gameState = Game1.State.Play;
                        return;
                    case 2:
                        return;
                    case 3:
                        quit = true;
                        return;
                }
            }
        }
    }
}
