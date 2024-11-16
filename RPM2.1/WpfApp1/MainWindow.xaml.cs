using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> Books { get; set; }

        public ICommand AddBookCommand { get; }
        public ICommand EditBookCommand { get; }
        public ICommand DeleteBookCommand { get; }

        public MainWindow()
        {
            InitializeComponent();

            Books = new ObservableCollection<Book>();
            LV1.ItemsSource = Books;

            AddBookCommand = new RelayCommand(AddBook);
            EditBookCommand = new RelayCommand(EditBook, CanEditOrDelete);
            DeleteBookCommand = new RelayCommand(DeleteBook, CanEditOrDelete);
        }

        private void AddBook()
        {
            
            Books.Add(new Book { Title = "New Book", Author = "Author Name", Year = 2023, Genre = "Fiction", NumberOfPages = 300 });
        }

        private void EditBook()
        {
            if (LV1.SelectedItem is Book selectedBook)
            {
                
                selectedBook.Title = "Edited Book Title"; 
            }
        }

        private void DeleteBook()
        {
            if (LV1.SelectedItem is Book selectedBook)
            {
                Books.Remove(selectedBook);
            }
        }

        private bool CanEditOrDelete()
        {
            return LV1.SelectedItem is Book;
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int NumberOfPages { get; set; }
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