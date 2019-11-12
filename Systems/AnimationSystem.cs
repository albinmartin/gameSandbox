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
    class AnimationSystem : GameSystem
    {
        private enum Direction { None = 0, Left = 1, Right = 2, Up = 3, Down = 4}
        private float timeSinceLast;

        public AnimationSystem(EntityManager entityManager) : base(entityManager)
        {
            _entitySet = ComponentType.Animation;
        }

        public override void Update(GameTime gameTime)
        {
            // Get animation entities.
            List<Entity> entities = _entityManager.GetEntities(ComponentType.Animation);

            //Loop them and update frames.
            foreach(var entity in entities)
            {
                Animation animation = (Animation)_entityManager.GetComponent(entity, ComponentType.Animation);

                // Check direction of movement if possible.
                // TODO: Make more generic?
                Movement movement = (Movement)_entityManager.GetComponent(entity, ComponentType.Movement);
                if(movement != null)
                {
                    // Determine direction and flip texture accordingly.
                    switch (GetDirection(movement.Velocity))
                    {
                        case Direction.None:
                            break;
                        case Direction.Left:
                            animation.SpriteLoop = SpriteLoop.Left;
                            break;
                        case Direction.Right:
                            animation.SpriteLoop = SpriteLoop.Right;
                            break;
                        case Direction.Up:
                            break;
                        case Direction.Down:
                            break;
                        default:
                            break;
                    }
                }

                // Calculate framerate based on animation.
                float framerate = (1.0f / animation.Framerate);
                timeSinceLast += (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Update frame.
                if (timeSinceLast > framerate)
                {
                    AdvanceFrame(animation);
                    timeSinceLast = 0.0f;
                }
            }
        }

        private void AdvanceFrame(Animation animation)
        {
            animation.CurrentFrame++;
            // Check if looped through animation. LoopLenght - 1 due to frame start at 0.
            if (animation.CurrentFrame > animation.LoopLenght - 1)
            {
                ResetAnimation(animation);
            }
        }

        private void ResetAnimation(Animation animation)
        {
            animation.CurrentFrame = 0;
        }


        // TODO: Add North / South directions. Fix bug when standing still sometimes flips animation.
        private Direction GetDirection(Vector2 velocity)
        {
            // Dot product with up vector (xna coordinates -1 is "north").
            velocity = Vector2.Normalize(velocity);
            float dot = Vector2.Dot(velocity, new Vector2(0, -1));
            if(velocity.X > 0.5 && velocity.Y > 0.5)
            {
            }
            if(dot >= 0)
            {
                // North
                dot = Vector2.Dot(velocity, new Vector2(1, 0));
                if(dot > 0 )
                {
                    // Right
                    return Direction.Right;
                }
                else
                {
                    // Left
                    return Direction.Left;
                }
            }else
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
