using System;
using System.Reflection;
using System.Windows.Forms;

namespace fabrica
{
    public partial class EditForm : Form
    {
        public Product objectToEdit;
        public EditForm(Product objectToEdit)
        {
            InitializeComponent();

            this.objectToEdit = objectToEdit;
            // Добавляем текстовые поля для каждого поля объекта
            int topMargin = 10;
            int leftMargin = 10;
            PropertyInfo[] properties = objectToEdit.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {

                Label label = new Label();
                label.Text = property.Name;
                label.Top = topMargin;
                label.Left = leftMargin;

                TextBox textBox = new TextBox();
                textBox.Text = property.GetValue(objectToEdit).ToString();
                textBox.Top = topMargin + 20;
                textBox.Left = leftMargin;

                Controls.Add(label);
                Controls.Add(textBox);

                topMargin += 50;
            }

            // Добавляем кнопку сохранения
            Button saveButton = new Button();
            saveButton.Text = "Save";
            saveButton.Top = topMargin;
            saveButton.Click += SaveButton_Click;
            Controls.Add(saveButton);

            // Располагаем кнопку по центру
            saveButton.Left = (ClientSize.Width - saveButton.Width) / 2;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            // Сохраняем изменения в объект
            //  foreach (Control control in Controls)
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is TextBox textBox)
                {
                    string propertyName = textBox.Parent.Controls[i-1].Text;
                    PropertyInfo property = objectToEdit.GetType().GetProperty(propertyName);
                    if (property != null)
                    {
                        try
                        {
                            property.SetValue(objectToEdit, Convert.ChangeType(textBox.Text, property.PropertyType));
                        }
                        catch
                        {
                            MessageBox.Show("Неверный тип введенного значения у " + propertyName +
                                ". \n Это поле не будет изменено." );
                        }
                    }
                }
            }

            // Закрываем окно
            Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // EditForm
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(910, 538);
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }
    }
}
