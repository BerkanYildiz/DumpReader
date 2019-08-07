namespace DumpReader
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using DumpReader.Logic;

    public class Dump
    {
        /// <summary>
        /// Gets the file.
        /// </summary>
        public FileInfo DumpFile
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the raw content.
        /// </summary>
        public List<string> Raw
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the packages.
        /// </summary>
        public List<string> Packages
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the classes.
        /// </summary>
        public Dictionary<string, DumpClass> Classes
        {
            get;
            private set;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Dump"/> class from being created.
        /// </summary>
        private Dump()
        {
            this.Raw        = new List<string>();
            this.Packages   = new List<string>();
            this.Classes    = new Dictionary<string, DumpClass>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dump"/> class.
        /// </summary>
        /// <param name="FilePath">The file path.</param>
        public Dump(string FilePath) : this()
        {
            this.SetDumpFile(FilePath);
        }

        /// <summary>
        /// Sets the dump file.
        /// </summary>
        /// <param name="FilePath">The file path.</param>
        /// <exception cref="ArgumentNullException">FilePath</exception>
        /// <exception cref="FileNotFoundException">The specified dump file does not exist</exception>
        public void SetDumpFile(string FilePath)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new ArgumentNullException(nameof(FilePath));
            }

            if (!File.Exists(FilePath))
            {
                throw new FileNotFoundException("The specified dump file does not exist", FilePath);
            }

            this.DumpFile = new FileInfo(FilePath);
            this.Raw = File.ReadAllLines(FilePath).ToList();
        }

        /// <summary>
        /// Reads this dump.
        /// </summary>
        public void Read()
        {
            if (this.DumpFile == null || !this.DumpFile.Exists)
            {
                throw new Exception("The dump is not initialized");
            }

            foreach (var Line in this.Raw)
            {
                if (string.IsNullOrWhiteSpace(Line))
                {
                    continue;
                }

                if (Line[0] != '/')
                {
                    continue;
                }

                var Splits      = Line.Split(' ');

                if (Splits.Length < 2)
                {
                    continue;
                }

                var Type        = Splits[0];
                var Package     = Splits[1];
                var Class       = string.Empty;
                var Field       = string.Empty;
                var SubField    = string.Empty; 
                var SubType     = string.Empty;
                var OffsetStr   = Splits.Last();

                Type            = string.Join(".", Type.Split('.').Skip(1));
                Package         = Package.Replace("/Script/", string.Empty);

                switch (Type)
                {
                    case "Package":
                    {
                        this.Packages.Add(Package);
                        break;
                    }

                    case "Class":
                    case "ScriptStruct":
                    {
                        Splits  = Package.Split('.');
                        Package = Splits[0];
                        Class   = Splits[1];

                        this.Classes.Add(Class, new DumpClass(Package, Class));
                        break;
                    }

                    case "Object":
                    {
                        break;
                    }

                    default:
                    {
                        Splits = Package.Split('.', ':');
                        Package = Splits[0];
                        Class = Splits[1];

                        if (!this.Packages.Contains(Package))
                        {
                            break;
                        }

                        if (Splits.Length > 2)
                        {
                            Field = Splits[2];

                            if (Splits.Length > 3)
                            {
                                SubField = Splits[3];

                                if (Splits.Length > 4)
                                {
                                    SubType = Splits[4];
                                }
                            }

                            if (this.Classes.TryGetValue(Class, out var DumpClass))
                            {
                                if (Type == "Function")
                                {
                                    DumpClass.AddFunction(Field);
                                }
                                else
                                {
                                    if (!OffsetStr.StartsWith("0x"))
                                    {
                                        continue;
                                    }

                                    if (!int.TryParse(OffsetStr.Substring(2), NumberStyles.HexNumber, new NumberFormatInfo(), out var Offset))
                                    {
                                        continue;
                                    }

                                    if (DumpClass.Functions.TryGetValue(Field, out var Function))
                                    {
                                        if (Function.Fields.Contains(SubField))
                                        {
                                            // Field specifies the <T> of a function sub-struct
                                        }
                                        else
                                        {
                                            Function.AddField(SubField, Offset);
                                        }
                                    }
                                    else
                                    {
                                        if (DumpClass.Fields.Contains(Field))
                                        {
                                            // Field specifies the <T> of a struct
                                        }
                                        else
                                        {
                                            DumpClass.AddField(Field, Offset);
                                        }
                                    }
                                }
                            }
                        }

                        break;
                    }
                }
            }
        }
    }
}
