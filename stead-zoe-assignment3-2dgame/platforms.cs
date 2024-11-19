using Game10003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace stead_zoe_assignment3_2dgame
{
    public class platforms
    {
        public Vector2 positionplatformtophor = new Vector2(900, -200);
        public Vector2 positionplatformbothor = new Vector2(900, 550);
        public float widthplatform = 30;
        public float heightplatform = 600;
        public Vector2 velocityplatform;
        public int speed = 200;
        int platformgap = Game10003.Random.Integer(10, 500);
        public int score = 0;

        public void Spawn()
        {
            platformgap = Game10003.Random.Integer(10, 500);
            positionplatformtophor = new Vector2(900, -200 - platformgap);
            positionplatformbothor = new Vector2(900, 550 - platformgap);
        }

        public void DrawPlatform()
        {
            // Design of the top platform
            Draw.FillColor = Color.Black;
            Draw.LineColor = Color.White;
            Draw.Rectangle(positionplatformtophor.X, positionplatformtophor.Y, widthplatform, heightplatform);

            // Design of the bottom platform
            Draw.FillColor = Color.Black;
            Draw.LineColor = Color.White;
            Draw.Rectangle(positionplatformbothor.X, positionplatformbothor.Y, widthplatform, heightplatform);
        }

        public void Detect()
        {
            // Design of the detector
            if (positionplatformbothor.X <= -100)
            {
                Spawn();
                score++;
            }
        }
    }
}
