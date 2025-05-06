using System.Windows;
using Pr9.entity;
using Pr9.repository;

namespace Pr9;

public partial class MainWindow : Window
{
    private Context _context;

    public MainWindow()
    {
        InitializeComponent();
        _context = new Context();
        LoadData();
    }

    private void LoadData()
    {
        DataGridMembers.ItemsSource = _context.members.ToList();
    }

    private void AddMember_Click(object sender, RoutedEventArgs e)
    {
        AddMemberWindow memberWindow = new AddMemberWindow();
        if (memberWindow.ShowDialog() == true)
        {
            LoadData();
        }
    }

    private void EditMember_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridMembers.SelectedItem is Member selectedMember)
        {
            EditMemberWindow memberWindow = new EditMemberWindow(selectedMember);
            if (memberWindow.ShowDialog() == true)
            {
                LoadData();
            }
        }
    }

    private void DeleteMember_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridMembers.SelectedItem is Member selectedMember)
        {
            _context.members.Remove(selectedMember);
            _context.SaveChanges();
            LoadData();
        }
    }
    
    private void OpenTrainingManagement_Click(object sender, RoutedEventArgs e)
    {
        TrainingManagementWindow trainingManagementWindow = new TrainingManagementWindow();
        trainingManagementWindow.ShowDialog();
    }

    private void OpenScheduleManagement_Click(object sender, RoutedEventArgs e)
    {
        ScheduleManagementWindow scheduleManagementWindow = new ScheduleManagementWindow();
        scheduleManagementWindow.ShowDialog();
    }
}