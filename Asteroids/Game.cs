using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    class Game
    {
        private static readonly Random Rnd = new Random();

        private static BufferedGraphicsContext _context;

        public static BaseObject[] Objs;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        static Game() {}

        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = 20 };
            timer.Start();
            timer.Tick += Timer_Tick;

            Load();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Load()
        {
            Objs = new BaseObject[50];
            for (int i = 0; i < Objs.Length; i++)
            {
                var rndObj = Rnd.Next(2);
                var rndSize = Rnd.Next(5, 20);
                if (rndObj == 1)
                {
                    Objs[i] = new Star(new Point(Rnd.Next(600), Rnd.Next(800)),
                                        new Point(15 - i, 15 - i),
                                        new Size(rndSize, rndSize));
                }
                else
                {
                    Objs[i] = new Asteroid(new Point(Rnd.Next(600), Rnd.Next(800)),
                                            new Point(15 - i, 15 - i),
                                            new Size(rndSize, rndSize));
                }

            }
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in Objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in Objs)
                obj.Update();
        }

    }
}
