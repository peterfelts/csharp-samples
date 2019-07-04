using System;
using System.Runtime.InteropServices;

namespace NetCoreApp
{
    class Program
    {
        [DllImport("SharedLibrary", EntryPoint = "DoEncode")]
        public static extern IntPtr DoEncode(byte[] message, int nSizeMessage, byte[] PsKey, int nSizePsKey);

        static void Main(string[] args)
        {
            // Convert the input strings to a byte arrays
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("Hellow World!");
            var message = Convert.ToBase64String(plainTextBytes);

            byte[] PsKey = Convert.FromBase64String("SGVsbG8gV29ybGQh");
            byte[] rawMessage = Convert.FromBase64String(message);

            Console.WriteLine("Loading shared library");

            Console.WriteLine("Calling function DoEncode()");

            // Note that returning a char* from unmanaged code to managed code can cause a 
            // memory leak if the unmanaged code allocates memory on the heap which is not ever
            // freed.
            //
            // See: https://www.codeproject.com/Articles/1189085/Passing-strings-between-managed-and-unmanaged-code
            var returnedString = DoEncode(rawMessage, rawMessage.Length, PsKey, PsKey.Length);

            // Marshal the char* returned from the shared library (unmanaged code) to a string
            string output = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(returnedString);

            Console.WriteLine($"The call to DoEncode() returned \"{output}\"");
            Console.WriteLine("All done.");
        }
    }
}
