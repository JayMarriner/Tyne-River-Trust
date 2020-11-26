using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.Threading;

namespace Jengine
{
    class Menu : Animation
    {
        float timer;
        int timecounter;
        bool changeFrame;
        Stopwatch stopWatch = new Stopwatch();

        public Menu(string assetname, Texture2D sprite)
        {
            // retrieve the sprite
            this.sprite = sprite;
            sheetColumns = 1;
            sheetRows = 1;

            //Set position and origin.
            this.position = new Vector2(0, 0);
            this.origin = new Vector2(0, 0);

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
            //If timer hits set amount of time, switch frame.
            if(stopWatch.ElapsedMilliseconds > 200)
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
    }
}
