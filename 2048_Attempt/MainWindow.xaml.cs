using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace _2048_Attempt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private int[,] _arr;
        private Random _genRandom;

        public MainWindow()
        {
            InitializeComponent();
            InitArray();
        }

        #region Methods

        private void InitArray()
        {
            _arr = new int[4, 4];
            _genRandom = new Random();

            //Init array values
            for (var k = 0; k < 4; k++) // Column
            {
                for (var j = 0; j < 4; j++) // Rows
                {
                    _arr[k, j] = 0;
                    //arr[k, j] = 2; //Test value
                }
            }

            //Test vals
            //arr[0, 0] = 2;
            //arr[0, 1] = 2;
            //arr[1, 0] = 2;
            //arr[0, 2] = 2;

            //Generate 2 numbers randomly
            var newRanCoordinate = Random();
            _arr[newRanCoordinate[0, 0], newRanCoordinate[0, 1]] = 2;
            newRanCoordinate = Random();
            _arr[newRanCoordinate[0, 0], newRanCoordinate[0, 1]] = 2;

            Display();
        }

        private bool MoveGridUp(bool ranTwice)
        {
            var moved = false;

            for(var k = 3; k >= 0; k--)
            {
                for(var j = 3; j >= 0; j--)
                {
                    if (j + 1 < 4)
                    {
                        if (ranTwice == false && (_arr[k, j] == _arr[k, j + 1] || _arr[k, j] == 0))
                        {
                            _arr[k, j] += _arr[k, j + 1];
                            _arr[k, j + 1] = 0;
                            moved = true;
                        }

                        if(ranTwice && _arr[k, j] == 0)
                        {
                            _arr[k, j] += _arr[k, j + 1];
                            _arr[k, j + 1] = 0;
                            moved = true;
                        }
                    }
                }
            }
            Display();
            return moved;
        }

        private bool MoveGridDown(bool ranTwice)
        {
            var moved = false;

            for (var k = 0; k < 4; k++)
            {
                for (var j = 0; j < 4; j++)
                {
                    if (j - 1 >= 0)
                    {
                        if (ranTwice == false && (_arr[k, j] == _arr[k, j - 1] || _arr[k, j] == 0))
                        {
                            _arr[k, j] += _arr[k, j - 1];
                            _arr[k, j - 1] = 0;
                            moved = true;
                        }

                        if(ranTwice && _arr[k, j] == 0)
                        {
                            _arr[k, j] += _arr[k, j - 1];
                            _arr[k, j - 1] = 0;
                            moved = true;
                        }
                    }
                }
            }
            Display();
            return moved;
        }

        private bool MoveGridLeft(bool ranTwice)
        {
            var moved = false;

            for (var k = 3; k >= 0; k--)
            {
                for (var j = 3; j >= 0; j--)
                {
                    if (k - 1 >= 0)
                    {
                        if (ranTwice == false && (_arr[k - 1, j] == _arr[k, j] || _arr[k - 1, j] == 0))
                        {
                            _arr[k - 1, j] += _arr[k, j];
                            _arr[k, j] = 0;
                            moved = true;
                        }

                        if(ranTwice && _arr[k - 1, j] == 0)
                        {
                            _arr[k - 1, j] += _arr[k, j];
                            _arr[k, j] = 0;
                            moved = true;
                        }
                    }
                }
            }
            Display();
            return moved;
        }

        private bool MoveGridRight(bool ranTwice)
        {
            var moved = false;

            for (var k = 0; k < 4; k++)
            {
                for (var j = 0; j < 4; j++)
                {
                    if (k + 1 < 4)
                    {
                        if (ranTwice == false && (_arr[k + 1, j] == _arr[k, j] || _arr[k + 1, j] == 0))
                        {
                            _arr[k + 1, j] += _arr[k, j];
                            _arr[k, j] = 0;
                            moved = true;
                        }

                        if(ranTwice && _arr[k + 1, j] == 0)
                        {
                            _arr[k + 1, j] += _arr[k, j];
                            _arr[k, j] = 0;
                            moved = true;
                        }
                    }
                }
            }
            Display();
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
                    if (_arr[k, j] != 0) continue;
                    emptyPost.Add(new Position(k, j));
                    size++;
                }
            }

            var values = new int[1, 2];
            var pos = _genRandom.Next(size);
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

        private void Display()
        {
            lbl00.Content = _arr[0, 0];
            lbl01.Content = _arr[0, 1];
            lbl02.Content = _arr[0, 2];
            lbl03.Content = _arr[0, 3];

            lbl10.Content = _arr[1, 0];
            lbl11.Content = _arr[1, 1];
            lbl12.Content = _arr[1, 2];
            lbl13.Content = _arr[1, 3];

            lbl20.Content = _arr[2, 0];
            lbl21.Content = _arr[2, 1];
            lbl22.Content = _arr[2, 2];
            lbl23.Content = _arr[2, 3];

            lbl30.Content = _arr[3, 0];
            lbl31.Content = _arr[3, 1];
            lbl32.Content = _arr[3, 2];
            lbl33.Content = _arr[3, 3];
        }

        private void CheckFinalOrGenerateNumber()
        {
            var newRanCoordinate = Random();
            if (newRanCoordinate[0, 0] == -1 && newRanCoordinate[0, 1] == -1)
            {
                MessageBox.Show("Game Over!");
            }

            else
                _arr[newRanCoordinate[0, 0], newRanCoordinate[0, 1]] = 2;
            Display();
        }

        #endregion

        #region User Input

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    if (MoveGridUp(false) &&
                        MoveGridUp(true)) //Repeats the loop to avoid having numbers stay behind
                    {              //This is a fix albeit not a very good one computationally speaking
                        CheckFinalOrGenerateNumber();
                    }
                    break;
                case Key.Down:
                    if (MoveGridDown(false) &&
                        MoveGridDown(true)) //Repeats the loop to avoid having numbers stay behind
                    {                //This is a fix albeit not a very good one computationally speaking
                        CheckFinalOrGenerateNumber();
                    }
                    break;
                case Key.Left:
                    if (MoveGridLeft(false) &&
                        MoveGridLeft(true)) //Repeats the loop to avoid having numbers stay behind
                    {                   //This is a fix albeit not a very good one computationally speaking

                        CheckFinalOrGenerateNumber();
                    }
                    break;
                case Key.Right:
                    if (MoveGridRight(false) &&
                        MoveGridRight(true)) //Repeats the loop to avoid having numbers stay behind
                    {                    //This is a fix albeit not a very good one computationally speaking
                        CheckFinalOrGenerateNumber();
                    }
                    break;
            }
        }

        #endregion
    }
}
