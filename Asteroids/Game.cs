using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    class Game
    {
        public static readonly Random Rnd = new Random();
        private static BufferedGraphicsContext _context;
        private static List<BaseObject> _objs;
        private static List<Bullet> _bullets;

        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }

        /// <summary>
        /// Создание списков объектов
        /// </summary>
        static Game()
        {
            _objs = new List<BaseObject>();
            _bullets = new List<Bullet>();
        }

        /// <summary>
        /// Инициализация игры
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            // Проверка размера окна, генерация исключения
            if (form.ClientSize.Width > 1000 ||form.ClientSize.Height > 1000 ||
                form.ClientSize.Width < 0 || form.ClientSize.Height < 0)
                throw new ArgumentOutOfRangeException("Недопустимый размер окна!");

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = 20 };
            timer.Start();
            timer.Tick += Timer_Tick;

            Load();
        }

        /// <summary>
        /// Обновление кадра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
        /// Загрузка игры - создание объектов
        /// </summary>
        public static void Load()
        {
            int countStars = 15;
            int countAsterouds = 25;
            int countBullet = 5;

            for (int i = 0; i < countStars; i++)
            {
                var rndSize = Rnd.Next(5, 20);
                _objs.Add(new Star(new Point(Rnd.Next(Game.Height), Rnd.Next(Game.Width)),
                                    new Point(15 - i, 15 - i),
                                    new Size(rndSize, rndSize)));
            }

            for (int i = 0; i < countAsterouds; i++)
            {
                var rndSize = Rnd.Next(5, 20);
                _objs.Add(new Asteroid(new Point(Rnd.Next(Game.Height), Rnd.Next(Game.Width)),
                          new Point(15 - i, 15 - i),
                          new Size(rndSize, rndSize)));
            }

            for (int i = 0; i < countBullet; i++)
            {
                _bullets.Add(new Bullet(new Point(0, Rnd.Next(Game.Width)), 
                          new Point(5, 0), 
                          new Size(4, 1)));
            }

        }

        /// <summary>
        /// Отрисовка всех объектов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (var bullet in _bullets)
                bullet.Draw();
            Buffer.Render();
        }

        /// <summary>
        /// Обновление всех объектов
        /// </summary>
        public static void Update()
        {

            foreach (BaseObject obj in _objs)
            {
                obj.Update();
                foreach (var bullet in _bullets)
                {
                    if (obj.Collision(bullet))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        obj.SetRandomPosition();
                        bullet.SetRandomPosition();
                    }
                }
            }

            foreach (var bullet in _bullets)
                bullet.Update();
        }

    }
}
