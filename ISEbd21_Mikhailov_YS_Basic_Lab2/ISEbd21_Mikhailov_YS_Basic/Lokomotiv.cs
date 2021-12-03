using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WindowsFormsTeplovoz
{
    public class Lokomotiv : Vehicle
    {
        protected readonly int teploWidth = 100;
        protected readonly int teploHeight = 30;

        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        public Lokomotiv(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="teploWidth">Ширина отрисовки автомобиля</param>
        /// <param name="teploHeight">Высота отрисовки автомобиля</param>

        protected Lokomotiv(int maxSpeed, float weight, Color mainColor, int TeploWidth, int
       TeploHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            this.teploWidth = TeploWidth;
            this.teploHeight = TeploHeight;
        }

        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - teploWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - teploHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
 
        /// <summary>
        /// <param name="g"></param>
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            //TeploBody:
            {
                //body
                g.DrawRectangle(pen, _startPosX, _startPosY + 15, 150, 20);
                g.DrawLine(pen, _startPosX, _startPosY + 15, _startPosX + 8, _startPosY);
                g.DrawLine(pen, _startPosX + 8, _startPosY, _startPosX + 150, _startPosY);
                g.DrawLine(pen, _startPosX + 150, _startPosY, _startPosX + 150, _startPosY + 18);
                //dopParts
                g.FillRectangle(Brushes.Black, _startPosX + 150, _startPosY + 10, 5, 25);
                g.FillRectangle(Brushes.Black, _startPosX + 10, _startPosY + 35, 45, 15);
                g.FillRectangle(Brushes.Black, _startPosX + 90, _startPosY + 35, 45, 15);
                //door
                g.DrawRectangle(pen, _startPosX + 50, _startPosY + 5, 15, 25);
                g.FillRectangle(Brushes.White, _startPosX + 50 + 1, _startPosY + 5 + 1, 15, 25);

                //wheels
                g.DrawEllipse(pen, _startPosX + 6, _startPosY + 40, 15, 15);
                g.DrawEllipse(pen, _startPosX + 35, _startPosY + 40, 15, 15);
                g.DrawEllipse(pen, _startPosX + 84, _startPosY + 40, 15, 15);
                g.DrawEllipse(pen, _startPosX + 115, _startPosY + 40, 15, 15);

                //windows
                g.DrawRectangle(Pens.Blue, _startPosX + 13, _startPosY + 3, 10, 10);
                g.DrawRectangle(Pens.Blue, _startPosX + 33, _startPosY + 3, 10, 10);
                g.DrawRectangle(Pens.Blue, _startPosX + 130, _startPosY + 3, 10, 10);

            }
        }
    }
}
 






