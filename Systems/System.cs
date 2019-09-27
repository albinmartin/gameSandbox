using GameSandbox.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSandbox.Systems
{
    public abstract class GameSystem
    {
        protected World _world;
        public GameSystem(World world)
        {
            _world = world;
        }

        public abstract void Update(GameTime gameTime);
    }
}
