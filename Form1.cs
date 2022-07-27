using System.Media;
using System.IO;

//Yes this is inefficient. I intend to itterate on it as I get better at C#
//Yes I shouldnt be using Windows Forms. But I wanted to make something quickly and lightweight for myself. 


//Loading two sounds causes the original to cause an error

namespace AudioTestingApp
{
    public partial class Form1 : Form
    {

        string buttonPlayBack1SoundFile;
        string buttonPlayBack2SoundFile;
        string buttonPlayBack3SoundFile;
        string buttonPlayBack4SoundFile;
        string buttonPlayBack5SoundFile;
        string buttonPlayBack6SoundFile;
        string buttonPlayBack7SoundFile;
        string buttonPlayBack8SoundFile;
        string buttonPlayBack9SoundFile;
        string buttonPlayBack10SoundFile;
        string buttonPlayBack11SoundFile;
        string buttonPlayBack12SoundFile;
        string buttonPlayBack13SoundFile;
        string buttonPlayBack14SoundFile;
        string buttonPlayBack15SoundFile;
        string buttonPlayBack16SoundFile;
        string buttonPlayBack17SoundFile;
        string buttonPlayBack18SoundFile;
        string buttonPlayBack19SoundFile;
        string buttonPlayBack20SoundFile;
        Button[] ButtonArray = new Button[20];
        string[] SoundFileArray = new string[20];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadButtons();
            LoadSoundFileArray();
        }

        void LoadButtons()
        {
            ButtonArray[0] = buttonPlayback1;
            ButtonArray[1] = buttonPlayback2;
            ButtonArray[2] = buttonPlayback3;
            ButtonArray[3] = buttonPlayback4;
            ButtonArray[4] = buttonPlayback5;
            ButtonArray[5] = buttonPlayback6;
            ButtonArray[6] = buttonPlayback7;
            ButtonArray[7] = buttonPlayback8;
            ButtonArray[8] = buttonPlayback9;
            ButtonArray[9] = buttonPlayback10;
            ButtonArray[10] = buttonPlayback11;
            ButtonArray[11] = buttonPlayback12;
            ButtonArray[12] = buttonPlayback13;
            ButtonArray[13] = buttonPlayback14;
            ButtonArray[14] = buttonPlayback15;
            ButtonArray[15] = buttonPlayback16;
            ButtonArray[16] = buttonPlayback17;
            ButtonArray[17] = buttonPlayback18;
            ButtonArray[18] = buttonPlayback19;
            ButtonArray[19] = buttonPlayback20;
        }
        void LoadSoundFileArray()
        {
            SoundFileArray[0] = buttonPlayBack1SoundFile;
            SoundFileArray[1] = buttonPlayBack2SoundFile;
            SoundFileArray[2] = buttonPlayBack3SoundFile;
            SoundFileArray[3] = buttonPlayBack4SoundFile;
            SoundFileArray[4] = buttonPlayBack5SoundFile;
            SoundFileArray[5] = buttonPlayBack6SoundFile;
            SoundFileArray[6] = buttonPlayBack7SoundFile;
            SoundFileArray[7] = buttonPlayBack8SoundFile;
            SoundFileArray[8] = buttonPlayBack9SoundFile;
            SoundFileArray[9] = buttonPlayBack10SoundFile;
            SoundFileArray[10] = buttonPlayBack11SoundFile;
            SoundFileArray[11] = buttonPlayBack12SoundFile;
            SoundFileArray[12] = buttonPlayBack13SoundFile;
            SoundFileArray[13] = buttonPlayBack14SoundFile;
            SoundFileArray[14] = buttonPlayBack15SoundFile;
            SoundFileArray[15] = buttonPlayBack16SoundFile;
            SoundFileArray[16] = buttonPlayBack17SoundFile;
            SoundFileArray[17] = buttonPlayBack18SoundFile;
            SoundFileArray[18] = buttonPlayBack19SoundFile;
            SoundFileArray[19] = buttonPlayBack20SoundFile;
        }

        private void buttonSavePreset_Click(object sender, EventArgs e)
        {
            var filePath = "";
            var exeFilePath = "";
            var fullFilePath = "";
            int i = 0;
            int j = 0;     

            exeFilePath = AppDomain.CurrentDomain.BaseDirectory;
            string textFileName = textBox1.Text;
            //TODO: Ensure this is right
            fullFilePath = exeFilePath + "/Presets" +  textFileName + ".txt";
            File.Create(fullFilePath);

            foreach (var item in SoundFileArray)
            {                
                File.WriteAllText(fullFilePath, SoundFileArray[i]);
                File.WriteAllText(fullFilePath, ",");
                i++;

                //TODO: Do something then catch error(s)?
                
            }

            foreach(var item in ButtonArray)
            {

                File.WriteAllText(fullFilePath, ButtonArray[i].Text);
                File.WriteAllText(fullFilePath, ",");
                j++;
                
                //TODO: Do something then catch error(s)?
                
            }
        }

