using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics.Eventing.Reader;

namespace Gomoku
{
    // 代表五子棋遊戲棋盤的類別
    class Board
    {
        // 棋盤節點的常數
        public static readonly int NODE_COUNT = 9;

        // 表示找不到匹配節點的常數
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);

        // 棋盤版面的常數
        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTANCE = 75;
        private Piece[,] pieces = new Piece[9, 9];

        // 紀錄最後放置的節點
        private Point lastPlacedNode = NO_MATCH_NODE;
        public Point LastPlacedNode { get { return lastPlacedNode; } }

        // 取得特定節點上棋子類型的方法
        public PieceType GetPieceType(int nodeIdX, int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
                return PieceType.None;
            else
                return pieces[nodeIdX, nodeIdY].GetPieceType();
        }

        // 檢查是否可以在特定位置放置棋子的方法
        public bool CanBePlaced(int x, int y)
        {
            // 找出最接近的節點（交叉點）
            Point nodeId = findTheClosestNode(x, y);

            // 如果找不到匹配的節點，則返回false
            if (nodeId == NO_MATCH_NODE)
                return false;

            // 檢查節點上是否已經有棋子
            if (pieces[nodeId.X, nodeId.Y] != null)
                return false;
            return true;
        }

        // 放置棋子在特定位置的方法
        public Piece PlaceAPiece(int x, int y, PieceType type)
        {
            // 找出最接近的節點（交叉點）
            Point nodeId = findTheClosestNode(x, y);

            // 如果找不到匹配的節點，則返回null
            if (nodeId == NO_MATCH_NODE)
                return null;

            // 檢查節點上是否已經有棋子，如果有則返回null
            if (pieces[nodeId.X, nodeId.Y] != null)
                return null;

            // 根據類型生成對應的棋子
            Point fromPosition = convertTOFormPosition(nodeId);
            if (type == PieceType.Black)
                pieces[nodeId.X, nodeId.Y] = new BlackPiece(fromPosition.X, fromPosition.Y);
            else if (type == PieceType.White)
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(fromPosition.X, fromPosition.Y);

            // 紀錄最後放置的節點
            lastPlacedNode = nodeId;
            return pieces[nodeId.X, nodeId.Y];
        }

        // 將節點位置轉換為視窗位置的方法
        private Point convertTOFormPosition(Point nodeId)
        {
            Point formPosition = new Point();
            formPosition.X = nodeId.X * NODE_DISTANCE + OFFSET;
            formPosition.Y = nodeId.Y * NODE_DISTANCE + OFFSET;
            return formPosition;
        }

        // 找出最接近特定點的節點的方法
        private Point findTheClosestNode(int x, int y)
        {
            // 在X軸上找到最接近的節點索引
            int nodeIdX = findTheClosestNodeIndex(x);
            if (nodeIdX == -1 || nodeIdX >= NODE_COUNT)
            {
                return NO_MATCH_NODE;
            }

            // 在Y軸上找到最接近的節點索引
            int nodeIdY = findTheClosestNodeIndex(y);
            if (nodeIdY == -1 || nodeIdY >= NODE_COUNT)
            {
                return NO_MATCH_NODE;
            }

            // 將最接近的節點作為Point返回
            return new Point(nodeIdX, nodeIdY);
        }

        // 這個方法根據給定的位置找到棋盤上最接近的節點的索引
        private int findTheClosestNodeIndex(int pos)
        {
            // 檢查位置是否小於偏移值減去節點半徑
            if (pos < OFFSET - NODE_RADIUS)
            {
                // 如果是，表示位置太小無法找到最接近的節點，返回-1
                return -1;
            }

            // 根據棋盤偏移調整位置
            pos -= OFFSET;

            // 計算商和餘數以確定最接近的節點
            int quotient = pos / NODE_DISTANCE;
            int remainder = pos % NODE_DISTANCE;

            // 檢查位置是否足夠接近節點，並返回節點索引
            if (remainder <= NODE_RADIUS)
            {
                return quotient;
            }
            else if (remainder > NODE_DISTANCE - NODE_RADIUS)
            {
                return quotient + 1;
            }
            else
            {
                // 範圍內找不到節點
                return -1;
            }
        }
    }
}