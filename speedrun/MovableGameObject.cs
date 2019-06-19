using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speedrun
{
    public abstract class MovableGameObject:GameObject
    {      
        public int speed { get; set; }
        public Matrix rotationMatrix { get; set; }
        public Texture2D tLeft { get; set; }
        public Texture2D tRight { get; set; }
        public Animation animation;
        public Vector2 Velocity;
        public MovableGameObject(Texture2D _texture, Vector2 _position, Texture2D _tLeft) : base(_texture, _position)
        {
            tLeft = _tLeft;
            tRight = _texture;
            rotationMatrix = Matrix.CreateRotationY((float)Math.PI / 2);
            Velocity = new Vector2();
            animation = new Animation();
            Animation();
        }
        public abstract void Animation();
        public abstract void Update(GameTime gametime);
        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Position, animation.CurrentFrame.SourceRectangle, Color.AliceBlue);
        }
    }
}
