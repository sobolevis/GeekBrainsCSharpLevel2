using System.Drawing;

namespace Asteroids
{
    class AidKit : BaseObject
    {
        public int Health { get; }

        public AidKit(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Image = new Bitmap(ReferenceImage, size);
            Health = Game.Rnd.Next(1, 3);
        }

        /// <summary>
        /// Загрузка изображения для аптечек
        /// </summary>
        static AidKit()
        {
            ReferenceImage = System.Drawing.Image.FromFile("AidKit.png");
        }

        /// <summary>
        /// Отрисовка аптечки
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }

        /// <summary>
        /// Обновление аптечки
        /// </summary>
        public override void Update() {}
    }
}
