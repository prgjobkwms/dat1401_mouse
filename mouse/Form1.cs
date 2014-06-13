using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mouse
{
    public partial class Form1 : Form
    {
        //ラベルの移動変数
        int iVelX = rand.Next(-10,11);
        int iVelY = rand.Next(-10,11);
        //rand変数
        private static Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //-------------------マウス追従--------------------------
            //2次元クラスPoint型（かた）の変数（へんすう）cposを宣言（せんげん）
            Point cpos;

            //cposにマウスのフォーム座標（ざひょう）を取り出す（とりだす）
            cpos = this.PointToClient(MousePosition);

            //フォームにマウス座標（ざひょう）を表示（ひょうじ）
            Text = "" + cpos.X + "," + cpos.Y;

            //マウス座標（ざひょう）にラベルをくっつける。(マウスの座標（ざひょう）をlabelに代入（だいにゅう）)
            label1.Left = cpos.X;
            label1.Top = cpos.Y;

            //------------------ラベル2の移動-------------------------
            //ラベル2の移動（いどう）
            int vx = iVelX;
            int vy = iVelY;
            // ラベルの座標（ざひょう）に加算（かさん）
            label2.Left += vx;
            label2.Top += vy;

            if ((label2.Left < 0) || (label2.Left + label2.Width > ClientSize.Width))
            {
                //左右反転（さゆうはんてん）
                label2.Left -= vx;
                iVelX = -vx;
            }
            else
            if ((label2.Top < 0) || (label2.Top + label2.Height > ClientSize.Height))
            {
                //上下反転（じょうげはんてん）
                label2.Top -= vy;
                iVelY = -vy;
            }

            //-------------------ラベル1とラベル2の衝突判定------------------------
            //マウスカーソルと重なったら
            //タイマー停止or表情変更
            //cpos.x : マウスｘ座標
            //cpos.y : マウスy座標

            if(    (cpos.X >= label2.Left)
                && (cpos.X < label2.Left + label2.Width)
                && (cpos.Y >= label2.Top)
                && (cpos.Y < label2.Top + label2.Height))
            {
                iVelX = 0;
                iVelY = 0;
            }

        }


        //テキストbox2のプログラム変更なしでよい
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
