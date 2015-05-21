using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2048_Attempt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[,] arr;
        private Random genRandom;

        public MainWindow()
        {
            InitializeComponent();
            initArray();
        }

        #region Methods

        private void initArray()
        {
            arr = new int[4, 4];
            genRandom = new Random();

            //Init array values
            for (int k = 0; k < 4; k++) // Column
            {
                for (int j = 0; j < 4; j++) // Rows
                {
                    arr[k, j] = 0;
                    //arr[k, j] = 2; //Test value
                }
            }

            //Test vals
            //arr[0, 0] = 2;
            //arr[0, 1] = 2;
            //arr[1, 0] = 2;
            //arr[0, 2] = 2;

            //Generate 2 numbers randomly
            int[,] newRanCoordinate;
            newRanCoordinate = Random();
            arr[newRanCoordinate[0, 0], newRanCoordinate[0, 1]] = 2;
            newRanCoordinate = Random();
            arr[newRanCoordinate[0, 0], newRanCoordinate[0, 1]] = 2;

            display();
        }

        private bool moveGridUp(bool ranTwice)
        {
            bool moved = false;

            for(int k = 3; k >= 0; k--)
            {
                for(int j = 3; j >= 0; j--)
                {
                    if (j + 1 < 4)
                    {
                        if (ranTwice == false && (arr[k, j] == arr[k, j + 1] || arr[k, j] == 0))
                        {
                            arr[k, j] += arr[k, j + 1];
                            arr[k, j + 1] = 0;
                            moved = true;
                        }

                        if(ranTwice == true && arr[k, j] == 0)
                        {
                            arr[k, j] += arr[k, j + 1];
                            arr[k, j + 1] = 0;
                            moved = true;
                        }
                    }
                }
            }
            display();
            return moved;
        }

        private bool moveGridDown(bool ranTwice)
        {
            bool moved = true;

            for (int k = 0; k < 4; k++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j - 1 >= 0)
                    {
                        if (ranTwice == false && (arr[k, j] == arr[k, j - 1] || arr[k, j] == 0))
                        {
                            arr[k, j] += arr[k, j - 1];
                            arr[k, j - 1] = 0;
                            moved = true;
                        }

                        if(ranTwice == true && arr[k, j] == 0)
                        {
                            arr[k, j] += arr[k, j - 1];
                            arr[k, j - 1] = 0;
                            moved = true;
                        }
                    }
                }
            }
            display();
            return moved;
        }

        private bool moveGridLeft(bool ranTwice)
        {
            bool moved = false;

            for (int k = 3; k >= 0; k--)
            {
                for (int j = 3; j >= 0; j--)
                {
                    if (k - 1 >= 0)
                    {
                        if (ranTwice == false && (arr[k - 1, j] == arr[k, j] || arr[k - 1, j] == 0))
                        {
                            arr[k - 1, j] += arr[k, j];
                            arr[k, j] = 0;
                            moved = true;
                        }

                        if(ranTwice == true && arr[k - 1, j] == 0)
                        {
                            arr[k - 1, j] += arr[k, j];
                            arr[k, j] = 0;
                            moved = true;
                        }
                    }
                }
            }
            display();
            return moved;
        }

        private bool moveGridRight(bool ranTwice)
        {
            bool moved = false;

            for (int k = 0; k < 4; k++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (k + 1 < 4)
                    {
                        if (ranTwice == false && (arr[k + 1, j] == arr[k, j] || arr[k + 1, j] == 0))
                        {
                            arr[k + 1, j] += arr[k, j];
                            arr[k, j] = 0;
                            moved = true;
                        }

                        if(ranTwice == true && arr[k + 1, j] == 0)
                        {
                            arr[k + 1, j] += arr[k, j];
                            arr[k, j] = 0;
                            moved = true;
                        }
                    }
                }
            }
            display();
            return moved;
        }

        private int[,] Random()
        {
            var size = 0;
            //Store empty positions in a list
            var emptyPost = new List<Position>();

            //Loop through all to find empty places
            for(var k = 0; k < 4; k++)
            {
                for(var j = 0; j < 4; j++)
                {
                    if (arr[k, j] != 0) continue;
                    emptyPost.Add(new Position(k, j));
                    size++;
                }
            }

            var values = new int[1, 2];
            var pos = genRandom.Next(size);
            try
            {
                var item = emptyPost[pos];
                values[0, 0] = item.PosX;
                values[0, 1] = item.PosY;
            }

            catch(ArgumentOutOfRangeException)
            {
                values[0, 0] = -1;
                values[0, 1] = -1;
            }

            return values;

        }

        private void display()
        {
            lbl00.Content = arr[0, 0];
            lbl01.Content = arr[0, 1];
            lbl02.Content = arr[0, 2];
            lbl03.Content = arr[0, 3];

            lbl10.Content = arr[1, 0];
            lbl11.Content = arr[1, 1];
            lbl12.Content = arr[1, 2];
            lbl13.Content = arr[1, 3];

            lbl20.Content = arr[2, 0];
            lbl21.Content = arr[2, 1];
            lbl22.Content = arr[2, 2];
            lbl23.Content = arr[2, 3];

            lbl30.Content = arr[3, 0];
            lbl31.Content = arr[3, 1];
            lbl32.Content = arr[3, 2];
            lbl33.Content = arr[3, 3];
        }

        private void CheckFinalOrGenerateNumber()
        {
            var newRanCoordinate = Random();
            if (newRanCoordinate[0, 0] == -1 && newRanCoordinate[0, 1] == -1)
            {
                MessageBox.Show("Game Over!");
            }

            else
                arr[newRanCoordinate[0, 0], newRanCoordinate[0, 1]] = 2;
        }

        #endregion

        #region User Input

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    if (moveGridUp(false) &&
                        moveGridUp(true)) //Repeats the loop to avoid having numbers stay behind
                    {              //This is a fix albeit not a very good one computationally speaking
                        CheckFinalOrGenerateNumber();
                    }
                    break;
                case Key.Down:
                    if (moveGridDown(false) &&
                        moveGridDown(true)) //Repeats the loop to avoid having numbers stay behind
                    {                //This is a fix albeit not a very good one computationally speaking
                        CheckFinalOrGenerateNumber();
                    }
                    break;
                case Key.Left:
                    if (moveGridLeft(false) &&
                        moveGridLeft(true)) //Repeats the loop to avoid having numbers stay behind
                    {                   //This is a fix albeit not a very good one computationally speaking

                        CheckFinalOrGenerateNumber();
                    }
                    break;
                case Key.Right:
                    if (moveGridRight(false) &&
                        moveGridRight(true)) //Repeats the loop to avoid having numbers stay behind
                    {                    //This is a fix albeit not a very good one computationally speaking
                        CheckFinalOrGenerateNumber();
                    }
                    break;
            }
        }

        #endregion
    }
}
