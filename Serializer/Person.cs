using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Serializer
{
    [Serializable()]

    class Person : ISerializable , IDeserializationCallback
    {

        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int serialNumber { get; set; }
        public DateTime dateRecording { get; set; }
        public Person()
        {
        }

        public Person(string name, string address, string phone, int serialNumber, DateTime dateRecording)
        {
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.serialNumber = serialNumber;
            this.dateRecording = dateRecording;
        }

        public Person(string name, string address, string phone, int serialNumber)
        {
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.serialNumber = serialNumber;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void seralizer()
        {
            Stream stream = File.Open(@"d:\teszt\person" + serialNumber + ".dat", FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                binaryFormatter.Serialize(stream, this);
            }
            catch(SerializationException e)
            {
                MessageBox.Show("Fail" + e.Message);
            }
            finally
            {
                stream.Close();
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", name);
            info.AddValue("address", address);
            info.AddValue("phone", phone);
            info.AddValue("dataRecording", dateRecording);
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            name = (string)info.GetValue("name", typeof(string));
            address = (string)info.GetValue("address", typeof(string));
            phone = (string)info.GetValue("phone", typeof(string));
            //dateRecording = (DateTime)info.GetValue("DataRecording", typeof(DateTime));
        }


        public Person Deserialization(int serialNumber)
        {
            
                        
            Stream stream = new FileStream(@"D:\teszt\person" + serialNumber + ".dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            Person newperson = (Person)formatter.Deserialize(stream);
            stream.Close();
            return newperson;


        }

        public void OnDeserialization(object sender)
        {            
            string[] directory = Directory.GetFiles(@"d:\teszt\");
            serialNumber = directory.Length;
            
        }
    }
}
