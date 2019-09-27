using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagonactic;

namespace GameSandbox.Components
{
    public class ComponentManager
    {
        private Dictionary<ComponentType, List<Component>> _nodeList;

        public ComponentManager()
        {
            _nodeList = new Dictionary<ComponentType, List<Component>>(Enums.EqualityComparer<ComponentType>());
        }

        public List<Component> GetComponentSet(ComponentType type)
        {
            if(_nodeList.TryGetValue(type, out var components))
            {
                return components;
            }
            return new List<Component>();
        }

        public void AddComponent(Component component)
        {
            if (_nodeList.TryGetValue(component.ComponentType, out var components))
            {
                components.Add(component);
            }
            else
            {
                _nodeList.Add(component.ComponentType, new List<Component>() { component });
            }
        }
    }
}
