using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Puzzle
{
    public class SinglePuzzle
    {
        public byte[,] PuzzleArray { get; private set; } //in this sample i decided that one puzzle is size ca. 100x100 pixels
        //public Image Image { get; set; }    
        public Bitmap Image { get; set; }
        public PuzzleType PuzzleType { get; private set; }

        public  SinglePuzzle(int[,] PixelMap)
        {
            int[,] ReadedPuzzle = new int[300, 300];
            Image = new Bitmap(300, 300, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 300; j++)
                {
                    //byte[] bgra = new byte[] { (byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255), 255 };
                    //byte[] bgra = new byte[] { (byte)PixelMap[i,j] }
                    Image.SetPixel(i,j, Color.FromArgb( PixelMap[i,j] ));
                }
            }
            //Image = new Bitmap(130, 130, 130 * 4, System.Drawing.Imaging.PixelFormat.Format32bppArgb, new IntPtr(ReadedPuzzle[0,0]));
            //Image = new Bitmap(130, 130, 130 * 4, System.Drawing.Imaging.PixelFormat.Format32bppArgb, new IntPtr(PixelMap[0,0]));
            // AnalyzePuzzle();
        }

        private void AnalyzePuzzle()
        {
            int TopY = 99999, DownY = 0, RightX = 99999, LeftX = 0;
            for (int i = 0; i < 100; i++) //x
            {
                for (int j = 0; j < 100; j++) //y
                {
                    if (Image.GetPixel(i, j).A == 0xff)
                    {
                        LeftX = LeftX > i ? LeftX : i;
                        RightX = RightX < i ? RightX : i;
                        TopY = TopY > j ? TopY : j;
                        DownY = DownY < j ? DownY : j;
                    }
                }
            }
            PuzzleType = PuzzleType.Cross;
        }

        public void SavePicture(int i)
        {
            Image.Save(i.ToString()+".png", System.Drawing.Imaging.ImageFormat.Png);
            Application.DoEvents();
            //using (StreamWriter sw = new StreamWriter(i.ToString()))
            //{
            //    Image.Save(sw as Stream, System.Drawing.Imaging.ImageFormat.Png);
            //}
        }

        private void ReturnPixelFormatted()
        {

        }
    }
}
