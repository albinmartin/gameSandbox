using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSandbox.Entities;

namespace GameSandbox.Components
{
    [Flags]
    public enum ComponentType { //Use values with power of 2 for bitmask purposes
        sprite = 0,
        movement = 2,
    };

    public abstract class Component
    {
        protected Entity _entity;
        protected ComponentType _type;

        public ComponentType ComponentType { get => _type; }

        public Component(Entity entity)
        {
            _entity = entity;
        }

        public abstract void OnStartup();
        public abstract void OnShutdown();
    }
}
