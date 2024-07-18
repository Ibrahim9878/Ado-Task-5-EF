using Microsoft.EntityFrameworkCore;

namespace Task_EF
{
    public partial class Form1 : Form
    {
        LibraryContext? db = null;
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = new List<string>() { "Authors", "Themes", "Categories" };
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (db = new())
            {
                var a = comboBox1.SelectedItem as string;
                if (a!.StartsWith("A"))
                    comboBox2.DataSource = db.Authors.ToList();
                else if (a!.StartsWith("T"))
                    comboBox2.DataSource = db.Themes.ToList();
                else
                    comboBox2.DataSource = db.Categories.ToList();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (db = new())
            {
                var a = comboBox1.SelectedItem as string;

                if (a!.StartsWith("A"))
                {
                    var b = comboBox2.SelectedItem as Author;
                    var list = db.Books.Where(f => f.IdAuthor == b!.Id).ToList();
                    listBox1.DataSource = list;
                }

                else if (a!.StartsWith("T"))
                {
                    var b = comboBox2.SelectedItem as Theme;
                    var list = db.Books.Where(f => f.IdThemes == b!.Id).ToList();
                    listBox1.DataSource = list;
                }
                else
                {
                    var b = comboBox2.SelectedItem as Category;
                    var list = db.Books.Where(f => f.IdCategory == b!.Id).ToList();
                    listBox1.DataSource = list;
                }
            }
        }
    }
}
