using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speedrun
{
    public abstract class Controls
    {
        public bool left { get; set; }
        public bool right { get; set; }
        public bool jump { get; set; }
        public abstract void Update();
    }

    public class ControlsArrows : Controls
    {
        public override void Update()
        {
            Microsoft.Xna.Framework.Input.KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(Keys.Left))
            {
                left = true;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                left = false;
            }

            if (stateKey.IsKeyDown(Keys.Right))
            {
                right = true;
            }
            if (stateKey.IsKeyUp(Keys.Right))
            {
                right = false;
            }

            if (stateKey.IsKeyDown(Keys.Up))
            {
                jump = true;
            }
            if (stateKey.IsKeyUp(Keys.Up))
            {
                jump = false;
            }
        }
    }

    public class ControlsKeyboard : Controls
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(Keys.D))
            {
                left = true;
            }
            if (stateKey.IsKeyUp(Keys.D))
            {
                left = false;
            }

            if (stateKey.IsKeyDown(Keys.Q))
            {
                right = true;
            }
            if (stateKey.IsKeyUp(Keys.Q))
            {
                right = false;
            }

            if (stateKey.IsKeyDown(Keys.Z))
            {
                jump = true;
            }
            if (stateKey.IsKeyUp(Keys.Z))
            {
                jump = false;
            }
        }
    }

    public class ControlsKeyNumbers : Controls
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(Keys.F1))
            {
                left = true;
            }
            if (stateKey.IsKeyUp(Keys.F1))
            {
                left = false;
            }

            if (stateKey.IsKeyDown(Keys.F2))
            {
                right = true;
            }
            if (stateKey.IsKeyUp(Keys.F2))
            {
                right = false;
            }
        }
    }
}
