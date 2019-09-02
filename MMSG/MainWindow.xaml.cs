using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using MMSG.Instances;

namespace MMSG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public InstanceHandler InstanceHandler { get; }

        public MainWindow()
        {
            InitializeComponent();
            InstanceHandler =
                new InstanceHandler("C:\\Users\\Joshua\\Documents\\Minecraft Server-1.14.3\\Paper-1.14.4_latest.jar");
        }

        private void ButtonSelectFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                IsFolderPicker = true
            };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                TextBoxOutputLocation.Text = dialog.FileName;
            }
        }

        private void ButtonGenerateWorld_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var serverCount = byte.Parse(TextBoxServerCount.Text);
                var startingPort = int.Parse(TextBoxStartingPort.Text);
                var ram = TextBoxRam.Text;
                var worldName = TextBoxWorldName.Text;
                var outputLocation = TextBoxOutputLocation.Text;
                var seed = TextBoxWorldSeed.Text;

                if (CheckBoxPatchJar.IsChecked != null && (bool) CheckBoxPatchJar.IsChecked)
                {
                    var patchServer = InstanceHandler.CreatePatchServer(ram, outputLocation);

                    patchServer.Start();
                    patchServer.Exited += (sender2, e2) =>
                    {
                        RunInstances(startingPort, serverCount, ram, worldName, outputLocation, seed);
                    };
                }
                else
                {
                    RunInstances(startingPort, serverCount, ram, worldName, outputLocation, seed);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

            }
        }

        private void RunInstances(int startingPort,byte serverCount,string ram, string worldName, string outputLocation, string seed)
        {
            InstanceHandler.Instances.Clear();
            InstanceHandler.Create(startingPort, serverCount, ram, worldName, outputLocation, seed);
            InstanceHandler.RunAll();


            //var radius = 

            //Create worldborders
            /*var sqrt = Math.Sqrt(serverCount);
            var width = canWidth / sqrt;
            for (var i = 0; i < sqrt; i++)
            {
                for (var j = 0; j < sqrt; j++)
                {
                    double x = centerX / sqrt * i * 2;
                    double y = centerY / sqrt * j * 2;


                    Square.Draw(Canvas, (int)Math.Round(x), (int)Math.Round(y), (int)(Math.Round(x) + width),
                        (int)Math.Round(y + width));
                }
            }*/
        }

        private void ButtonStopAll_Click(object sender, RoutedEventArgs e)
        {
            InstanceHandler.StopAll();
        }
    }
}