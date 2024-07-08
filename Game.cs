using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    // 代表遊戲邏輯的類別
    class Game
    {
        // 初始化遊戲棋盤
        private Board board = new Board();

        // 初始化當前玩家為黑色
        private PieceType currentPlayer = PieceType.Black;

        // 初始化勝利者為None
        private PieceType winner = PieceType.None;

        // 取得勝利者的屬性
        public PieceType WINNER { get { return winner; } }

        // 檢查是否可以在指定座標放置棋子
        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }

        // 在指定座標放置棋子
        public Piece PlaceAPiece(int x, int y)
        {
            // 在棋盤上放置棋子
            Piece piece = board.PlaceAPiece(x, y, currentPlayer);

            // 如果放置了棋子
            if (piece != null)
            {
                // 檢查是否有勝利者
                checkWinner();

                // 切換玩家
                if (currentPlayer == PieceType.Black)
                {
                    currentPlayer = PieceType.White;
                }
                else
                {
                    currentPlayer = PieceType.Black;
                }
                return piece;
            }
            return null;
        }

        // 檢查是否有勝利者的方法
        private void checkWinner()
        {
            // 取得最後一個放置棋子的座標
            int centerX = board.LastPlacedNode.X;
            int centerY = board.LastPlacedNode.Y;

            // 在八個方向檢查連線
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    // 排除中心方向
                    if (xDir == 0 && yDir == 0)
                        continue;

                    // 計算相同顏色棋子的數量
                    int count = 1;
                    while (count < 5)
                    {
                        int targetX = centerX + count * xDir;
                        int targetY = centerY + count * yDir;

                        // 檢查該方向上的棋子顏色是否相同
                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                            targetY < 0 || targetY >= Board.NODE_COUNT ||
                            board.GetPieceType(targetX, targetY) != currentPlayer)
                            break;
                        count++;
                    }

                    // 如果有五顆相同顏色的棋子連線，設定勝利者
                    if (count == 5)
                    {
                        winner = currentPlayer;
                    }
                }
            }
        }
    }
}