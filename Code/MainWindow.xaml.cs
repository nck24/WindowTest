using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace WindowTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new Random();
        int randomInt;

        public MainWindow()
        {
            InitializeComponent();
            CheckButton.IsEnabled = false;
        }

        public void StartButton_Click(object sender, RoutedEventArgs e){
            randomInt = rand.Next(511);
            QuestionLabel.Content=$"What is {randomInt} in binary?";
            foreach (var v in binaryGrid.Children.OfType<StackPanel>()){
                v.Children.OfType<TextBox>().ElementAt(0).Text = "0";
            }

            CheckButton.IsEnabled = true;
        }
        
        public void HelpButton_Click(object sender, RoutedEventArgs e){
            MessageBox.Show(
                "Click on the start button to begin" + Environment.NewLine +
                "Enter 1 or 0 into the boxes" + Environment.NewLine +
                "If you enter 1 into a box it will represent the value above the box, 0 will deactivate it" + Environment.NewLine +
                "Click on check answer to see if its correct" + Environment.NewLine +
                "You can retry until its correct or start with a new number", "Help box"
            );
        }

        public void CheckButton_Click(object sender, RoutedEventArgs e){
            int sum = 0;
            string bin = "";
            foreach (var v in binaryGrid.Children.OfType<StackPanel>()){
                if (v.Children.OfType<TextBox>().ElementAt(0).Text == "1")
                    sum += Convert.ToInt32(v.Tag);
                
                bin += v.Children.OfType<TextBox>().ElementAt(0).Text;
            }
            if (sum == randomInt){
                ResultLabel.Content = $"{bin} is correct";
                CheckButton.IsEnabled = false;
            }else
                ResultLabel.Content = $"{bin} is incorrect";
        }

    }
}
