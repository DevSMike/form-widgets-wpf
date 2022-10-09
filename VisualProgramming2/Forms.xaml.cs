using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VisualProgramming2
{
    /// <summary>
    /// Логика взаимодействия для виджета Анкеты
    /// </summary>
    public partial class Forms : UserControl
    {
        private List<string> commands = new List<string>();
        private bool isListFilled = false;
        private event Action ClearAllTextBoxes;
     
        public Forms()
        {
            InitializeComponent();
            Subscribe();
        }
        private void Subscribe()
        {
            ClearAllTextBoxes += txt_CurrentJob.Clear;
            ClearAllTextBoxes += txt_Password.Clear;
            ClearAllTextBoxes += txt_Salary.Clear;
            ClearAllTextBoxes += txt_UserName.Clear;
            ClearAllTextBoxes += txt_YearsOld.Clear;

        }
        private bool changeBrushes(bool isFilled, TextBox tb)
        {
            if (tb.Text == String.Empty)
            {
                isFilled = false;
                tb.BorderBrush = Brushes.Red;
            }
            return isFilled;
        }
        private bool isFilledBlanks()
        {
            bool isFilled = true;

            isFilled = changeBrushes(isFilled, txt_UserName);
            isFilled = changeBrushes(isFilled, txt_CurrentJob);
            isFilled = changeBrushes(isFilled, txt_YearsOld);
            isFilled = changeBrushes(isFilled, txt_Salary);
            isFilled = changeBrushes(isFilled, txt_Password);


            return isFilled;
        }

        private void addTextToList()
        {
            commands.Add(txt_UserName.Text);
            commands.Add(txt_Password.Text);
            commands.Add(txt_CurrentJob.Text);
            commands.Add(txt_YearsOld.Text);
            commands.Add(txt_Salary.Text);
        }
        private void txt_UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_UserName.BorderBrush = Brushes.LightGray;
        }

        private void txt_CurrentJob_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_CurrentJob.BorderBrush = Brushes.LightGray;
        }

        private void txt_YearsOld_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_YearsOld.BorderBrush = Brushes.LightGray;
        }

        private void txt_Salary_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_Salary.BorderBrush = Brushes.LightGray;
        }

        private void txt_Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_Password.BorderBrush = Brushes.LightGray;
        }

        private void btn_Enter_Click(object sender, RoutedEventArgs e)
        {
            if (isFilledBlanks())
            {
                if (!isListFilled)
                {
                    addTextToList();
                    isListFilled = true;
                }
                string message = "Ваши данные: " + '\n' ;

                foreach (var commnd in commands)
                {
                   message += commnd + '\n';
                }
                
                MessageBox.Show(message); 

            } else MessageBox.Show("Заполните остальные поля!");
        }

        
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (isFilledBlanks())
            {
                commands.Clear();
                isListFilled = false;
                ClearAllTextBoxes();
                MessageBox.Show("Все поля и данные очищены!");
            }
            else MessageBox.Show("Поля итак пустые!");
            

        }
    }
}
