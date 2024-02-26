using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getPokemon();
        }

        public async void getPokemon()
        {
            using (var http = new HttpClient()) {
                try {
                    var resp = await http.GetStringAsync("https://pokeapi.co/api/v2/pokemon/"+ pokeName.Text.ToLower());
                    dynamic? result = JsonConvert.DeserializeObject(resp);
                    string name = result["name"];
                    int weight = result["weight"];
                    string urlImage = result["sprites"]["front_default"];
                    pokeFrame.Content = new Pokemon(name,urlImage,weight);
                }catch(HttpRequestException exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        public async void getRandPokemon()
        {
            using (var http = new HttpClient())
            {
                try
                {
                    var resp = await http.GetStringAsync("https://pokeapi.co/api/v2/pokemon/" + rnd.Next(200));
                    dynamic? result = JsonConvert.DeserializeObject(resp);
                    string name = result["name"];
                    int weight = result["weight"];
                    string urlImage = result["sprites"]["front_default"];
                    pokeFrame.Content = new Pokemon(name, urlImage, weight);
                }
                catch (HttpRequestException exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void pokeName_MouseEnter(object sender, MouseEventArgs e)
        {
            if (pokeName.Text == "Pokemon name")
            {
                pokeName.Text = "";
            }
        }

        private void pokeName_MouseLeave(object sender, MouseEventArgs e)
        {
            if (pokeName.Text == "")
            {
                pokeName.Text = "Pokemon name";
            }
        }

        private void pokeRand_Click(object sender, RoutedEventArgs e)
        {
            getRandPokemon();
        }
    }
}
