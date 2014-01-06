using DataServiceTest.SvcReference;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
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

namespace DataServiceTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Uri svcUrl = new Uri("http://localhost:3298/DemoService.svc");
        TestDbEntities context = new TestDbEntities(svcUrl);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FetchAll_Click(object sender, RoutedEventArgs e)
        {
            //DataServiceCollection<Person> peopleCollection = new DataServiceCollection<Person>(context);

            //var allPeople=context.People.ToList();
            //LstOfPeople.ItemsSource = allPeople;
            
        }

        private void FetchAll()
        {
            var all = from p in context.People select p;

            DataServiceCollection<Person> peopleCollection = new DataServiceCollection<Person>(all);

            //var allPeople=context.People.ToList();
            LstOfPeople.DataContext = peopleCollection;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FetchAll();
            
        }

        private void BahadurPeopleButton_Click(object sender, RoutedEventArgs e)
        {
            var bahadurPeople = from p in context.People where p.LastName.Equals("Bahadur", StringComparison.OrdinalIgnoreCase) select p;

            DataServiceCollection<Person> peopleCollection = new DataServiceCollection<Person>(bahadurPeople);

            //var allPeople=context.People.ToList();
            LstOfPeople.DataContext = peopleCollection;
        }
    }
}
