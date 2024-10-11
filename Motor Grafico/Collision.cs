using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    internal class Collision
    {
        public static bool Col_CreateRectangularCollision(Rectangle rect1, Rectangle rect2)
        {
            return rect1.IntersectsWith(rect2);
        }

        public static bool Col_CreateCircularCollision(PointF center1, float radius1, PointF center2, float radius2)
        {
            float dx = center1.X - center2.X;
            float dy = center1.Y - center2.Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);
            return distance <= (radius1 + radius2);
        }

        public static bool Col_CreateCapsuleCollision(PointF pointA1, PointF pointB1, float radius1, PointF pointA2, PointF pointB2, float radius2)
        {
            return Col_CreateCircularCollision(pointA1, radius1, pointA2, radius2) ||
                   Col_CreateCircularCollision(pointA1, radius1, pointB2, radius2) ||
                   Col_CreateCircularCollision(pointB1, radius1, pointA2, radius2) ||
                   Col_CreateCircularCollision(pointB1, radius1, pointB2, radius2);
        }

        public static void DrawRectangularCollision(Graphics g, Rectangle rect, Pen pen)
        {
            g.DrawRectangle(pen, rect);
        }
        public static void DrawCircularCollision(Graphics g, PointF center, float radius, Pen pen)
        {
            g.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }

        public static void DrawCapsuleCollision(Graphics g, PointF pointA, PointF pointB, float radius, Pen pen)
        {
            g.DrawEllipse(pen, pointA.X - radius, pointA.Y - radius, radius * 2, radius * 2);
            g.DrawEllipse(pen, pointB.X - radius, pointB.Y - radius, radius * 2, radius * 2);
            g.DrawLine(pen, pointA.X + radius, pointA.Y, pointB.X + radius, pointB.Y);
            g.DrawLine(pen, pointA.X - radius, pointA.Y, pointB.X - radius, pointB.Y);
        }
    }
}
