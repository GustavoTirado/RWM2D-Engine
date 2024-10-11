using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Motor_Grafico
{
    internal class Camera
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }

        public Camera(float width, float height)
        {
            Width = width;
            Height = height;
            X = 0;
            Y = 0;
        }

        public void Follow(Player player)
        {
            X = player.X + player.Width / 2 - Width / 2;
            Y = player.Y + player.Height / 2 - Height / 2;
        }

        public Matrix GetTransform()
        {
            Matrix matrix = new Matrix();
            matrix.Translate(-X, -Y);
            return matrix;
        }
    }
}
