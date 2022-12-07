using System.ComponentModel.DataAnnotations;

namespace ChessBlazor.Client.Pages
{



    public class Board
    {


        public int turn = 1;



        public List<piece> pieces = new List<piece>();

        public Dictionary<string, string> BoardState = new Dictionary<string, string>();


        public string[,] TileAddresses = new string[8, 8];
        public List<string> TileNames = new List<string>();

        public string[] Rows = { "1", "2", "3", "4", "5", "6", "7", "8" };
        public string[] Columns = { "A", "B", "C", "D", "E", "F", "G", "H" };


        public string[] Player1pieces = { "r1", "n1", "b1", "k1", "q1", "b2", "n2", "r2" };
        public string[] Player2pieces = { "R1", "N1", "B1", "Q1", "K1", "B2", "N2", "R2" };

        public string[,] BoardLayout = new string[8, 8];
        public List<string> pieceslist = new List<string>();

        public List<string> deadpieces = new List<string>();

        public int[] indexOfPiece(string PieceSelect)
        {
            int[] array = new int[2];
            for (int i = 0; i <= 7; i++)
            {

                for (int j = 0; j <= 7; j++)
                {


                    if (BoardLayout[i, j] == PieceSelect) { array[0] = i; array[1] = j; }

                }

            }
            return array;
        }

        //return the index of the selected board address
        public int[] indexOfAddress(string AddressSelect)
        {
            int[] array = new int[2];
            for (int i = 0; i <= 7; i++)
            {

                for (int j = 0; j <= 7; j++)
                {


                    if (TileAddresses[i, j] == AddressSelect.ToUpper()) { array[0] = i; array[1] = j; }

                }

            }
            return array;
        }

        public void initialize()
        {

            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    TileAddresses[i, j] = Columns[j] + Rows[i]; TileNames.Add(TileAddresses[i, j]);

                }
            }
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (i == 0) { BoardLayout[i, j] = Player1pieces[j]; pieceslist.Add(BoardLayout[i, j]); }

                    else if (i == 7) { BoardLayout[i, j] = Player2pieces[j]; pieceslist.Add(BoardLayout[i, j]); }

                    else if (i == 6) { BoardLayout[i, j] = $"P{j + 1}"; pieceslist.Add(BoardLayout[i, j]); }

                    else if (i == 1) { BoardLayout[i, j] = $"p{j + 1}"; pieceslist.Add(BoardLayout[i, j]); }

                    else { BoardLayout[i, j] = "  "; }


                }
            }

            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++)
                {
                    BoardState.Add(TileAddresses[i, j], BoardLayout[i, j]);
                    if (BoardLayout[i, j] != "  " && BoardLayout[i, j].ToUpper() == BoardLayout[i, j])
                    {

                        pieces.Add(new piece()
                        {
                            address = TileAddresses[i, j],

                            piecetype = BoardLayout[i, j],
                            player = 1



                        });
                    }
                    else if (BoardLayout[i, j] != "  ")
                    {
                        pieces.Add(new piece()
                        {
                            address = TileAddresses[i, j],

                            piecetype = BoardLayout[i, j],

                            player = 2


                        });




                    }


                }



            }






        }









    }




























}



