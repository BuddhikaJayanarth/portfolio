using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using TrueMarbleBiz;
using System.Runtime.Serialization;
using System.IO;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TrueMarbleGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [CallbackBehavior(ConcurrencyMode=ConcurrencyMode.Multiple,UseSynchronizationContext =false)]
    public partial class MainWindow : ITMBizControllerCallback
    {
        int xaxis = 0;
        int yaxis = 0;
        int slideraddhistent = 1;
        private TrueMarbleBiz.TMBizController m_biz;
        private TrueMarbleBiz.HistEntry HE;
        TrueMarbleBiz.BrowseHistory History;
        public MainWindow()
        {
            InitializeComponent();

        }

        public void loader()
        {


            int zoom = (int)slider.Value;
            byte[] imagebuff;
            try
            {
                imagebuff = m_biz.LoadTile(zoom, xaxis, yaxis);
                MemoryStream MS = new MemoryStream(imagebuff);
                JpegBitmapDecoder JD = new JpegBitmapDecoder(MS, BitmapCreateOptions.None, BitmapCacheOption.None);
                var bitmap = BitmapFrame.Create(JD.Frames[0]);
                imgTile.Source = bitmap;
            }
            catch (Exception ex)
            {
               // Console.WriteLine(zoom);
                //Console.WriteLine(m_tmData.GetNumTilesAcross(zoom));
                //Console.WriteLine(xaxis);
                //Console.WriteLine(m_tmData.GetNumTilesDown(zoom));
                //Console.WriteLine(yaxis);
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NetTcpBinding tcpBinding = new NetTcpBinding();
            tcpBinding.MaxReceivedMessageSize = System.Int32.MaxValue;
            tcpBinding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;
            
            ChannelFactory<TMBizController> tmDataFactory;
            string surl = "net.tcp://localhost:50002/TMBiz";

            tmDataFactory = new DuplexChannelFactory<TMBizController>(this,tcpBinding, surl);

            m_biz = tmDataFactory.CreateChannel();

            //running VerifyTilesAsync()
            m_biz.VerifyTilesAsync();
            loader();
            int zoom = (int)slider.Value;
            m_biz.AddHisEntry(xaxis,yaxis,zoom);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

            loader();
        }

        private void btn_S_Click(object sender, RoutedEventArgs e)
        {

            int zoom = (int)slider.Value;
            int maxy = m_biz.GetNumTilesDown(zoom) -1;
            if (yaxis < maxy)
            {

                yaxis++;
                loader();
                m_biz.AddHisEntry(xaxis, yaxis, zoom);

            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int zoom = (int)slider.Value;
            xaxis = 0;
            yaxis = 0;
            loader();
            if (slideraddhistent == 1)
            {
                m_biz.AddHisEntry(xaxis, yaxis, zoom);
            }
            slideraddhistent = 1;
        }

        private void btn_W_Click(object sender, RoutedEventArgs e)
        {
            int zoom = (int)slider.Value;
            if (xaxis > 0)
            {

                xaxis--;
                loader();
                m_biz.AddHisEntry(xaxis, yaxis, zoom);

            }
        }

        private void btn_N_Click(object sender, RoutedEventArgs e)
        {
            int zoom = (int)slider.Value;
            if (yaxis > 0)
            {

                yaxis--;
                loader();
                m_biz.AddHisEntry(xaxis, yaxis, zoom);

            }
        }

        private void btn_E_Click(object sender, RoutedEventArgs e)
        {
            int zoom = (int)slider.Value;
            int maxx = m_biz.GetNumTilesAcross(zoom) - 1;
            if (xaxis < maxx)
            {

                xaxis++;
                loader();
                m_biz.AddHisEntry(xaxis, yaxis, zoom);

            }
        }

        public void OnVerificationComplete(bool x)
        {
            if(x == true) {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("All Tiles Loaded");
            }
            else
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("Tile Error");
            }

        }

        public void CloseIt()
        {
            System.Threading.Thread.Sleep(5000);
            Microsoft.VisualBasic.Interaction.AppActivate(
                System.Diagnostics.Process.GetCurrentProcess().Id);
            System.Windows.Forms.SendKeys.SendWait(" ");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            int curridx = m_biz.GetCurrentIndex();
            if (curridx > 0)
            {
                int currentzoom = (int)slider.Value;
                HE = m_biz.HistBack();
                xaxis = HE.x;
                yaxis = HE.y;
                if (currentzoom != HE.zoom)
                {
                    slideraddhistent = 0;
                    slider.Value = HE.zoom;
                }
                else
                {
                    loader();
                }
            }
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            int curridx = m_biz.GetCurrentIndex();
            int lastidx = m_biz.GetLastIndex();
            if (curridx < lastidx)
            {
                int currentzoom = (int)slider.Value;
                HE = m_biz.HistForward();
                xaxis = HE.x;
                yaxis = HE.y;
                if (currentzoom != HE.zoom)
                {
                    slideraddhistent = 0;
                    slider.Value = HE.zoom;
                }
                else
                {
                    loader();
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            History = m_biz.GetFullHistory();
            //Note: It may required to run Visual Studio in administrator mode fro filestream to work
            FileStream f = new FileStream("C:/History.xml", FileMode.Create,FileAccess.Write);

            DataContractSerializer sz = new DataContractSerializer(typeof(BrowseHistory));
            sz.WriteObject(f, History);
            f.Close();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            //Note: It may required to run Visual Studio in administrator mode fro filestream to work
            FileStream f = new FileStream("C:/History.xml", FileMode.Open, FileAccess.Read);
            DataContractSerializer sz = new DataContractSerializer(typeof(BrowseHistory));
            History = (BrowseHistory)sz.ReadObject(f);
            f.Close();
            m_biz.SetFullHistory(History);

            int currentzoom = (int)slider.Value;
            HE = m_biz.GetCurrHistEntry();
            xaxis = HE.x;
            yaxis = HE.y;
            if (currentzoom != HE.zoom)
            {
                slideraddhistent = 0;
                slider.Value = HE.zoom;
            }
            else
            {
                loader();
            }

        }

        private void ShowHistory_Click(object sender, RoutedEventArgs e)
        {
            History = m_biz.GetFullHistory();
            DisplayHistory disp = new DisplayHistory(History);
            disp.Show();
        }
    }
}
