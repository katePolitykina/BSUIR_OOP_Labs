using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using CosmeticsBase;
using fabrica;
using Signature;


namespace cosmetics
{
    public partial class Form1 : Form
    {
        private Factory factory;
        private List<Factory> factories;
        private Coord[] objArr;
        private bool clicked = false;
        private int clickIndx;
        private Graphics g;
        private int size = 0;
        private int line1 = 140;
        private int line2 = 320;
        private int picHeight = 140;
        private int picWidth = 60;
        public Form1()
        {

            InitializeComponent();
            objArr = new Coord[10];
            g = pbMain.CreateGraphics();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DrawArr();
            factories = new List<Factory>();
            factories.Add(new MascaraFactory());
            factories.Add(new MaskFactory());
            factories.Add(new SerumFactory());
            factories.Add(new FoundationFactory());
            foreach (Factory fact in factories)
            {
                cmbBox.Items.Add(fact.Name());
            }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            factory = factories[cmbBox.SelectedIndex];
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
                    if (size == objArr.Length)
                    {
                        int objArrSize = objArr.Length*2+1;
                        var tempArr = new Coord[objArrSize];
                        objArr.CopyTo(tempArr, 0);
                        objArr = tempArr;
                    }
                    objArr[size++] = new Coord(factory.Create(tbName.Text, tbBrand.Text, cost), 0, 0, cmbBox.SelectedIndex);
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
                objArr[clickIndx].x = e.X - picWidth / 2;
                if(e.Y < line1)
                {
                    objArr[clickIndx].y = line1-picHeight;
                } else
                {
                    objArr[clickIndx].y = line2 - picHeight;
                }
                clicked = false;
                DrawArr();
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    if (e.X >= objArr[i].x && e.X <= (objArr[i].x + picWidth))
                    {
                        if (e.Y >= objArr[i].y && e.Y <= (objArr[i].y + picHeight))
                        {
                            tbInf.Text = objArr[i].self.getinfo();
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

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            Coord[] data = new Coord[size];
            Array.Copy(objArr, data, size);
            var knownTypes = new List<Type>();
            foreach (var fact in factories)
            {
                knownTypes.Add(fact.CreatedClassName());
            }
            if (rbBinary.Checked)
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Coord[]),knownTypes);
                using (FileStream stream = new FileStream("suda.bin", FileMode.Create))
                {
                    serializer.WriteObject(stream, data);
                }
            }
            else
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Coord[]),knownTypes);
                using (FileStream stream = new FileStream("suda.json", FileMode.Create))
                {
                    serializer.WriteObject(stream, data);
                }
            }

        }

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            var knownTypes = new List<Type>();
            foreach (var fact in factories)
            {
                knownTypes.Add(fact.CreatedClassName());
            }
            if (rbBinary.Checked)
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Coord[]), knownTypes);
                try
                {
                    using(FileStream stream = new FileStream("suda.bin", FileMode.OpenOrCreate))
                    {
                        objArr = (Coord[])serializer.ReadObject(stream);
                    }      
                    size = objArr.Length;
                    DrawArr();
                }catch
                {
                    MessageBox.Show("Файл для с данными для десериализации не существует или поврежден. Проверьте подключенные плагины.\n");
                }
            }
            else
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Coord[]), knownTypes);

                try
                {

                    using (FileStream stream = new FileStream("suda.json", FileMode.OpenOrCreate))
                    {
                        objArr = (Coord[])serializer.ReadObject(stream);
                    }
                    size = objArr.Length;
                    DrawArr();
                }
                catch
                {
                    MessageBox.Show("Файл для с данными для десериализации не существует или поврежден. Проверьте подключенные плагины.\n");
                }
                
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (clicked)
            {
                using (var editForm = new EditForm(objArr[clickIndx].self))
                {
                    editForm.ShowDialog();
                    //          objArr[clickIndx].self = editForm.objectToEdit;
                }

                tbInf.Text = objArr[clickIndx].self.getinfo();
                clicked = false;
            }
            DrawArr();
        }

        private void pluginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Динамическая библиотека (*.dll)|*.dll"
            };
            /*

            string myDllPath = "\\\\Mac\\Home\\Documents\\oop\\lab2_fabrica\\BrushPlugin\\bin\\Debug\\BrushPlugin.dll";
            byte[] dll = File.ReadAllBytes(myDllPath);
            if (Signature.Signature.Sign(dll, "\\\\Mac\\Home\\Documents\\oop\\lab2_fabrica\\SignedBrushPlugin"))
                Console.WriteLine("Чекай все успешно");*/
            openFileDialog.ShowDialog();
            byte [] newDll = File.ReadAllBytes(openFileDialog.FileName);
            if(Signature.Signature.Verify(newDll, Path.GetDirectoryName(openFileDialog.FileName)))
            {
                List<Factory> fact = PluginLoader.LoadPlugin(openFileDialog.FileName);
                if (fact != null)
                {
                    foreach (Factory factory in fact)
                    {
                        factories.Add(factory);
                        cmbBox.Items.Add(factory.Name());

                    }
                }
            }else{
                MessageBox.Show("Unable to verify signature");
            }
            
        }
    }

    
}
