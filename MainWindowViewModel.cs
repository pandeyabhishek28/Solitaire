using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Solitaire.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Solitaire
{
    public class MainWindowViewModel : ViewModelBase
    {
        private BitmapSource[,] _bitmapCards;

        private int _selectedNumberOfCardsToShowAfterShuffle;

        public int SelectedNumberOfCardsToShowAfterShuffle
        {
            get { return _selectedNumberOfCardsToShowAfterShuffle; }
            set
            {
                _selectedNumberOfCardsToShowAfterShuffle = value;
                RaisePropertyChanged("SelectedNumberOfCardsToShowAfterShuffle");
            }
        }

        public List<int> NumbersOFCardsToShow
        {
            get; set;
        }
        private ObservableCollection<System.Windows.Controls.Image> _cards;

        public ObservableCollection<System.Windows.Controls.Image> Cards
        {
            get { return _cards; }
            set
            {
                _cards = value;
                RaisePropertyChanged("Cards");
            }
        }

        public RelayCommand ResetCommand { get; set; }
        public RelayCommand ShuffleCommand { get; set; }

        public MainWindowViewModel()
        {
            NumbersOFCardsToShow = new List<int>() { 3, 52 };
            ResetCommand = new RelayCommand(ResetCardDeck);
            ShuffleCommand = new RelayCommand(ShuffleDeck);
            Cards = new ObservableCollection<System.Windows.Controls.Image>();
            LoadImageSource();
            LoadCanvas();
            SelectedNumberOfCardsToShowAfterShuffle = 3;
        }

        private void ShuffleDeck()
        {
            try
            {
                var numRows = _bitmapCards.GetUpperBound(0) + 1;
                var numCols = _bitmapCards.GetUpperBound(1) + 1;
                var numCells = numRows * numCols;

                var rand = new Random();
                for (int i = 0; i < numCells - 1; i++)
                {
                    var j = rand.Next(i, numCells);

                    var rowI = i / numCols;
                    var colI = i % numCols;
                    var rowJ = j / numCols;
                    var colJ = j % numCols;

                    BitmapSource temp = _bitmapCards[rowI, colI];
                    _bitmapCards[rowI, colI] = _bitmapCards[rowJ, colJ];
                    _bitmapCards[rowJ, colJ] = temp;
                }

                LoadCanvas();

                Cards = new ObservableCollection<System.Windows.Controls.Image>(Cards.Skip(Cards.Count - SelectedNumberOfCardsToShowAfterShuffle));
            }
            catch (Exception ex)
            {
                // this is wrong
                // we cann't show a dialog from view model
                // as no logging is implemented so I am adding it here
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private void ResetCardDeck()
        {
            try
            {
                Cards.Clear();
                LoadImageSource();
                LoadCanvas();
            }
            catch (Exception ex)
            {
                // this is wrong
                // we cann't show a dialog from view model
                // as no logging is implemented so I am adding it here
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private void LoadCanvas()
        {
            Cards = new ObservableCollection<System.Windows.Controls.Image>();
            var hghtCard = 100;
            var wdthCard = 80;
            var deck = new DeckSet();
            foreach (var card in deck)
            {
                var img = new System.Windows.Controls.Image()
                {
                    Source = GetCard(card.Suit, (int)card.Type),
                    Height = hghtCard
                };

                Cards.Add(img);
                Canvas.SetLeft(img, (int)card.Type * wdthCard);
                Canvas.SetTop(img, (int)card.Suit * hghtCard);
            }
        }

        private void LoadImageSource()
        {
            _bitmapCards = new BitmapSource[4, 13];
            var hmodCards = LoadLibraryEx("cards.dll", IntPtr.Zero, LOAD_LIBRARY_AS_DATAFILE);
            if (hmodCards == IntPtr.Zero)
            {
                throw new FileNotFoundException("Couldn't find cards.dll");
            }
            Func<int, BitmapSource> getImageSource = (j) =>
                         {
                             var bmRsrc = LoadBitmap(hmodCards, j);
                             var bmp = Bitmap.FromHbitmap(bmRsrc);
                             DeleteObject(bmRsrc);
                             var hbmp = bmp.GetHbitmap();
                             var bmpSrc = Imaging.CreateBitmapSourceFromHBitmap(
                                         hbmp,
                                        palette: IntPtr.Zero,
                                        sourceRect: Int32Rect.Empty,
                                        sizeOptions: BitmapSizeOptions.FromEmptyOptions());

                             DeleteObject(hbmp);
                             return bmpSrc;
                         };

            for (var suit = CardSuit.Clubs; suit <= CardSuit.Spades; suit++)
            {
                for (int i = 1; i < 14; i++)
                {
                    int ndx = 13 * (int)suit + i;
                    _bitmapCards[(int)suit, i - 1] = getImageSource(ndx);
                }
            }
        }

        private BitmapSource GetCard(CardSuit nSuit, int nDenom)
        {
            if (nDenom < 0 || nDenom > 13)
            {
                throw new ArgumentOutOfRangeException();
            }
            return _bitmapCards[(int)nSuit, nDenom];
        }

        public const int LOAD_LIBRARY_AS_DATAFILE = 2;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFileReserved, uint dwFlags);

        [DllImport("User32.dll")]
        public static extern IntPtr LoadBitmap(IntPtr hInstance, int uID);

        [DllImport("gdi32")]
        static extern int DeleteObject(IntPtr o);
    }
}
