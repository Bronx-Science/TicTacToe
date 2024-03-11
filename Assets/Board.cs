using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Board : MonoBehaviour
{
//Player 1 is x
//Player 2 is 0
[SerializeField]
Button b0,b1,b2,b3,b4,b5,b6,b7,b8;
[SerializeField]
Sprite clean, p1, p2;
static Button[] buttons;
int[] gameBoard = new int[9] {0,0,0,0,0,0,0,0,0};
int[] cleanBoard = new int[9] {0,0,0,0,0,0,0,0,0};
int player = 1;
bool winner = false;
List<int> p1Position = new List<int>();
List<int> p2Position = new List<int>();

void Start()
{
    buttons = new Button[]{b0, b1, b2, b3, b4, b5, b6, b7, b8};
}

public void pick(int position)
{
    int state;
  if(!p1Position.Contains(position) && !p2Position.Contains(position) && !winner)
    {
        p1Position.Add(position);
        gameBoard[position] = -1;
        setImg(position, 1);
        player = 2;

        state = eval(gameBoard);

        if(moves(gameBoard).Length == 0){
        winner = true;
        return;
        }

        if(state != 0)
        {
         winner = true;
        win(state);
        return;
        }

        
        position = GetBestMove(gameBoard, 1);
        p2Position.Add(position);
        gameBoard[position] = 1;
        setImg(position, 2);
        player = 1;

        state = eval(gameBoard);

        if(moves(gameBoard).Length == 0){
        winner = true;
        return;
        }

        if(state != 0)
        {
        winner = true;
        win(state);
        }
    }


}

public void setImg(int position, int player)
{
    Image img = buttons[position].GetComponent<Image>();
    if(player == 1)
    img.sprite = p1;
    else
    img.sprite = p2;
}
public void win(int winner)
{
;
}
public void reset()
{
  gameBoard = (int[])cleanBoard.Clone();
  int player = 1;
  winner = false;
  p1Position.Clear();
  p2Position.Clear();
  foreach (Button button in buttons)
  {
    Image img = button.GetComponent<Image>();
    img.sprite = clean;
  }
}


public int GetBestMove(int[] board, int player)
{
    int bestMove = moves(board)[0];
    int bestValue = player == 1 ? Int32.MinValue : Int32.MaxValue;

    int[] availableMoves = moves(board);

    foreach (int move in availableMoves)
    {
        int[] newBoard = (int[])board.Clone();
        newBoard[move] = player;

        int value = ABPrune(newBoard, -player, Int32.MinValue, Int32.MaxValue) * player;

        if (value > bestValue)
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
            newBoard[move] = player;

            int value = ABPrune(newBoard, -1, alpha, beta);
            bestValue = Math.Max(bestValue, value);
            //alpha = Math.Max(alpha, bestValue);
            //if (beta <= alpha)
            if(bestValue > beta)
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
            newBoard[move] = player;

            int value = ABPrune(newBoard, 1, alpha, beta);
            bestValue = Math.Min(bestValue, value);
            //beta = Math.Min(beta, bestValue);
            //if (beta <= alpha)
            if(bestValue < alpha)
                break;
        }
        return bestValue;
    }
}





    public int[] moves(int[] board){
        List<int> moves = new List<int>();
        for (int i = 0; i < 9; i++){
            if (board[i] == 0){
                moves.Add(i);
            }
        }
        return moves.ToArray();


    }
    public int eval(int[] board){
        for (int i = 0; i <3; i++){
            if (board[i*3] != 0 && board[i*3] == board[i*3+1] && board[i*3+1] == board[i*3+2]){
                return board[i*3];
            }
            if (board[i] != 0 && board[i] == board[i+3] && board[i] == board[i+6]){
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

}
