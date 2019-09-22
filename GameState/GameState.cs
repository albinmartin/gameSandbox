using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSandbox.Controls;

namespace GameSandbox.GameState
{
    public abstract class GameState
    {
        private GameStateManager _manager;

        protected GameState(GameStateManager manager)
        {
            _manager = manager;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
        public abstract void LoadContent();
        public abstract void UnloadContent();
}
}
