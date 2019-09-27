using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSandbox.Components;

namespace GameSandbox.Entities
{
    public class Entity
    {
        // TODO: Add entity ID
        // TODO: Comparer for enum in dictionary
        Dictionary<ComponentType, Component> _components;
        public Entity()
        {
            _components = new Dictionary<ComponentType, Component>();
        }

        public void AddComponent(Component component)
        {
            _components.Add(component.ComponentType, component);
        }

        public void Startup()
        {
            foreach(var component in _components.Values)
            {
                component.OnStartup();
            }
        }

        public void Shutdown()
        {
            foreach(var component in _components.Values)
            {
                component.OnShutdown();
            }
        }

        // TODO: Rewrite ?
        public Component GetComponent (ComponentType type)
        {
             if(_components.TryGetValue(type, out var component))
            {
                return component;
            }
            return null;
        }
    }
}
