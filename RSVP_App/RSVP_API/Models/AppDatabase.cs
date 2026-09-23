using RSVP_API.Models;
using SQLite;

namespace RSVP_API.DataAccess
{
    public class AppDatabase
    {
        private SQLiteAsyncConnection? database;

        private async Task Init()
        {
            if (database != null)
                return;

            database = new SQLiteAsyncConnection(
                DatabaseConstants.DatabasePath,
                DatabaseConstants.Flags);

            await database.CreateTableAsync<User>();
            await database.CreateTableAsync<Event>();
            await database.CreateTableAsync<RSVP>();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            await Init();

            return await database!.Table<User>().ToListAsync();
        }

        public async Task<User?> LoginAsync(
            string username,
            string password)
        {
            await Init();

            return await database!
                .Table<User>()
                .Where(x =>
                    x.UserName == username &&
                    x.Password == password)
                .FirstOrDefaultAsync();
        }

        public async Task<int> AddUserAsync(User user)
        {
            await Init();

            return await database!.InsertAsync(user);
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            await Init();

            return await database!.Table<Event>().ToListAsync();
        }

        public async Task<Event?> GetEventAsync(int id)
        {
            await Init();

            return await database!
                .Table<Event>()
                .Where(x => x.ID == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Event>> GetHostedEventsAsync(int userId)
        {
            await Init();

            return await database!
                .Table<Event>()
                .Where(x => x.HostUserID == userId)
                .ToListAsync();
        }

        public async Task<int> AddEventAsync(Event eventItem)
        {
            await Init();

            return await database!.InsertAsync(eventItem);
        }

        public async Task<int> AddRSVPAsync(RSVP rsvp)
        {
            await Init();

            return await database!.InsertAsync(rsvp);
        }

        public async Task<List<RSVP>> GetUserRSVPsAsync(int userId)
        {
            await Init();

            return await database!
                .Table<RSVP>()
                .Where(x =>
                    x.UserID == userId &&
                    x.Response == "Attending")
                .ToListAsync();
        }

        public async Task<List<Event>> GetAttendingEventsAsync(int userId)
        {
            await Init();

            var rsvps = await GetUserRSVPsAsync(userId);

            var events = new List<Event>();

            foreach (var rsvp in rsvps)
            {
                var eventItem =
                    await GetEventAsync(rsvp.EventID);

                if (eventItem != null)
                    events.Add(eventItem);
            }

            return events;
        }
    }
}