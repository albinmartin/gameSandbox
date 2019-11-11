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
        private float timeSinceLast;

        public AnimationSystem(EntityManager entityManager) : base(entityManager)
        {
            _entitySet = ComponentType.Animation;
        }

        public override void Update(GameTime gameTime)
        {
            //Get animation entities
            List<Entity> entities = _entityManager.GetEntities(ComponentType.Animation);

            //Loop them and update frames
            foreach(var entity in entities)
            {
                Animation animation = (Animation)entity.GetComponent(ComponentType.Animation);

                // Calculate framerate based on animation
                float framerate = (1.0f / animation.Framerate);
                timeSinceLast += (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Update frame
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
            if (animation.CurrentFrame > animation.StopIndex)
            {
                animation.CurrentFrame = animation.StartIndex;
            }
        }
    }
}
