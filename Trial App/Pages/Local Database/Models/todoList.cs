using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trial_App.Pages.Local_Database.Models
{
    public class todoList
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        public string listItems { get; set; }
        public string timeStamp{ get; set; }
    }
}
