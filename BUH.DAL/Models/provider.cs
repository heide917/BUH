using System.Collections.Generic;

namespace BUH.DAL.Models
{
    public class Provider
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public string OKPO { get; set; }

        public string Title { get; set; }

        public string Certificate { get; set; }

        public string FullName { get; set; }

        public string Bank { get; set; }

        public int AccountId { get; set; }

        public virtual Account Account { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }

        public virtual ICollection<Journal> Journals { get; set; }
    }
}





/*IV.Поставщики
Id      Id int
Tip     Type int (1-организация,2-ФОП...)
Kod Code      int (TMC)   //связка   
OKPO    OKPO vchar(20)   //ОКПО для орг.
Nazv Title    vchar(max) //название для орг.
Svid Сertificate    vchar(250)  //свидетельство для ФОП
FIO FullName       vchar(250)  //ФИО ФОП
Bank Bank     vchar(max)
Rsch Account       vchar(max)  //расчетный счет
Dogov Сontract      int (DOG)     //связкка
*/