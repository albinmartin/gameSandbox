using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSandbox.Components;
using GameSandbox.Controls;
using GameSandbox.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameSandbox.Systems
{
    class PlayerSystem : GameSystem
    {
        InputManager _input;
        public PlayerSystem(EntityManager entityManager, InputManager input)
            : base(entityManager)
        {
            _input = input;
            _entitySet = ComponentType.Player | ComponentType.Movement;
        }

        public override void Update(GameTime gameTime)
        {
            List<Entity> players = _entityManager.GetEntities(_entitySet);
            int i = 0;
            if (players.Count > 0)
            {
                Keys[] keys = _input.GetKeysDown();
                Vector2 direction = Vector2.Zero;

                foreach (var key in keys)
                {
                    switch (key)
                    {
                        case Keys.A:
                            direction.X -= 1;
                            break;
                        case Keys.D:
                            direction.X += 1;
                            break;
                        case Keys.S:
                            direction.Y += 1;
                            break;
                        case Keys.W:
                            direction.Y -= 1;
                            break;
                        default:
                            break;
                    }
                }

                foreach(var player in players)
                {
                    // Update movement
                    Movement m = (Movement)_entityManager.GetComponent(player, ComponentType.Movement);
                    m.Velocity += direction * m.Speed * (gameTime.ElapsedGameTime.Milliseconds/16.0f);

                    // TODO: Update frames in animation 
                    Animation a = (Animation)_entityManager.GetComponent(player, ComponentType.Animation);
                    
                }
            }

        }
    }
}
