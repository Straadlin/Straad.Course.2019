//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exercise0001.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Foots { get; set; }
        public int IdState { get; set; }
        public byte[] picture { get; set; }
    
        public virtual State State { get; set; }
    }
}
