using System;
using System.Collections.Generic;
using BUH.DAL.Models;

namespace BUH.DAL.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Department { get; set; }

        public int Position { get; set; }

        public virtual ICollection<Journal> Journals { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}


/*
 * III.МОЛ Person
Id   Id		    int
Kod  Code		  int(TMC)       //связка
FIO  FullName		   vchar(250)     
Mr   Department		 ? vchar(100)     //место работы 
Dol  Position		    int               //должность 1-зав.,2-сестра-хозяйка,3-кладовщик....
*/