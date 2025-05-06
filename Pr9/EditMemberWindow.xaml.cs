using System.Windows;
using Pr9.entity;
using Pr9.repository;

namespace Pr9;

public partial class EditMemberWindow : Window
{
    private Context _context;
    private Member _member;

    public EditMemberWindow(Member member)
    {
        InitializeComponent();
        _context = new Context();
        _member = _context.members.FirstOrDefault(m => m.id == member.id);
        DataContext = _member;
        
        TxtName.Text = member.name;
        TxtEmail.Text = member.email;
    }

    private void SaveChanges_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TxtName.Text) || string.IsNullOrWhiteSpace(TxtEmail.Text))
        {
            MessageBox.Show("Заполните все поля", "Ошибка", 
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _context.members.Update(_member);
        _context.SaveChanges();
        DialogResult = true;
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}