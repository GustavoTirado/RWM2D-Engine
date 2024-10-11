using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Motor_Grafico
{
    public partial class Form1 : Form
    {
        private Player player;
        private Input input;
        private List<Sprite> walls;  // Cambiado a una lista de Sprite
        private float playerSpeed = 110f;
        private Stopwatch stopwatch;
        private float deltaTime;
        private Camera camera;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;  // Color de fondo para ver bien el contenido

            input = new Input();
            player = new Player(50, 50, 50, 50, playerSpeed);

            walls = new List<Sprite>()
            {
                new Sprite(200, 100, 150, 150,"Object",false, 255, 255, 255),
                new Sprite(400, 50, 100, 200,"Object",true, 255, 0, 255),    
                new Sprite(100, 300, 200, 100,"Object",false, 255, 255, 255), 
            };
            camera = new Camera(this.ClientSize.Width, this.ClientSize.Height);


            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);

            stopwatch = new Stopwatch();
            stopwatch.Start();

            Timer gameTimer = new Timer();
            gameTimer.Interval = 16;
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            g.Transform = camera.GetTransform();

            player.Draw(g);

            foreach (var wall in walls)
            {
                wall.Draw(g);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            input.KeyDown(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            input.KeyUp(e);
        }

        private void GameLoop(object sender, EventArgs e)
        {
            float currentTime = (float)stopwatch.Elapsed.TotalSeconds;
            deltaTime = currentTime;
            stopwatch.Restart();
            player.HandleInput(input, walls, deltaTime);
            camera.Follow(player);
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }




    }
}