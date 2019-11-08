using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSandbox.Entities;
using Microsoft.Xna.Framework;

namespace GameSandbox.Systems
{
    class AnimationSystem : GameSystem
    {
        public AnimationSystem(EntityManager entityManager) : base(entityManager)
        {

        }

        public override void Update(GameTime gameTime)
        {
            //Get animation entities

            //Loop them and update frames
        }
    }
}
