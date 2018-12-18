using System.ComponentModel;
using System.Drawing;

namespace Asteroids
{
    class Bullet : BaseObject
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        /// <summary>
        /// Отрисовка пули
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Обновление пули
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + 3;
        }

        /// <summary>
        /// Установка случайной позиции пули
        /// </summary>
        public override void SetRandomPosition()
        {
            Pos = new Point(Game.Rnd.Next(Game.Height), Game.Rnd.Next(Game.Width));
        }
    }
}
