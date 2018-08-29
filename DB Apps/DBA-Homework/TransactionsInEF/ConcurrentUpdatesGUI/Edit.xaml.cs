using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
using System.Windows.Shapes;
using NewsDB.Data;

namespace ConcurrentUpdatesGUI
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit()
        {
            InitializeComponent();
        }

        public NewsDBContext Context { get; set; }

        public dynamic Data { get; set; }

        private void Save(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Data.Content = textBox.Text;
                Context.SaveChanges();
                Success Success = new Success();
                Success.Show();
                Close();
            }
            catch (DbUpdateConcurrencyException exc)
            {
                exc.Entries.Single().Reload();
                Error Error = new Error();
                Error.Show();
                Close();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
        }

        private void Edit_OnLoaded(object sender, RoutedEventArgs e)
        {
            Context = new NewsDBContext();

            Data = Context.News.Find(1);
        }
    }
}
