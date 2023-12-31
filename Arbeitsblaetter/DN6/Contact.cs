﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DN6 {
    public class Contact : IComparable<Contact> {
        public String Name { get; set; }
        public String Kurz { get; set; }
        public String Standort { get; set; }
        public String Kategorie { get; set; }
        public String EMail { get; set; }
        public String Tel { get; set; }
        public String Departement { get; set; }
        
        public Contact(string name, string kurz, string standort, string kategorie, string eMail, string tel, string dep) {
            Name = name;
            Kurz = kurz;
            Standort = standort;
            Kategorie = kategorie;
            EMail = eMail;
            Tel = tel;
            Departement = dep;
        }

        public override String ToString() => $"{Name};{Kurz};{Standort};{Kategorie};{EMail};{Tel};{Departement};";

        public String ToVcf()
        =>
            $@"BEGIN:VCARD
            VERSION:3.0
            N:{Name}
            FN:{Name}
            ORG:{Departement}
            ADR;WORK:{Standort}
            TEL;WORK;VOICE:{Tel}
            EMAIL;INTERNET:{EMail}
            END:VCARD";
        

        public IEnumerator<String> GetEnumerator() {
            yield return Name;
            yield return Kurz;
            yield return Standort;
            yield return Kategorie;
            yield return EMail;
            yield return Tel;
            yield return Departement;
        }

        public int CompareTo(Contact other) => String.Compare(Name, other.Name, StringComparison.Ordinal);
    }
}