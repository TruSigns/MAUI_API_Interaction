using SQLite;
using RSVP_App.Models;

namespace RSVP_App.DataAccess
{
    public class AppDatabase
    {
        private SQLiteAsyncConnection? database;

        private async Task Init()
        {
            if (database is not null)
            {
                return;
            }

            database = new SQLiteAsyncConnection(
                DatabaseConstants.DatabasePath,
                DatabaseConstants.Flags);

            await database.CreateTableAsync<User>();
            await database.CreateTableAsync<Event>();
            await database.CreateTableAsync<RSVP>();
        }

        public async Task<int> AddUserAsync(User user)
        {
            await Init();

            return await database!.InsertAsync(user);
        }

        public async Task<User?> LoginAsync(
            string userName,
            string password)
        {
            await Init();

            return await database!
                .Table<User>()
                .Where(u =>
                    u.UserName == userName &&
                    u.Password == password)
                .FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            await Init();

            return await database!
                .Table<User>()
                .ToListAsync();
        }

        public async Task<int> AddEventAsync(Event eventItem)
        {
            await Init();

            return await database!.InsertAsync(eventItem);
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            await Init();

            return await database!
                .Table<Event>()
                .ToListAsync();
        }

        public async Task<Event?> GetEventAsync(int id)
        {
            await Init();

            return await database!
                .Table<Event>()
                .Where(e => e.ID == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Event>> GetHostedEventsAsync(
            int userId)
        {
            await Init();

            return await database!
                .Table<Event>()
                .Where(e => e.HostUserID == userId)
                .ToListAsync();
        }

        public async Task<int> AddRSVPAsync(RSVP rsvp)
        {
            await Init();

            return await database!.InsertAsync(rsvp);
        }

        public async Task<List<RSVP>> GetUserRSVPsAsync(
            int userId)
        {
            await Init();

            return await database!
                .Table<RSVP>()
                .Where(r =>
                    r.UserID == userId &&
                    r.Response == "Attending")
                .ToListAsync();
        }

        public async Task<List<Event>> GetAttendingEventsAsync(
            int userId)
        {
            await Init();

            var rsvps = await GetUserRSVPsAsync(userId);
            var events = new List<Event>();

            foreach (var rsvp in rsvps)
            {
                var eventItem =
                    await GetEventAsync(rsvp.EventID);

                if (eventItem is not null)
                {
                    events.Add(eventItem);
                }
            }

            return events;
        }
    }
}