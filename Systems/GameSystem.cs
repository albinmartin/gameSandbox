using GameSandbox.Components;
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
        protected EntityManager _entityManager;
        protected ComponentType _entitySet;

        public ComponentType EntitySet { get => _entitySet; }

        public GameSystem(EntityManager entityManager)
        {
            _entityManager = entityManager;
        }

        public abstract void Update(GameTime gameTime);
    }
}
