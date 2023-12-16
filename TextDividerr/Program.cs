namespace TextDividerr
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.AddMessageFilter(new MessageFilter());
            ApplicationConfiguration.Initialize();
            Form1 myForm = new Form1();  // Создаем экземпляр формы
            Application.Run(myForm);
        }  

    }
}