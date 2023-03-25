using addressbook.Models;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace addressbook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private ObservableCollection<Contact> contacts;
        private List<MenuItem> menuItems;
        public MainPage()
        {
            this.InitializeComponent();
            CrudGrid.Visibility = Visibility.Collapsed;
            contacts = new ObservableCollection<Contact>();
            ContactManager.GetAllContacts(contacts);

            menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-a-50.png",
                FirstAlphabet = Alphabet.A
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-b-50.png",
                FirstAlphabet = Alphabet.B
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-c-50.png",
                FirstAlphabet = Alphabet.C
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-d-50.png",
                FirstAlphabet = Alphabet.D
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-e-50.png",
                FirstAlphabet = Alphabet.E
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-f-50.png",
                FirstAlphabet = Alphabet.F
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-g-50.png",
                FirstAlphabet = Alphabet.G
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-h-50.png",
                FirstAlphabet = Alphabet.H
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-i-50.png",
                FirstAlphabet = Alphabet.I
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-j-50.png",
                FirstAlphabet = Alphabet.J
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-k-50.png",
                FirstAlphabet = Alphabet.K
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-l-50.png",
                FirstAlphabet = Alphabet.L
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-m-50.png",
                FirstAlphabet = Alphabet.M
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-n-50.png",
                FirstAlphabet = Alphabet.N
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-o-50.png",
                FirstAlphabet = Alphabet.O
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-p-50.png",
                FirstAlphabet = Alphabet.P
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-q-50.png",
                FirstAlphabet = Alphabet.Q
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-r-50.png",
                FirstAlphabet = Alphabet.R
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-s-50.png",
                FirstAlphabet = Alphabet.S
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-t-50.png",
                FirstAlphabet = Alphabet.T
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-u-26.png",
                FirstAlphabet = Alphabet.U
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-v-50.png",
                FirstAlphabet = Alphabet.V
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-w-50.png",
                FirstAlphabet = Alphabet.W
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-x-50.png",
                FirstAlphabet = Alphabet.X
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-y-50.png",
                FirstAlphabet = Alphabet.Y
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/icons8-z-50.png",
                FirstAlphabet = Alphabet.Z
            });

        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            CrudGrid.Visibility = Visibility.Visible;
            TableGrid.Visibility = Visibility.Collapsed;
            ContactDataGrid.SelectedItem = null;
            MenuItemsListView.SelectedItem = null;
            ClearTextbox();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            ContactManager.GetAllContacts(contacts);
            MenuItemsListView.SelectedItem = null;
            CrudGrid.Visibility = Visibility.Collapsed;
            TableGrid.Visibility = Visibility.Visible;
            ClearTextblock();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            TableGrid.Visibility = Visibility.Visible;
            CrudGrid.Visibility = Visibility.Collapsed;
            ClearTextblock();
            var selectedItem = ContactDataGrid.SelectedItem as Contact;
            if (selectedItem != null)
            {
                ContactManager.DeleteContact(contacts, selectedItem);

            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            TableGrid.Visibility = Visibility.Visible;
            CrudGrid.Visibility = Visibility.Visible;
            var selectedItem = ContactDataGrid.SelectedItem as Contact;
            if (selectedItem != null)
            {
                Name.Text = selectedItem.Name;
                if (selectedItem.MailingAddress != null)
                {
                    AddressLine1.Text = selectedItem.MailingAddress.AddressLine1 != null ? selectedItem.MailingAddress.AddressLine1 : string.Empty;
                    AddressLine2.Text = selectedItem.MailingAddress.AddressLine2 != null ? selectedItem.MailingAddress.AddressLine2 : string.Empty;
                    City.Text = selectedItem.MailingAddress.City != null ? selectedItem.MailingAddress.City : string.Empty;
                    State.Text = selectedItem.MailingAddress.State != null ? selectedItem.MailingAddress.State : string.Empty;
                    Zip.Text = selectedItem.MailingAddress.ZipCode != null ? selectedItem.MailingAddress.ZipCode : string.Empty;
                }

                Mobile.Text = selectedItem.Phone1 == null ? "Enter Mobile Number" : selectedItem.Phone1;
                Home.Text = selectedItem.Phone2 == null ? "Enter LandLine Number" : selectedItem.Phone2;
                Email.Text = selectedItem.Email == null ? "Enter Email" : selectedItem.Email;
                Url.Text = selectedItem.Url == null ? "Enter URL" : selectedItem.Url;
            }
        }

        private void SearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            TableGrid.Visibility = Visibility.Visible;
            //CrudGrid.Visibility = Visibility.Visible;
            ContactDataGrid.ItemsSource = contacts;
        }

        private void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            TableGrid.Visibility = Visibility.Visible;
            var cont = from s in contacts where s.Name.Contains(SearchAutoSuggestBox.Text)  select s;
            ContactDataGrid.ItemsSource = cont;
        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClearTextbox();
            ClearTextblock();
            var menuItem = (MenuItem)e.ClickedItem;
            ContactManager.GetContactsByAlphabet(contacts, menuItem.FirstAlphabet);
            //AlphabetTextBlock.Text = menuItem.FirstAlphabet.ToString();
        }

        private void ContactGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void ContactDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ContactDataGrid.SelectedItem as Contact;

            if (selectedItem != null)
            {
                if (CrudGrid.Visibility == Visibility.Visible)
                {
                    Name.Text = selectedItem.Name;
                    if (selectedItem.MailingAddress != null)
                    {
                        AddressLine1.Text = selectedItem.MailingAddress.AddressLine1 != null ? selectedItem.MailingAddress.AddressLine1 : string.Empty;
                        AddressLine2.Text = selectedItem.MailingAddress.AddressLine2 != null ? selectedItem.MailingAddress.AddressLine2 : string.Empty;
                        City.Text = selectedItem.MailingAddress.City != null ? selectedItem.MailingAddress.City : string.Empty;
                        State.Text = selectedItem.MailingAddress.State != null ? selectedItem.MailingAddress.State : string.Empty;
                        Zip.Text = selectedItem.MailingAddress.ZipCode != null ? selectedItem.MailingAddress.ZipCode : string.Empty;
                    }

                    Mobile.Text = selectedItem.Phone1 == null ? "Enter Mobile Number" : selectedItem.Phone1;
                    Home.Text = selectedItem.Phone2 == null ? "Enter LandLine Number" : selectedItem.Phone2;
                    Email.Text = selectedItem.Email == null ? "Enter Email" : selectedItem.Email;
                    Url.Text = selectedItem.Url == null ? "Enter URL" : selectedItem.Url;
                }

                NameDetail.Text = selectedItem.Name;
                AddressDetail.Text = selectedItem.MailingAddress.ToString() == null ? "Address:" : $"Address: {selectedItem.MailingAddress.ToString()}";
                Phone1Detail.Text = selectedItem.Phone1 == null ? $"Mobile:" : $"Mobile: {selectedItem.Phone1}";
                Phone2Detail.Text = selectedItem.Phone2 == null ? "Home:" : $"Home: {selectedItem.Phone2}";
                EmailDetail.Text = selectedItem.Email == null ? "Email:" : $"Email: {selectedItem.Email}";
                UrlDetail.Text = selectedItem.Url == null ? "Url:" : $"Url: {selectedItem.Url}";
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            var selectedItem = ContactDataGrid.SelectedItem as Contact;
            int id = selectedItem != null ? selectedItem.Id : -1;
            Contact c = new Contact(
                                id,
                                Name.Text,
                                new Address(
                                        AddressLine1.Text,
                                        AddressLine2.Text,
                                        City.Text,
                                        State.Text,
                                        Zip.Text),
                                Url.Text,
                                Email.Text,
                                Mobile.Text,
                                Home.Text);

            ContactManager.AddOrUpdateContact(contacts, c);

            //ClearTextblock();
            //ClearTextbox();
            //GetToHome();
            if(TableGrid.Visibility == Visibility.Collapsed)
            {
                TableGrid.Visibility = Visibility.Visible;
                ContactDataGrid.SelectedItem = contacts.Last();    
            }
            else
            {
                if(MenuItemsListView.SelectedItem == null)
                {
                    ContactDataGrid.SelectedItem = from contact in contacts
                                                   where contact.Id == id
                                                   select contact;
                }
                else
                {
                    var menuItem = (MenuItem)MenuItemsListView.SelectedItem;
                    ContactManager.GetContactsByAlphabet(contacts, menuItem.FirstAlphabet);
                }
                ClearTextblock();
                ClearTextbox();
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearTextbox();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TableGrid.Visibility == Visibility.Collapsed)
            {
                GetToHome();
            }
            else
            {
                CrudGrid.Visibility = Visibility.Collapsed; 
            }

        }
        private void GetToHome()
        {
            ContactManager.GetAllContacts(contacts);
            MenuItemsListView.SelectedItem = null;
            CrudGrid.Visibility = Visibility.Collapsed;
            TableGrid.Visibility = Visibility.Visible;
            ClearTextbox();
        }
        private void ClearTextblock()
        {
            NameDetail.Text = string.Empty;
            AddressDetail.Text = string.Empty;
            Phone1Detail.Text = string.Empty;
            Phone2Detail.Text = string.Empty;
            EmailDetail.Text = string.Empty;
            UrlDetail.Text = string.Empty;
        }

        private void ClearTextbox()
        {
            //ContactDataGrid.SelectedItem = null;
            Name.Text = string.Empty;
            Mobile.Text = string.Empty;
            Home.Text = string.Empty;
            Email.Text = string.Empty;
            Url.Text = string.Empty;
            AddressLine1.Text = string.Empty;
            AddressLine2.Text = string.Empty;
            City.Text = string.Empty;
            State.Text = string.Empty;
            Zip.Text = string.Empty;
        }
    }
}