        private void buttonLoadNewPreset_Click(object sender, EventArgs e)
        {
            //TODO: Create check for .txt files and test to see if this and saving presets works
            var filePath = string.Empty;
            var fileContent = string.Empty;
            var fileName = string.Empty;
            int i = 0;
            int j = 0;
            int z = 0;
            char trimChar = ',';

            using (OpenFileDialog ofg = new OpenFileDialog())
            {
                ofg.InitialDirectory = "c\\";
                ofg.Filter = "All files (*.*)|*.*";

                if(ofg.ShowDialog() == DialogResult.OK)
                {
                    //TODO: Check for .txt file here, if not have user try again
                    
                    
                    filePath = ofg.FileName;
                    fileName = ofg.SafeFileName;
                }
            }

            string text = File.ReadAllText(filePath);
            string[] TextArray = new string[40];
            TextArray = Text.Split(",");
            foreach(var item in TextArray)
            {
                TextArray[z].Trim(trimChar);
                z++;
            }

            int y = 0;
            int x = 0;
            foreach(var item in TextArray)
            {
                //TODO: Create check for when SoundFileArray[] maxes out
                if(y <= 19)
                {
                    foreach(var item2 in SoundFileArray)
                    {
                        SoundFileArray[i] = TextArray[x];
                        i++;
                        x++;
                    }
                    y++;
                }
                //TODO: Create check for when ButtonArray[] maxes out
                if (y >= 19)
                {
                    foreach(var item3 in ButtonArray)
                    {
                        ButtonArray[j].Text = TextArray[x];
                        j++;
                        x++;
                    }
                    y++;
                }
            }
        }

        private void buttonLoadNew_Click(object sender, EventArgs e)
        {
            //LoadButtons();
            //LoadSoundFileArray();

            var filePath = string.Empty;
            var fileContent = string.Empty;
            var fileName = string.Empty;
            int i = 0;
            int z = 0;

            using (OpenFileDialog ofg = new OpenFileDialog())
            {
                ofg.InitialDirectory = "c:\\";
                ofg.Filter = "All files (*.*)|*.*";
                //ofg.RestoreDirectory = true;

                if (ofg.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofg.FileName;
                    fileName = ofg.SafeFileName;
                }
            }

            //TODO: Implement catch for if any value in SoundFileArray[i] = null
            while (z == 0)
            {
                foreach (var item in SoundFileArray)
                {
                    if (fileName == null || filePath == null)
                    {
                        //TODO: Catch Error
                    }
                    else if (SoundFileArray[i] == null)
                    {
                        SoundFileArray[i] = filePath.Normalize();
                        ButtonArray[i].Text = fileName.Normalize();
                        z++;
                        return;
                    }
                    else
                    {
                        i++;
                        //TODO: Catch Error
                    }
                }
            }
            //TODO: Catch it or do something when all 20 are full
        }

