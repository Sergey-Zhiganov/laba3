using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using laba1.up01DataSetTableAdapters;

namespace laba1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentsTableAdapter students = new StudentsTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            up01DataGrid.ItemsSource = students.Select1();
            Group_IDText.ItemsSource = students.Select1();
            Window1 window1 = new Window1();
            //window1.Show();
        }
        private void up01DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (up01DataGrid.SelectedItem != null)
            {
                DataRowView selected = (up01DataGrid.SelectedItem as DataRowView);
                SurnameText.Text = selected["Surname"].ToString();
                FirstnameText.Text = selected["Fistname"].ToString();
                MiddleNameText.Text = selected["MiddleName"].ToString();
                Group_IDText.Text = selected["Title"].ToString();
            }
            else
            {
                SurnameText.Text = null;
                FirstnameText.Text = null;
                MiddleNameText.Text = null;
                Group_IDText.Text = null;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                students.Insert1(SurnameText.Text, FirstnameText.Text, MiddleNameText.Text, Group_IDText.SelectedIndex + 1);
                up01DataGrid.ItemsSource = students.GetData();
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Students student = up01DataGrid.SelectedItem as Students;
                students.Update1(SurnameText.Text, FirstnameText.Text, MiddleNameText.Text, Group_IDText.SelectedIndex + 1, student.ID_Student);
                up01DataGrid.ItemsSource = students.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                students.Delete1(Convert.ToInt32(students.GetData()[up01DataGrid.SelectedIndex][0]));
                up01DataGrid.ItemsSource = students.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
