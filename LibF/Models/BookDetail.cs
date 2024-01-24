using System;
using System.Collections.Generic;

namespace LibF.Models;

public partial class BookDetail
{
    public int BookID { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public string? BookType { get; set; }

    public DateTime Publisheddate { get; set; }

    public int? Price { get; set; }
}
