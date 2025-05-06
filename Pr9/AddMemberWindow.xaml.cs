using System.Windows;
using Pr9.entity;
using Pr9.repository;

namespace Pr9;

public partial class AddMemberWindow : Window
{
    private Context _context;
    private Member _member;

    public AddMemberWindow()
    {
        InitializeComponent();
        _context = new Context();
        _member = new Member();
    }

    private void SaveMember_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TxtName.Text) || string.IsNullOrWhiteSpace(TxtEmail.Text))
        {
            MessageBox.Show("Заполните все поля", 
                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _member.name = TxtName.Text;
        _member.email = TxtEmail.Text;
        
        _context.members.Add(_member);
        _context.SaveChanges();
        DialogResult = true;
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}