namespace DumpReader.CLI
{
    using System.IO;

    using DumpReader.Logic;

    internal static class Extensions
    {
        internal static void WriteOffset(this StreamWriter Stream, DumpClass Class, string Field, int Offset)
        {
            Stream.WriteLine("internal const int Offset_" + Class.ClassName + "_" + Field + " = 0x" + Offset.ToString("X").ToUpper() + ";");
        }

        internal static void WriteHeader(this StreamWriter Stream, string Header)
        {
            Stream.WriteLine();
            Stream.WriteLine("/*** " + Header + " ***/");
            Stream.WriteLine();
        }
    }
}
