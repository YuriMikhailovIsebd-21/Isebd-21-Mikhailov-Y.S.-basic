using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormTeplo
{
    class Teplovoz : Lokomotiv, IEquatable<Teplovoz>
    {
        public Color DopColor { private set; get; }

        public bool Tube { private set; get; }

        public bool Wheels { private set; get; }

        public Teplovoz(int maxSpeed, float weight, Color mainColor, Color dopColor, bool tube, bool wheels)
            : base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
            Tube = tube;
            Wheels = wheels;
        }


        public Teplovoz(string info) : base(info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 6)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                Tube = Convert.ToBoolean(strs[4]);
                Wheels = Convert.ToBoolean(strs[5]);
            }
        }


        public void setDopColor(Color dopColor)
        {
            DopColor = dopColor;
        }

        public override void DrawTransport(Graphics g)
        {
            base.DrawTransport(g);
            Pen pen = new Pen(DopColor);
            if (Tube)
            {
                g.DrawLine(pen, _startPosX + 90, _startPosY - 12, _startPosX + 90, _startPosY + 0);
                g.DrawLine(pen, _startPosX + 80, _startPosY - 12, _startPosX + 80, _startPosY + 0);
                g.DrawLine(pen, _startPosX + 80, _startPosY - 12, _startPosX + 90, _startPosY - 12);
            }

            if (Wheels)
            {
                g.DrawEllipse(pen, _startPosX + 6, _startPosY + 40, 15, 15);
                g.DrawEllipse(pen, _startPosX + 35, _startPosY + 40, 15, 15);
                g.DrawEllipse(pen, _startPosX + 84, _startPosY + 40, 15, 15);
                g.DrawEllipse(pen, _startPosX + 115, _startPosY + 40, 15, 15);
                g.DrawLine(pen, _startPosX + 42, _startPosY + 40, _startPosX + 42, _startPosY + 55);
                g.DrawLine(pen, _startPosX + 13, _startPosY + 40, _startPosX + 13, _startPosY + 55);
                g.DrawLine(pen, _startPosX + 92, _startPosY + 40, _startPosX + 92, _startPosY + 55);
                g.DrawLine(pen, _startPosX + 123, _startPosY + 40, _startPosX + 123, _startPosY + 55);
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}{separator}{DopColor.Name}{separator}{Tube}{separator}{Wheels}";
        }

        public bool Equals(Teplovoz other)
        {
            if (DopColor == other.DopColor && Tube == other.Tube && Wheels == other.Wheels)
            {
                return base.Equals(other);
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Teplovoz))
            {
                return false;
            }
            else
            {
                return Equals(obj as Teplovoz);
            }
        }
    }
}
