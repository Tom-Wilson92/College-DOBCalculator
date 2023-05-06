using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timerDate_Tick(object sender, EventArgs e)
        {


            // Display the time and date in 2 labels 
            labeldate.Text = DateTime.Now.ToLongDateString();
            labeltime.Text = DateTime.Now.ToLongTimeString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Starts the date and time loading
            timerDateandTime.Start();
            // making an array for the months 
            String[] arrayOfMonths = { "January", "Feburary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            // storing a variable that is the current year
            var year = DateTime.Now.Year;
            // uses the variable above and then counts down to 1920
            while (year >= 1920)
            {
                comboBoxYears.Items.Add(year);
                year = year - 1;

            }
            //populates the combobox with 1 - 31 for the days
            int day = 1;

            while (day <= 31)
            {
                comboBoxDay.Items.Add(day);
                day = day + 1;
            }
            //uses the array to populate the comboboxmonths with the months
            int i = 0;
            while (i < arrayOfMonths.Length)
            {
                comboBoxMonths.Items.Add(arrayOfMonths[i]);
                i++;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDateAndTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {


        }





        private void buttonOk_Click(object sender, EventArgs e)
        {
            // name the variable
            DateTime dob;
            
            
             try
            {
                // defining the variable and checking its valid
                dob = new DateTime(Convert.ToInt32(comboBoxYears.SelectedItem), comboBoxMonths.SelectedIndex + 1, Convert.ToInt32(comboBoxDay.SelectedItem));
            }
            catch (Exception)
            {
                // gives an error message if the date is invalid as well as displaying a message box icon and giving you the option to retry or exit the program
                DialogResult dialogue = MessageBox.Show("Sorry " + textBoxNameinput.Text + "but the date you entered is not a valid date", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                // if user clicks retry return to from if they click cancel close application
                if (dialogue == DialogResult.Retry)
                {
                    return;
                }
                else if (dialogue == DialogResult.Cancel)
                {
                    Application.Exit();
                    return;
                
                }

            }




            dob = new DateTime(Convert.ToInt32(comboBoxYears.SelectedItem), comboBoxMonths.SelectedIndex + 1, Convert.ToInt32(comboBoxDay.SelectedItem));


            
            
                // creates a time span variable called diff that takes the date and works out the difference between the variable dob
               TimeSpan diff = DateTime.Now - dob;
                
              
                // this converts the date and time variable into a number of days 
                int days = (int)diff.TotalDays;
                //same as above but hours
                int hours = (int)diff.TotalHours;
                //minutes
                int minutes = (int)diff.TotalMinutes;
                //seconds
                int seconds = (int)diff.TotalSeconds;
                //weeks
                int weeks = days / 7;

                
                // creating a datetime variable which takes the current year and adds one as well as taking the month and day from the combo boxes this is for working out how long till your next birthday
                DateTime future = new DateTime(DateTime.Now.Year + 1, comboBoxMonths.SelectedIndex + 1, Convert.ToInt32(comboBoxDay.SelectedItem));
                // works out the difference in time between the variable date future
                TimeSpan futures = future - DateTime.Now;
                //converts from a date and time variable to just days
                int futuredate = (int)futures.TotalDays;
           

             


               // makes a variable and divides total days by days in a year to work out the number of years old someone is 
                int years = days / 365;
                // creating variable to divide total days into average days in a month 30.4
                double months = days / 30.4;
                // then converting the variable from a double to an integar as I felt it was better to display a whole number
                int months2 = Convert.ToInt32(months);

            //creating a string from the textbox input
            string firstName = textBoxNameinput.Text;
            string lastName = textBoxLastNameInput.Text;

            // forces the string to have a capital letter first and lowercase after
            lastName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(lastName.ToLower());
            // forces the string to have a capital letter first and lowercase after
            firstName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(firstName.ToLower());

           



            //creates a list to store errors in
            List<string> errors = new List<string>();

                // checks if the text box is empty 
                if (string.IsNullOrEmpty(textBoxNameinput.Text))
                {
                    // adds an error to the list
                    errors.Add("First Name");
                }
                //checks if there ís an empty box 
                if (string.IsNullOrEmpty(textBoxLastNameInput.Text))
                {
                    //adds an error if there is one
                    errors.Add("Last Name");
                }

                // if errors are over 0
                if (errors.Count > 0)
                {
                    // inserts this text into the list
                    errors.Insert(0, "The following fields are empty:");
                    // creates a variable message which adds together the errors if there is multiple and puts them onto seperate lines
                    string message = string.Join(Environment.NewLine, errors);
                    // displays á message box with the message variable and adds a warning symbol and titles the message box error
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // returns back to form
                    return;

                }


            // shows a message box with a new line for each of these, your age in years,months,days,hours,minutes,seconds also formatted the bigger numbers so they include commas so its easier to read

            MessageBox.Show (firstName + " " + lastName +
            Environment.NewLine + "You are " + years.ToString() + " years old ..." +
            Environment.NewLine + "Or " + months2.ToString() + " months old" +
            Environment.NewLine + "Or " + weeks.ToString() + " weeks old" +
            Environment.NewLine + "Or " + string.Format("{0:#,0}", days) + " days old" +
            Environment.NewLine + "Or " + string.Format("{0:#,0}", hours) + " hours old" +
            Environment.NewLine + "Or " + string.Format("{0:#,0}", minutes) + " minutes old " +
            Environment.NewLine + "Or " + string.Format("{0:#,0}", seconds) + " seconds old " +
            Environment.NewLine + "And, your next birthday is in: " + futuredate.ToString() + " days");




         }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void labeldate_Click(object sender, EventArgs e)
        {

        }
        string oldText = string.Empty;
        private void textBoxNameinput_TextChanged(object sender, EventArgs e)
        {
            {   //checking when the user presses a key in the textbox if it is a letter not a number or special character
                if (textBoxNameinput.Text.All(chr => char.IsLetter(chr)))
                {
                    oldText = textBoxNameinput.Text;
                    textBoxNameinput.Text = oldText;

                    textBoxNameinput.BackColor = System.Drawing.Color.White;
                    textBoxNameinput.ForeColor = System.Drawing.Color.Black;
                }
                else // stops the user entering anything that isnt a character and if it isnt makes the text box go red and stops the input
                {
                    textBoxNameinput.Text = oldText;
                    textBoxNameinput.BackColor = System.Drawing.Color.Red;
                    textBoxNameinput.ForeColor = System.Drawing.Color.White;
                }
                textBoxNameinput.SelectionStart = textBoxNameinput.Text.Length;
            }
        }

        private void textBoxLastNameInput_TextChanged(object sender, EventArgs e)
        {  //checking when the user presses a key in the textbox if it is a letter not a number or special character
            if (textBoxLastNameInput.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = textBoxLastNameInput.Text;
                textBoxLastNameInput.Text = oldText;

                textBoxLastNameInput.BackColor = System.Drawing.Color.White;
                textBoxLastNameInput.ForeColor = System.Drawing.Color.Black;
            }
            else // stops the user entering anything that isnt a character and if it isnt makes the text box go red and stops the input
            {
                textBoxLastNameInput.Text = oldText;
                textBoxLastNameInput.BackColor = System.Drawing.Color.Red;
                textBoxLastNameInput.ForeColor = System.Drawing.Color.White;
            }
            textBoxLastNameInput.SelectionStart = textBoxLastNameInput.Text.Length;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }
    }

   
}
    





    



