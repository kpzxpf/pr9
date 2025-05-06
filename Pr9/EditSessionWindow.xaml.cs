using System.Windows;
using Pr9.entity;
using Pr9.repository;

namespace Pr9;

public partial class EditSessionWindow : Window
{
    private Context _context;
    private Session _session;

    public EditSessionWindow(Session session)
    {
        InitializeComponent();
        _context = new Context();
        _session = _context.sessions.FirstOrDefault(s => s.id == session.id);
        DataContext = _session;
        LoadTrainings();
    }

    private void LoadTrainings()
    {
        CmbTrainings.ItemsSource = _context.trainings.ToList();
        CmbTrainings.DisplayMemberPath = "Name";
        CmbTrainings.SelectedValuePath = "Id";
        CmbTrainings.SelectedValue = _session.training_id;
    }

    private void SaveChanges_Click(object sender, RoutedEventArgs e)
    {
        if (DpDate.SelectedDate == null || CmbTrainings.SelectedItem == null)
        {
            MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _session.date = (DateTime)DpDate.SelectedDate;
        _session.training_id = (int)CmbTrainings.SelectedValue;
        _context.SaveChanges();
        DialogResult = true;
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}