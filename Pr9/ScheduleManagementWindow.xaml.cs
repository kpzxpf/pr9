using System.Windows;
using Pr9.entity;
using Pr9.repository;

namespace Pr9;

public partial class ScheduleManagementWindow : Window
{
    private Context _context;

    public ScheduleManagementWindow()
    {
        InitializeComponent();
        _context = new Context();
        LoadData();
    }

    private void LoadData()
    {
        DataGridSchedule.ItemsSource = _context.sessions.ToList();
    }

    private void AddSession_Click(object sender, RoutedEventArgs e)
    {
        AddSessionWindow addSessionWindow = new AddSessionWindow();
        if (addSessionWindow.ShowDialog() == true)
        {
            LoadData();
        }
    }

    private void EditSession_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridSchedule.SelectedItem is Session selectedSession)
        {
            EditSessionWindow editSessionWindow = new EditSessionWindow(selectedSession);
            if (editSessionWindow.ShowDialog() == true)
            {
                LoadData();
            }
        }
    }

    private void DeleteSession_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridSchedule.SelectedItem is Session selectedSession)
        {
            _context.sessions.Remove(selectedSession);
            _context.SaveChanges();
            LoadData();
        }
    }
}