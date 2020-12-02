﻿using Microsoft.Xna.Framework;
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
        Stopwatch stopWatch = new Stopwatch();
        public Player(Vector2 position, int Speed, ContentManager Content)
        {
            //playerDefault = Content.Load<Texture2D>("player@1x1");
            //playerUp = Content.Load<Texture2D>("playerUp@2x1");
            //playerLeft = Content.Load<Texture2D>("playerLeft@2x1");
            this.sprite = Content.Load<Texture2D>("playerDown@2x1");
            playerDown = Content.Load<Texture2D>("playerDown@2x1");
            //playerRight = Content.Load<Texture2D>("playerRight@2x1");
            //this.sprite = Content.Load<Texture2D>("player@1x1");
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

        public void Initialize()
        {
            stopWatch.Start();
        }

        public override void Update()
        {
            KeyboardState keyInput = Keyboard.GetState();
            if (keyInput.IsKeyDown(Keys.LeftShift) || keyInput.IsKeyDown(Keys.RightShift))
                Boost = 1;
            else
                Boost = 0;

            if (keyInput.IsKeyDown(Keys.S))
            {
                this.sprite = playerDown;
                assetname = "playerDown@2x1";
                position.Y+= Speed + Boost;
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
            }
            updateSheet();
        }

    }
}
