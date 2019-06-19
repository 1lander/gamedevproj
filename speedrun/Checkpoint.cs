using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speedrun
{
    //Checkpoint class erft alles over van gameobject.
    public abstract class Checkpoint : GameObject
    {
        public Checkpoint(Texture2D _texture, Vector2 _position) : base(_texture, _position)
        {
        }
    }
}
