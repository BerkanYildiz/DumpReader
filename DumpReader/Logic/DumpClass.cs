namespace DumpReader.Logic
{
    using System;
    using System.Collections.Generic;

    public class DumpClass
    {
        /// <summary>
        /// Gets the name of the package.
        /// </summary>
        public string PackageName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the name of the class.
        /// </summary>
        public string ClassName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the fields in this class.
        /// </summary>
        public List<string> Fields
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the functions in this class.
        /// </summary>
        public Dictionary<string, DumpFunction> Functions
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the offsets of fields and functions in this class.
        /// </summary>
        public Dictionary<string, int> Offsets
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the offset of the specified field.
        /// </summary>
        public int this[string FieldName]
        {
            get
            {
                if (this.Fields.Contains(FieldName))
                {
                    if (this.Offsets.TryGetValue(FieldName, out var Offset))
                    {
                        return Offset;
                    }
                }

                return -1;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="DumpClass"/> class from being created.
        /// </summary>
        private DumpClass()
        {
            this.Fields = new List<string>();
            this.Functions = new Dictionary<string, DumpFunction>();
            this.Offsets = new Dictionary<string, int>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DumpClass"/> class.
        /// </summary>
        /// <param name="PackageName">Name of the package.</param>
        /// <param name="ClassName">Name of the class.</param>
        public DumpClass(string PackageName, string ClassName) : this()
        {
            this.PackageName = PackageName;
            this.ClassName = ClassName;
        }

        /// <summary>
        /// Adds the specified field.
        /// </summary>
        /// <param name="FieldName">Name of the field.</param>
        /// <param name="FieldOffset">The field offset.</param>
        public void AddField(string FieldName, int FieldOffset)
        {
            if (this.Fields.Contains(FieldName))
            {
                throw new Exception("Field already exist in the list");
            }

            this.Fields.Add(FieldName);
            this.Offsets.Add(FieldName, FieldOffset);
        }

        /// <summary>
        /// Adds the specified function.
        /// </summary>
        /// <param name="FunctionName">Name of the function.</param>
        public void AddFunction(string FunctionName)
        {
            if (this.Functions.ContainsKey(FunctionName))
            {
                throw new Exception("Function already exist in the list");
            }

            this.Functions.Add(FunctionName, new DumpFunction(this.PackageName, this.ClassName, FunctionName));
        }

        /// <summary>
        /// Removes the specified field.
        /// </summary>
        /// <param name="FieldName">Name of the field.</param>
        public void RemoveField(string FieldName)
        {
            if (!this.Fields.Contains(FieldName))
            {
                return;
            }

            this.Fields.Remove(FieldName);
            this.Offsets.Remove(FieldName);
        }

        /// <summary>
        /// Removes the specified function.
        /// </summary>
        /// <param name="FunctionName">Name of the function.</param>
        public void RemoveFunction(string FunctionName)
        {
            if (!this.Functions.ContainsKey(FunctionName))
            {
                return;
            }

            this.Functions.Remove(FunctionName);
        }

        /// <summary>
        /// Gets a string that represents this instance.
        /// </summary>
        public override string ToString()
        {
            return this.PackageName + "::" + this.ClassName;
        }
    }
}
