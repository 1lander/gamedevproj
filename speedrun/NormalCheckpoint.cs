using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace speedrun
{
    public class NormalCheckpoint : Checkpoint
    {
        public NormalCheckpoint(Texture2D _texture, Vector2 _position) : base(_texture, _position)
        {
        }
    }
}
