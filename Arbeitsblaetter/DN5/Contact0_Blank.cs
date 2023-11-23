using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace DN6 {
    public class Contact0_Blank /* TODO Implement */ {
        public String Name {get;set;}
        public String Kurz {get;set;}
        public String Standort{get;set;}
        public String Kategorie{get;set;}
        public String EMail{get;set;}
        public String Tel{get;set;}
        public String Departement{get;set;}
        
        public override String ToString() {
            // TODO Implement
        }
        
        public String ToVcf () {
            // TODO Implement 
        }

        public IEnumerator<String> GetEnumerator() {
            // TODO Implement
        }

        public Contact0_Blank(string name, string kurz, string standort, string kategorie, string eMail, string tel, string dep)  {
            // TODO Implement
        }

        public int CompareTo(Contact0_Blank other) {
            // TODO Implement
        }

    }
}
