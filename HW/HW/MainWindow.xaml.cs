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

namespace HW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isChecking = false;
        private int imageIndex;
        private List<Image> images;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseGame()
        {
            if (!isChecking)
            {
                nextBtn.Opacity = 0;
                preBtn.Opacity = 0;
                gameImage.Opacity = 0;
                contentSP.Opacity = 0;
                contentInfoSP.Opacity = 0;
                closeBtn.Opacity = 0;
                paginationTB.Opacity = 0;
                chooseGame.Opacity = 1;
            }
        }

        private void Open()
        {
            if (isChecking)
            {
                nextBtn.Opacity = 1;
                preBtn.Opacity = 1;
                gameImage.Opacity = 1;
                contentSP.Opacity = 1;
                contentInfoSP.Opacity = 1;
                closeBtn.Opacity = 1;
                paginationTB.Opacity = 1;
                chooseGame.Opacity = 0;
            }
        }

        private void ShowGame(string name)
        {
            imageIndex = 0;
            isChecking = true;
            Open();
            using (var context = new Context())
            {

                var game = context.Games.FirstOrDefault(x => x.Name == name);
                if (game is null) return;
                images = context.Images.Where(x => x.Game.Id == game.Id).ToList();
                gameImage.Source = new BitmapImage(new Uri(images[imageIndex].Url, UriKind.Absolute));
                paginationTB.Text = $"{imageIndex+1} | {images.Count}";
                dateInfo.Text = game.IssueYear;
                descriptionInfo.Text = game.Description;
                genreInfo.Text = game.Genre;
                priceInfo.Text = game.Price;
                nameInfo.Text = game.Name;
            }
        }

        private void CloseBtnClick(object sender, RoutedEventArgs e)
        {
            isChecking = false;
            CloseGame();
        }

        private void NextBtnClick(object sender, RoutedEventArgs e)
        {
            if (images.Count > imageIndex+1)
            {
                gameImage.Source = new BitmapImage(new Uri(images[++imageIndex].Url, UriKind.Absolute));
                paginationTB.Text = $"{imageIndex + 1} | {images.Count}";
            }
        }

        private void PreBtnClick(object sender, RoutedEventArgs e)
        {
            if (imageIndex != 0)
            {
                gameImage.Source = new BitmapImage(new Uri(images[--imageIndex].Url, UriKind.Absolute));
                paginationTB.Text = $"{imageIndex + 1} | {images.Count}";
            }
        }

        private void Dota2BtnClick(object sender, RoutedEventArgs e)
        {
            ShowGame("Dota 2");
        }

        private void Dota2BClick(object sender, RoutedEventArgs e)
        {
            Dota2BtnClick(sender, e);
        }

        private void W3BtnClick(object sender, RoutedEventArgs e)
        {
            ShowGame("Warcraft III The Frozen Throne");
        }

        private void W3BClick(object sender, RoutedEventArgs e)
        {
            W3BtnClick(sender, e);
        }

        private void NfsBtnClick(object sender, RoutedEventArgs e)
        {
            ShowGame("Need For Speed: Most Wanted");
        }

        private void NfsBClick(object sender, RoutedEventArgs e)
        {
            NfsBtnClick(sender, e);
        }
    }
}
