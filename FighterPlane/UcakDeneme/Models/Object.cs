using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FighterPlane.Models
{
    abstract  class Object
    {
        public virtual void unit(int x, int y)
        {
            Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            Picture.BackColor = Color.Transparent;
            Size = new Size(x, y);
        }
        public PictureBox Picture { get; set; } = new PictureBox();

        public Point Location
        {
            get
            {
                return Picture.Location;
            }

            set
            {
                Picture.Location = value;
            }
        }

        public Size Size
        {
            get
            {
                return Picture.Size;
            }
            set
            {
                Picture.Size = value;
            }
        }
    }
}
