using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Interface;
using INNForm;

namespace PassportForm1
{
    public partial class Passport : Form, ITest
    {
        public Passport()
        {
            InitializeComponent();
        }
        Form formINN;



        public string ByIssued = "Россия,Санкт-Петербург";
        public string DateofIssue = "26.12.1997";
        public string NameOrganization = "8";
        public string Surname = "Sinashkina";
        public string NameOfPerson = "Anna";
        public string Patronymic = "Aleksandrovna";
        public string CountryofBirth = "Russia";
        public string DateofBirth = "26.11.1997";
        public string CityofBirth = "Saint-Petersburg";
        public Dictionary<TextBox,string> value=new Dictionary<TextBox, string>();

        public void AddInformationInControl(TextBox textbox, String text)
        {

            textbox.Text = text;

        }

        public void CompareString(TextBox textbox, String text)

        {

     
             
            string path =
                @"C:\Users\guest2\Documents\Visual Studio 2015\TestProject\PassportForm1\PassportForm1\LOGPassportForm.txt";




            using (FileStream file = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(file))

                {


                    if (textbox.Text != text)
                    {


                        sw.WriteLine(" No converge the value:" + text);
                    }

                    else
                    {
                        sw.WriteLine("Converge the value:" + text);
                    }
                }
            }
        }
        public Dictionary<TextBox, string> GetDictionary(){

            value.Add(ByIssue, ByIssued);
            value.Add(Date, DateofIssue);
            value.Add(NameOrg, NameOrganization);
            value.Add(SurnamePeople, Surname);
            value.Add(NamePerson, NameOfPerson);
            value.Add(PatronymicPeople, Patronymic);
            value.Add(CountryPeople, CountryofBirth);
            value.Add(DateofbirthPeople, DateofBirth);
            value.Add(CountruofBirthPeople, CityofBirth);
            return value;

        }

        public void doTest()

        {
            GetDictionary();
            foreach (KeyValuePair<TextBox, string> keyvalue in value)
            {
                AddInformationInControl(keyvalue.Key, keyvalue.Value);
               
            }

            this.ShowDialog();
            foreach(KeyValuePair<TextBox, string> keyvalue in value)
            {
                 
                CompareString(keyvalue.Key, keyvalue.Value);
            }

             
             
            this.Close();



        }

        public void dotestModal()
        {
            GetDictionary();
            foreach (KeyValuePair<TextBox, string> keyvalue in value)
            {
                AddInformationInControl(keyvalue.Key, keyvalue.Value);

            }

            this.Show();
            foreach (KeyValuePair<TextBox, string> keyvalue in value)
            {

                CompareString(keyvalue.Key, keyvalue.Value);
            }

            Assembly assem = Assembly.LoadFrom(
                @"C:\Users\guest2\Documents\Visual Studio 2015\TestProject\INNForm\INNForm\bin\Debug\INNForm.exe");

            Type[] typess = assem.GetTypes();
            foreach (var item in typess)
            {
                var iTestInterfaseType = item.GetInterface(typeof(ITest).ToString());
                if (iTestInterfaseType != null)
                {
                    formINN = (Form)Activator.CreateInstance(item);
                     
                }


            }
    formINN.ShowDialog(this);
            this.Close();
        }




    }

}
    

