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
using System.IO;
using Newtonsoft.Json;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace RickyAndMorty
{
    
    public partial class MainWindow : Window
    {
        // create a static list so that pages can access easily without creating an instance
        public static List<Characters> chars = new List<Characters>();

        public MainWindow()
        {
            InitializeComponent();

            // get the list of characters
            getChars();

            // initial view is Characters Page
            Main.Content = new CharactersPage();
        }

        private void getChars()
        {
            // read the json file
            JObject job = JObject.Parse(Properties.Resources.ricky);

            // get the results fragment of the json as a list of JTokens
            List<JToken> results = job["results"].Children().ToList();

            // populate the list
            foreach (JToken result in results)
            {
                Characters character = result.ToObject<Characters>();

                chars.Add(character);
            }
        }

        private void Species_button_Click(object sender, RoutedEventArgs e)
        {
            changeContent("Species");
        }

        private void CharsPage_button_Click(object sender, RoutedEventArgs e)
        {
            changeContent("Characters");
        }

        public void changeContent(string content)
        {
            switch(content)
            {
                case "Species":
                    Main.Content = new Species();
                    break;
                case "Characters":
                    Main.Content = new CharactersPage();
                    break;
            }
        }
    }
}
