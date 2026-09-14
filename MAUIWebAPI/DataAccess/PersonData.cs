using SQLite;
using MAUIWebAPI.Models;

namespace MAUIWebAPI.DataAccess
{
    public class PersonData
    {
        private SQLiteConnection? database;

        public void Init()
        {
            if (database is not null)
            {
                return;
            }

            database = new SQLiteConnection(
                DatabaseConstants.DatabasePath,
                DatabaseConstants.Flags);

            database.CreateTable<Person>();
        }

        public List<Person> GetPeople()
        {
            Init();

            return database!.Table<Person>().ToList();
        }

        public int SavePerson(Person person)
        {
            Init();

            if (person.ID != 0)
            {
                return database!.Update(person);
            }
            else
            {
                return database!.Insert(person);
            }
        }
    }
}