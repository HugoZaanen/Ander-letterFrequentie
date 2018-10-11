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

namespace LetterFrequentie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<char, int> dictionary = new Dictionary<char, int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string text = TextBlock.Text;
            text = text.ToLower();
            char[] chars = text.ToCharArray();

            foreach(char letter in chars)
            {
                if (!dictionary.ContainsKey(letter) && letter != ' ')
                    dictionary.Add(letter, 1);
                else if(letter != ' ')
                    dictionary[letter] = dictionary[letter] + 1;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Dictionary<char, int> dict = sortDictionary(dictionary);

            string text = "";
            foreach (KeyValuePair<char, int> keyPair in dict)
                text += "\n" + keyPair.ToString();
            MessageBox.Show(text);
        }

        private Dictionary<char, int> sortDictionary(Dictionary<char, int> source)
        {
            return source.Keys.OrderBy(k => k).ToDictionary(k => k, k => source[k]);
        }
    }
}
