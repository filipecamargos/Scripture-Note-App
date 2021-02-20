using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    //This is the model for the scripture note to be manipulated
    public class Scripture
    {   
        //The scripture ID
        public int ID { get; set; }

        //Scritpure reference
        public string MyScripture { get; set; }

        //Date of entry
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
        
        //Scripture Note
        public string SriptureNote { get; set; }



    }
}
