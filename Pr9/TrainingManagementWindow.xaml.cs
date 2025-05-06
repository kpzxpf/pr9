using System.Windows;
using Microsoft.EntityFrameworkCore;
using Pr9.entity;
using Pr9.repository;

namespace Pr9;

public partial class TrainingManagementWindow : Window
{
    private Context _context;

    public TrainingManagementWindow()
    {
        InitializeComponent();
        _context = new Context();
        LoadData();
    }

    private void LoadData()
    {
        var trainings = _context.trainings
            .Include(t => t.trainer)  
            .Select(t => new 
            { 
                t.id, 
                t.name, 
                trainer_name = t.trainer != null ? t.trainer.name : "Без тренера" 
            })
            .ToList();

        DataGridTrainings.ItemsSource = trainings;
    }

    private void AddTraining_Click(object sender, RoutedEventArgs e)
    {
        AddTrainingWindow addTrainingWindow = new AddTrainingWindow();
        if (addTrainingWindow.ShowDialog() == true)
        {
            LoadData();
        }
    }

    private void EditTraining_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridTrainings.SelectedItem is Training selectedTraining)
        {
            EditTrainingWindow editTrainingWindow = new EditTrainingWindow(selectedTraining);
            if (editTrainingWindow.ShowDialog() == true)
            {
                LoadData();
            }
        }
    }

    private void DeleteTraining_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridTrainings.SelectedItem is Training selectedTraining)
        {
            _context.trainings.Remove(selectedTraining);
            _context.SaveChanges();
            LoadData();
        }
    }
}