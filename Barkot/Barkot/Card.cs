using SQLite;
namespace Barkot
{
    [Table("Cards")]
    public class Card
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        public string Company { get; set; }
        public string Barcode { get; set; }
        public string Type { get; set; }
        public string Site { get; set; }

        public Card()
        {
        }
    }
}