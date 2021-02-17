using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Uwp.Controllers;
using Uwp.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static Tester TesterCurrent { get; set; }
        public Store Store { get; set; }
        public string PackageText { get { return tbPackageText.Text; } }
        public string FindText { get { return tbFindText.Text; } }
        public string Output { get { return tbOutput.Text; } set { tbOutput.Text = value; } }
        public MainPage()
        {
            this.InitializeComponent();
            QueriesToOracle oracle = new QueriesToOracle(this);
            Store = new Store(oracle);
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            TesterCurrent = new Tester(new PackageManager(this));
            
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            TesterCurrent.DoTest();
            //Store.Load();
        }
    }
}
