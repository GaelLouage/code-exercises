using Code_Exercises.LibraryExercises.Interfaces;

namespace Code_Exercises.LibraryExercises.Classes
{
    public class Book : IIdentifiable
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
    }
}
