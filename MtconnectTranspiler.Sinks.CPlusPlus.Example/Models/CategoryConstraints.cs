using MtconnectTranspiler.Sinks.ScribanTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MtconnectTranspiler.Sinks.CPlusPlus.Example.Models
{
    /// <summary>
    /// Structure for grouping observation constraints by category
    /// </summary>
    [ScribanTemplate("CategoryConstraint.scriban")]
    public class CategoryConstraints : IFileSource
    {
        /// <summary>
        /// Name of the observation category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Collection of observations for the provided <see cref="Category"/> and any relevant constraints
        /// </summary>
        public Dictionary<string, List<string>> Constraints { get; set; } = new Dictionary<string, List<string>>();

        /// <summary>
        /// Internal string, used by <see cref="Filename"/>.
        /// </summary>
        protected string _filename { get; set; }
        /// <inheritdoc />
        public string Filename
        {
            get
            {
                if (string.IsNullOrEmpty(_filename))
                    _filename = $"{Category}.h";
                return _filename;
            }
            set { _filename = value; }
        }

        public string Namespace { get; set; }
    }
}
