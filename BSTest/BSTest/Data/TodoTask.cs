using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Data
{
    public class TodoTask
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string TaskName { get; set; }

        public bool Done { get; set; }
    }
}
