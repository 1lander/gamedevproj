using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speedrun
{
    //Block class erft alles over van gameobject.
    public class Block : GameObject
    {
        public Block(Texture2D _texture, Vector2 _position) : base(_texture, _position)
        {
        }
    }
}
