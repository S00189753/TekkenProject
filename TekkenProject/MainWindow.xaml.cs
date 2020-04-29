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

namespace TekkenProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TekkenProjectDBContainer db = new TekkenProjectDBContainer();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string data = JsonConvert.SerializeObject(GetRandomAccounts(), Formatting.Indented);

            using (StreamWriter sw = new StreamWriter("C:/Users/mitko/source/repos/TekkenProject/accountData.json"))
            {
                sw.Write(data);
                sw.Close();
            }

            var query = from b in db.Characters
                        select b;

            lbxSelect.ItemsSource = query.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool found;
            if (txtbxSearch.Text == "")
            {
                MessageBox.Show("Search For Character");
            }
            else
            {
                found = false;
                string searchName = txtbxSearch.Text;

                foreach (Characters characters in lbxSelect.Items)
                {
                    if (characters.Name == searchName)
                    {
                        found = true;

                            var query = from p in db.Characters
                                        where p.Name == searchName
                                        select p;

                            lbxSelect.ItemsSource = query.ToList();
                    }
                }
                if (found == false)
                {
                    MessageBox.Show("Character was not found");
                }
            }
        }

        private void lbxSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Characters selectCharacter = lbxSelect.SelectedItem as Characters;

            //Check for null
            if (selectCharacter != null)
            {
                //Display Band Info
                string BandText = $"{selectCharacter.Name}";
                lbxName.Text = BandText;

                //Display Band Image
                Image.Source = new BitmapImage(new Uri($"/Images/{selectCharacter.Image}", UriKind.Relative));


                //Punishers Section
                var punish = from b in db.Stats
                             where b.CharactersID == selectCharacter.ID
                             select b.Punishers;

                lbxPunish.ItemsSource = punish.ToList();

                //Plus Frame Moves Section
                var plusframemoves = from b in db.Stats
                                     where b.CharactersID == selectCharacter.ID
                                     select b.Plus_Frame_Moves;

                lbxPlusFrame.ItemsSource = plusframemoves.ToList();

                //Difficulty Section
                var difficulty = from b in db.PlayStyles
                                 where b.CharactersID == selectCharacter.ID
                                 select b.Difficulty;



                lbxDifficulty.ItemsSource = difficulty.ToList();

                //Play Style Section
                var playstyle = from b in db.PlayStyles
                                where b.CharactersID == selectCharacter.ID
                                select b.Play_Style;

                lbxPlayStyle.ItemsSource = playstyle.ToList();
            }
        }


        private static List<Account> GetRandomAccounts()
        {
            Random rand = new Random();
            List<Account> accounts = new List<Account>();

            for (int i = 0; i < 20; i++)
            {
                int accountNumber = rand.Next(1, 100000000);
                int wins = rand.Next(100);
                int losses = rand.Next(100);
                int totalPlayed = wins + losses;

                Account acc = new Account()
                {
                    AccountNumber = accountNumber.ToString("D8"),
                    TotalPlayed = totalPlayed,
                    Wins = wins,
                    Losses = losses
                };
                accounts.Add(acc);
            }
            return accounts;
        }

        private void btnClear(object sender, RoutedEventArgs e)
        {
            var query = from b in db.Characters
                        select b;

            lbxSelect.ItemsSource = query.ToList();

            txtbxSearch.Text = "";
        }
    }
}
