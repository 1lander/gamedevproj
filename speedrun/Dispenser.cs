using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speedrun
{
    //Dispenser class erft alles over van gameobject maar heeft eigen methodes voor het schieten en tekenen van projectiles
    class Dispenser : GameObject
    {
        Projectile p;
        float time = 0f;
        public List<Projectile> projectile = new List<Projectile>();
        private Texture2D t;
        public Dispenser(Texture2D _texture, Texture2D _textureProj, Vector2 _position) : base(_texture, _position)
        {
            t = _textureProj;
        }
        //schiet elke 2 seconden een projectile object af
        public void Shoot(GameTime gametime)
        {
            time += (float)gametime.ElapsedGameTime.TotalSeconds;
            if (time > 2f)
            {
                p = new Projectile(t, Position, t);
                projectile.Add(p);
                time = 0f;
            }          
        }
        //Zorgt ervoor dat alle projectiles door de lucht vliegen en verdwijnen als ze ergens tegen botsen
        public void UpdateProj(GameTime gametime, GameObject[,] B)
        {
            for (int i = 0; i < projectile.Count; i++)
            {
                projectile[i].Update(gametime);
                if (projectile[i].Collide(B))
                {
                    projectile.RemoveAt(i);
                }
            }
        }
        //tekent alle projectiles
        public void DrawProj(SpriteBatch spritebatch)
        {
            for (int i = 0; i < projectile.Count; i++)
            {
                projectile[i].Draw(spritebatch);
            }
        }
    }
}
