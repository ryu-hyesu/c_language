using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Label[] hmm;
        public Label[] title;
        //public Label[] hmm_text_x;
        public int[] hmm_text_y= new int[16];
        public int hmm_text_x;

        public Label[] page_1;
        public int[] page1_x = new int[24];
        public int[] page1_y = new int[24];
        public Panel[] panel_1;

        public Form1()
        {
            InitializeComponent();

            
            Label[] page1 = new Label[] { label65,
                label66, label67, label68, label69 ,label70, label71,
                label72, label73, label74,label75,
                label76, label77,label78, label79,label80, label81,label82,
                label83, label84, label85,
                label86,label87,
            label88, label89};
            page_1 = page1;
            for (int j = 0; j < 24; j++)
            {
                page1_x[j] = page1[j].Location.X;
                page1_y[j] = page1[j].Location.Y;
                page1[j].Font = new Font("Calibri", 11);
                page_1[j].Font = new Font("Calibri", 11);
            }

            //label1.Anchor = AnchorStyles.None;
            //MessageBox.Show(Label + 1);
            double lbd = 677.9;
            double fy = 168.3;
            Label[] hmm_t = new Label[] {label6, label7 , label8 , label9 , label10 , label11 , label12 , label13, label14 , label15 , label16 , label17 , label18 , label19 , label20 , label37 };
            hmm = hmm_t;
            Label[] title_t = new Label[] { label1, label2, label3, label4, label5 };
            title = title_t;
            Label[] fd = new Label[] { label21, label22, label23, label24, label25, label26, label27, label28, label29, label30,label31, label32, label33, label34, label35, label36 };

            int[] hmm_text_y_t = new int[16];
            hmm_text_y = hmm_text_y_t;
            hmm_text_x = label6.Location.X;

            int[] h = {100 ,125 ,150 ,175 ,200 ,225 ,250 ,300 ,350 ,400 ,450 ,500 ,600 ,700 ,800 ,1000};
            
            for (int i = 0; i < 16; i++)
            {
                hmm[i].Text = h[i].ToString();
                hmm[i].Font = new Font("Calibri", 15);
                fd[i].Text = Math.Round(((double)h[i]*fy/lbd),2).ToString();
                fd[i].Font = new Font("Calibri", 15);

                hmm_text_y_t[i] = hmm[i].Location.Y;
            }
            for (int i=0; i<5; i++)
                title[i].Font = new Font("Calibri", 15);


            using (Graphics G = CreateGraphics())
            {
                fonts.Add(new DrawFont(G, new FontFamily("Calibri"), 15, FontStyle.Regular));
                fonts.Add(new DrawFont(G, new FontFamily("Calibri"), 12, FontStyle.Regular));
                fonts.Add(new DrawFont(G, new FontFamily("Calibri"), 15, FontStyle.Regular));
            }


        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        
        }

  

        List<DrawFont> fonts = new List<DrawFont>();

        class DrawFont
        {
            public Font Font { get; set; }
            public float baseLine { get; set; }
            public DrawFont(Graphics G, FontFamily FF, float height, FontStyle style)
            {
                Font = new Font(FF, height, style);
                float lineSpace = FF.GetLineSpacing(Font.Style);
                float ascent = FF.GetCellAscent(Font.Style);
                baseLine = Font.GetHeight(G) * ascent / lineSpace;
            }
        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {

            Graphics graphics = e.Graphics;
            //Graphics graphics1 = Panel2.CreateGraphics();

            Pen pen = new Pen(Color.Black, (float)2.4);
            Pen pen_middle = new Pen(Color.Black, (float)2);
            Font ft = new Font("Calibri", 12);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            int start_X1 = Panel1.Location.X;
            int start_Y1 = Panel1.Location.Y;
            int start_X2 = Panel2.Location.X;
            int start_Y2 = Panel2.Location.Y;
            int panel1_width = Panel1.Width;
            int panel1_hieght = Panel1.Height;
            int panel2_width = Panel2.Width;
            int panel2_hieght = Panel2.Height;
            //MessageBox.Show(start_X1.ToString());

            int row0_heights = Panel1.GetRowHeights()[0];
            int row1_heights = Panel1.GetRowHeights()[1];
            int column0_width = Panel1.GetColumnWidths()[0];
            int column1_width = Panel1.GetColumnWidths()[1];
            graphics.DrawLine(pen, start_X1, start_Y1, start_X1 + panel1_width, start_Y1);
            graphics.DrawLine(pen, start_X1, start_Y1 + panel1_hieght, start_X1 + panel1_width, start_Y1 + panel1_hieght);

            graphics.DrawLine(pen_middle, start_X1 + column0_width, start_Y1 + row0_heights, start_X1 + panel1_width, start_Y1 + row0_heights);
            graphics.DrawLine(pen, start_X1, start_Y1 + panel1_hieght+ panel2_hieght, start_X1 + panel1_width, start_Y1 + panel1_hieght+ panel2_hieght);
            graphics.DrawLine(pen_middle, start_X1 + column0_width + column1_width, start_Y1, start_X1 + column0_width + column1_width, start_Y1 + panel1_hieght + panel2_hieght);
            graphics.DrawLine(pen_middle, start_X1 + column0_width, start_Y1 + row0_heights, start_X1 + column0_width, start_Y1 + row0_heights * 2);
            //graphics.DrawString("bd", ft, drawBrush, column0_width + start_X1+17, start_Y1+ row0_heights + 7);

            int sample = start_X1 + column1_width;
            int i = 0;
            float x = column0_width + start_X1 + 13;
            foreach (DrawFont font in fonts)
            {
                if (i == 0)
                {
                    e.Graphics.DrawString("l", font.Font, Brushes.Black, x, start_Y1 + row0_heights +25 - font.baseLine);
                    x += 6;
                    i = 1;
                }
                else if (i==1)
                {
                    e.Graphics.DrawString("bd", font.Font, Brushes.Black, x, start_Y1 + row0_heights + 27 - font.baseLine);
                    i = 2;
                    x += 23;
                }
                else
                    e.Graphics.DrawString("[mm]", font.Font, Brushes.Black, x, start_Y1 + row0_heights + 25 - font.baseLine);

            }

            


           
            StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
         

            format1.Alignment = StringAlignment.Center;



            for (int j = 0; j < 16; j++)
                e.Graphics.DrawString(hmm[j].Text, new Font("Calibri", 15), Brushes.Black, Panel2.Location.X+hmm_text_x,Panel2.Location.Y+hmm_text_y[j], format1);


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            float x = 5f;
            foreach (DrawFont font in fonts)
            {
                e.Graphics.DrawString("Fy", font.Font, Brushes.DarkSlateBlue, x, 80 - font.baseLine);
                x += 50;
            }
            e.Graphics.DrawLine(Pens.LightSlateGray, 0, 80, 999, 80);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            ToolStripButton b = new ToolStripButton();
            //b.Image = Properties.Resources.print2;
            b.DisplayStyle = ToolStripItemDisplayStyle.Image;
            b.Click += printPreview_PrintClick;
            ((ToolStrip)(printPreviewDialog1.Controls[1])).Items.RemoveAt(0);
            ((ToolStrip)(printPreviewDialog1.Controls[1])).Items.Insert(0, b);
            this.printPreviewDialog1.ShowDialog();
        }

        private void printPreview_PrintClick(object sender, EventArgs e)
        {
            try
            {
                printDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ToString());
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 595, 842);
            for (int i=0; i<24; i++)
                e.Graphics.DrawString(page_1[i].Text, new Font("Calibri", 11), Brushes.Black, page1_x[i], page1_y[i]);

        }

        private void printPreviewControl3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
