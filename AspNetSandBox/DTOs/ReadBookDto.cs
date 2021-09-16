using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandBox.DTOs
{
    /// <summary>
    /// Reads book without showing PurchasePrice.
    /// </summary>
    public class ReadBookDto
    {
        /// <summary>Gets or sets the Id of Book object.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the Title of Book object.</summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the Author of Book object.</summary>
        public string Author { get; set; }

        /// <summary>Gets or sets the Language of Book object.</summary>
        public string Language { get; set; }
    }
}
