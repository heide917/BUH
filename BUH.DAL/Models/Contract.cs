using System;

namespace BUH.DAL.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Object { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public int ProviderId { get; set; }

        public virtual Provider Provider { get; set; }
    }
}


/*V.Договора  Contract 
Id  	Id	    int
Kod 	Code	  int(POST)         //связка
Nom	Number	  vchar(100)         //номер
Predm	Object	 vchar(max) //предмет договора
Dn   	DateStart	   date           //дата начала
Do   	DateEnd	   date           //дата окончания
*/