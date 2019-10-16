using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GameSandbox.Systems;
using GameSandbox.Components;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameSandbox.Entities
{
    public class World
    {
        private List<GameSystem> _systems;
        private List<DrawSystem> _drawSystems; //TODO: implement
        private EntityManager _entityManager;

        public World()
        {
            _systems = new List<GameSystem>();
            _drawSystems = new List<DrawSystem>();
            _entityManager = new EntityManager();
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            // Create systems
            AddSystem(new RenderSystem(_entityManager, content, graphics));
            AddSystem(new MovementSystem(_entityManager));

            // Create Entities
            Entity e = new Entity();
            e.AddComponent(new Sprite(e));
            e.AddComponent(new Movement(e));
            AddEntity(e);
        }

        public void Draw()
        {
            foreach(var system in _drawSystems)
            {
                system.Draw();
            }
        }

        public void AddEntity(Entity entity)
        {
            _entityManager.AddEntity(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            //TODO: Implement.
        }

        public void AddSystem(GameSystem system)
        {
            _systems.Add(system);
            _entityManager.AddSystemEntry(system.EntitySet);
        }

        public void AddSystem(DrawSystem system)
        {
            _drawSystems.Add(system);
            _entityManager.AddSystemEntry(system.EntitySet);
        }

        public void RemoveSystem(GameSystem system)
        {
            _systems.Remove(system);
        }

        // Used by systems to get its set of entities to operate on.
        public List<Entity> GetEntitySet(ComponentType type)
        {
            return _entityManager.GetEntities(type);
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
