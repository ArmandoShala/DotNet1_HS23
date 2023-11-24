using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

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
        
        private static string GetTelNumber(String kurz) {
            return "+41589347588";
            try {
                var url = $"https://www.zhaw.ch/de/ueber-uns/person/{kurz}";
                using var client = new WebClient();
                var html = client.DownloadString(url);

                var match = Regex.Match(html, @"<span class=\""person-fon\""><a href=\""tel:(.+?)\"">");
                if (match.Success) {
                    var phone = match.Groups[1].Value.Replace("(0)","").Replace(" ","");
                    return phone;
                } else {
                    // Wenn kein Match gefunden wurde, geben Sie eine klare Nachricht zurück oder loggen Sie den Fehler.
                    Console.WriteLine("Keine Telefonnummer gefunden.");
                    return string.Empty;
                }
            } catch (WebException webEx) {
                // Log the web exception details
                Console.WriteLine("WebException: " + webEx.Message);
                return string.Empty;
            } catch (Exception ex) {
                // Log any other exception details
                Console.WriteLine("Exception: " + ex.Message);
                return string.Empty;
            }

        }


        
        public void addPhoneNumber() => Tel = GetTelNumber(Kurz).Replace("(0)","").Replace(" ","");


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