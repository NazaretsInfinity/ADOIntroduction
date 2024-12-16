using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LibraryTWO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library.Select("author_id, first_name, last_name", "Authors");
            Library.Select("book_title, publish_date ,[Author]=first_name+ ' ' + last_name", "Authors,Books", "author = author_id", 34);
        }
    }
}
