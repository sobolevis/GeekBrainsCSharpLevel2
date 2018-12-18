using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Asteroids
{
    class Game
    {
        public static event Action<string> GameMessage;

        public static readonly Random Rnd = new Random();
        public static Timer Timer = new Timer();

        public static List<Bullet> Bullets;
        private static List<Asteroid> _asteroids;
        private static List<Star> _stars;
        private static Ship _ship;
        private static AidKit _aidKit;

        public const int CountStars = 15;
        public const int CountAsterouds = 25;

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        /// <summary>
        /// Создание статичных объектов
        /// </summary>
        static Game()
        {
            _asteroids = new List<Asteroid>();
            _stars = new List<Star>();
            Bullets = new List<Bullet>();
            _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));
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

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer.Interval = 20;
            Timer.Start();
            Timer.Tick += Timer_Tick;

            Load();

            GameMessage += PrintMessageToConsole;
            GameMessage += PrintMessageToFile;
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
        }

        /// <summary>
        /// Управление кораблем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _ship.Shoot();
            if (e.KeyCode == Keys.Up) _ship.MoveUp();
            if (e.KeyCode == Keys.Down) _ship.MoveDown();
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
            // Создание корабля
            _ship = new Ship(new Point(50, Height / 2), new Point(1, 0), new Size(25, 40));

            // Создание звезд
            for (int i = 0; i < CountStars; i++)
            {
                var rndSize = Rnd.Next(5, 20);
                _stars.Add(new Star(new Point(Rnd.Next(Width), Rnd.Next(Height)),
                    new Point(Rnd.Next(5, 10), Rnd.Next(5, 10)),
                    new Size(rndSize, rndSize)));
            }

            // Создание астероидов
            for (int i = 0; i < CountAsterouds; i++)
            {
                var rndSize = Rnd.Next(5, 20);
                _asteroids.Add(new Asteroid(new Point(Rnd.Next(Width / 2, Width), Rnd.Next(Height)),
                    new Point(Rnd.Next(5, 10), Rnd.Next(5, 10)),
                    new Size(rndSize, rndSize)));
            }
        }

        /// <summary>
        /// Отрисовка всех объектов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            Buffer.Graphics.DrawString("Health:" + _ship.Heath, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            Buffer.Graphics.DrawString("Score:" + _ship.Score, SystemFonts.DefaultFont, Brushes.White, Width / 2, 0);

            foreach (Star star in _stars)
                star.Draw();
            foreach (Asteroid asteroid in _asteroids)
                asteroid.Draw();
            foreach (Bullet bullet in Bullets)
                bullet.Draw();

            _aidKit?.Draw();
            _ship.Draw();

            Buffer.Render();
        }

        /// <summary>
        /// Обновление всех объектов
        /// </summary>
        public static void Update()
        {
            foreach (Star star in _stars)
                star.Update();
            foreach (Bullet bullet in Bullets)
                bullet.Update();
            foreach (Asteroid asteroid in _asteroids.ToArray())
            {
                asteroid.Update();

                foreach (Bullet bullet in Bullets.ToArray())
                {
                    if (asteroid.Collision(bullet))
                    {
                        GameMessage?.Invoke($"Попадание в {nameof(asteroid)}! Нанесено урона: {bullet.Damage}");
                        asteroid.ToDamage(bullet.Damage);
                        Bullets.Remove(bullet);
                    }
                }

                if (_ship.Collision(asteroid))
                {
                    GameMessage?.Invoke($"Столкновение с {nameof(asteroid)}! Получено урона: {asteroid.Damage}");
                    _ship.ToDamage(asteroid.Damage);
                    asteroid.ToDamage(1);
                }

                if (asteroid.Health <= 0)
                {
                    GameMessage?.Invoke($"{nameof(asteroid)} уничтожен! Текущий счет: {_ship.Score}");
                    _asteroids.Remove(asteroid);
                    _ship.Score++;
                }
            }

            _ship.Update();

            if (_aidKit != null)
                if (_ship.Collision(_aidKit))
                {
                    GameMessage?.Invoke($"Аптечка поднята! Жизней восстановлено: {_aidKit.Health}");
                    _ship.Heath += _aidKit.Health;
                    _aidKit = null;
                }
            
            if (_ship.Heath <= 5)
            {
                GameMessage?.Invoke($"Внимание!!! Низкий уровень здоровья!!! Осталось жизней: {_ship.Heath}");
                if (_aidKit == null) _aidKit = new AidKit(new Point(50, Rnd.Next(Height)), new Point(1, 0), new Size(20, 20));
            }

            if (_ship.Heath <= 0)
            {
                GameMessage?.Invoke($"{nameof(_ship)} уничтожен!");
                _ship.ToDie();
            }
        }

        /// <summary>
        /// Конец игры
        /// </summary>
        public static void Finish()
        {
            Timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

        /// <summary>
        /// Вывод сообщений в консоль
        /// </summary>
        /// <param name="str"></param>
        public static void PrintMessageToConsole(string str)
        {
            Console.WriteLine(str);
        }

        /// <summary>
        /// Вывод сообщений в файл
        /// </summary>
        /// <param name="str"></param>
        public static void PrintMessageToFile(string str)
        {
            using (StreamWriter sw = new StreamWriter("Log.txt", true))
            {
                sw.WriteLine(str);
            }
        }
    }
}