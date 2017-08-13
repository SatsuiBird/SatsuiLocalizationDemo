using System.Windows;
using SatsuiLocalization;
using DemoWPF.Controls;

namespace DemoWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Translation myLang;

        public MainWindow()
        {
            InitializeComponent();

            // Loading availables langs into the ComboBox
            this.cmbLangs.Items.Add("English");
            this.cmbLangs.Items.Add("Français");
            //this.cmbLangs.SelectedIndex = 0;

            // Creating the Translation object
            this.myLang = new Translation();

            // You can create it by giving the path to the xml file
            //this.myLang = Translation.FromFile("path-to-the-xml-file.xml");

            // Or you can load an embed resource (don't forget to set your resource as an embed resource)
            //this.myLang = Translation.FromResource("en", "MyProject.Folder.XmlFile.xml");

            // You can define custom variables
            // It's useful when you need to show informations which are not language related, like application name, version, ...
            // Default variables are : 
            // $p = parameter when used with GetString
            // $ln = new line
            Translation.AddVar("customVar1", "hello");
            Translation.AddVar("customVar2", "world");

            // If you want to translate your custom control, you can use the AddCustomControl function
            this.myLang.AddCustomControl(typeof(MyCustomControl), "MyCustomProperty");
        }

        private void LoadTranslation()
        {
            // Loading the translation from an embed resource
            // You can also load it from a file 

            string resource = "", error = "";

            if (this.cmbLangs.SelectedIndex == 0) resource = "DemoWPF.Langs.en.xml";
            else if (this.cmbLangs.SelectedIndex == 1) resource = "DemoWPF.Langs.fr.xml";
            else return;

            if (!this.myLang.LoadResource("en", resource, ref error)) MessageBox.Show(error, "DemoWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
            else
            {
                this.myLang.Translate(this, "main-window");
                MessageBox.Show(this.myLang.GetString("messages/translation-success"), "DemoWPF", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ShowGetString()
        {
            // The entry for getstring-result in english is defined as [Your message is : $p]
            // So the translation replace $p with the parameter
            string msg = this.myLang.GetString("messages/getstring-result", this.txtGetString.Text);
            MessageBox.Show(msg, "DemoWPF", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        #region Controls events

        private void btnTranslate_Click(object sender, RoutedEventArgs e)
        {
            LoadTranslation();
        }

        private void btnGetString_Click(object sender, RoutedEventArgs e)
        {
            ShowGetString();
        }

        private void mnu_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion


    }
}
