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
    /// Логика взаимодействия для Myra.xaml
    /// </summary>
    public partial class Myra : Window
    {
        int[,] array;
        ComboBox[,] cm1;
        TextBlock[] xx;
        TextBlock[] ss;
        int s;
        int p;
        List<string> bezstrih;
        string[] strih;
        public Myra(List<string> bezstrih,string[] strih)
        {
            s = strih.Length;
            p = 2;
            this.bezstrih = bezstrih;
            this.strih = strih;
            array = new int[p, s];
            cm1 = new ComboBox[s, p];
            xx = new TextBlock[p];
            ss = new TextBlock[s];
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    cm1[i, j] = new ComboBox();
                    Canvas.SetLeft(cm1[i, j], (55 * (j + 1)) + 40);
                    Canvas.SetTop(cm1[i, j], 40 * (i + 1));
                    cm1[i, j].Height = 20;
                    cm1[i, j].Width = 50;
                    cm1[i, j].HorizontalAlignment = HorizontalAlignment.Left;
                    cm1[i, j].VerticalAlignment = VerticalAlignment.Top;
                    cm1[i, j].SelectionChanged += ComboBox_SelectionChanged;
                }
            }
            for (int j = 0; j < p; j++)
            {
                xx[j] = new TextBlock();
                Canvas.SetLeft(xx[j], (90 * (j + 1))+10);
                Canvas.SetTop(xx[j], 10);
                xx[j].Height = 20;
                xx[j].Width = 30;
                xx[j].HorizontalAlignment = HorizontalAlignment.Left;
                xx[j].VerticalAlignment = VerticalAlignment.Top;
                xx[j].TextWrapping = TextWrapping.Wrap;
                xx[j].Text = "x" + (j + 1);
            }
            for (int j = 0; j < s; j++)
            {
                ss[j] = new TextBlock();
                Canvas.SetLeft(ss[j], 10);
                Canvas.SetTop(ss[j], 40 * (j + 1));
                ss[j].Height = 20;
                ss[j].Width = 60;
                ss[j].HorizontalAlignment = HorizontalAlignment.Left;
                ss[j].VerticalAlignment = VerticalAlignment.Top;
                ss[j].TextWrapping = TextWrapping.Wrap;
                ss[j].Text = strih[j]+"/"+bezstrih[j];
            }
            InitializeComponent();
        }

        List<string> l = new List<string>();
        TextBlock[] xx1;
        TextBlock[] ss1;
        TextBlock[,] tb1;
        string[,] rez;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.Height = 40 * (s + 1);
            for (int j = 0; j < s; j++)
            {
                Canvas.Children.Add(ss[j]);
                l.Add("S'"+(j+1));
            }
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    Canvas.Children.Add(cm1[i, j]);
                    foreach (var item in l)
                    {
                        cm1[i, j].Tag = bezstrih[i].Substring(1,bezstrih[i].IndexOf(' '))+j+"";
                        cm1[i, j].Items.Add(item);
                    }
                }
            }
            for (int j = 0; j < p; j++)
            {
                Canvas.Children.Add(xx[j]);
            }
        }
        private void BTx1_Click(object sender, RoutedEventArgs e)
        {
            TBXX.Text += "x1 ";
        }
        private void BTx2_Click(object sender, RoutedEventArgs e)
        {
            TBXX.Text += "x2 ";
        }
        private void BTd1_Click(object sender, RoutedEventArgs e)
        {
            if (TBXX.Text.Length >= 3)
                TBXX.Text = TBXX.Text.Substring(0, TBXX.Text.Length - 3);
        }
        private void BTdall_Click(object sender, RoutedEventArgs e)
        {
            TBXX.Text = "";
        }
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            react.Text = "";if (TBXX.Text == "") { return; }
            TBXX.Text = TBXX.Text.Substring(0, TBXX.Text.Length - 1);
            string[] xs = TBXX.Text.Split(' ');
            int start = 0;
            string starts = "S1";
            for (int i = 0; i < xs.Length; i++)
            {
                string t = xs[i].Substring(1);
                int next = Convert.ToInt32(t) - 1;
                string[] temp1 = sss1[start, next].Split(' ');
                react.Text += "γ(" + starts + "," + xs[i] + ") = " + temp1[0] + "  \n";
                react.Text += "λ(" + starts + "," + xs[i] + ") = " + temp1[1] + " \n";
                string t1 = sss1[start, next].Substring(1, sss1[start, next].IndexOf(' '));
                starts = "S" + t1;
                start = Convert.ToInt32(t1) - 1;
            }
            react.Text += "\n";
            start = 0;
            starts = "S'1";
            for (int i = 0; i < xs.Length; i++)
            {
                string t = xs[i].Substring(1);
                int next = Convert.ToInt32(t) - 1;
                string temp = sss[start, next];
                string temp2 = temp.Substring(2);
                int ytemp2 = Convert.ToInt32(temp2) - 1;
                string temp1 = bezstrih[ytemp2];
                string[] yt = temp1.Split(' ');
                react.Text += "γ(" + starts + "," + xs[i] + ") = " + temp + "  \n";
                react.Text += "λ(" + temp + ") = " + yt[1] + " \n";
                string t1 = sss[start, next].Substring(2);
                starts = "S'" + t1;
                start = Convert.ToInt32(t1) - 1;
            }
            TBXX.Text += " ";
        }
        string[,] sss;
        string[,] sss1;
        private void BT1_Click(object sender, RoutedEventArgs e)
        {
            sss = new string[s, p];
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    if (cm1[i, j].SelectedIndex == -1)
                    {
                        return;
                    }
                    sss[i, j] = l[cm1[i, j].SelectedIndex];
                }
            }
            BT1.Visibility = Visibility.Hidden;
            rez = new string[strih.Length, 2];
            for (int i = 0; i < strih.Length; i++)
            {
                int id = int.Parse(sss[i,0].Substring(2)) - 1;
                string str = bezstrih[id];
                rez[i, 0] = str;
                id = int.Parse(sss[i, 1].Substring(2)) - 1;
                str = bezstrih[id];
                rez[i, 1] = str;
            }
            List<string> ls1 = new List<string>();
            List<string> ls2 = new List<string>();
            for (int i = 0; i < strih.Length; i++)
            {
                if (ls1.Contains(rez[i, 0]) == false || ls2.Contains(rez[i, 1]) == false) { ls1.Add(rez[i, 0]);ls2.Add(rez[i, 1]); }
            }
            sss1 = new string[ls1.Count, 2];
            for (int i = 0; i < ls1.Count; i++)
            {
                sss1[i, 0] = ls1[i];
                sss1[i, 1] = ls2[i];
            }
            xx1 = new TextBlock[2];
            ss1 = new TextBlock[strih.Length];
            tb1 = new TextBlock[strih.Length, 2];
            for (int i = 0; i < ls1.Count; i++)
            {
                tb1[i, 0] = new TextBlock();
                Canvas.SetLeft(tb1[i, 0], (100 * (0 + 1)) + 300);
                Canvas.SetTop(tb1[i, 0], 40 * (i + 1));
                tb1[i, 0].Height = 20;
                tb1[i, 0].Width = 50;
                tb1[i, 0].HorizontalAlignment = HorizontalAlignment.Left;
                tb1[i, 0].VerticalAlignment = VerticalAlignment.Top;
                Canvas.Children.Add(tb1[i, 0]);
                tb1[i, 0].Text = ls1[i];
                tb1[i, 1] = new TextBlock();
                Canvas.SetLeft(tb1[i, 1], (100 * (1 + 1)) + 300);
                Canvas.SetTop(tb1[i, 1], 40 * (i + 1));
                tb1[i, 1].Height = 20;
                tb1[i, 1].Width = 50;
                tb1[i, 1].HorizontalAlignment = HorizontalAlignment.Left;
                tb1[i, 1].VerticalAlignment = VerticalAlignment.Top;
                Canvas.Children.Add(tb1[i, 1]);
                tb1[i, 1].Text = ls2[i];
            }
            for (int j = 0; j < 2; j++)
            {
                xx1[j] = new TextBlock();
                Canvas.SetLeft(xx1[j], (100 * (j + 1)) + 300);
                Canvas.SetTop(xx1[j], 10);
                xx1[j].Height = 20;
                xx1[j].Width = 30;
                xx1[j].HorizontalAlignment = HorizontalAlignment.Left;
                xx1[j].VerticalAlignment = VerticalAlignment.Top;
                xx1[j].TextWrapping = TextWrapping.Wrap;
                xx1[j].Text = "x" + (j + 1);
                Canvas.Children.Add(xx1[j]);
            }
            for (int j = 0; j < ls1.Count; j++)
            {
                ss1[j] = new TextBlock();
                Canvas.SetLeft(ss1[j], (10 + 300));
                Canvas.SetTop(ss1[j], 40 * (j + 1));
                ss1[j].Height = 20;
                ss1[j].Width = 30;
                ss1[j].HorizontalAlignment = HorizontalAlignment.Left;
                ss1[j].VerticalAlignment = VerticalAlignment.Top;
                ss1[j].TextWrapping = TextWrapping.Wrap;
                ss1[j].Text = "S"+(j+1);
                Canvas.Children.Add(ss1[j]);
            }
            ok.Visibility = Visibility.Visible;
            BTx1.Visibility = Visibility.Visible;
            BTx2.Visibility = Visibility.Visible;
            TBXX.Visibility = Visibility.Visible;
            BTd1.Visibility = Visibility.Visible;
            BTdall.Visibility = Visibility.Visible;
            react.Visibility = Visibility.Visible;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            foreach (UIElement c in Canvas.Children)
            {
                 if (c is ComboBox)
                 {
                    ComboBox cbt = (ComboBox)c;
                    string s1 = cb.Tag.ToString();
                    string s2 = cbt.Tag.ToString(); 
                    if (s1==s2)
                    { 
                         cbt.SelectedItem = cb.SelectedItem;
                    }
                 }
            }
        }
    }
}
