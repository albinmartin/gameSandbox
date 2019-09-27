using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GameSandbox.Systems;
using GameSandbox.Components;

namespace GameSandbox.Entities
{
    public class World
    {
        private List<GameSystem> _systems;
        private List<Entity> _entites;
        private ComponentManager _componentManager;

        public void AddEntity(Entity entity)
        {
            _entites.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            _entites.Remove(entity);
        }

        public void AddSystem(GameSystem system)
        {
            _systems.Add(system);
        }
        
        public void RemoveSystem(GameSystem system)
        {
            _systems.Remove(system);
        }

        // Used by systems to get its set of components to operate on
        public void GetComponentSet(ComponentType type)
        {
            _componentManager.GetComponentSet(type);
        }

        public void Update(GameTime gameTime)
        {
            foreach(var system in _systems)
            {
                system.Update(gameTime);
            }
        }
    }
}
