using System.Windows;
using Pr9.entity;
using Pr9.repository;

namespace Pr9;

public partial class AddSessionWindow : Window
{
    private Context _context;
    private Session _session;

    public AddSessionWindow()
    {
        InitializeComponent();
        _context = new Context();
        _session = new Session();
        DataContext = _session;
        LoadTrainings();
    }

    private void LoadTrainings()
    {
        CmbTrainings.ItemsSource = _context.trainings.ToList();
        CmbTrainings.DisplayMemberPath = "name";
        CmbTrainings.SelectedValuePath = "id";
    }

    private void SaveSession_Click(object sender, RoutedEventArgs e)
    {
        if (DpDate.SelectedDate == null || CmbTrainings.SelectedItem == null)
        {
            MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _session.date = (DateTime)DpDate.SelectedDate;
        _session.training_id = (int)CmbTrainings.SelectedValue;
        _context.sessions.Add(_session);
        _context.SaveChanges();
        DialogResult = true;
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}