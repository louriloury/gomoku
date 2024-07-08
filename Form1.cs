// �R�W�Ŷ�Gomoku
namespace Gomoku
{
    // Form1���O�A�~�Ӧ�Form
    public partial class Form1 : Form
    {
        // �إߤ@��Game���
        private Game _game = new Game();

        // Form1�غc�禡
        public Form1()
        {
            // ��l�Ƥ���
            InitializeComponent();
        }

        // �ƹ��I���ƥ�B�z�禡
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // �b�C������m�@�ӴѤl
            Piece piece = _game.PlaceAPiece(e.X, e.Y);
            
            // �p�G���\��m�Ѥl
            if (piece != null)
            {
                // �N�Ѥl�[�J�������
                this.Controls.Add(piece);

                // �ˬd�O�_���ӧQ��
                if (_game.WINNER != PieceType.None)
                {
                    // ��ܳӧQ�̰T��
                    MessageBox.Show("Winner is " + _game.WINNER);
                }
            }
        }

        // �ƹ����ʨƥ�B�z�禡
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // �ھڹC���W�h�]�w���
            this.Cursor = _game.CanBePlaced(e.X, e.Y) ? Cursors.Hand : Cursors.Default;
        }
    }
}