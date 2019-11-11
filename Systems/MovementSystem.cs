using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSandbox.Components;
using GameSandbox.Entities;
using Microsoft.Xna.Framework;

namespace GameSandbox.Systems
{
    public class MovementSystem : GameSystem
    {
        public MovementSystem(EntityManager entityManager)
            :base(entityManager)
        {
            _entitySet = ComponentType.Movement;
        }

        public override void Update(GameTime gameTime)
        {
            List<Entity> entities = _entityManager.GetEntities(_entitySet);
            foreach (var entity in entities)
            {
                Movement m = (Movement)entity.GetComponent(ComponentType.Movement);
                m.Position += m.Velocity;

                // Add friction.
                if (m.Velocity.Length() < 0.01f)
                {
                    m.Velocity = Vector2.Zero;
                }
                else
                {
                    m.Velocity = m.Velocity * 0.7f;
                }
            }
        }
    }
}
