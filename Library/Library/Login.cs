using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Model;

namespace Library
{
    public partial class Login : Form
    {
        LibraryEntities db = new LibraryEntities();
        
        public User selectedUser;
        public Login()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register rgs = new Register();
            rgs.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if(Extensions.checkAllValues(new string[] { username, password},
                String.Empty))
            {
                checkUsernameAndPassword(username, password);               
            }
            else
            {
                ShowMessage("Username and/or password fields should be filled.");
            }
        }

        private void checkUsernameAndPassword(string username, string password)
        {
            string hashedPassword = Extensions.getHashCode(password);
            User usr = db.Users.FirstOrDefault(us => us.Username == username &&
            us.Password == hashedPassword);
            if(usr != null)
            {
                selectedUser = usr;
                LibraryHomePage lbh = new LibraryHomePage(selectedUser);
                lbh.ShowDialog();
            }
            else
            {
                ShowMessage("Username and/or password are incorrect.");
                SuggestMessage("You should create new user.");
            }
        }

        private void ShowMessage(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void SuggestMessage(string message)
        {
            lblSuggest.Text = message;
            lblSuggest.Visible = true;
        }

       
    }
}
