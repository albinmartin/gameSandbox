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
using GameSandbox.Controls;

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

        public void LoadContent(ContentManager content, GraphicsDevice graphics, InputManager input)
        {
            // Create systems.
            AddSystem(new RenderMapSystem(_entityManager, content, graphics));
            AddSystem(new RenderSystem(_entityManager, content, graphics));
            AddSystem(new PlayerSystem(_entityManager, input));
            AddSystem(new AnimationSystem(_entityManager));
            AddSystem(new CollisionSystem(_entityManager));
            AddSystem(new MovementSystem(_entityManager));


            // Create Entities.
            Entity e = new Entity();
            e.AddComponent(new Sprite(e, SpriteType.Goatman));
            e.AddComponent(new Movement(e));
            e.AddComponent(new Player(e));
            e.AddComponent(new Animation(e, SpriteLoop.Left, 4, 4));
            e.AddComponent(new Collision(e));
            AddEntity(e);

            // Spawn many entities
            for(int i = 0; i < 10; i++)
            {
                Entity t = new Entity();
                t.AddComponent(new Sprite(t, SpriteType.Goatman));
                t.AddComponent(new Movement(t, new Vector2(250 +(float)(i*50), 130)));
                t.AddComponent(new Animation(t, SpriteLoop.Left, 4, 4));
                t.AddComponent(new Collision(t));
                AddEntity(t);
            }
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
