using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Threading;

namespace Homework2
{
    public partial class MainWindow : Window
    {
        private int i = 0;

        private readonly SynchronizationContext synchronizationContext;

        private readonly List<double> results = new List<double>();

        private readonly DispatcherTimer timer = new DispatcherTimer();

        private DateTime time = new DateTime();

        public MainWindow()
        {
            InitializeComponent();

            ClickMeButton.Click += ClickMeButton_Click;

            synchronizationContext = SynchronizationContext.Current;

            MessageTextBox.Text = "You'll play 5 rounds!\nPlay as fast as you can!";

            Random randomNumber = new Random();

            int randNum = randomNumber.Next(3000, 7000);

            timer.Interval = TimeSpan.FromMilliseconds(randNum);   

            timer.Tick += timer_Tick;

            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                synchronizationContext.Send(state =>
                {
                    MessageTextBox.Text = "Click Button!";

                    time = DateTime.Now;

                    if (i == 5)
                    {
                        MessageTextBox.Text = string.Empty;
                    }
                }, null);
            });

            thread.Start();
        }

        private void ClickMeButton_Click(object sender, RoutedEventArgs e)
        {
            Thread thread2 = new Thread(() =>
            {
                synchronizationContext.Send(state =>
                {
                    if (MessageTextBox.Text == "Click Button!")
                    {
                        var finalResult = (DateTime.Now - time).TotalMilliseconds;

                        ResultBox.Text += $"Your result: {finalResult} Milliseconds!\n";

                        results.Add(finalResult);

                        MessageTextBox.Text = "Wait next signal...";

                        i++;

                        if (i == 5)
                        {
                            MessageBoxResult info = MessageBox.Show($"Game was ended! Your final average result: {results.Average()} Milliseconds!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                            Environment.Exit(0);
                        }
                    }                             
                }, null);             
            });

            thread2.Start();
        }
    }
}