        private void button1Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback1.Text = "Empty";
            buttonPlayBack1SoundFile = "";
        }
        private void button2Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback2.Text = "Empty";
            buttonPlayBack2SoundFile = "";
        }
        private void button3Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback3.Text = "Empty";
            buttonPlayBack3SoundFile = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            buttonPlayback4.Text = "Empty";
            buttonPlayBack4SoundFile = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            buttonPlayback5.Text = "Empty";
            buttonPlayBack5SoundFile = "";
        }
        private void button6Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback6.Text = "Empty";
            buttonPlayBack6SoundFile = "";
        }
        private void button7Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback7.Text = "Empty";
            buttonPlayBack7SoundFile = "";
        }
        private void button8Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback8.Text = "Empty";
            buttonPlayBack8SoundFile = "";
        }
        private void button9Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback9.Text = "Empty";
            buttonPlayBack9SoundFile = "";
        }
        private void button10Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback10.Text = "Empty";
            buttonPlayBack10SoundFile = "";
        }
        private void button11Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback11.Text = "Empty";
            buttonPlayBack11SoundFile = "";
        }
        private void button12Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback12.Text = "Empty";
            buttonPlayBack12SoundFile = "";
        }
        private void button13Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback13.Text = "Empty";
            buttonPlayBack13SoundFile = "";
        }
        private void button14Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback14.Text = "Empty";
            buttonPlayBack14SoundFile = "";
        }
        private void button15Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback15.Text = "Empty";
            buttonPlayBack15SoundFile = "";
        }
        private void button16Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback16.Text = "Empty";
            buttonPlayBack16SoundFile = "";
        }
        private void button17Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback17.Text = "Empty";
            buttonPlayBack17SoundFile = "";
        }
        private void button18Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback18.Text = "Empty";
            buttonPlayBack18SoundFile = "";
        }
        private void button19Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback19.Text = "Empty";
            buttonPlayBack19SoundFile = "";
        }
        private void button20Exit_Click(object sender, EventArgs e)
        {
            buttonPlayback20.Text = "Empty";
            buttonPlayBack20SoundFile = "";
        }

        private void buttonPlayback1_Click(object sender, EventArgs e)
        {
            //Suggestion: It needs to quickly confirm the soundfile exists, if it does exist it can play the sound. If not, then do nothing and write an error to the log file
            int i = 0;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
                //TODO: Create a way to verify the location and file exists!
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player1 = new SoundPlayer(SoundFileArray[i]);
                player1.Play();
            }
        }
        private void buttonPlayback2_Click(object sender, EventArgs e)
        {
            int i = 1;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
                //TODO: Create a way to verify the location and file exists!
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player2 = new SoundPlayer(SoundFileArray[i]);
                player2.Play();
            }
        }
        private void buttonPlayback3_Click(object sender, EventArgs e)
        {
            int i = 2;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
                //TODO: Create a way to verify the location and file exists!
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player3 = new SoundPlayer(SoundFileArray[i]);
                player3.Play();
            }
        }
        private void buttonPlayback4_Click(object sender, EventArgs e)
        {
            int i = 3;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
                //TODO: Create a way to verify the location and file exists!
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player4 = new SoundPlayer(SoundFileArray[i]);
                player4.Play();
            }
        }
        private void buttonPlayback5_Click(object sender, EventArgs e)
        {
            int i = 4;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
                //TODO: Create a way to verify the location and file exists!
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player5 = new SoundPlayer(SoundFileArray[i]);
                player5.Play();
            }
        }
        private void buttonPlayback6_Click(object sender, EventArgs e)
        {
            int i = 5;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
                //TODO: Create a way to verify the location and file exists!
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player6 = new SoundPlayer(SoundFileArray[i]);
                player6.Play();
            }
        }
        private void buttonPlayback7_Click(object sender, EventArgs e)
        {
            int i = 6;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player7 = new SoundPlayer(SoundFileArray[i]);
                player7.Play();
            }
        }
        private void buttonPlayback8_Click(object sender, EventArgs e)
        {
            int i = 7;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player8 = new SoundPlayer(SoundFileArray[i]);
                player8.Play();
            }
        }
        private void buttonPlayback9_Click(object sender, EventArgs e)
        {
            int i = 8;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player9 = new SoundPlayer(SoundFileArray[i]);
                player9.Play();
            }
        }
        private void buttonPlayback10_Click(object sender, EventArgs e)
        {
            int i = 9;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player10 = new SoundPlayer(SoundFileArray[i]);
                player10.Play();
            }
        }
        private void buttonPlayback11_Click(object sender, EventArgs e)
        {
            int i = 10;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player11 = new SoundPlayer(SoundFileArray[i]);
                player11.Play();
            }
        }
        private void buttonPlayback12_Click(object sender, EventArgs e)
        {
            int i = 11;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player12 = new SoundPlayer(SoundFileArray[i]);
                player12.Play();
            }
        }
        private void buttonPlayback13_Click(object sender, EventArgs e)
        {
            int i = 12;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player13 = new SoundPlayer(SoundFileArray[i]);
                player13.Play();
            }
        }
        private void buttonPlayback14_Click(object sender, EventArgs e)
        {
            int i = 13;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player14 = new SoundPlayer(SoundFileArray[i]);
                player14.Play();
            }
        }
        private void buttonPlayback15_Click(object sender, EventArgs e)
        {
            int i = 14;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player15 = new SoundPlayer(SoundFileArray[i]);
                player15.Play();
            }
        }
        private void buttonPlayback16_Click(object sender, EventArgs e)
        {
            int i = 15;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player16 = new SoundPlayer(SoundFileArray[i]);
                player16.Play();
            }
        }
        private void buttonPlayback17_Click(object sender, EventArgs e)
        {
            int i = 16;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player17 = new SoundPlayer(SoundFileArray[i]);
                player17.Play();
            }
        }
        private void buttonPlayback18_Click(object sender, EventArgs e)
        {
            int i = 17;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player18 = new SoundPlayer(SoundFileArray[i]);
                player18.Play();
            }
        }
        private void buttonPlayback19_Click(object sender, EventArgs e)
        {
            int i = 18;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player19 = new SoundPlayer(SoundFileArray[i]);
                player19.Play();
            }
        }
        private void buttonPlayback20_Click(object sender, EventArgs e)
        {
            int i = 19;
            if (SoundFileArray[i] == "null")
            {
                //Or a location that does not exist
            }
            else if (!File.Exists(SoundFileArray[i]))
            {
                //TODO: Test and create an error catch if this happens            
            }
            else
            {
                SoundPlayer player20 = new SoundPlayer(SoundFileArray[i]);
                player20.Play();
            }
        }
    }
}