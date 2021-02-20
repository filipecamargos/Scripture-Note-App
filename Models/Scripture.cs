using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }
        public string ScriptureReference { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Note { get; set; }

    }
}
