using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Puzzle
{
    public partial class Form1 : Form
    {
        public Bitmap bitmap;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream;
                if ((stream = openFileDialog.OpenFile()) != null)
                {
                    using (stream)
                    {
                        bitmap = new Bitmap(stream);
                        pictureBoxPuzzleSet.Image = bitmap;
                        
                        buttonFindPuzzle.Enabled = true;
                    }
                }
            }

        }

        private void buttonFindPuzzle_Click(object sender, EventArgs e)
        {
            PuzzleSet puzzleSet = new PuzzleSet(bitmap, ref progressBarOfX);
            //pictureBoxPuzzleSet.Image = puzzleSet.ReturnPuzzle()[0].Image;
            for (int i = 0; i < puzzleSet.ReturnPuzzle().Count; i++)
            {
                puzzleSet.ReturnPuzzle()[i].SavePicture(i);
            }
            //  puzzleSet.ReturnPuzzle()[5].SavePicture(5);
        }
    }
}
