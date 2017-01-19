using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf2
{
    public partial class MainWindow : Window
    {
        Controller controller;
        public MainWindow()
        {
            controller = Controller.GetInstance();
            InitializeComponent();

            countLabel.Content = controller.PersonCount;
            countIndex.Content = controller.PersonIndex;

            newBtn.IsEnabled = false;
        }

        private void SetButton()
        {
            newBtn.IsEnabled = (firstNameTxtbox.Text != "" && lastNameTxtbox.Text != "" && ageTxtbox.Text != "" && numberTxtbox.Text != "");
        }
        private void newBtn_Click(object sender, RoutedEventArgs e)
        {
            controller.AddPerson();
            controller.CurrentPerson.FirstName = firstNameTxtbox.Text;
            controller.CurrentPerson.LastName = lastNameTxtbox.Text;
            controller.CurrentPerson.Age = int.Parse(ageTxtbox.Text);
            controller.CurrentPerson.TelephoneNr = numberTxtbox.Text;

            firstNameTxtbox.Clear();
            lastNameTxtbox.Clear();
            ageTxtbox.Clear();
            numberTxtbox.Clear();

            countLabel.Content = controller.PersonCount;
            countIndex.Content = controller.PersonIndex;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            controller.DeletePerson();

            firstNameTxtbox.Clear();
            lastNameTxtbox.Clear();
            ageTxtbox.Clear();
            numberTxtbox.Clear();

            countLabel.Content = controller.PersonCount;
            countIndex.Content = controller.PersonIndex;
        }

        private void upBtn_Click(object sender, RoutedEventArgs e)
        {
            controller.NextPerson();

            firstNameTxtbox.Text = controller.CurrentPerson.FirstName;
            lastNameTxtbox.Text = controller.CurrentPerson.LastName;
            ageTxtbox.Text = controller.CurrentPerson.Age.ToString();
            numberTxtbox.Text = controller.CurrentPerson.TelephoneNr;

            countLabel.Content = controller.PersonCount;
            countIndex.Content = controller.PersonIndex;
        }

        private void dwnBtn_Click(object sender, RoutedEventArgs e)
        {
            controller.PrevPerson();

            firstNameTxtbox.Text = controller.CurrentPerson.FirstName;
            lastNameTxtbox.Text = controller.CurrentPerson.LastName;
            ageTxtbox.Text = controller.CurrentPerson.Age.ToString();
            numberTxtbox.Text = controller.CurrentPerson.TelephoneNr;

            countLabel.Content = controller.PersonCount;
            countIndex.Content = controller.PersonIndex;
        }
        private void numberTxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }
        private void firstNameTxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }
        private void lastNameTxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }
        private void ageTxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }
    }
}
