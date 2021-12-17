using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsTeplovoz
{
    public class Parking<T> where T : class, ITransport
    {


        private readonly List<T> _places;

        private readonly int _maxCount;

        private readonly int pictureWidth;
        private readonly int pictureHeight;
        private const int _placeSizeWidth = 175;
        private const int _placeSizeHeight = 80;

        public Parking(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _maxCount = width * height;
            _places = new List<T>();
            pictureWidth = picWidth;
            pictureHeight = picHeight;
        }

       

        public static bool operator +(Parking<T> p, T teplovoz)
        {
            if (p._places.Count >= p._maxCount - 0)
            {
                return false;
            }
            p._places.Add(teplovoz);
            return true;
        }

        public static T operator -(Parking<T> p, int index)
        {
            if (index <= -1 || index >= p._places.Count)
            {
                return null;
            }
            T lokomotiv = p._places[index];
            p._places.RemoveAt(index);
            return lokomotiv;
        }
        
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Count; i++)
            {
                _places[i].SetPosition(i % 4 * _placeSizeWidth + 5, i / 4 * _placeSizeHeight + 15,pictureWidth , pictureHeight);
                _places[i]?.DrawTransport(g);
            }
        }

        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);

            for (int i = 0; i < pictureWidth / _placeSizeWidth; i++)
            {
                for (int j = 0; j < pictureHeight / _placeSizeHeight + 1; ++j)
                {//линия разметки места 
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight, i *_placeSizeWidth + _placeSizeWidth / 2, j * _placeSizeHeight);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, (pictureHeight / _placeSizeHeight) * _placeSizeHeight);
            }
        }
    }
}
