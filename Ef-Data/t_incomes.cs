//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ef_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_incomes
    {
        public int ID { get; set; }
        public double AMOUNT { get; set; }
        public Nullable<System.DateTime> INC_DATE { get; set; }
        public int CATEGORY { get; set; }
        public int METHOD { get; set; }
        public string COMMENTS { get; set; }
    
        public virtual t_incomes_category t_incomes_category { get; set; }
        public virtual t_payment_methods t_payment_methods { get; set; }
    }
}
