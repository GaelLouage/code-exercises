using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code_Exercises.LibraryExercises.Interfaces;

namespace Code_Exercises.LibraryExercises.Classes
{
    public class Library : ILibrary
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Member> Members { get; set; } = new List<Member>();
        public void LendBook(Book book, int memberId)
        {
            if (Books.Contains(book))
            {
                var member = Members.FirstOrDefault(x => x.Id == memberId);
                if (member is not null)
                {
                    member.Books.Add(book);
                    Books.Remove(book);
                }
            }
        }

        public void ReturnBook(Member member, Book book)
        {
            var bookToReturn = member.Books.FirstOrDefault(x => x.Id == book.Id);
            if (bookToReturn is not null)
            {
                member.Books.Remove(bookToReturn);
                Books.Add(bookToReturn);
            }

        }
    }
}
