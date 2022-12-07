namespace ChessServerApp.Data
{
    public static class PieceMap
    {

        public static string Pieces(string piece)
        {

            if (piece.Contains('p')|| piece.Contains('P'))
            {

                return "\u2659";


            }

            if (piece.Contains('q') || piece.Contains('Q'))
            {

                return "\u2655";


            }
            if (piece.Contains('r') || piece.Contains('R'))
            {

                return "\u2656";


            }
            if (piece.Contains('K') || piece.Contains('k'))
            {

                return "\u2654";


            }
            if (piece.Contains('B') || piece.Contains('b'))
            {

                return "\u2657";


            }
            if (piece.Contains('n') || piece.Contains('N'))
            {

                return "\u2658";


            }
            else return piece; 















        }






    }
}
