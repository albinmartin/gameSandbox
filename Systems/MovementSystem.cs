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
                Movement movement = (Movement)_entityManager.GetComponent(entity, ComponentType.Movement);
                movement.Position += movement.Velocity;

                // Add friction.
                if (movement.Velocity.Length() < 0.01f)
                {
                    movement.Velocity = Vector2.Zero;
                }
                else
                {
                    movement.Velocity = movement.Velocity * 0.7f;
                }

                // Set face direciton
                if (movement.Velocity != Vector2.Zero)
                {
                    // Moving
                    movement.Facing = GetDirection(movement.Velocity);
                }
            }
        }

        // TODO: Add North / South directions. Fix bug when standing still sometimes flips animation.
        private Direction GetDirection(Vector2 velocity)
        {
            // Dot product with up vector (xna coordinates -1 is "north").
            velocity = Vector2.Normalize(velocity);
            float dot = Vector2.Dot(velocity, new Vector2(0, -1));

            if (dot >= 0)
            {
                // North
                dot = Vector2.Dot(velocity, new Vector2(1, 0));
                if (dot > 0)
                {
                    // Right
                    return Direction.Right;
                }
                else
                {
                    // Left
                    return Direction.Left;
                }
            }
            else
            {
                // South
                dot = Vector2.Dot(velocity, new Vector2(1, 0));
                if (dot > 0)
                {
                    // Right
                    return Direction.Right;
                }
                else
                {
                    // Left
                    return Direction.Left;
                }
            }
        }
    }
}
