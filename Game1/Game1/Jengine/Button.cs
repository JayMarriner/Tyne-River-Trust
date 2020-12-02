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
        protected int height;
        protected int width;
        protected int posInList;
        protected int currentPos;
        protected int listTotal;
        protected SpriteFont text;
        protected string name;
        KeyboardState lastKey = Keyboard.GetState();

        /* FOR CHILD CLASS
        public Button(int height, int width, Vector2 position, Texture2D tex, int posInList, int listTotal, SpriteFont text, String name)
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
        */

        public void Initialize()
        {
            currentPos = 1;
        }

        public override void Update()
        {
            KeyboardState keyInput = Keyboard.GetState();
            if(keyInput.IsKeyUp(Keys.S) && lastKey.IsKeyDown(Keys.S) || keyInput.IsKeyUp(Keys.Down) && lastKey.IsKeyDown(Keys.Down))
            {
                if (currentPos == listTotal)
                    currentPos = 1;
                else
                    currentPos++;
            }
            if (keyInput.IsKeyUp(Keys.W) && lastKey.IsKeyDown(Keys.W) || keyInput.IsKeyUp(Keys.Up) && lastKey.IsKeyDown(Keys.Up))
            {
                if (currentPos == 1)
                    currentPos = listTotal;
                else
                    currentPos--;
            }
            if (posInList == currentPos)
            {
                color = Color.White;
            }
            else
                color = Color.Gray;

            lastKey = keyInput;
        }

        public void TextDraw(SpriteBatch sb)
        {

            //sb.DrawString(text, name, new Vector2(position.X + width/2, position.Y + height/2), Color.Black);
        }
    }
}
