using Microsoft.Xna.Framework;
using SharpDX.Direct3D11;
using SharpDX.MediaFoundation.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class Animation {

        private List<Frame> frames;
        public Frame CurrentFrame { get; set; }
        private int counter;
        private double secondCounter = 0;
        public Animation()
        {
            frames = new List<Frame>();
        }
        public void Addframe(Frame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }
        public void Update(GameTime gameTime)
        {
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 15;
            double frameTime = 1d / fps;
            if (secondCounter >= frameTime)
            {
                counter++;
                secondCounter = 0;
            }
            if (counter >= frames.Count) counter = 0;
            CurrentFrame = frames[counter];
        }
        
    }
}
