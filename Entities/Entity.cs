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
        private List<Component> _components;
        private ComponentType _componentMask;

        public List<Component> Components { get => _components; }
        public ComponentType ComponentMask { get => _componentMask;}

        public Entity()
        {
            _components = new List<Component>();
            _componentMask = 0;
        }

        public void AddComponent(Component component)
        {
            _components.Add(component);
            _componentMask = _componentMask | component.ComponentType;
        }

        public void Startup()
        {
            foreach(var component in _components)
            {
                component.OnStartup();
            }
        }

        public void Shutdown()
        {
            foreach(var component in _components)
            {
                component.OnShutdown();
            }
        }


        public Component GetComponent (ComponentType type)
        {
            foreach(var component in _components)
            {
                if(component.ComponentType == type)
                {
                    return component;
                }
            }
            return null;
        }
    }
}
