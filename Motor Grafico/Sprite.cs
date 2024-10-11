using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Grafico
{
    internal class Sprite
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Rotation { get; set; }

        public string CollisionType { get; set; }

        public bool CanColision { get; set; }

        public Color color { get; set; }

        public Sprite(float x, float y, float width, float height, string collisiontype, bool canCol, int? r = null, int? g = null, int? b = null)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Rotation = 0;
            CollisionType = collisiontype;
            CanColision = canCol;

            if (r.HasValue && g.HasValue && b.HasValue &&
                r.Value >= 0 && r.Value <= 255 &&
                g.Value >= 0 && g.Value <= 255 &&
                b.Value >= 0 && b.Value <= 255)
            {
                color = Color.FromArgb(r.Value, g.Value, b.Value); 
            }
            else
            {
                color = Color.Yellow;
            }
        }

        public void Move(float deltaX, float deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }

        public void Rotate(float deltaRotation)
        {
            Rotation += deltaRotation;
        }

        public void Draw(Graphics g)
        {
            Rectangle wallRect = new Rectangle((int)X, (int)Y, (int)Width, (int)Height);

            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, wallRect);  
            }
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
        }

    }
}
