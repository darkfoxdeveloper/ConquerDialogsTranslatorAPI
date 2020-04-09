using System;
using System.Windows.Forms;

namespace UsingAPIExample
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void BtnTranslate_Click(object sender, EventArgs e)
        {
            txtTarget.Text = ConquerDialogsTranslatorAPI.Translator.GetTranslatedString(txtSource.Text, ConquerDialogsTranslatorAPI.Translator.Language.ES, ConquerDialogsTranslatorAPI.Translator.Language.EN);
        }
    }
}
