using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using System.Speech.Recognition;
//using System.Speech.Recognition;
//using System.Speech.Synthesis;

namespace SpeechProject
{
    public partial class Form1 : Form
    {

        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        public Form1()
        {
            InitializeComponent();
        }

         private void button1_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            btnDisable.Enabled = true;
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            btnDisable.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            Choices commands = new Choices();

            // commands.Add("Я пишу сообщение");
            //  commands.Add("точка");
            // SpeechRecognizedEventArgs eventArgs = new SpeechRecognizedEventArgs();
            //SpeechRecognizedEventArgs args = new SpeechRecognizedEventArgs();

             GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(e.ToString());


            Grammar grammar = new Grammar(gBuilder);
            
            recEngine.LoadGrammarAsync(new DictationGrammar());
       
            recEngine.SetInputToDefaultAudioDevice();
         
            recEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Speech_SpeechRecognized);
           
            
        }

         void Speech_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            string str = e.Result.Text;
            switch(e.Result.Text)
            {
                case "точка":
                    richTextBox1.Text += ".";

                    break;
            }
            if (e.Result.Text != "точка")
            {
                richTextBox1.Text += e.Result.Text + " ";
            }
            }

        
    }
}
