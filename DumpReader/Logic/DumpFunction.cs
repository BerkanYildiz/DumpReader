namespace DumpReader.Logic
{
    using System;
    using System.Collections.Generic;

    public class DumpFunction
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
        /// Gets the name of the function.
        /// </summary>
        public string FunctionName
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
        /// Gets the offsets of fields and functions in this class.
        /// </summary>
        public Dictionary<string, int> Offsets
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the offset of the specified field or function name.
        /// </summary>
        public int this[string FieldOrFunctionName]
        {
            get
            {
                if (this.Fields.Contains(FieldOrFunctionName))
                {
                    if (this.Offsets.TryGetValue(FieldOrFunctionName, out var Offset))
                    {
                        return Offset;
                    }
                }

                return -1;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="DumpFunction"/> class from being created.
        /// </summary>
        private DumpFunction()
        {
            this.Fields = new List<string>();
            this.Offsets = new Dictionary<string, int>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DumpFunction"/> class.
        /// </summary>
        /// <param name="PackageName">Name of the package.</param>
        /// <param name="ClassName">Name of the class.</param>
        /// <param name="FunctionName">Name of the function.</param>
        public DumpFunction(string PackageName, string ClassName, string FunctionName) : this()
        {
            this.PackageName = PackageName;
            this.ClassName = ClassName;
            this.FunctionName = FunctionName;
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
        /// Gets a string that represents this instance.
        /// </summary>
        public override string ToString()
        {
            return this.PackageName + "::" + this.ClassName + "->" + this.FunctionName + "(..)";
        }
    }
}
