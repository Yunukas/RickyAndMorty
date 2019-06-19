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
using Newtonsoft.Json.Linq;

namespace RickyAndMorty
{
    /// <summary>
    /// Species.xaml etkileşim mantığı
    /// </summary>
    public partial class Species : Page
    {
        public Species()
        {
            InitializeComponent();
 
            // get the unique species
            var uniqueSpecies = MainWindow.chars.Select(x => x.Species).GroupBy(m => m).Select(g => g.FirstOrDefault());

            // add them to the list box
            foreach (var s in uniqueSpecies)
            {
                species_listBox.Items.Add(s);
            }
        }

        private void Species_listBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // firstly clear the list box
            speciesChars_listBox.Items.Clear();

            // check if an empty cell is clicked
            if (species_listBox.SelectedItem == null)
                return;

            string selected = species_listBox.SelectedItem.ToString();

            // filter out the characters belonging to the selected species
            var chars = MainWindow.chars.Where(x => x.Species.Contains(selected)).Select(y => y.Name).ToList();

            // populate the list box
            foreach (string name in chars)
            {
                speciesChars_listBox.Items.Add(name);
            }
        }
        

        private void SpeciesChars_listBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // check if an empty cell is clicked
            if (speciesChars_listBox.SelectedItem == null)
                return;

            string selection = speciesChars_listBox.SelectedItem.ToString();

            // get the image url of selected char
            var image = MainWindow.chars.Where(x => x.Name.Equals(selection)).Select(y => y).ToList();


            string imageURL = "";
            string character = "";
            //Console.WriteLine(imageUrl);

            //start browser and go to the url
            foreach (Characters s in image)
            {
                //System.Diagnostics.Process.Start(s);
                imageURL = s.Image;
                character = s.Name;

            }

            showImage(imageURL, character);
        }

        // this method will show the selected character's image in a new grid
        // making the grid visible and hiding the upper grid
        private void showImage(string imageURL, string name)
        {
            var image = new Image();
            var fullFilePath = imageURL;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();

            image.Source = bitmap;
            grid_species_image.Children.Add(image);
            lbl_species.Content = name;
            grid_species_image.Visibility = Visibility.Visible;
            grid_species_inner.Visibility = Visibility.Hidden;
        }
    }
}
