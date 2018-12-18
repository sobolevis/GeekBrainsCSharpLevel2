using System.Drawing;

namespace Asteroids
{
    class Bullet : BaseObject
    {
        public int Damage { get; }

        /// <summary>
        /// Загрузка изображения для пуль
        /// </summary>
        static Bullet()
        {
            ReferenceImage = System.Drawing.Image.FromFile("Bullet.png");
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Image = new Bitmap(ReferenceImage, size);
            Damage = 2;
        }

        /// <summary>
        /// Отрисовка пули
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }

        /// <summary>
        /// Обновление пули
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + 10;
        }

    }
}
