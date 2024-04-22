using System.Collections.Generic;

namespace SviatoslavSkobalskyi.Meninx.DevTestTask.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Book> Books { get; } = new List<Book>();
    }
}
