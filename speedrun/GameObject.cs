using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speedrun
{
    //elk object in mijn game erft over van deze klasse
    public abstract class GameObject
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle CollisionRectangle;
        public GameObject(Texture2D _texture, Vector2 _position)
        {
            Texture = _texture;
            Position = _position;
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 64, 64);
        }
        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Position, Color.AliceBlue);
        }       
        public virtual Rectangle GetCollisionRectangle()
        {
            return CollisionRectangle;
        }
    }
}
