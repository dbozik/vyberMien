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

namespace Vyber_mien
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private short _counter = -1;

        public MainWindow()
        {
            InitializeComponent();

            InitializeButtons();
        }

        private void InitializeButtons()
        {
            _counter++;
            counter.Content = _counter;
            var names = new Names();

            var pair = names.GetPair();

            btn1.Content = pair.Item1;
            btn2.Content = pair.Item2;
            lblCount.Content = "Count: " + names.Count;
        }

        private void btn_Click(string winner, string looser)
        {
            var names = new Names();
            names.ProcessChoice(winner, looser);
            names.SaveFile();
            InitializeButtons();
        }

        private void Delete_Click(string name, string name2 = null)
        {
            var names = new Names();
            names.Delete(name);
            names.Delete(name2);
            names.SaveFile();
            InitializeButtons();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            btn_Click(btn1.Content.ToString(), btn2.Content.ToString());
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            btn_Click(btn2.Content.ToString(), btn1.Content.ToString());
        }

        private void delete1_Click(object sender, RoutedEventArgs e)
        {
            Delete_Click(btn1.Content.ToString());
        }

        private void delete2_Click(object sender, RoutedEventArgs e)
        {
            Delete_Click(btn2.Content.ToString());
        }

        private void deleteBoth_Click(object sender, RoutedEventArgs e)
        {
            Delete_Click(btn2.Content.ToString(), btn2.Content.ToString());
        }
    }
}
