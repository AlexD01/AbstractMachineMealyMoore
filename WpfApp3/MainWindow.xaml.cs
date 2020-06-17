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

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            S1.PreviewTextInput += TextBox1_PreviewTextInput;
            S2.PreviewTextInput += TextBox1_PreviewTextInput;
            S21.PreviewTextInput += TextBox1_PreviewTextInput;
            P1.PreviewTextInput += TextBox1_PreviewTextInput;
            P2.PreviewTextInput += TextBox1_PreviewTextInput;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (S1.Text == "" || P1.Text == "") { MessageBox.Show("Введите значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            int k1 = int.Parse(S1.Text);
            int k2 = int.Parse(P1.Text);
            if (k1>=10|| k2 >= 10) { MessageBox.Show("Значение не меньше 10", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            Mili win1 = new Mili(S1.Text, P1.Text);
            win1.Show();
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (S21.Text == "" || S2.Text == "" || P2.Text == "") { MessageBox.Show("Введите значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return;}
            int k1 = int.Parse(S2.Text);
            int k2 = int.Parse(P2.Text);
            if (k1 >= 10 || k2 >= 10) { MessageBox.Show("Значение не меньше 10", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            myrasoo win2 = new myrasoo(S2.Text, P2.Text,S21.Text);
            win2.Show();
            this.Close();
        }
        private void TextBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsNumber(Convert.ToChar(e.Text))) e.Handled = true;
        }
    }
}
