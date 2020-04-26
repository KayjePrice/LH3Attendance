using System;
using System.Collections.Generic;

namespace web.ViewModels
{
    public class TrailEditViewModel
    {  
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public List<Guid> HasherIds {get; set;}
    
    }
}