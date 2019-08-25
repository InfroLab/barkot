/*using SQLite;
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
        public string Site
        {
            get
            {
                return Site;
            }
            set
            {
                Site = @"https://logo.clearbit.com/" + value;
            }
        }

        public Card()
        {
        }
        public Card(string company, string barcode, string type, string site)
        {
            Company = company;
            Barcode = barcode;
            Type = type;
            Site = site;
        }
    }
}
*/