using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serializer
{
    public partial class Form1 : Form
    {
        int serialNum = 0;
        Person person = new Person();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadPerson();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
            if(serialNum < 99)
            {
                serialNum += 1;
                person = new Person(textName.Text, textAddress.Text, textPhone.Text, serialNum);
                person.seralizer();    
            }
        }

        public void loadPerson()
        {
            try
            {
                person = person.Deserialization(serialNum = 1);
                textPhone.Text = person.phone;
                textName.Text = person.name;
                textAddress.Text = person.address;          
          
            }
            catch
            {
                MessageBox.Show("nincs itt semmi látnivaló");
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            serialNum = serialNum + 1;
            person = person.Deserialization(serialNum);
            textPhone.Text = person.phone;
            textName.Text = person.name;
            textAddress.Text = person.address;
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            serialNum = serialNum - 1;
            person = person.Deserialization(serialNum);
            textPhone.Text = person.phone;
            textName.Text = person.name;
            textAddress.Text = person.address;
        }

        private void lastButton_Click(object sender, EventArgs e)
        {
            string[] directory = Directory.GetFiles(@"D:\teszt\");
            serialNum = directory.Length;
            person = person.Deserialization(serialNum);
            textPhone.Text = person.phone;
            textName.Text = person.name;
            textAddress.Text = person.address;

        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {

        }
    }
}
