using System;
using System.Collections.Generic;

namespace web.Models 
{     
    public class Hasher     
    {           
        public Guid Id { get; set; }
        public string HashName { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set;}
        public string City {get; set;}
        public ICollection<HasherTrail> HasherTrails { get; set; }

    }

    public class HasherTrail
    {
        public Hasher Hasher {get; set;}
        public Guid TrailId {get; set;}
        public Guid HasherId { get; set; }
        public Trail Trail {get; set;}
    }

    public class Trail
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<HasherTrail> HasherTrails { get; set; }
        

    }
}