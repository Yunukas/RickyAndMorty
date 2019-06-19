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

namespace RickyAndMorty
{
    /// <summary>
    /// CharactersPage.xaml etkileşim mantığı
    /// </summary>
    public partial class CharactersPage : Page
    {
        public CharactersPage()
        {
            InitializeComponent();

            // populate the list box with char names
            foreach(Characters c in MainWindow.chars)
            {
                chars_listBox.Items.Add(c.Name);
            }
           
        }

        private void Search_textBox_KeyUp(object sender, KeyEventArgs e)
        {
            // first clear the listbox
            chars_listBox.Items.Clear();

            // filter the listbox based on the search text and search everything in lower case
            var result = MainWindow.chars.Where(x => x.Name.ToLower().Contains(search_textBox.Text.ToLower())).Select(y => y.Name).ToList();

            // populate the listbox with the result
            foreach (string name in result)
            {
                chars_listBox.Items.Add(name);
            }
        }
        private void Chars_listBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // check if an empty cell is clicked
            if (chars_listBox.SelectedItem == null)
                return;

            string selection = chars_listBox.SelectedItem.ToString();

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
            grid_image.Children.Add(image);
            lbl_char_page.Content = name;
            grid_image.Visibility = Visibility.Visible;
            grid_chars.Visibility = Visibility.Hidden;
        }


       
    }
}
