using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serializer
{
    public partial class Form1 : Form
    {
        string inputName;
        string inputAddress;
        int inputPhone;
        Person currentPerson;

        public Form1()
        {
            InitializeComponent(); 
        }

        void SetData()
        {
            inputName = txtName.Text;
            inputAddress = txtAddress.Text;
            inputPhone = Int32.Parse(txtPhone.Text);
            currentPerson = new Person(inputName, inputAddress, inputPhone);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FileNameCounter fileName = new FileNameCounter();
            SetData();
            string path = fileName.ReturnPathToSerializer();
            currentPerson.Serialize(path);
        }       
    }
}
