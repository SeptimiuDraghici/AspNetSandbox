using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandBox.DTOs
{
    /// <summary>
    /// Creates book without Id and PurchasePrice.
    /// </summary>
    public class CreateBookDto
    {
        /// <summary>Gets or sets the Title of Book object.</summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the Author of Book object.</summary>
        public string Author { get; set; }

        /// <summary>Gets or sets the Language of Book object.</summary>
        public string Language { get; set; }
    }
}
