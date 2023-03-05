using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class Form1 : Form
    {
        List<puzzle> puzzles = new List<puzzle>();
        public Form1()
        {
            InitializeComponent();
            init();
            shuffle();
        }
        void init ()
            {
            puzzles.Add(button1);
            puzzles.Add(button2);
            puzzles.Add(button3);
            puzzles.Add(button4);
            puzzles.Add(button5);
            puzzles.Add(button6);
            puzzles.Add(button7);
            puzzles.Add(button8);
            puzzles.Add(button9);
            place(puzzles[0], null, button2, null, button4);
            place(puzzles[1], button1, button3, null, button5);
            place(puzzles[2], button2, null, null, button6);
            place(puzzles[3], null, button5, button1, button7);
            place(puzzles[4], button4, button6, button2, button8);
            place(puzzles[5], button5, null, button3, button9);
            place(puzzles[6], null, button8, button4, null);
            place(puzzles[7], button7, button9, button5, null);
            place(puzzles[8], button8, null, button6, null);

        }
        void place(puzzle x, puzzle left
             , puzzle right , puzzle up , puzzle down)
        {
            x.left = left;
            x.right = right;
            x.up = up;
            x.down = down;
            
        }
        void shuffle()
        {
            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Random r = new Random();
            nums = nums.OrderBy(x=>r.Next()).ToList();
            for (int i = 0; i < puzzles.Count; i++)
            {
                if (nums[i] == 9)
                {
                    puzzles[i].Text = "";

;
                }
                else
                {
                    puzzles[i].Text = nums[i].ToString();
                }
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (((puzzle)sender).left!=null&& ((puzzle)sender).left.Text == "")
            {
                swap(((puzzle)sender).left, (puzzle)sender);
            }
            else if (((puzzle)sender).right!= null&&((puzzle)sender).right.Text == "")
            {
                swap(((puzzle)sender).right, (puzzle)sender);
            }
            else if (((puzzle)sender).up!= null&&((puzzle)sender).up.Text == "")
            {
                swap(((puzzle)sender).up, (puzzle)sender);

            }

            else if (((puzzle)sender).down!= null&&((puzzle)sender).down.Text == "")
            {
                swap(((puzzle)sender).down, (puzzle)sender);
            }
            if (goal())
            {
                MessageBox.Show("congrat");
            } 




        }
        void swap(puzzle a , puzzle b)
        {
            string temp = a.Text;
            a.Text = b.Text;
            b.Text = a.Text;
        }
        bool goal()
        {
            for (int i = 0; i < puzzles.Count; i++)
            {
                if(!(i<8&&puzzles[i].Text==(i+1).ToString() || i==8&& puzzles[i].Text == ""))
                {
                    return false;
                }
            }
            return true;
        }
       
    }
}
