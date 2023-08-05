using Code_Exercises.LibraryExercises.Interfaces;

namespace Code_Exercises.LibraryExercises.Classes
{
    public class Member : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book>? Books { get; set; }
    }
}
