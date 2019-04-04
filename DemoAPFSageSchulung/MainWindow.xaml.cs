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
using HelloWorldDempProject;

namespace DemoAPFSageSchulung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILoggingService _logger;
        private readonly ILoggingServiceInit _initService;
        public MainWindow()
        {
            InitializeComponent();
            var service = new LoggingService();
            _initService = service;
            _logger = service;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Hintergrundfarbe ändern
            var btn = sender as Control;
            if(btn != null)
            {
                try
                {
                    var tag = (string)btn.Tag;

                    switch (tag)
                    {
                        case "Log":
                            _initService.Init();
                            _logger.Log("Aus der WPF-Anwendung heraus");
                            break;

                        case "DeleteLog":

                            break;

                        default:
                            break;
                    }
                }
                catch (InvalidCastException ice)
                {

                    //TODO
                    var logger2 = new LoggingService();
                    logger2.Log(ice.Message.ToString());

                }
                catch (Exception ex)
                {
                    var logger3 = new LoggingService();
                    logger3.Log(ex.Message.ToString());
            
                }

            }

            //if (sender is Button s)
            //{
            //    s.Background = Brushes.OrangeRed;
            //}

            /*
               Gettype() vom Object ist ja immer da
            */ 


            //// ********************************************
            //// elvis operator und as 
            //var btn = sender as Button;
            //var color = btn?.Background;
            //// *********************************************

            // ich will das Handle behandeln !!!
            e.Handled = true;
        }

    }
}
