using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSandbox.Components;
using GameSandbox.Entities;
using GameSandbox.MathExtended;
using Microsoft.Xna.Framework;

namespace GameSandbox.Systems
{
    class CollisionSystem : GameSystem
    {
        public CollisionSystem(EntityManager entityManager)
            : base(entityManager)
        {
            _entitySet = ComponentType.Collision;
        }

        public override void Update(GameTime gameTime)
        {
            List<Entity> colEntities = EntityManager.GetEntities(_entitySet);
            List<Entity> colCheck = new List<Entity>();

            // Check first entity.
            CheckCollision(colEntities.First(), colEntities.Skip(1).ToList());
            
            // Check collision for rest of entities.
            foreach (Entity entity in colEntities)
            {
                CheckCollision(entity, colCheck);
                colCheck.Add(entity);
            }
        }

        // TODO: Optimize?
        private void CheckCollision(Entity entity, List<Entity> others)
        {
            // Get bounding box
            Collision collisionThis = ((Collision)entity.GetComponent(ComponentType.Collision));

            // TODO: REMOVE IF NOT NEEDED! Reset collider list.
            collisionThis.CollidedWith = new List<Entity>();

            Rectangle bb1 = collisionThis.BoundingBox;
            Movement movementThis = ((Movement)entity.GetComponent(ComponentType.Movement));
            bb1.X = (int)(movementThis.Position.X + movementThis.Velocity.X);
            bb1.Y = (int)(movementThis.Position.Y + movementThis.Velocity.Y);
            Rectangle bb2;
            foreach ( Entity other in others)
            {
                bb2 = ((Collision)other.GetComponent(ComponentType.Collision)).BoundingBox;
                Movement movementOther = ((Movement)other.GetComponent(ComponentType.Movement));
                bb2.X = (int)movementOther.Position.X;
                bb2.Y = (int)movementOther.Position.Y;
                if (bb1.Intersects(bb2))
                {
                    // Collision happened.
                    collisionThis.CollidedWith.Add(other);
                    // TODO: Check type of object this entity collided with and do appropriate actions. Alternatively use collideWith and process.
                    // Default collision stops entity.
                    movementThis.Velocity = Vector2.Zero;
                }
            }
        }
    }
}
