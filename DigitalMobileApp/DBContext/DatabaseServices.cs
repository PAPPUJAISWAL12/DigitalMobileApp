using DigitalMobileApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMobileApp.DBContext
{
    
    class DatabaseServices
    {
        private readonly SQLiteAsyncConnection _context;

        public DatabaseServices(string dbpath)
        {
            _context =new SQLiteAsyncConnection(dbpath);
            InitializeDatabase();
        }
        private async void InitializeDatabase()
        {
            await _context.CreateTableAsync<Notes>();
        }
        public Task<List<Notes>> GetNoteList()
        {
            return _context.Table<Notes>().ToListAsync();
        }

        public async Task AddNotes(Notes note)
        {
            await _context.InsertAsync(note);
        }

        public async void DeleteNotes(Notes n)
        {
            await _context.DeleteAsync(n);
        }
        public async Task UpdateNotes(Notes note)
        {
            await _context.UpdateAsync(note);
        }
    }
}
