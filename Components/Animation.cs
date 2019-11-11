using GameSandbox.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSandbox.Components
{
    public class Animation : Component
    {
        public int StartIndex { get; set; }
        public int StopIndex { get; set; }
        public int CurrentFrame { get; set; }
        public bool Animating { get; set; }

        // Frame transitions per second
        public float Framerate { get; set; }

        public Animation(Entity entity, int startIndex, int stopIndex, float framerate)
            : base(entity)
        {
            _type = ComponentType.Animation;
            StartIndex = startIndex;
            StopIndex = stopIndex;
            CurrentFrame = 0;
            Framerate = framerate;
            Animating = false;
        }

        public override void OnShutdown()
        {
        }

        public override void OnStartup()
        {
        }
    }
}
