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
    public partial class Mili : Window
    {
        int[,] array;
        ComboBox[,] cm1;
        ComboBox[,] cm2;
        TextBlock[] xx;
        TextBlock[] ss;
        int s;
        int p;
        int y;
        public Mili(string S1,string P1)
        {
            s = int.Parse(S1);
            p = 2;
            y= int.Parse(P1);
            array = new int[p,s];          
            cm1 = new ComboBox[s, p];
            cm2 = new ComboBox[s, p];
            xx = new TextBlock[p];
            ss = new TextBlock[s];
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j <p; j++)
                {
                    cm1[i, j] = new ComboBox();
                    Canvas.SetLeft(cm1[i,j], (110 * (j + 1))-50);
                    Canvas.SetTop(cm1[i, j], 40 * (i + 1));
                    cm1[i, j].Height = 20;
                    cm1[i, j].Width = 50;
                    cm1[i, j].HorizontalAlignment = HorizontalAlignment.Left;
                    cm1[i, j].VerticalAlignment = VerticalAlignment.Top;
                    cm2[i, j] = new ComboBox();
                    Canvas.SetLeft(cm2[i, j], (110 * (j + 1)));
                    Canvas.SetTop(cm2[i, j], 40 * (i + 1));
                    cm2[i, j].Height = 20;
                    cm2[i, j].Width = 50;
                    cm2[i, j].HorizontalAlignment = HorizontalAlignment.Left;
                    cm2[i, j].VerticalAlignment = VerticalAlignment.Top;

                }
            }
            for (int j = 0; j < p; j++)
            {
                xx[j] = new TextBlock();
                Canvas.SetLeft(xx[j], 100 * (j + 1));
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
                ss[j].Width = 30;
                ss[j].HorizontalAlignment = HorizontalAlignment.Left;
                ss[j].VerticalAlignment = VerticalAlignment.Top;
                ss[j].TextWrapping = TextWrapping.Wrap;
                ss[j].Text = "S" + (j + 1);
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
                Canvas.Children.Add(ss[j]);
                l.Add(ss[j].Text);
            }
            for (int j = 1; j <= y; j++)
            {               
                l1.Add("y"+j);
            }
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    Canvas.Children.Add(cm1[i, j]);
                    foreach (var item in l)
                    {
                        cm1[i, j].Items.Add(item);
                    }                                   
                    Canvas.Children.Add(cm2[i, j]);
                    foreach (var item in l1)
                    {
                        cm2[i, j].Items.Add(item);
                    }                    
                }
            }
            for (int j = 0; j<p; j++)
            {
                Canvas.Children.Add(xx[j]);    
            }
        }
        string[,] sss;
        string[,] s1;
        string[,] y1;
        List<string> ls ;
        string[] strih;
        string[,] rez;
        TextBlock[] xx1;
        TextBlock[] ss1;
        TextBlock[,]tb1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sss = new string[s, p];
            s1 = new string[s, p];
            y1 = new string[s, p];
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    if (cm1[i, j].SelectedIndex == -1)
                    {
                        return;
                    }
                    if (cm2[i, j].SelectedIndex == -1)
                    {
                        return;
                    }
                    s1[i, j] = l[cm1[i, j].SelectedIndex];
                    y1[i, j] = l1[cm2[i, j].SelectedIndex];
                    sss[i, j] = s1[i,j]+" "+y1[i,j];
                }
            }
            BT1.Visibility = Visibility.Hidden;
            ls = new List<string>();
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    if (ls.Contains(sss[i, j]) == false) ls.Add(sss[i, j]);
                }
            }
            ls.Sort();
            strih=new string[ls.Count];
            int ii = 0;
            foreach (var item in ls)
            {
                strih[ii] = "S'"+(ii+1);
                ii++;
            }
            rez = new string[strih.Length, 2];
            for (int i = 0; i < strih.Length; i++)
            {
                int prob = ls[i].IndexOf(" ");
                int id =int.Parse( ls[i].Substring(1,prob-1))-1;
                string str = sss[id,0];
                int id1 = ls.IndexOf(str);
                rez[i, 0] = strih[id1];
                str = sss[id, 1];
                id1 = ls.IndexOf(str);
                rez[i, 1] = strih[id1];
            }
            xx1 = new TextBlock[2];
            ss1 = new TextBlock[strih.Length];
            tb1 = new TextBlock[strih.Length,2];
            for (int i = 0; i < strih.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    tb1[i, j] = new TextBlock();
                    Canvas.SetLeft(tb1[i, j], (100 * (j + 1)) +300);
                    Canvas.SetTop(tb1[i, j], 40 * (i + 1));
                    tb1[i, j].Height = 20;
                    tb1[i, j].Width = 50;
                    tb1[i, j].HorizontalAlignment = HorizontalAlignment.Left;
                    tb1[i, j].VerticalAlignment = VerticalAlignment.Top;
                    Canvas.Children.Add(tb1[i, j]);
                    tb1[i, j].Text = rez[i, j];
                }
            }
            for (int j = 0; j < 2; j++)
            {
                xx1[j] = new TextBlock();
                Canvas.SetLeft(xx1[j], (100 * (j + 1))+300);
                Canvas.SetTop(xx1[j], 10);
                xx1[j].Height = 20;
                xx1[j].Width = 30;
                xx1[j].HorizontalAlignment = HorizontalAlignment.Left;
                xx1[j].VerticalAlignment = VerticalAlignment.Top;
                xx1[j].TextWrapping = TextWrapping.Wrap;
                xx1[j].Text = "x" + (j + 1);
                Canvas.Children.Add(xx1[j]);
            }
            for (int j = 0; j < strih.Length; j++)
            {
                ss1[j] = new TextBlock();
                Canvas.SetLeft(ss1[j], (10+300));
                Canvas.SetTop(ss1[j], 40 * (j + 1));
                ss1[j].Height = 20;
                ss1[j].Width = 30;
                ss1[j].HorizontalAlignment = HorizontalAlignment.Left;
                ss1[j].VerticalAlignment = VerticalAlignment.Top;
                ss1[j].TextWrapping = TextWrapping.Wrap;
                ss1[j].Text = strih[j];
                Canvas.Children.Add(ss1[j]);
            }
            Canvas.Height = 40 * (strih.Length + 1);
            ok.Visibility = Visibility.Visible;
            BTx1.Visibility = Visibility.Visible;
            BTx2.Visibility = Visibility.Visible;
            TBXX.Visibility = Visibility.Visible;
            BTd1.Visibility = Visibility.Visible;
            BTdall.Visibility = Visibility.Visible;
            react.Visibility = Visibility.Visible;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            react.Text = "";
            if (TBXX.Text == "") { return; }
            TBXX.Text = TBXX.Text.Substring(0, TBXX.Text.Length - 1);
            string[] xs = TBXX.Text.Split(' ');
            int start = 0;
            string starts = "S1";
            for(int i=0;i<xs.Length;i++)
            {
                string t = xs[i].Substring(1);
                int next = Convert.ToInt32(t)-1;              
                string []temp1 = sss[start, next].Split(' ');
                react.Text += "γ("+ starts + ","+xs[i]+") = "+temp1[0] + "  \n";
                react.Text += "λ(" + starts + "," + xs[i] + ") = " + temp1[1] + " \n";
                string t1 = sss[start, next ].Substring(1, sss[start, next].IndexOf(' '));
                starts = "S"+t1;
                start = Convert.ToInt32(t1)-1;                
            }
            react.Text += "\n";
            start = 0;
            starts = "S'1";
            for (int i = 0; i < xs.Length; i++)
            {
                string t = xs[i].Substring(1);
                int next = Convert.ToInt32(t) - 1;
                string temp = rez[start, next];
                string temp2 = temp.Substring(2);
                int ytemp2 = Convert.ToInt32(temp2) - 1;
                string temp1 = ls[ytemp2];
                string[] yt = temp1.Split(' ');
                react.Text += "γ(" + starts + "," + xs[i] + ") = " + temp + "  \n";
                react.Text += "λ(" + temp + ") = " + yt[1] + " \n";
                string t1 = rez[start, next].Substring(2);
                starts = "S'" + t1;
                start = Convert.ToInt32(t1)-1;
            }
            TBXX.Text += " ";
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
            if(TBXX.Text.Length>=3)
            TBXX.Text = TBXX.Text.Substring(0, TBXX.Text.Length - 3);
        }
        private void BTdall_Click(object sender, RoutedEventArgs e)
        {
            TBXX.Text = "";
        }
    }
}
