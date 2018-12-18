using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace Asteroids
{
    class Star : BaseObject
    {
        protected static readonly Image ReferenceImage;

        /// <summary>
        /// Загрузка изображения для звезд
        /// </summary>
        static Star()
        {
            ReferenceImage = System.Drawing.Image.FromFile("Star.png");
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Image = new Bitmap(ReferenceImage, size);
        }

        /// <summary>
        /// Отрисовка звезды
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }

        /// <summary>
        /// Обновление звезды
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

        /// <summary>
        /// Установка случайной позиции звезды
        /// </summary>
        public override void SetRandomPosition() { }
    }
}
