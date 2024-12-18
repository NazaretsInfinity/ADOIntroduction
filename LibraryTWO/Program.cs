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
            //Library.Insert("Authors", "author_id, last_name, first_name", "11, 'Stroustrup', 'Bjarne'");
            //Library.InsertAuthor(12, "Randy", "Gadge");
            //Console.WriteLine(Library.GetAuthorID("Scott Muller"));
            //Library.InsertAuthor(13, "Stroustrup", "Bjarne");


            Library.InsertBook(7, "C++ Programming Language", 331, "1986-01-29", "Bjarne Stroustroup");

            Library.Select("author_id, first_name, last_name", "Authors");
            Library.Select("book_title, publish_date ,[Author]=first_name+ ' ' + last_name", "Authors,Books", "author = author_id", 34);
        }
    }
}
