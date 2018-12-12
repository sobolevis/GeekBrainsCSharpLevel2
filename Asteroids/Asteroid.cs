using System.Drawing;

namespace Asteroids
{
    class Asteroid : BaseObject
    {
        protected static readonly Image ReferenceImage;

        /// <summary>
        /// "Сила" астероида
        /// </summary>
        public int Power { get; set; }

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
            Power = 1;
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
        public override void Update() {}

        /// <summary>
        /// Установка случайной позиции астероида
        /// </summary>
        public override void SetRandomPosition()
        {
            Pos = new Point(Game.Rnd.Next(Game.Height), Game.Rnd.Next(Game.Width));
        }
    }
}