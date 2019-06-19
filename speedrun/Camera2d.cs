using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace speedrun
{
    public class Camera2d
    {
        private readonly Viewport _viewport;

        public Camera2d(Viewport viewport)
        {
            _viewport = viewport;
            Origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
            Position = Vector2.Zero;
        }

        public Vector2 ViewportCenter
        {
            get
            {
                return new Vector2(_viewport.Width * 0.5f, _viewport.Height * 0.5f);
            }
        }
        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }
        public Matrix GetViewMatrix()
        {
            Matrix m = Matrix.CreateTranslation(new Vector3(-Position, 0));
            return m;
        }
    }
}