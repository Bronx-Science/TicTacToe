using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{/* 
int[] gameBoard = new int[9];
int player = 0;
bool win = false;

public int reset()
{
  gameBoard = new int[9];
  int player = 0;
  bool win = false;
}


public int GetBestMove(int[] board, int player)
{
    int bestMove = -1;
    int bestValue = player == 1 ? Int32.MinValue : Int32.MaxValue;

    int[] availableMoves = moves(board);

    foreach (int move in availableMoves)
    {
        int[] newBoard = (int[])board.Clone();
        newBoard[Array.IndexOf(newBoard, 0)] = player;

        int value = ABPrune(newBoard, player == 1 ? 2 : 1, Int32.MinValue, Int32.MaxValue);

        if ((player == 1 && value > bestValue) || (player == 2 && value < bestValue))
        {
            bestMove = move;
            bestValue = value;
        }
    }

    return bestMove;
}
	

public int ABPrune(int[] board, int player, int alpha, int beta)
{
    int result = eval(board);
    if (result != 0)
        return result;

    int[] availableMoves = moves(board);
    if (availableMoves.Length == 0)
        return 0;

    if (player == 1)
    {
        int bestValue = Int32.MinValue;
        foreach (int move in availableMoves)
        {
            int[] newBoard = (int[])board.Clone();
            newBoard[Array.IndexOf(newBoard, 0)] = player;

            int value = ABPrune(newBoard, 2, alpha, beta);
            bestValue = Math.Max(bestValue, value);
            alpha = Math.Max(alpha, bestValue);
            if (beta <= alpha)
                break;
        }
        return bestValue;
    }
    else
    {
        int bestValue = Int32.MaxValue;
        foreach (int move in availableMoves)
        {
            int[] newBoard = (int[])board.Clone();
            newBoard[Array.IndexOf(newBoard, 0)] = player;

            int value = ABPrune(newBoard, 1, alpha, beta);
            bestValue = Math.Min(bestValue, value);
            beta = Math.Min(beta, bestValue);
            if (beta <= alpha)
                break;
        }
        return bestValue;
    }
}





    public int[] moves(int[] board){
        List<int> moves = new List<int>();
        for (int i = 0; i < board.Length; i++){
            if (board[i] !=0){
                moves.Add(board[i]);
            }
        }
        return moves.ToArray();


    }
    public int eval(int[] board){
        for (int i = 0; i <3; i++){
            if (board[i*3] != 0 && board[i*3] == board[i*3+1] && board[i*3+1] == board[i*3+2]){
                return board[i*3];
            }
            if (board[i] != 0 && board[i] == board[i+3] && board[i] == board[i+7]){
                return board[i];
            }
        }
        if(board[0] != 0 && board[0] == board[4] && board[0] == board[8]){
            return board[0];
        }
        if (board[2] != 0 && board[2] == board[4] && board[4] == board[6]){
            return board[2];
        }
        return 0;
    }
*/
}
