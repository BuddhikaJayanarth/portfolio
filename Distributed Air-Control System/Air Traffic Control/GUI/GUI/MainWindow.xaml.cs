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
using Master;
using System.ServiceModel;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMasterControllerCallback
    {

        // Master controller interface object
        private IMasterController masterInter; 

        // List of initiated airports
        private List<Airport> displayAirports = new List<Airport>();

        // Queue of landed airplanes
        private Queue<Airplane> landedPlanes = new Queue<Airplane>();


        // list of entering-circling airplanes
        private List<Airplane> enteringPlanes = new List<Airplane>();

        // list of in transit airplanes
        private List<Airplane> transitPlanes = new List<Airplane>();

        // Queue of circling airplanes
        private List<Airplane> circlingPlanes = new List<Airplane>();

        // list of in crashed airplanes
        private List<Airplane> crashedPlanes = new List<Airplane>();

        //selected item
        private string selected;

        //do nothing
        public Airport getSlaveAirPort()
        {
            //leave blank
            return null;
        }

        //do nothing
        public void incrementSlaveAirport()
        {
            //leave blank
        }

        public MainWindow()
        {

            //establishes connection to Master Server
            NetTcpBinding tcpBinding = new NetTcpBinding();
            tcpBinding.MaxReceivedMessageSize = System.Int32.MaxValue;
            tcpBinding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;

            ChannelFactory<IMasterController> MasterFactory;
            string surl = "net.tcp://localhost:50000/Master";

            MasterFactory = new DuplexChannelFactory<IMasterController>(this, tcpBinding, surl);

            //channel to Master set
            masterInter = MasterFactory.CreateChannel();
            Console.WriteLine("here");
            displayAirports = masterInter.GetAllAirports();
            Console.WriteLine("here");
            foreach (Airport airporttest in displayAirports)
            {
                Console.WriteLine(airporttest.airportID + airporttest.airportName);
            }
            Console.WriteLine("here");


            InitializeComponent();

            airportListBox.Items.Clear();
            //display the airports in listbox
            foreach (Airport displayport in displayAirports)
            {
                Console.WriteLine(displayport.airportName);
                airportListBox.Items.Add(displayport.airportName);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void airportListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (airportListBox.SelectedItem.ToString() != null)
                {
                    selected = airportListBox.SelectedItem.ToString();

                    //retrieving the plane lists for the selected airport and displaying in listviews
                    foreach (Airport airport2 in displayAirports)
                    {
                        if (airport2.airportName == selected)
                        {
                            //display landed planes
                            landedPlanes = airport2.landedQueue;
                            landedListView.ItemsSource = landedPlanes;

                            //display entering-circling planes
                            enteringPlanes = airport2.enteringList;
                            enteringListView.ItemsSource = enteringPlanes;

                            //display circling planes
                            circlingPlanes = airport2.circlingList;
                            circlingListView.ItemsSource = circlingPlanes;

                            //display circling planes
                            circlingPlanes = airport2.circlingList;
                            circlingListView.ItemsSource = circlingPlanes;

                            //display in trasnit planes
                            transitPlanes = airport2.transitList;
                            transitListView.ItemsSource = transitPlanes;

                        }
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(selected);
                Console.WriteLine(ex.Message);
            }
        }

        private void step_btn_Click(object sender, RoutedEventArgs e)
        {

            Console.WriteLine("here");
            displayAirports = masterInter.incrementAllAirports();
            Console.WriteLine("here");
            foreach (Airport airporttest in displayAirports)
            {
                Console.WriteLine(airporttest.airportID + airporttest.airportName);
            }
            Console.WriteLine("here");


//            string selected = airportListBox.SelectedItem.ToString();

            //retrieving the plane lists for the selected airport and displaying in listviews
            foreach (Airport airport2 in displayAirports)
            {
                if (airport2.airportName == selected)
                {
                    //display landed planes
                    landedPlanes = airport2.landedQueue;
                    landedListView.ItemsSource = landedPlanes;

                    //display entering-circling planes
                    enteringPlanes = airport2.enteringList;
                    enteringListView.ItemsSource = enteringPlanes;

                    //display circling planes
                    circlingPlanes = airport2.circlingList;
                    circlingListView.ItemsSource = circlingPlanes;

                    //display circling planes
                    circlingPlanes = airport2.circlingList;
                    circlingListView.ItemsSource = circlingPlanes;

                    //display in trasnit planes
                    transitPlanes = airport2.transitList;
                    transitListView.ItemsSource = transitPlanes;

                }
            }
        }
    }
}
