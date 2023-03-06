using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

// Thias Schou Dehlendorff Opgave Svar


using (var reader = new StreamReader("Prisliste.csv"))
{
    List<Vare> VareList = new List<Vare>();
    int i = 0;
    Console.WriteLine(" Kurs Euro to dkk = 7.44");
    // Her checker jeg om det er den første entry eller ej hvis ja springer den over for ellers for jeg denne linje med "Item;article description;unit;kostpris EUR;price unit;price group;date of issuance Vil jeg ikke :D
    while (reader.EndOfStream == false)
    {
        if(i == 0)
        {

            var line = reader.ReadLine();
        }
        else
        {
            var line = reader.ReadLine();
            //her spiltter jeg linjen op ved alle ";" Så jeg har det forskellige elementer
            List<string> strVare = line.Split(';').ToList();
            Console.WriteLine(i);
            // Her instancere jeg min nye fine vare og parser dem så jeg kan få dem i Float og Int variabler og Bruger min ItemUpdater og min priceGroupUpdater
            VareList.Add(new Vare(strVare[0], itemUpdater(strVare[1]), strVare[2], float.Parse(strVare[3].Substring(0, strVare[3].Length - 2)), float.Parse(strVare[4]), priceGroupUpdate(strVare[5]), DateTime.Parse(strVare[6])));
        }
       i++;

    }
    // Her åbner jeg eller laver en ny file og åbner, alt efter om den allerede existere
    var writer = File.Open("NyPrisliste.csv", FileMode.OpenOrCreate, FileAccess.Write);
    foreach (Vare vare in VareList)
    {
        
        string text = vare.item + ";" + vare.articleDescription + ";" + vare.kostPrisDkk + "Dkk;" + vare.SlagsPris.ToString() + "Dkk;\n";
        //Her encoder jeg texten til bytes som jeg så skriver i filen og Men den oven stående string(text)
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);
        
        //her skriver den det
        writer.Write(bytes);
    }
    // her lukker jeg filen så den ikke er i bruge af programmet så jeg faktisk kan åbne filen efter jeg er færdig med at skrive til den
    writer.Close();

    //Bare så programmet ikke lukker når den er færdig(for debugging skyld)
    Console.Read();

}


    string itemUpdater(string item)
    {
        // Her finder vi bare ordet black og replacer det med sort hvis det er der
        if (item.Contains("black"))
        {
            item = item.Replace("black", "sort");
        }
        return item;
    }

string priceGroupUpdate(string priceGroup)
{
    // Her checker jeg hvad fortjenesten er for de forskellige produkter og laver dem og til procent som beskrevet i opgaven
    string newpriceGroup = priceGroup.ToString() + "%";
    if (priceGroup == "21")
    {
        newpriceGroup = "30%";
    }
    else if (priceGroup == "22")
    {
        newpriceGroup = "50%";
    }
    else if (priceGroup == "23")
    {
        newpriceGroup = "40%";
    }
    else if (priceGroup == "24")
    {
        newpriceGroup = "40%";
    }
    else if (priceGroup == "25")
    {
        newpriceGroup = "50%";
    }

    return newpriceGroup;
}



