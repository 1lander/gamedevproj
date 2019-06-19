using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace speedrun
{
    class Level
    {
        private Texture2D Background;
        private Texture2D tBlock;
        private Texture2D tTrap;
        private Texture2D tCheckNorm;
        private Texture2D tCheckPow;
        private Texture2D tCheckFin;
        private Texture2D tDispenser;
        private Texture2D tProjectile;
        public Level(Texture2D _Background, Texture2D _tBlock, Texture2D _tTrap, Texture2D _tCheckNorm, Texture2D _tCheckPow, Texture2D _tCheckFin, Texture2D _tDispenser, Texture2D _tProjectile)
        {
            Background = _Background;
            tBlock = _tBlock;
            tTrap = _tTrap;
            tCheckNorm = _tCheckNorm;
            tCheckPow = _tCheckPow;
            tCheckFin = _tCheckFin;
            tDispenser = _tDispenser;
            tProjectile = _tProjectile;
        }
        public byte[,] tileArray = new byte[13, 40];
        private GameObject[,] gameobjectArray = new GameObject[13, 40];
        private Projectile[,] proj = new Projectile[13, 40];
        private Dispenser[,] dis = new Dispenser[13, 40];
        public void CreateWorld()
        {
            for (int x = 0; x < 13; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    if (tileArray[x, y] == 1)
                    {
                        gameobjectArray[x, y] = new Block(tBlock, new Microsoft.Xna.Framework.Vector2(y * 64, x * 64));
                    }
                    if (tileArray[x, y] == 2)
                    {
                        gameobjectArray[x, y] = new Trap(tTrap, new Microsoft.Xna.Framework.Vector2(y * 64, x * 64));
                    }
                    if (tileArray[x, y] == 3)
                    {
                        gameobjectArray[x, y] = new NormalCheckpoint(tCheckNorm, new Microsoft.Xna.Framework.Vector2(y * 64, x * 64));
                    }
                    if (tileArray[x, y] == 4)
                    {
                        gameobjectArray[x, y] = new PowerUpCheckpoint(tCheckPow, new Microsoft.Xna.Framework.Vector2(y * 64, x * 64));
                    }
                    if (tileArray[x, y] == 5)
                    {
                        gameobjectArray[x, y] = new FinishCheckpoint(tCheckFin, new Microsoft.Xna.Framework.Vector2(y * 64, x * 64));
                    }
                    if (tileArray[x, y] == 6)
                    {
                        gameobjectArray[x, y] = new Dispenser(tDispenser, tProjectile, new Microsoft.Xna.Framework.Vector2(y * 64, x * 64));
                    }
                }
            }
        }

        public void DrawLevel(SpriteBatch spritebatch)
        {
            for (int i = 0; i < 5; i++)
            {
                spritebatch.Draw(Background, new Rectangle(i * 1200, 0, 1200, 800), Color.White);
            }
            for (int x = 0; x < 13; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    if (gameobjectArray[x, y] != null)
                    {
                        gameobjectArray[x, y].Draw(spritebatch);
                    }
                    if (gameobjectArray[x, y] is Dispenser)
                    {
                        ((Dispenser)gameobjectArray[x, y]).DrawProj(spritebatch);
                    }
                }
            }
        }
        public void Update(GameTime gametime)
        {
            for (int x = 0; x < 13; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    if(gameobjectArray[x, y] is Dispenser)
                    {
                        ((Dispenser)gameobjectArray[x, y]).UpdateProj(gametime, gameobjectArray);
                        ((Dispenser)gameobjectArray[x, y]).Shoot(gametime);
                    }                 
                }
            }
        }
        public GameObject[,] GetCollisionArray()
        {
            return gameobjectArray;
        }
        /*public Projectile[,] GetProjectile()
        {
            return dis[,].projectile;
        }*/
    }
}
