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
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для myrasoo.xaml
    /// </summary>
    public partial class myrasoo : Window
    {
        ComboBox[] cm1; ComboBox[] cm2;  
        int s;
        int ss1;
        int y;
        public myrasoo(string S1, string P1,string S2)
        {
            s = int.Parse(S1);
            ss1 = int.Parse(S2);
            y = int.Parse(P1);
            cm1 = new ComboBox[ss1]; cm2 = new ComboBox[ss1];
            for (int i = 0; i < ss1; i++)
            {
                cm1[i] = new ComboBox();
                Canvas.SetLeft(cm1[i], (110 * 1) - 100);
                Canvas.SetTop(cm1[i], 40 * (i + 1));
                cm1[i].Height = 20;
                cm1[i].Width = 50;
                cm1[i].HorizontalAlignment = HorizontalAlignment.Left;
                cm1[i].VerticalAlignment = VerticalAlignment.Top;
                cm2[i] = new ComboBox();
                Canvas.SetLeft(cm2[i], (110 * 1) - 50);
                Canvas.SetTop(cm2[i], 40 * (i + 1));
                cm2[i].Height = 20;
                cm2[i].Width = 50;
                cm2[i].HorizontalAlignment = HorizontalAlignment.Left;
                cm2[i].VerticalAlignment = VerticalAlignment.Top;  
            }
            InitializeComponent();
        }
        List<string> l = new List<string>();
        List<string> l1 = new List<string>();       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.Height = 40 * (s + 1);
            for (int j = 0; j < s; j++)
            {
                l.Add("S"+(j+1));
            }
            for (int j = 1; j <= y; j++)
            {
                l1.Add("y" + j);
            }
            for (int i = 0; i < ss1; i++)
            { 
                Canvas.Children.Add(cm1[i]);
                foreach (var item in l)
                {
                    cm1[i].Items.Add(item);
                }
                Canvas.Children.Add(cm2[i]);
                foreach (var item in l1)
                {
                    cm2[i].Items.Add(item);
                }            
            }
        }
        string[] strih;
        List<string> bezstrih;
        string[] sss;
        string[] s1;
        string[] y1;
        private void BT1_Click(object sender, RoutedEventArgs e)
        {
            sss = new string[ss1];
            s1 = new string[ss1];
            y1 = new string[ss1];
            for (int i = 0; i < ss1; i++)
            {
                    if (cm1[i].SelectedIndex == -1)
                    {
                        return;
                    }
                    if (cm2[i].SelectedIndex == -1)
                    {
                        return;
                    }
                    s1[i] = l[cm1[i].SelectedIndex];
                    y1[i] = l1[cm2[i].SelectedIndex];
                    sss[i] = s1[i] + " " + y1[i];
            }
            bezstrih = new List<string>();
            for (int i = 0; i < ss1; i++)
            {
                if (bezstrih.Contains(sss[i]) == false) bezstrih.Add(sss[i]);
            }
            bezstrih.Sort();
            strih = new string[bezstrih.Count];
            int ii = 0;
            foreach (var item in bezstrih)
            {
                strih[ii] = "S'" + (ii + 1);
                ii++;
            }
            Myra win2 = new Myra(bezstrih,strih);
            win2.Show();
            this.Close();
        }
    }
}
