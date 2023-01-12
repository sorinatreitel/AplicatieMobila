using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AplicatieMobila.Models
{
    public class Comenzi
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(250), Unique]
        public string Description { get; set; }
        public DateTime DateComanda { get; set; }
        [ForeignKey(typeof(Magazin))]
        public int MagazinID { get; set; }

    }
}
