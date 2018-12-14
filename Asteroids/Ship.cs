using System.Drawing;

namespace Asteroids
{
    class Ship : BaseObject
    {
        public static event Message MessageDie;

        private readonly int _speed;
        public int Heath { get; set; }
        public int Score { get; set; }

        /// <summary>
        /// Загрузка изображения для корабля
        /// </summary>
        static Ship()
        {
            ReferenceImage = System.Drawing.Image.FromFile("Ship.png");
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Image = new Bitmap(ReferenceImage, size);
            _speed = 10;
            Heath = 10;
            Score = 0;
        }

        /// <summary>
        /// Отрисовка корабля
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }

        /// <summary>
        /// Обновление корабля
        /// </summary>
        public override void Update()
        {

        }

        /// <summary>
        /// Передвижение корабля вверх
        /// </summary>
        public void MoveUp()
        {
            if (Pos.Y > 0) Pos.Y -= _speed;
        }

        /// <summary>
        /// Перемещение корабля вниз
        /// </summary>
        public void MoveDown()
        {
            if (Pos.Y < Game.Height) Pos.Y += _speed;
        }

        /// <summary>
        /// Получение урона
        /// </summary>
        /// <param name="damage"></param>
        public void ToDamage(int damage)
        {
            Heath -= damage;
        }

        /// <summary>
        /// Выстрел
        /// </summary>
        public void Shoot()
        {
            Game.Bullets.Add(new Bullet(new Point(Rect.X + 25, Rect.Y + 20), new Point(4, 0), new Size(4, 1)));
        }

        /// <summary>
        /// Уничтожение корабля
        /// </summary>
        public void ToDie()
        {
            MessageDie?.Invoke();
        }

    }

}
