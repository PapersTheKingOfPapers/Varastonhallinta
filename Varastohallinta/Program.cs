using Varastohallinta;

Console.WriteLine("VARASTONHALLINTA");
while (true)
{
    OptionPrint();
    float vastaus = Convert.ToInt32(Console.ReadLine());
    if(vastaus == 0)
    {
        break;
    }
    else
    {

    }
}

void OptionPrint()
{
    Console.WriteLine("1 - Lisää uusi tuote");
    Console.WriteLine("2 - Poista tuote");
    Console.WriteLine("3 - Tulosta eri tuotteiden määrät");
    Console.WriteLine("4 - Muokkaa tuotenimeä");
    Console.WriteLine("0 - Lopeta sovellus");
    Console.WriteLine(""); // Empty Line
    Console.WriteLine("Valintasi on:");
}



