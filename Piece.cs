// 引用必要的命名空間
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

// 命名空間：Gomoku
namespace Gomoku
{
    // 抽象類：Piece，繼承自PictureBox
    abstract class Piece : PictureBox
    {
        // 圖片寬度常數
        private static readonly int IMAGE_WIDTH = 50;

        // 構造函數，初始化棋子的大小、背景色和位置
        public Piece(int x, int y)
        {
            this.Size = new Size(50, 50); // 設置大小為50x50
            this.BackColor = Color.Transparent; // 設置背景色為透明
            this.Location = new Point(x - IMAGE_WIDTH / 2, y - IMAGE_WIDTH / 2); // 設置位置為(x-圖片寬度/2, y-圖片寬度/2)
        }

        // 抽象方法：獲取棋子類型，需要在子類中實現
        public abstract PieceType GetPieceType();
    }
}