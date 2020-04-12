using ConquerDialogsTranslatorAPI;
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
            Translator.Language srcLang = (Translator.Language)Enum.Parse(typeof(Translator.Language), sourceLang.SelectedItem.ToString());
            Translator.Language tgtLang = (Translator.Language)Enum.Parse(typeof(Translator.Language), targetLang.SelectedItem.ToString());
            txtTarget.Text = Translator.GetTranslatedString(txtSource.Text, srcLang, tgtLang);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            foreach (Translator.Language lang in (Translator.Language[])Enum.GetValues(typeof(Translator.Language)))
            {
                sourceLang.Items.Add(lang.ToString());
                targetLang.Items.Add(lang.ToString());
            }
            sourceLang.SelectedIndex = 0;
            targetLang.SelectedIndex = 1;
        }

        private void ClearCache_Click(object sender, EventArgs e)
        {
            Translator.ClearCache();
        }
    }
}
