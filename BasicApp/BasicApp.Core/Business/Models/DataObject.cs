using SQLite.Net.Attributes;

namespace BasicApp.Business.Models
{
    public class DataObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
