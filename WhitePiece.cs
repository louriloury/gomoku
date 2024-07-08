// 引入必要的命名空間
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 將類別放在Gomoku命名空間下
namespace Gomoku
{
    // 定義一個內部類別WhitePiece，繼承自Piece類別
    internal class WhitePiece: Piece
    {
        // WhitePiece的建構子，接收x和y座標參數，調用父類別的建構子，設置圖片為白色
        public WhitePiece(int x, int y) : base(x, y)
        {
            this.Image = Properties.Resources.white;
        }

        // 覆寫基類的GetPieceType方法，返回棋子類型為白色
        public override PieceType GetPieceType()
        {
            return PieceType.White;
        }
    }
}