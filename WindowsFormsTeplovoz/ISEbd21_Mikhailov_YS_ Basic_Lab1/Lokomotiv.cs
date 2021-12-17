using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormTeplo
{
    public class Lokomotiv : Vehicle , IEquatable<Lokomotiv>
    {
        private readonly int carWidth = 150;
        private readonly int carHeight = 50;

        protected readonly char separator = ';';

        public Lokomotiv(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        public Lokomotiv(string info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
        }


        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - carWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step >= 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step >= 0)
                    {
                        _startPosY -= step;
                    }
                    break;

                //вниз
                case Direction.Down:
                    if (_startPosY + step <= _pictureHeight - carHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(MainColor);
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

        public override string ToString()
        {
            return $"{MaxSpeed}{separator}{Weight}{separator}{MainColor.Name}";
        }

        public bool Equals(Lokomotiv other)
        {
            if (other == null)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (MainColor != other.MainColor)
            {
                return false;
            }
            return true;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Lokomotiv))
            {
                return false;
            }
            else
            {
                return Equals(obj as Lokomotiv);
            }
        }

    }
}
