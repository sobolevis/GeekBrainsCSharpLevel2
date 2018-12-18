using System.Drawing;

namespace Asteroids
{
    class Asteroid : BaseObject
    {
        public int Health { get; set; }
        public int Damage { get; }

        /// <summary>
        /// Загрузка изображения для астероидов
        /// </summary>
        static Asteroid()
        {
            ReferenceImage = System.Drawing.Image.FromFile("Asteroid.png");
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Image = new Bitmap(ReferenceImage, size);
            Damage = Game.Rnd.Next(1, 3);
            Health = Game.Rnd.Next(3, 5);
        }

        /// <summary>
        /// Отрисовка астероида
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }

        /// <summary>
        /// Обновление астероида
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

        /// <summary>
        /// Получение урона
        /// </summary>
        /// <param name="damage"></param>
        public void ToDamage(int damage)
        {
            Health -= damage;
        }
    }
}