using System;
using System.Collections.Generic;
using BUH.DAL.Models;

namespace BUH.DAL.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int AccountId { get; set; }

        public virtual Account Account { get; set; }

        public string Manufacturer { get; set; }

        public int Series { get; set; }

        public string Unit { get; set; }

        public decimal? Cost { get; set; }

        public decimal Amortization { get; set; }

        public DateTime ComingDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ProviderId { get; set; }

        public virtual Provider Provider { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        public ICollection<Journal> Journals { get; set; }

        public ICollection<SubTransaction> SubTransactions { get; set; }
    }
}


/*
 * II. ТМЦ
Id    Id			     int
Sch   Account 			 vchar(10)(SCH)     //счет на котором сидит возможно забаланс
Kod   Code   			int                //?? типа уник внутренне поле для связи 
Nom   Number  			vchar(100)          //номер инвентарный
Nazv  Title  			 vchar(max)         //название
Opis  Description 		 vchar(max)         //описание
Przv  Manufacturer 		vchar(nax)        //производитель
Ser   Series    		int               //серия,партия
Edis  Unit    			vhar(50)          //ед.измерения
MOL   Person  			 int(MOL)           //мол связка с таб
POST  Provider			        int(POST)           //поставщик  связка с таб
*/
