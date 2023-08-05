using Code_Exercises.LibraryExercises.Classes;

namespace Code_Exercises.LibraryExercises.Interfaces
{
    public interface ILibrary
    {
        List<Book> Books { get; set; }
        List<Member> Members { get; set; }
        void LendBook(Book book, int memberId);
        void ReturnBook(Member member, Book book);
    }
}