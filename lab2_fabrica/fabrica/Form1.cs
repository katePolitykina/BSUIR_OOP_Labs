using System;
using System.Drawing;
using System.Windows.Forms;

namespace fabrica
{
    public partial class Form1 : Form
    {
        private Factory factory;
        private Coord[] objArr;
        private bool clicked = false;
        private int clickIndx;
        private Graphics g;
        private int size = 0;
        private int objArrSize = 10;
        private int line1 = 140;
        private int line2 = 320;
        public Form1()
        {

            InitializeComponent();
            objArr = new Coord[objArrSize];
            g = pbMain.CreateGraphics();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DrawArr();

       }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbBox.SelectedIndex)
            {
                case 0:
                    factory = new MascaraFactory();
                    break;
                case 1:
                    factory = new MaskFactory();
                    break;
                case 2:
                    factory = new SerumFactory();
                    break;
                case 3:
                    factory = new FoundationFactory();
                    break;
            }
        }

        private void DrawLines()
        {
            Pen pen = new Pen(Color.Red, 4);

            // Рисуем горизонтальную линию
            g.DrawLine(pen, 0, line1, pbMain.Width, line1);
            g.DrawLine(pen, 0, line2, pbMain.Width, line2);

            // Освобождаем ресурсы
            pen.Dispose();
        }
        private void DrawArr()
        {
            g.FillRectangle(Brushes.White, new RectangleF(0, 0, pbMain.Width, pbMain.Height));
            DrawLines();
            for (int i = 0; i < size; i++)
            {
                g.DrawImage(image: objArr[i].self.Img(), new Rectangle(objArr[i].x, objArr[i].y, 60, 140));
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (factory != null && !string.IsNullOrEmpty(tbBrand.Text) && !string.IsNullOrEmpty(tbprice.Text ) && !string.IsNullOrEmpty(tbName.Text ))
            {
                double cost;
                if (double.TryParse(tbprice.Text.Replace('.', ','), out cost))
                {
                    objArr[size++] = new Coord(factory.Create(tbName.Text, tbBrand.Text, cost), 0, 0, cmbBox.SelectedIndex);    
                    if (size == objArrSize)
                    {
                        objArrSize *= 2;
                        var tempArr = new Coord[objArrSize];
                        objArr.CopyTo(tempArr, 0);
                        objArr = tempArr;
                    }
                    DrawArr();
                    
                }
                else
                {
                    MessageBox.Show("Заполните графу цена (разделитель - \",\")");
                }              
            }
            else
                MessageBox.Show("Заполните все поля");
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                objArr[clickIndx].x = e.X - Coord.width / 2;
                if(e.Y < line1)
                {
                    objArr[clickIndx].y = line1-Coord.height;
                } else
                {
                    objArr[clickIndx].y = line2 - Coord.height;
                }
                clicked = false;
                DrawArr();
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    if (e.X >= objArr[i].x && e.X <= (objArr[i].x + Coord.width))
                    {
                        if (e.Y >= objArr[i].y && e.Y <= (objArr[i].y + Coord.height))
                        {
                            
                            tbBrand.Text = objArr[i].self.getBrand();
                            tbName.Text = objArr[i].self.getName();
                            tbprice.Text = objArr[i].self.getPrice().ToString();
                            cmbBox.SelectedIndex = objArr[i].nameToShow;
                            clickIndx = i;
                            clicked = true;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clicked)
            {
                while (clickIndx<size-1)
                {
                    objArr[clickIndx] = objArr[++clickIndx];
                }
                objArr[size - 1] = null;
                size--;
                clicked = false;
            }
            DrawArr();
        }
    }

    
}
