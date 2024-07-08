// 命名空間Gomoku
namespace Gomoku
{
    // Form1類別，繼承自Form
    public partial class Form1 : Form
    {
        // 建立一個Game實例
        private Game _game = new Game();

        // Form1建構函式
        public Form1()
        {
            // 初始化元件
            InitializeComponent();
        }

        // 滑鼠點擊事件處理函式
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // 在遊戲中放置一個棋子
            Piece piece = _game.PlaceAPiece(e.X, e.Y);
            
            // 如果成功放置棋子
            if (piece != null)
            {
                // 將棋子加入視窗控制項
                this.Controls.Add(piece);

                // 檢查是否有勝利者
                if (_game.WINNER != PieceType.None)
                {
                    // 顯示勝利者訊息
                    MessageBox.Show("Winner is " + _game.WINNER);
                }
            }
        }

        // 滑鼠移動事件處理函式
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // 根據遊戲規則設定游標
            this.Cursor = _game.CanBePlaced(e.X, e.Y) ? Cursors.Hand : Cursors.Default;
        }
    }
}