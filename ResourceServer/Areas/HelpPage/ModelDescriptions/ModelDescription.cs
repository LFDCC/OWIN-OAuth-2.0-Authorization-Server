using System;
using System.ComponentModel;

namespace ResourceServer.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Describes a type model.
    /// </summary>
    public abstract class ModelDescription
    {
        [DisplayName("√Ë ˆ")]
        public string Documentation { get; set; }

        [DisplayName("¿‡–Õ")]
        public Type ModelType { get; set; }

        [DisplayName("√˚≥∆")]
        public string Name { get; set; }
    }
}