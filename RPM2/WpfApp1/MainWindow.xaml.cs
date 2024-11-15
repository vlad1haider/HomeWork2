using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int numCounter = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_B_Click(object sender, RoutedEventArgs e)
        {
            numCounter++;
            LV1.Items.Add(numCounter);
        }

        private void Del_B_Click(object sender, RoutedEventArgs e)
        {
            if (LV1.SelectedItem != null)
            {
                LV1.Items.Remove(LV1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Элемент не выбран");
            }
        }

        private void Clear_B_Click(object sender, RoutedEventArgs e)
        {
            LV1.Items.Clear();
            numCounter = -1;
        }
    }



public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

}
