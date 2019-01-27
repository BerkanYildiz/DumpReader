namespace DumpReader.CLI
{
    using System.IO;
    using System.Threading.Tasks;

    using DumpReader.Logic;

    internal static class Extensions
    {
        internal static Task WriteOffset(this StreamWriter Stream, DumpClass Class, string Field, int Offset)
        {
            return Stream.WriteLineAsync("internal const int Offset_" + Class.ClassName + "_" + Field + " = 0x" + Offset.ToString("X").ToUpper() + ";");
        }

        internal static async Task WriteHeader(this StreamWriter Stream, string Header)
        {
            await Stream.WriteLineAsync();
            await Stream.WriteLineAsync("/*** " + Header + " ***/");
            await Stream.WriteLineAsync();
        }
    }
}
