using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speedrun
{
    
    public class Hero : MovableGameObject
    {
        public Controls _controls { get; set; }
        public bool isUnder { get; set; }
        public Vector2 lastPos;
        public Vector2 spawnPoint;
        public bool hasJumped = false;
        public Rectangle ColRight, ColLeft, ColTop, ColBot;

        public Hero(Texture2D _texture, Vector2 _position, Texture2D _tLeft) : base(_texture, _position, _tLeft)
        {
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 100, 109);
            _controls = new ControlsKeyboard();
            speed = 5;
            lastPos = _position;
            ColBot = new Rectangle((int)Position.X, (int)Position.Y,64,1);
        }
        public override void Animation()
        {
            animation.AddFrame(new Rectangle(10, 0, 95, 109));
            animation.AddFrame(new Rectangle(135, 0, 98, 109));
            animation.AddFrame(new Rectangle(265, 0, 103, 109));
            animation.AddFrame(new Rectangle(395, 0, 110, 109));
            animation.MovesPerSecond = 10;
        }

        public void Die()
        {
            Position = spawnPoint;
        }
        public void SetSpawn(GameObject C)
        {
            spawnPoint.Y = C.Position.Y - 45;
            spawnPoint.X = C.Position.X - 45;
        }

        public void CheckCollision(GameObject[,] B)
        {
            Collide<Trap>(B, Die);
            Collide<Projectile>(B, Die);
            //CollideTrap(B);
            CollideBlock(B);
            CollideCheckpoint(B);
        }
        public void CollideBlock(GameObject[,] B)
        {
            int Bcord = CollisionRectangle.Bottom / 64;
            int Rcord = CollisionRectangle.Right / 64;
            int Lcord = CollisionRectangle.Left / 64;
            int Tcord = CollisionRectangle.Top / 64;
            int centerY = CollisionRectangle.Center.Y / 64;
            int centerX = CollisionRectangle.Center.X / 64;
            

            //BOTTEM
            if (B[Bcord, Lcord] is Block)
            {
                OnIntersect(B[Bcord, Lcord]);
                hasJumped = false;
                isUnder = true;
            }
            else if (B[Bcord, Rcord] is Block)
            {
                OnIntersect(B[Bcord, Rcord]);
                hasJumped = false;
                isUnder = true;
            }else if (B[Bcord, centerX] is Block)
            {
                OnIntersect(B[Bcord, centerX]);
                hasJumped = false;
                isUnder = true;
            }
            else
            {
                isUnder = false;
            }

            //RIGHT
            if (B[Bcord - 1, Rcord] is Block)
            {
                Position = lastPos;
                hasJumped = false;
                //Velocity.X = 0;
            }
            //LEFT
            if (B[Bcord - 1, Lcord] is Block)
            {
                Position = lastPos;
                hasJumped = false;
                //Velocity.X = 0;
            }
            //TOP
            if (B[Tcord, Lcord] is Block)
            {
                Position = lastPos;
                hasJumped = false;
                //Velocity.X = 0;
            }
        }

        public void CollideTrap(GameObject[,] B)
        {
            int Bcord = CollisionRectangle.Bottom / 64;
            int Rcord = CollisionRectangle.Right / 64;
            int Lcord = CollisionRectangle.Left / 64;
            int Tcord = CollisionRectangle.Top / 64;
            int centerY = CollisionRectangle.Center.Y / 64;
            int centerX = CollisionRectangle.Center.X / 64;

            //BOTTEM
            if (B[Bcord, Lcord] is Trap)
            {
                Die();
            }
            else if (B[Bcord, Rcord] is Trap)
            {
                Die();
            }
            else if (B[Bcord, centerX] is Trap)
            {
                Die();
            }

            //RIGHT
            if (B[Bcord - 1, Rcord] is Trap)
            {
                Die();
            }
            //LEFT
            if (B[Bcord - 1, Lcord] is Trap)
            {
                Die();
            }
            //TOP
            if (B[Tcord, Lcord] is Trap)
            {
                Die();
            }
        }
        public void Collide<T>(GameObject[,] B, Action A)
        {
            int Bcord = CollisionRectangle.Bottom / 64;
            int Rcord = CollisionRectangle.Right / 64;
            int Lcord = CollisionRectangle.Left / 64;
            int Tcord = CollisionRectangle.Top / 64;
            int centerY = CollisionRectangle.Center.Y / 64;
            int centerX = CollisionRectangle.Center.X / 64;

            //BOTTEM
            if (B[Bcord, Lcord] is T)
            {
                A();
            }
            else if (B[Bcord, Rcord] is T)
            {
                A();
            }
            else if (B[Bcord, centerX] is T)
            {
                A();
            }

            //RIGHT
            if (B[Bcord - 1, Rcord] is T)
            {
                A();
            }
            //LEFT
            if (B[Bcord - 1, Lcord] is T)
            {
                A();
            }
            //TOP
            if (B[Tcord, Lcord] is T)
            {
                A();
            }
        }
        public void CollideCheckpoint(GameObject[,] B)
        {
            int Bcord = CollisionRectangle.Bottom / 64;
            int Rcord = CollisionRectangle.Right / 64;
            int Lcord = CollisionRectangle.Left / 64;
            int Tcord = CollisionRectangle.Top / 64;
            int centerY = CollisionRectangle.Center.Y / 64;
            int centerX = CollisionRectangle.Center.X / 64;

            //BOTTEM
            if (B[Bcord, Lcord] is NormalCheckpoint)
            {
                SetSpawn(B[Bcord, Lcord]);
            }
            else if (B[Bcord, Rcord] is NormalCheckpoint)
            {
                SetSpawn(B[Bcord, Rcord]);
            }
            else if (B[Bcord, centerX] is NormalCheckpoint)
            {
                SetSpawn(B[Bcord, centerX]);
            }

            //RIGHT
            if (B[Bcord - 1, Rcord] is NormalCheckpoint)
            {
                SetSpawn(B[Bcord - 1, Rcord]);
            }
            //LEFT
            if (B[Bcord - 1, Lcord] is NormalCheckpoint)
            {
                SetSpawn(B[Bcord - 1, Lcord]);
            }
            //TOP
            if (B[Tcord, Lcord] is NormalCheckpoint)
            {
                SetSpawn(B[Bcord - 1, Lcord]);
            }
        }
        /*public void CollideProj(Projectile[,] B)
        {
            int Bcord = CollisionRectangle.Bottom / 64;
            int Rcord = CollisionRectangle.Right / 64;
            int Lcord = CollisionRectangle.Left / 64;
            int Tcord = CollisionRectangle.Top / 64;
            int centerY = CollisionRectangle.Center.Y / 64;
            int centerX = CollisionRectangle.Center.X / 64;

            //BOTTEM
            if (B[Bcord, Lcord] is Projectile)
            {
                SetSpawn(B[Bcord, Lcord]);
            }
            else if (B[Bcord, Rcord] is Projectile)
            {
                SetSpawn(B[Bcord, Rcord]);
            }
            else if (B[Bcord, centerX] is Projectile)
            {
                SetSpawn(B[Bcord, centerX]);
            }

            //RIGHT
            if (B[Bcord - 1, Rcord] is Projectile)
            {
                SetSpawn(B[Bcord - 1, Rcord]);
            }
            //LEFT
            if (B[Bcord - 1, Lcord] is Projectile)
            {
                SetSpawn(B[Bcord - 1, Lcord]);
            }
            //TOP
            if (B[Tcord, Lcord] is Projectile)
            {
                SetSpawn(B[Bcord - 1, Lcord]);
            }
        }*/

        public void OnIntersect(GameObject O)
        {
            if (O.CollisionRectangle.Intersects(CollisionRectangle))
            {
                Position = lastPos;
                hasJumped = false;
            }
        }
        public override void Update(GameTime gameTime)
        {
            Velocity.X = 1;
            _controls.Update();          
            if (_controls.left || _controls.right || _controls.jump)
            {
                animation.Update(gameTime);
            }
            if (_controls.left)
            {
                Velocity.X = speed;
                Texture = tRight;
            }
            else if (_controls.right)
            {
                Velocity.X = -speed;
                Texture = tLeft;
            }
            else
                Velocity.X = 0;

            if (_controls.jump && hasJumped == false)
            {
                Velocity.Y = -20;
                hasJumped = true;
            }
            else if (isUnder)
            {
                Velocity.Y = 0;
            }

            if (hasJumped || isUnder == false)
            {                
                Velocity.Y -= -0.9f;
                hasJumped = true;
            }
            //Console.WriteLine(CollisionRectangle.X);
            lastPos = Position;
            Position += Velocity;
            ColBot.X = (int)Position.X;
            ColBot.Y = (int)Position.Y + 109;
            CollisionRectangle.X = (int)Position.X;
            CollisionRectangle.Y = (int)Position.Y;
        }          
    }
}
