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
        int chrnum;
        int time;
        
        //定数宣言
        const int TEKI_MAX = 10;
        const int SPEED_MAX = 11;
        const int SPEED_MIN = -10;
        //const int chrnum = TEKI_MAX;
             
        //ラベルの表示個数と移動変数
        Label[] chrs = new Label[TEKI_MAX];
        int[] iVX = new int[TEKI_MAX];
        int[] iVY = new int[TEKI_MAX];

        //rand変数
        private static Random rand = new Random();
        //ラベルの移動変数
        int iVelX = rand.Next(SPEED_MIN,SPEED_MAX);
        int iVelY = rand.Next(SPEED_MIN,SPEED_MAX);

        public Form1()
        {
            chrnum = TEKI_MAX;
            time = 0;

            InitializeComponent();
            /*コンストラクタ
             * Form1クラスが生成される時に実行する特別な変数
             */
            //ラベルの生成
            for (int i = 0; i < 10; i++)
            {
                //ラベルのステータス
                chrs[i] = new Label();
                chrs[i].AutoSize = true;//ミソ
                chrs[i].Text = "|電柱|◞౪◟◞≼●≽◟)";
                chrs[i].Left = rand.Next(ClientSize.Width);
                chrs[i].Top = rand.Next(ClientSize.Height);
                chrs[i].Font = new Font("メイリオ", 8);
                chrs[i].ForeColor = Color.FromArgb(150, 80, 00);
                Controls.Add(chrs[i]);//フォームに追加
                //移動変数
                iVX[i] = rand.Next(SPEED_MIN, SPEED_MAX);
                iVY[i] = rand.Next(SPEED_MIN, SPEED_MAX);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //time+キャラを全部消したら止める
            if (chrnum > 0)
            {
                time++;
                label3.Text = "Time:" + time;
            }
            //-------------------マウス追従--------------------------
            //2次元クラスPoint型の変数cposを宣言
            Point cpos;

            //cposにマウスのフォーム座標を取り出す
            cpos = this.PointToClient(MousePosition);

            //フォームにマウス座標を表示
            Text = "" + cpos.X + "," + cpos.Y;

            //マウス座標にラベルをくっつける。(マウスの座標をlabelに代入）
            label1.Left = cpos.X;
            label1.Top = cpos.Y;

            //------------------ラベル2の移動-------------------------
            //ラベル2の移動値
            int vx = iVelX;
            int vy = iVelY;
            // 移動値をラベルの座標に加算
            label2.Left += iVelX;
            label2.Top += iVelY;

            if ((label2.Left < 0) || (label2.Left + label2.Width > ClientSize.Width))
            {
                //左右反転
                label2.Left -= vx;
                iVelX = -vx;
            }
            if ((label2.Top < 0) || (label2.Top + label2.Height > ClientSize.Height))
            {
                //上下反転
                label2.Top -= vy;
                iVelY = -vy;
            }
            //------------------for制作のラベルの移動-------------------------
            
            //ラベルの移動
            for (int i = 0; i < TEKI_MAX; i++)
            {
                //キャラが有効か
                if (chrs[i].Visible == false) 
                {
                    continue;
                }

                chrs[i].Left += iVX[i];
                chrs[i].Top += iVY[i];

                //ラベルの移動
                if ((chrs[i].Left < 0) || (chrs[i].Left + chrs[i].Width > ClientSize.Width))
                {
                    //左右反転
                    chrs[i].Left -= iVX[i];
                    iVX[i] = -iVX[i];
                }
                
                if ((chrs[i].Top < 0) || (chrs[i].Top + chrs[i].Height > ClientSize.Height))
                {
                    //上下反転）
                    chrs[i].Top -= iVY[i];
                    iVY[i] = -iVY[i];
                }
                //
                if ((cpos.X >= chrs[i].Left)
                    && (cpos.X < chrs[i].Left + chrs[i].Width)
                    && (cpos.Y >= chrs[i].Top)
                    && (cpos.Y < chrs[i].Top + chrs[i].Height))
                {
                    chrs[i].Visible = false;  //消える
                    //クリア表示
                    chrnum--;
                    if (chrnum == 0) 
                    {
                        MessageBox.Show("クリア");
                    }
                }
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
        

        //------------------------ボタン練習（game関係なし）-------------------------------------
        //配列練習ボタン
        private void button1_Click(object sender, EventArgs e)
        {
            //int型の配列変数を３つ定義
            int[] iar = new int [4];
            //[]の中に添え字を入れることで別の場所にアクセスできる
            iar[0] = 0;
            iar[1] = 1;
            iar[2] = 2;
            MessageBox.Show(iar[0].ToString());
            MessageBox.Show(iar[1].ToString());
            MessageBox.Show(iar[2].ToString());
            //添え字には変数も使うことができる
            int i = 0;
            MessageBox.Show(iar[i].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            for (i = 0; i < 10; i++)
            {
                if (i < 3)
                {
                    continue;
                }
                else
                if (i >= 6)
                {
                    break;
                }
                MessageBox.Show(i.ToString());
            }
            MessageBox.Show("i =" + i);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //ラベル２再起動ボタン
       private void button3_Click(object sender, EventArgs e)
        {
             iVelX = rand.Next(SPEED_MIN, SPEED_MAX);
             iVelY = rand.Next(SPEED_MIN, SPEED_MAX);
        }
        
    }
}
