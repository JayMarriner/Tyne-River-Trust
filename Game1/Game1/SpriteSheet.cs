using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    class SpriteSheet : GameObject
    {
        protected int sheetIndex = 0;
        protected int sheetColumns;
        protected int sheetRows;

        /// <summary>
        /// Gets the width of a single sprite in this sprite sheet.
        /// </summary>
        public int Width
        {
            get { return sprite.Width / sheetColumns; }
        }

        /// <summary>
        /// Gets the height of a single sprite in this sprite sheet.
        /// </summary>
        public int Height
        {
            get { return sprite.Height / sheetRows; }
        }

        /// <summary>
        /// Gets a vector that represents the center of a single sprite in this sprite sheet.
        /// </summary>
        public Vector2 Center
        {
            get { return new Vector2(Width, Height) / 2; }
        }

        /// <summary>
        /// Gets or sets the sprite index within this sprite sheet to use. 
        /// If you set a new index, the object will recalculate which part of the sprite should be drawn.
        /// </summary>
        public int SheetIndex
        {
            get { return sheetIndex; }
            set
            {
                if (value >= 0 && value < NumberOfSheetElements)
                {
                    sheetIndex = value;

                    // recalculate the part of the sprite to draw
                    int columnIndex = sheetIndex % sheetColumns;
                    int rowIndex = sheetIndex / sheetColumns;
                    spriteRectangle = new Rectangle(columnIndex * Width, rowIndex * Height, Width, Height);
                }
            }
        }

        /// <summary>
        /// Gets a Rectangle that represents the bounds of a single sprite in this sprite sheet.
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(0, 0, Width, Height);
            }
        }

        /// <summary>
        /// Gets the total number of elements in this sprite sheet.
        /// </summary>
        public int NumberOfSheetElements
        {
            get { return sheetColumns * sheetRows; }
        }
    }
}
