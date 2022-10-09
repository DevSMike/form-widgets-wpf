using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisualProgramming2
{
    /// <summary>
    /// Логика взаимодействия для Forms.xaml
    /// </summary>
    public partial class Forms : UserControl
    {
        private List<string> commands = new List<string>();
        bool isListFilled = false;
        //private bool isFilled = false;
        enum blankFields
        {
            USERNAME,
            JOB,
            YEARS,
            SALARY,
            PASSWORD

        }
        public Forms()
        {
            InitializeComponent();
        }
       private void changeBrushes(bool isFilled)
        {

        }
        private bool isFilledBlanks()
        {
            bool isFilled = true;
            if (txt_CurrentJob.Text == "")
            {
                isFilled = false;
                txt_CurrentJob.BorderBrush = Brushes.Red;
            }
            if (txt_Password.Text == "")
            {
                isFilled = false;
                txt_Password.BorderBrush = Brushes.Red;
            }
            if (txt_Salary.Text == "")
            {
                isFilled = false;
                txt_Salary.BorderBrush = Brushes.Red;
            }
            if (txt_UserName.Text == "")
            {
                isFilled = false;
                txt_UserName.BorderBrush = Brushes.Red;
            }
            if (txt_YearsOld.Text == "")
            {
                isFilled = false;
                txt_YearsOld.BorderBrush = Brushes.Red;
            }

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

        }
    }
}
