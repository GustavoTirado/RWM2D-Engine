using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motor_Grafico
{
    internal class Player
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }
        private float speed;

        public Player(float x, float y, float width, float height, float speed)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            this.speed = speed;
        }

        public void Move(float deltaX, float deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }

        public void Draw(Graphics g)
        {
            Rectangle playerRect = new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
            g.FillRectangle(Brushes.Red, playerRect);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
        }

        public void HandleInput(Input input, List<Sprite> walls, float deltaTime)
        {
            Rectangle playerRect = GetBounds();
            Rectangle futureRect;
            float adjustedSpeed = speed * deltaTime;

            if (input.IsKeyPressed(Keys.W))
            {
                futureRect = new Rectangle(playerRect.X, playerRect.Y - (int)adjustedSpeed, playerRect.Width, playerRect.Height);
                if (!CheckCollisions(futureRect, walls))
                    Move(0, -adjustedSpeed);
            }

            if (input.IsKeyPressed(Keys.S))
            {
                futureRect = new Rectangle(playerRect.X, playerRect.Y + (int)adjustedSpeed, playerRect.Width, playerRect.Height);
                if (!CheckCollisions(futureRect, walls))
                    Move(0, adjustedSpeed);
            }

            if (input.IsKeyPressed(Keys.A))
            {
                futureRect = new Rectangle(playerRect.X - (int)adjustedSpeed, playerRect.Y, playerRect.Width, playerRect.Height);
                if (!CheckCollisions(futureRect, walls))
                    Move(-adjustedSpeed, 0);
            }

            if (input.IsKeyPressed(Keys.D))
            {
                futureRect = new Rectangle(playerRect.X + (int)adjustedSpeed, playerRect.Y, playerRect.Width, playerRect.Height);
                if (!CheckCollisions(futureRect, walls))
                    Move(adjustedSpeed, 0);
            }

            if (CheckCollisions(GetBounds(), walls))
            {
                if (input.IsKeyPressed(Keys.W))
                {
                    Move(0, adjustedSpeed);
                }
                else if (input.IsKeyPressed(Keys.S))
                {
                    Move(0, -adjustedSpeed); 
                }

                if (input.IsKeyPressed(Keys.A))
                {
                    Move(adjustedSpeed, 0); 
                }
                else if (input.IsKeyPressed(Keys.D))
                {
                    Move(-adjustedSpeed, 0); 
                }
            }
        }

        private bool CheckCollisions(Rectangle futureRect, List<Sprite> walls)
        {
            foreach (var wall in walls)
            {
                if (futureRect.IntersectsWith(wall.GetBounds())) 
                {
                    return true; 
                }
            }
            return false; 
        }
    }
}
