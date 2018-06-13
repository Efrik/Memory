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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memory
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Memory.Themes"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Memory.Themes;assembly=Memory.Themes"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CardButton/>
    ///
    /// </summary>
    public class CardButton : Button
    {
        Card cardHere = Deck.RetrieveCard();

        Image image = new Image();
        

        public CardButton(int a, int b)
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(CardButton), new FrameworkPropertyMetadata(typeof(CardButton)));
            //Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata { DefaultValue = 5 });

            Grid.SetColumn(this, a);
            Grid.SetRow(this, b);

/*           DrawingGroup place = new DrawingGroup();
                       ImageDrawing image = new ImageDrawing();
                       image.Rect = new Rect(0, 0, 200, 200);
                       image.ImageSource = Deck.backCard;
                       place.Children.Add(image);
                       DrawingImage allthis = new DrawingImage(place);
                       allthis.Freeze();*/
//All that thing was just to draw an image with other images

            image.Source = Deck.backCard;
            image.Stretch = Stretch.Fill;
            this.AddChild(image);
            SetImage();

            this.Click += CardButton_Click;
        }

        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            FlipCard();
        }

        private void SetImage() //checks which image it should have and sets it right.
        {

            if (cardHere.IsHide())
            {
                image.Source = Deck.backCard;
            }
            else
            {
                image.Source= new BitmapImage(new Uri(@"D:\Efrik\Documents\Visual Studio 2017\Projects\Memory\Memory\Resources\Images\Background.png"));
            }
        }

        public void FlipCard() //shrinks the card, changes the image, and resizes the card, hopefully dinamically.
        {
            cardHere.FlipCard();
            double width = Width;
            while (Width > 5) { Width /=2; }
            SetImage();
            while (Width*2 < width) { Width *= 2; }
            Width = width;
        }

    }
}
