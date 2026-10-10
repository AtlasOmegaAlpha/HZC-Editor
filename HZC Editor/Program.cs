namespace HZC_Editor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            if (args.Length >= 1)
            {
                Form1 form = new Form1();
                form.OpenFile(args[0]);
                Application.Run(form);
            }
            else
                Application.Run(new Form1());
        }
    }
}