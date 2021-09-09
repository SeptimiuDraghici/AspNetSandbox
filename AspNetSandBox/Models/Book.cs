using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandBox.Models
{
    /// <summary>Book model used to create Book objects for our List.</summary>
    public class Book
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
