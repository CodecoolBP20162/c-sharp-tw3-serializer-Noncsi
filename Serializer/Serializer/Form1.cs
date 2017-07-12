using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Serializer
{
    public partial class Form1 : Form
    {
        Person currentPerson;
        FileNameCounter fileName;
        List<Person> people = new List<Person>();
        int index;

        public Form1()
        {
            InitializeComponent(); 
        }

        void SetData()
        {
            currentPerson = new Person(txtName.Text, txtAddress.Text, Int32.Parse(txtPhone.Text));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ( txtName.Text.Length == 0 || txtAddress.Text.Length == 0 || txtPhone.Text.Length == 0 ) MessageBox.Show("Invalid input.");
            else
            {
                SetData();
                string path = fileName.ReturnPathToSerializer();
                if (Int32.Parse(fileName.finalFileName) <= 99) currentPerson.Serialize(path);
                else MessageBox.Show("I wasn't allowed to do more than 99 files.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileName = new FileNameCounter();
            FileInfo[] files = fileName.GetAllFiles();
            if (files.Length != 0)
            {              
                foreach (FileInfo file in files)
                {
                    currentPerson = Person.Deserialize(file.FullName);
                    people.Add(currentPerson);
                }
                index = 0;
                SetTextBoxes();
            }
        }

        void SetTextBoxes()
        {
            txtName.Text = people[index].name.ToString();
            txtAddress.Text = people[index].address.ToString();
            txtPhone.Text = people[index].phone.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (index < people.Count-1)
            {
                ++index;
                SetTextBoxes();
            }
            else
            {
                MessageBox.Show("You are on the last person");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                --index;
                SetTextBoxes();
            } else
            {
                MessageBox.Show("You are on the first person");
            }           
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            index = 0;
            SetTextBoxes();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            index = people.Count - 1;
            SetTextBoxes();
        }
    }
}
