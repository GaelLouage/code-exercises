using Code_Exercises.LibraryExercises.Classes;
using Code_Exercises.LibraryExercises.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Exercises.LibraryExercises.Data
{
    internal class LibraryManager
    {
        private readonly ILibrary _library;
        public LibraryManager(ILibrary library)
        {
            _library = library;
        }

        public (StringBuilder sb, Func<string> fs) CallLibrary()
        {
            var sb = new StringBuilder();
            List<Member> members = new List<Member>
        {
            new Member { Id = 101, Name = "Member1", Books = new List<Book>() { new Book() { Id = 2, Author = "Author2", Title = "Book2"}} },
            new Member { Id = 102, Name = "Member2" },
            new Member { Id = 103, Name = "Member3" }
        };

            _library.Books.Add(new Book { Id = 1, Author = "Author1", Title = "Book1" });
            _library.Books.Add(new Book { Id = 2, Author = "Author2", Title = "Book2" });
            _library.Books.Add(new Book { Id = 3, Author = "Author3", Title = "Book3" });

            _library.Members.AddRange(members);
            var member = _library.Members.FirstOrDefault(x => x.Id == 101);

            if (member is null)
            {
                return (null, () => $"No member with id {101} found!");
            }
            var bookToLend = _library.Books.FirstOrDefault(x => x.Id == 1);
            if (bookToLend is null)
            {
                return (null, () => $"No Book with id {1} found!");
            }
            _library.LendBook(bookToLend, member.Id);

            // book to return 

            _library.ReturnBook(member, member.Books.FirstOrDefault(x => x.Id == 2));
            foreach (var book in member.Books)
            {
                sb.Append($"Book id: {book.Id}.");
                sb.Append($"Book title: {book.Title}.");
            }
            return (sb, () => "Succes");
        }
    }
}
