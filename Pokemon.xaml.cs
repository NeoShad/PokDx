using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для Pokemon.xaml
    /// </summary>
    public partial class Pokemon : Page
    {
        public Pokemon(string name, string urlImage, int weight)
        {
            InitializeComponent();

            pokeName.Text = name + " - name";
            pokeWeight.Text = weight.ToString() + " - weight";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(urlImage);
            bitmap.EndInit();
           
            //using (WebClient client = new WebClient())
            //{
            //    client.DownloadFile(new Uri(urlImage), @"name.png");
               
            //}

            pokePic.Source = bitmap;
        }
    }
}
