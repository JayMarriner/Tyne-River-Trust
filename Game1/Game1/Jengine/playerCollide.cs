using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jengine
{
    class playerCollide : Animation
    {
        public playerCollide(Vector2 position, Texture2D sprite, string assetname)
        {
            this.position = position;

            // retrieve the sprite
            this.sprite = sprite;
            sheetColumns = 1;
            sheetRows = 1;

            //Set position and origin.
            this.position = position;
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

        public Rectangle hitBox => new Rectangle(Convert.ToInt32(position.X) - sprite.Width/2, Convert.ToInt32(position.Y) - sprite.Height/2, sprite.Width, sprite.Height);

        public void UpdateCollision(Player player)
        {
            if (this.hitBox.Intersects(player.newMove))
                player.setIntersect = true;
        }
    }
}
