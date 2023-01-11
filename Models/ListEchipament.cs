using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace AplicatieMobila.Models
{
   public class ListEchipament
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Comenzi))]
        public int ComenziID { get; set; }
        public int EchipamentID { get; set; }
    }
}
