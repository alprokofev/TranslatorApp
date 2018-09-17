using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TranslatorApp.Properties;

namespace TranslatorApp
{
    public partial class MainForm : Form
    {
        private Translator Translator;
        private string langDirection = "";
        private string sourceText = "";
        private string translatedText = "";
        private DateTime dtTranslated;
        private List<Language> listLangsFrom = new List<Language>();
        private List<Language> listLangsTo = new List<Language>();

        public MainForm()
        {
            InitializeComponent();
            Translator = new Translator();
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            try
            {
                Database database = new Database(Settings.Default.dbFileName);
                listLangsFrom = database.GetLanguages();
                if (listLangsFrom == null)
                    return;

                listLangsTo = new List<Language>(listLangsFrom.Count);
                listLangsFrom.ForEach((item) =>
                {
                    listLangsTo.Add(new Language(item));
                });

                InitCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void InitCombo()
        {
            cbLanguageTo.DataSource = listLangsTo;
            cbLanguageTo.ValueMember = "Key";
            cbLanguageTo.DisplayMember = "Value";

            cbLanguageFrom.DataSource = listLangsFrom;
            cbLanguageFrom.ValueMember = "Key";
            cbLanguageFrom.DisplayMember = "Value";
        }

        private async void btnTranslate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbSourceText.Text.Trim()))
                {
                    MessageBox.Show("Отсутствует строка для перевода");
                    return;
                }
                
                if (cbLanguageFrom.Items.Count == 0 || cbLanguageTo.Items.Count == 0)
                {
                    MessageBox.Show("Не загружены доступные языки для перевода");
                    return;
                }

                string source = ((Language)cbLanguageFrom.SelectedItem).Key.ToString();
                string target = ((Language)cbLanguageTo.SelectedItem).Key.ToString();

                langDirection = string.Format("{0}-{1}", source, target);
                sourceText = tbSourceText.Text;
                translatedText = await Translator.Translate(sourceText, langDirection);
                if (string.IsNullOrEmpty(translatedText))
                    return;

                tbTranslatedText.Text = translatedText;
                btnExport.Enabled = true;
                dtTranslated = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbLanguageFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbLanguageFrom.SelectedItem == null || cbLanguageTo.SelectedItem == null)
                    return;

                CheckDirectionEnable();

                string source = ((Language)cbLanguageFrom.SelectedItem).Value.ToString();
                if (string.Equals(source, "Русский"))
                {
                    cbLanguageTo.DataSource = null;
                    Language ruLang = (Language)cbLanguageFrom.SelectedItem;
                    listLangsTo.Remove(listLangsTo.Find(P => P.Key == ruLang.Key));

                    cbLanguageTo.DataSource = listLangsTo;
                    cbLanguageTo.ValueMember = "Key";
                    cbLanguageTo.DisplayMember = "Value";
                    cbLanguageTo.SelectedIndex = 0;
                }
                else
                {
                    cbLanguageTo.DataSource = null;
                    listLangsTo = new List<Language>(listLangsFrom.Count);
                    listLangsFrom.ForEach((item) =>
                    {
                        listLangsTo.Add(new Language(item));
                    });

                    cbLanguageTo.DataSource = listLangsTo;
                    cbLanguageTo.ValueMember = "Key";
                    cbLanguageTo.DisplayMember = "Value";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbTranslatedText.Text))
                    return;

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.InitialDirectory = Application.StartupPath;
                saveFile.Filter = "xml files (*.xml)|*.xml|All files|*.*";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFile.FileName;
                    XmlCreator.Create(fileName, langDirection, sourceText, translatedText, dtTranslated);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbLanguageTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLanguageFrom.SelectedItem == null || cbLanguageTo.SelectedItem == null)
                return;

            CheckDirectionEnable();
        }

        private void CheckDirectionEnable()
        {
            string source = ((Language)cbLanguageFrom.SelectedItem).Value.ToString();
            string target = ((Language)cbLanguageTo.SelectedItem).Value.ToString();

            if (string.Equals(source, "Английский") && string.Equals(target, "Словенский") ||
                (string.Equals(source, "Словенский") && string.Equals(target, "Английский")))
            {
                btnTranslate.Enabled = false;
            }
            else
            {
                btnTranslate.Enabled = true;
            }
        }

    }
}
