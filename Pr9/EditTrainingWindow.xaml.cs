using System.Windows;
using Pr9.entity;
using Pr9.repository;

namespace Pr9;

public partial class EditTrainingWindow : Window
{
    private Context _context;
    private Training _training;

    public EditTrainingWindow(Training training)
    {
        InitializeComponent();
        _context = new Context();
        _training = _context.trainings.FirstOrDefault(t => t.id == training.id);
        DataContext = _training;
        LoadTrainers();
    }

    private void LoadTrainers()
    {
        CmbTrainers.ItemsSource = _context.trainers.ToList();
        CmbTrainers.DisplayMemberPath = "Name";
        CmbTrainers.SelectedValuePath = "Id";
        CmbTrainers.SelectedValue = _training.trainer_id;
    }

    private void SaveChanges_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TxtTrainingName.Text) || CmbTrainers.SelectedItem == null)
        {
            MessageBox.Show("Заполните все поля", "Ошибка", 
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _training.name = TxtTrainingName.Text;
        _training.trainer_id = (int)CmbTrainers.SelectedValue;
        _context.SaveChanges();
        DialogResult = true;
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}