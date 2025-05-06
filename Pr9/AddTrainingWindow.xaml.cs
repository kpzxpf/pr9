using System.Windows;
using Pr9.entity;
using Pr9.repository;

namespace Pr9;

public partial class AddTrainingWindow : Window
{
    private Context _context;
    private Training _training;

    public AddTrainingWindow()
    {
        InitializeComponent();
        _context = new Context();
        _training = new Training();
        DataContext = _training;
        LoadTrainers();
    }

    private void LoadTrainers()
    {
        CmbTrainers.ItemsSource = _context.trainers.ToList();
        CmbTrainers.DisplayMemberPath = "name";
        CmbTrainers.SelectedValuePath = "id";
    }

    private void SaveTraining_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TxtTrainingName.Text) || CmbTrainers.SelectedItem == null)
        {
            MessageBox.Show("Заполните все поля", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _training.name = TxtTrainingName.Text;
        _training.trainer_id = (int)CmbTrainers.SelectedValue;
        _context.trainings.Add(_training);
        _context.SaveChanges();
        DialogResult = true;
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}