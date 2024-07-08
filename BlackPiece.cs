using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 命名空間 Gomoku 中
namespace Gomoku
{
    // 定義了一個內部類 BlackPiece，繼承自 Piece 類
    internal class BlackPiece: Piece
    {
        // BlackPiece 類的建構函數，接收兩個整數參數 x 和 y
        public BlackPiece(int x, int y) : base(x, y)
        {
            // 設置 BlackPiece 物件的圖像為黑色棋子的圖像
            this.Image = Properties.Resources.black;
        }

        // 覆寫基類 Piece 的 GetPieceType 方法
        public override PieceType GetPieceType()
        {
            // 返回這個棋子的類型為黑色
            return PieceType.Black;
        }
    }
}