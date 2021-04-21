using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FighterPlane.Models
{
    sealed class FighterPlane : Object
    {
        public FighterPlane()
        {
            Picture.ImageLocation = "Resources/fighterplane.PNG";
            Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            Picture.BackColor = Color.Transparent;
            Size = new Size(60, 60);
            
        }
    }
}
