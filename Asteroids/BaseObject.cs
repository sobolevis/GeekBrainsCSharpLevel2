using System.Drawing;

namespace Asteroids
{
    abstract class BaseObject : ICollision
    {
        public delegate void Message();

        protected static Image ReferenceImage;

        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected Bitmap Image;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        /// <summary>
        /// Коллайдер
        /// </summary>
        public Rectangle Rect => new Rectangle(Pos, Size);

        /// <summary>
        /// Отрисовка
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Обновление
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Столкновение
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(Rect);

    }
}