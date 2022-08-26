using System;
using Varastohallinta;

while (true)
{
    OptionPrint();
    float vastaus = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("-=====-"); // Divider Line
    if(vastaus == 0)
    {
        break;
    }
    else if(vastaus == 1)
    {
        AddProduct();
    }
    else if(vastaus == 2)
    {
        DeleteProduct();
    }
    else if(vastaus == 3)
    {
        QueringAmounts();
    }
    else if(vastaus == 4)
    {

    }
}

void OptionPrint()
{
    //Call this method to print these lines, cleaner in a method because you can close the method.
    Console.WriteLine("-=====-"); // Divider Line
    Console.WriteLine(""); // Empty Line
    Console.WriteLine("VARASTONHALLINTA");
    Console.WriteLine("1 - Lisää uusi tuote");
    Console.WriteLine("2 - Poista tuote");
    Console.WriteLine("3 - Tulosta eri tuotteiden määrät");
    Console.WriteLine("4 - Muokkaa tuotenimeä");
    Console.WriteLine("0 - Lopeta sovellus");
    Console.WriteLine(""); // Empty Line
    Console.WriteLine("Valintasi on:");
}

static bool AddProduct()
{
    using (Varastonhallinta varastohallinta = new())
    {
        Console.WriteLine("Tuotteen nimi? (STRING)");
        string productName = Console.ReadLine();
        Console.WriteLine("Tuotteen hinta? (INT)");
        int productPrice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Tuotteen määrä? (INT)");
        int productAmount = Convert.ToInt32(Console.ReadLine());

        IQueryable<Tuote>? tuotteet = varastohallinta.Tuotteet;

        Tuote tuote = new()
        {
            id = tuotteet?.Count()+1,
            tuoteNimi = productName,
            tuotenHinta = productPrice,
            varastoSaldo = productAmount
        };

        varastohallinta.Tuotteet?.Add(tuote);

        int affected = varastohallinta.SaveChanges();
        if(affected == 1)
        {
            Console.WriteLine("Tuote Lisätty ID:llä " + tuote.id);
        }
        return (affected == 1);
    }
}

static bool ChangeProductName()
{
    using (Varastonhallinta varastohallinta = new())
    {
        Console.WriteLine("Muokattavan tuotteen ID? (INT)");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Uusi tuotteen nimi? (STRING)");
        string newProductName = Console.ReadLine();

        Tuote tuoteUpdate = varastohallinta.Tuotteet.Find(id);

        if (tuoteUpdate is null)
        {
            return false;
        }
        else
        {
            tuoteUpdate.tuoteNimi = newProductName;
            int affected = varastohallinta.SaveChanges();
            if (affected == 1)
            {
                Console.WriteLine("Tuotteen nimi vaihdettu id:llä" + id);
            }
            return (affected == 1);
        }
    }
}

static void QueringAmounts()
{
    using (Varastonhallinta varastohallinta = new())
    {
        Console.WriteLine("Tuotteen ID, nimi ja niiden määrä:");

        IQueryable<Tuote>? tuotteet = varastohallinta.Tuotteet;

        if (tuotteet == null)
        {
            Console.WriteLine("Yhtään tuotteita ei ole tietokannassa.");
            return;
        }

        foreach (Tuote tuote in tuotteet)
        {
            Console.WriteLine($"{tuote.id}, {tuote.tuoteNimi}:n määrä on: {tuote.varastoSaldo}");
        }
    }
}

static int DeleteProduct()
{
    using (Varastonhallinta varastohallinta = new())
    {
        Console.WriteLine("Poistettavan tuotteen ID? (INT)");
        int id = Convert.ToInt32(Console.ReadLine());

        Tuote tuotePoisto = varastohallinta.Tuotteet.Find(id);

        if (tuotePoisto is null)
        {
            Console.WriteLine("Ei löydy!");
            return 0;
        }
        else
        {
            varastohallinta.Remove(tuotePoisto);
            int affected = varastohallinta.SaveChanges();
            if (affected == 1)
            {
                Console.WriteLine("Tuote poistettu id:llä " + id);
            }
            return affected;
        }
    }
}



