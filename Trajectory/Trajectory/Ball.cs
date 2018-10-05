using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trajectory
{
    class Ball
    {
        public double x;
        public double y;
        public double speedX;
        public double speedY;
        public Ball(double x, double y, double speed, double angle)
        {
            this.x = x;
            this.y = y;
            this.speedX = speed * Math.Cos(angle);
            this.speedY = speed * Math.Sin(angle);

        }
        public void Tick()
        {
            x += speedX * 0.001;
            y += speedY * 0.001;
            speedY += 9.8 * 0.001;
        }
        public void reflect (double angle)
        {
            double speed = Math.Sqrt(speedX * speedX + speedY * speedY);
            double alpha = Math.PI / 2 - Math.Atan(speedX / speedY) - angle;
         
        alpha = angle - alpha;
            speedY = speed * Math.Sin(alpha);
            speedX = speed * Math.Cos(alpha);

        }
    }
}
