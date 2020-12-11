using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jengine
{
    class Player : Animation
    {
        Texture2D playerDefault;
        Texture2D playerUp;
        Texture2D playerLeft;
        Texture2D playerDown;
        Texture2D playerRight;
        string assetname;
        int Speed;
        int Boost = 0;
        Vector2 nextPos;
        bool intersect;
        Stopwatch stopWatch = new Stopwatch();
        public Player(Vector2 position, int Speed, ContentManager Content)
        {
            this.sprite = Content.Load<Texture2D>("playerDown@2x1");
            playerDown = Content.Load<Texture2D>("playerDown@2x1");
            playerUp = Content.Load<Texture2D>("playerUp@2x1");
            playerLeft = Content.Load<Texture2D>("playerLeft@2x1");
            playerRight = Content.Load<Texture2D>("playerRight@2x1");
            assetname = "player@2x1";

            sheetColumns = 1;
            sheetRows = 1;
            spriteRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            //Set position and origin.
            this.position = position;
            this.Speed = Speed;
            this.origin = new Vector2(0, 0);
            Initialize();
            updateSheet();
        }

        //public Rectangle nextMove => new Rectangle(new Vector2(position.X, position.Y), sprite.Width, sprite.Height);
        public Rectangle newMove => new Rectangle(Convert.ToInt32(nextPos.X) - sprite.Width/2, Convert.ToInt32(nextPos.Y) - sprite.Height/2, sprite.Width, sprite.Height);

        public void updateSheet()
        {
            // see if we can extract the number of sheet elements from the assetname
            string[] assetSplit = assetname.Split('@');
            if (assetSplit.Length >= 2)
            {
                // behind the last '@' symbol, there should be a number.
                // This number can be followed by an 'x' and then another number.
                string sheetNrData = assetSplit[assetSplit.Length - 1];
                string[] columnAndRow = sheetNrData.Split('x');
                sheetColumns = int.Parse(columnAndRow[0]);
                if (columnAndRow.Length == 2)
                    sheetRows = int.Parse(columnAndRow[1]);
            }

            // apply the sheet index; this will also calculate spriteRectangle
            SheetIndex = sheetIndex;
        }

        public bool setIntersect
        {
            set
            {
                intersect = value;
            }
        }

        public void Initialize()
        {
            stopWatch.Start();
            nextPos.X = position.X;
            nextPos.Y = position.Y;
        }

        public override void Update()
        {
            KeyboardState keyInput = Keyboard.GetState();
            if (keyInput.IsKeyDown(Keys.LeftShift) || keyInput.IsKeyDown(Keys.RightShift))
                Boost = 1;
            else
                Boost = 0;

            if (keyInput.IsKeyDown(Keys.S) || keyInput.IsKeyDown(Keys.Down))
            {
                this.sprite = playerDown;
                assetname = "playerDown@2x1";
                nextPos.Y += Speed + Boost;
            }

            else if (keyInput.IsKeyDown(Keys.A) || keyInput.IsKeyDown(Keys.Left))
            {
                this.sprite = playerLeft;
                assetname = "playerLeft@2x1";
                nextPos .X -= Speed + Boost;
            }

            else if (keyInput.IsKeyDown(Keys.D) || keyInput.IsKeyDown(Keys.Right))
            {
                this.sprite = playerRight;
                assetname = "playerRight@2x1";
                nextPos.X += Speed + Boost;
            }

            else if (keyInput.IsKeyDown(Keys.W) || keyInput.IsKeyDown(Keys.Up))
            {
                this.sprite = playerUp;
                assetname = "playerUp@2x1";
                nextPos.Y -= Speed + Boost;
            }

            if(keyInput.IsKeyDown(Keys.W) || keyInput.IsKeyDown(Keys.Up) || keyInput.IsKeyDown(Keys.S) || keyInput.IsKeyDown(Keys.Down) || keyInput.IsKeyDown(Keys.D) || keyInput.IsKeyDown(Keys.Right) || keyInput.IsKeyDown(Keys.A) || keyInput.IsKeyDown(Keys.Left))
            //If timer hits set amount of time, switch frame.
            if (stopWatch.ElapsedMilliseconds > 200)
            {
                //Check if there are frames left to switch, if not go back to frame 0.
                if (SheetIndex < totalSheetFrames - 1)
                {
                    SheetIndex++;
                }
                else
                    SheetIndex = 0;
                stopWatch.Restart();
            }
            moveCheck();
            updateSheet();
        }

        public void moveCheck()
        {

            if (intersect)
            {
                nextPos = position;
                intersect = false;

            }
            position = nextPos;
        }

    }
}
