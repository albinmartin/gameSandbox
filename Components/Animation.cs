using GameSandbox.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSandbox.Components
{
    // Enum for spritesheet indexes
    // TODO: Fix spritesheet and update indexes, idle should be 0 IMO!
    public enum SpriteLoop { Left = 0, Right = 1, Idle = 2}

    public class Animation : Component
    {
        public int CurrentFrame { get; set; }
        public SpriteLoop SpriteLoop { get; set; }
        public int LoopLenght { get; set; }
        public bool Animating { get; set; }

        // Frame transitions per second
        public float Framerate { get; set; }

        public Animation(Entity entity, SpriteLoop spriteLoop, int loopLenght, float framerate)
            : base(entity)
        {
            _type = ComponentType.Animation;
            CurrentFrame = 0;
            SpriteLoop = spriteLoop;
            LoopLenght = loopLenght;
            Animating = false;
            Framerate = framerate;
        }

        public override void OnShutdown()
        {
        }

        public override void OnStartup()
        {
        }
    }
}
