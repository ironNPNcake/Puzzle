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
    public class PuzzleSet
    {
        public Bitmap Bitmap { get; private set; }
        public int Count;
        private List<SinglePuzzle> PuzzleList = new List<SinglePuzzle>();
        public List<SinglePuzzle> ReturnPuzzle()
        {
            return PuzzleList;
        }


        public PuzzleSet(Bitmap bitmap,ref ProgressBar progressBar)
        {
            Bitmap = bitmap;
            AnalyzeSet(ref progressBar);
        }
        public void AnalyzeSet(ref ProgressBar progressBar)
        {
            int StartX = 0, StartY = 0;
            int[,] ReadedPuzzle = new int[300, 300];
            for (int x = 0; x < Bitmap.Width; x++)
            {
                for (int y = 0; y < Bitmap.Height; y++)
                {
                    if (Bitmap.GetPixel(x, y).B < 200 || Bitmap.GetPixel(x, y).R < 200 || Bitmap.GetPixel(x, y).G < 200)
                    {

                        if (StartX == 0) { StartX = x; StartY = y; ReadedPuzzle = new int[300, 300]; }

                        for(int i=x-5,ArrayX=0;ArrayX<260;i++,ArrayX++)
                        {
                            for (int j = y-100,ArrayY=0; ArrayY < 260; j++, ArrayY++)
                            {
                                i = i >= Bitmap.Width ? Bitmap.Width-1 : i;
                                j = j >= Bitmap.Height ? Bitmap.Height-1 : j;
                                i = i <= 0 ? 0 : i;
                                j = j <= 0 ? 0 : j;

                                if (Bitmap.GetPixel(i,j).B < 200 || Bitmap.GetPixel(i,j).R < 200 || Bitmap.GetPixel(i,j).G < 200)
                                {
                                    ReadedPuzzle[ArrayX, ArrayY] = Bitmap.GetPixel(i, j).ToArgb();
                                    Bitmap.SetPixel(i, j,Color.White);
                                //    Bitmap.Save(x.ToString() +"a.png");
                                }
                            }
                        }
                        StartX = 0;
                        StartY = 0;
                        PuzzleList.Add(new SinglePuzzle(ReadedPuzzle));
                      //  y += 100;
                    }
                }
                progressBar.Value = Convert.ToInt32((x*100)/Bitmap.Width*progressBar.Maximum/100);
                Application.DoEvents();
            }
        }
    }
}
