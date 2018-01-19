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
    public partial class Users_rent_Books : Form
    {
        LibraryEntities db = new LibraryEntities();
        User selectedUser;
        public Users_rent_Books(User usr)
        {
            selectedUser = usr;
            InitializeComponent();
            this.fillDgwData();
        }

        private void fillDgwData()
        {
            this.dgwRentBook.DataSource = db.Book_To_Users.Where(bk => bk.User_id == this.selectedUser.ID).Select(bk => new
            {
                Id = bk.ID,
                Username = bk.User.Name,
                Rent_Book = bk.Book.Name,
                Get_Date = bk.Get_date
            }).ToList();
        }

        private void dgwRentBook_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(this.dgwRentBook.Rows[e.RowIndex].Cells[0].Value);
            Book_To_Users book_to_user = db.Book_To_Users.Find(id);
            Book book = db.Books.FirstOrDefault(bk => bk.ID == book_to_user.Book_id);
            book.Available_count += 1;
            User user = db.Users.FirstOrDefault(us => us.ID == book_to_user.User_id);
            user.Rent_count -= 1;
            db.Book_To_Users.Remove(book_to_user);
            db.SaveChanges();
            this.fillDgwData();
        }
    }
}
