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
        string name;
        string address;
        int phone;
        DateTime dateOfRecording;


        public Person(string name, string address, int phone)
        {
            id++;
            this.name = name;
            this.address = address;
            this.phone = phone;
            dateOfRecording = DateTime.Now;
        }

        public int GetId()
        {
            return id;
        }

        public void Serialize(string output)
        {
            if (File.Exists(output))
            {
                File.Delete(output);
            }
            // Create file to save the data
            FileStream filestream = new FileStream(output, FileMode.Create);

            // Create and use a BinaryFormatter object to perform the serialization
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(filestream, this);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }

            // Close the file
            filestream.Close();
        }

        public override string ToString()
        {
            return "id: " + id + "\n" +
                   "name: " + name + "\n" +
                   "address: " + address + "\n" +
                   "phone: " + phone + "\n" +
                   "Date of recording: " + dateOfRecording;
        }
    }
}
