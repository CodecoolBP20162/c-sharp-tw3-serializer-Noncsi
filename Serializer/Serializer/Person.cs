using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializer
{
    [Serializable]
    class Person
    {
        [NonSerialized] int id;
        public string name;
        public string address;
        public int phone;
        public DateTime dateOfRecording;


        public Person(string name, string address, int phone)
        {
            id++;
            this.name = name;
            this.address = address;
            this.phone = phone;
            dateOfRecording = DateTime.Now;
        }

        public void Serialize(string output)
        {
            if (File.Exists(output)) File.Delete(output);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream filestream = new FileStream(output, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(filestream, this);
        }

        public static Person Deserialize(string fileNameToCall)
        {
            Stream filestream = new FileStream(fileNameToCall, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            Person person = (Person)formatter.Deserialize(filestream);
            filestream.Close();
            return person;
        }
    }
}
