using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization;

namespace DN7 {
    public class Contact_Blank : IComparable<Contact> {
        public String Name { get; set; }
        public String Kurz { get; set; }
        public String Standort { get; set; }
        public String Kategorie { get; set; }
        public String EMail { get; set; }
        public String Tel { get; set; }
        public String Departement { get; set; }

        public override String ToString() {
            StringBuilder b = new StringBuilder();
            foreach (String s in this) { b.Append(s); b.Append(";"); }
            return b.ToString();
        }

        public String ToVcf() {
            string res = "BEGIN:VCARD\n" +
                      "VERSION:3.0\n" +
                      "N;CHARSET=ISO-8859-1:" + Name + ";;;;\n" +
                      "FN;CHARSET=ISO-8859-1:" + Name + "\n" +
                      "ADR;TYPE=work,pref;CHARSET=ISO-8859-1:;/" + Standort + "\n" +
                      "TEL;TYPE=work,voice,pref:+" + Tel + "\n" +
                      "EMAIL;TYPE=INTERNET:natalie.lynch@pencloud.com\n" +
                      "END:VCARD";
            return res;
        }

        private static string GetTelNumber(String kurz) {
            // TODO Implement
        }


        public void addPhoneNumber() {
            Tel = GetTelNumber(Kurz).Replace("(0)","").Replace(" ","");
        }

        public IEnumerator<String> GetEnumerator() {
            // TODO Implement
        }

        public Contact_Blank(string name, string kurz, string standort, string kategorie, string eMail, string tel, string dep) {
            Name = name;
            Kurz = kurz;
            Standort = standort;
            Kategorie = kategorie;
            EMail = eMail;
            Tel = tel;
            Departement = dep;
        }

        public int CompareTo(Contact other) {
            return other.Name.CompareTo(Name);
        }

    }
}
