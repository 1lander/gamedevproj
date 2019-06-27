using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speedrun
{
    public class Projectile:MovableGameObject
    {
        public Projectile(Texture2D _texture, Vector2 _position, Texture2D _tLeft) : base(_texture, _position, _tLeft)
        {
        }

        public override void Animation()
        {
            animation = new Animation();
            animation.AddFrame(new Rectangle(0, 0, 64, 64));
            animation.MovesPerSecond = 10;
        }

        public override void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            Velocity.X = -2;
            Velocity.Y = 0;
            Position += Velocity;
            CollisionRectangle.X = (int)Position.X;
            CollisionRectangle.Y = (int)Position.Y;
        }

        public bool Collide(GameObject[,] B)
        {
            bool c = false;
            int Bcord = CollisionRectangle.Bottom / 64;
            int Rcord = CollisionRectangle.Right / 64;
            int Lcord = CollisionRectangle.Left / 64;
            int Tcord = CollisionRectangle.Top / 64;
            int centerY = CollisionRectangle.Center.Y / 64;
            int centerX = CollisionRectangle.Center.X / 64;

            //BOTTEM
            /*if (B[Bcord, Lcord] != null && !(B[Bcord, Lcord] is Dispenser))
            {
                c = true;
            }
            else if (B[Bcord, Rcord] != null && !(B[Bcord, Rcord] is Dispenser))
            {
                c = true;
            }
            else if (B[Bcord, centerX] != null && !(B[Bcord, centerX] is Dispenser))
            {
                c = true;
            }*/

            //RIGHT
            if (B[Bcord - 1, Rcord] != null && !(B[Bcord - 1, Rcord] is Dispenser))
            {
                c = true;
            }
            //LEFT
            if (B[Bcord - 1, Lcord] != null && !(B[Bcord - 1, Lcord] is Dispenser))
            {
                c = true;
            }
            //TOP
            if (B[Tcord, Lcord] != null && !(B[Tcord, Lcord] is Dispenser))
            {
                c = true;
            }

            return c;
        }
    }
}
