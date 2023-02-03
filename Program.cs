namespace MCal
{
      public partial class MCalEntry
      {
            /// <summary>
            /// The entry point of the program, where the program control starts and ends.
            /// </summary>
            /// <param name="args">The command-line arguments.</param>
            static void Main(string[] args)
            {

                  Arguments = args;
                  //foreach (string a in Arguments) Get.Blue(a); 
                  LoadSettings(); 
                  while (true) MainMenu(Arguments);
            }

      }
}
