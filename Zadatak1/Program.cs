using System;
using System.Collections.Generic;

public abstract class Student
{
    public int BrojIndeksa { get; set; }
    public string Ime { get; set; }
    public int Godina { get; set; }

    public Student(int brojIndeksa, string ime, int godina)
    {
        BrojIndeksa = brojIndeksa;
        Ime = ime;
        Godina = godina;
    }

    public abstract void PrikaziDetalje();
}

public class BachelorStudent : Student
{
    public BachelorStudent(int brojIndeksa, string ime, int godina)
        : base(brojIndeksa, ime, godina) { }

    public override void PrikaziDetalje()
    {
        Console.WriteLine($"Bachelor Student - Broj Indeksa: {BrojIndeksa}, Ime: {Ime}, Godina: {Godina}");
    }
}

public class MasterStudent : Student
{
    public string TemaRada { get; set; }

    public MasterStudent(int brojIndeksa, string ime, int godina, string temaRada)
        : base(brojIndeksa, ime, godina)
    {
        TemaRada = temaRada;
    }

    public override void PrikaziDetalje()
    {
        Console.WriteLine($"Master Student - Broj Indeksa: {BrojIndeksa}, Ime: {Ime}, Godina: {Godina}, Tema Rada: {TemaRada}");
    }
}

public class StudentskiSistem
{
    private static List<Student> studenti = new List<Student>();

    public static void DodajStudenta()
    {
        // Anand unosi kod rjesenja ove metode
        Console.Write("Unesite broj indeksa: ");
        int brojIndeksa = int.Parse(Console.ReadLine());
        Console.Write("Unesite ime studenta: ");
        string ime = Console.ReadLine();
        Console.Write("Unesite godinu: ");
        int godina = int.Parse(Console.ReadLine());

        studenti.Add(new BachelorStudent(brojIndeksa, ime, godina));
        Console.WriteLine("Student je uspješno dodan.");
    }

    public static void DodajMasterStudenta()
    {
        // Anand unosi kod rjesenja ove metode
        Console.Write("Unesite broj indeksa: ");
        int brojIndeksa = int.Parse(Console.ReadLine());
        Console.Write("Unesite ime studenta: ");
        string ime = Console.ReadLine();
        Console.Write("Unesite godinu: ");
        int godina = int.Parse(Console.ReadLine());
        Console.Write("Unesite temu master rada: ");
        string temaRada = Console.ReadLine();

        studenti.Add(new MasterStudent(brojIndeksa, ime, godina, temaRada));
        Console.WriteLine("Master student je uspješno dodan.");
    }

    public static void IspisiStudente()
    {
        // Anand unosi kod rjesenja ove metode
        foreach (var student in studenti)
        {
            student.PrikaziDetalje();
        }
    }

    public static void IspisiStudenta(int brojIndeksa)
    {
        // Abdullah unosi kod rjesenja ove metode
         Student student = studenti.Find(s => s.BrojIndeksa == brojIndeksa);
    if (student == null)
    {
        Console.WriteLine("Student sa datim indeksom nije pronađen.");
        return;
    }

    student.PrikaziDetalje();
    }

    public static void ObrisiStudenta(int brojIndeksa)
    {
        // Abdullah unosi kod rjesenja ove metode
         Student student = studenti.Find(s => s.BrojIndeksa == brojIndeksa);
    if (student == null)
    {
        Console.WriteLine("Student sa datim indeksom nije pronađen.");
        return;
    }

    studenti.Remove(student);
    Console.WriteLine("Student je uspješno obrisan.");
    }

    public static void AzurirajStudenta(int brojIndeksa)
    {
        // Ahmed unosi kod rjesenja ove metode.
        // .

        Student student = studenti.Find(s => s.BrojIndeksa == brojIndeksa);
    if (student == null)
    {
        Console.WriteLine("Student sa datim indeksom nije pronađen.");
        return;
    }

    Console.WriteLine($"Ažuriranje podataka za studenta: {student.Ime}");
    Console.Write("Unesite novo ime (ili pritisnite Enter da zadržite postojeće): ");
    string novoIme = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(novoIme))
    {
        student.Ime = novoIme;
    }

    Console.Write("Unesite novu godinu (ili pritisnite Enter da zadržite postojeću): ");
    string novaGodina = Console.ReadLine();
    if (int.TryParse(novaGodina, out int novaGodinaInt))
    {
        student.Godina = novaGodinaInt;
    }

    if (student is MasterStudent masterStudent)
    {
        Console.Write("Unesite novu temu rada (ili pritisnite Enter da zadržite postojeću): ");
        string novaTema = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novaTema))
        {
            masterStudent.TemaRada = novaTema;
        }
    }

    Console.WriteLine("Podaci su uspješno ažurirani.");
    }

    public static void PretragaStudenta(string keyword)
    {
        // Ahmed unosi kod rjesenja ove metode

        List<Student> rezultatiPretrage = studenti.FindAll(s =>
        s.BrojIndeksa.ToString().Contains(keyword) ||
        s.Ime.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);

    if (rezultatiPretrage.Count == 0)
    {
        Console.WriteLine("Nema studenata koji odgovaraju pretrazi.");
        return;
    }

    Console.WriteLine("Pronađeni studenti:");
    foreach (Student s in rezultatiPretrage)
    {
        s.PrikaziDetalje();
    }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n1. Dodaj studenta");
            Console.WriteLine("2. Dodaj postdiplomskog studenta");
            Console.WriteLine("3. Prikaži sve studente");
            Console.WriteLine("4. Prikaži detalje studenta");
            Console.WriteLine("5. Ažuriraj podatke studenta");
            Console.WriteLine("6. Izbriši studenta");
            Console.WriteLine("7. Pretraži studente");
            Console.WriteLine("0. Izlaz");
            Console.Write("Odaberite opciju: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    StudentskiSistem.DodajStudenta();
                    break;
                case "2":
                    StudentskiSistem.DodajMasterStudenta();
                    break;
                case "3":
                    StudentskiSistem.IspisiStudente();
                    break;
                case "4":
                    Console.Write("\nUnesite indeks studenta za ispis: ");
                    int brojIndeksa = int.Parse(Console.ReadLine());
                    StudentskiSistem.IspisiStudenta(brojIndeksa);
                    break;
                case "5":
                    Console.Write("\nUnesite indeks studenta za azurirati: ");
                    brojIndeksa = int.Parse(Console.ReadLine());
                    StudentskiSistem.AzurirajStudenta(brojIndeksa);
                    break;
                case "6":
                    Console.Write("\nUnesite indeks studenta za obrisati: ");
                    brojIndeksa = int.Parse(Console.ReadLine());
                    StudentskiSistem.ObrisiStudenta(brojIndeksa);
                    break;
                case "7":
                    Console.Write("\nUnesite indeks ili ime studenta za pretragu: ");
                    string keyword = Console.ReadLine();
                    StudentskiSistem.PretragaStudenta(keyword);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Nevažeća opcija! Pokušajte ponovo.");
                    break;
            }
        }
    }
}

