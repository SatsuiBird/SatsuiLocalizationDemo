using System.Windows;

namespace DemoWPF
{
    public partial class Bootstrap
    {
        protected override void OnStartup(StartupEventArgs e)
        {
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // No resource need to be cleaned
            base.OnExit(e);
        }
    }


}
