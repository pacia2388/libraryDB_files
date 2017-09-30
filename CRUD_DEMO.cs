using LibrarySystemDemo.DAL;
using System;
using System.Windows.Forms;
using LibrarySystemDemo.Model2;
using BookType = LibrarySystemDemo.Models.BookType;

namespace LibrarySystemDemo
{
    public partial class CrudDemo : Form
    {
        public CrudDemo()
        {
            InitializeComponent();
        }

        private void btnAddBookType_Click(object sender, EventArgs e)
        {
            var bookType = new BookType
            {
                BookTypeID = Convert.ToInt32(txtID.Text),
                BookTypeName = txtName.Text,
                Memo = txtMemo.Text
            };

            var result = dalBookType.AddBookType(bookType);
            var dialogResult = result > 0 ? MessageBox.Show("Success") : MessageBox.Show("Failed");
        }

        private void btnRefreshDataGrid_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dalBookType.GetBookTypes();
            ApplicatopmUser user = new ApplicatopmUser();
            user.
        }

        private void btnSaveBookType_Click(object sender, EventArgs e)
        {
            var bookType = new BookType
            {
                BookTypeID = Convert.ToInt32(txtID.Text),
                BookTypeName = txtName.Text,
                Memo = txtMemo.Text
            };

            var result = dalBookType.SaveBookType(bookType);
            var dialogResult = result > 0 ? MessageBox.Show("Success") : MessageBox.Show("Failed");
        }

        private void btnDeleteBookType_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(txtID.Text);
            var result = dalBookType.DeleteBookType(id);
            var dialogResult = result > 0 ? MessageBox.Show("Success") : MessageBox.Show("Failed");
        }

        private void txtID_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtName_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMemo_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
