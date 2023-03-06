using CsvHelper.Configuration.Attributes;

public class Vare
{
    // Bruger Bare denne værdi som min kurs håber det er okay
    // Public bruger jeg så kan senere kan bruge nogle af de neden stående variabler i andre classes og senere Skrive dem i min nye CSV file
    public static float EuroTODkk = 7.44f;
    public readonly string item;
    public readonly string articleDescription = "DataIkkeHentet";
    private readonly string unit;
    private readonly float kostPrisEuro;
    public float kostPrisDkk;
    private readonly float priceUnit;
    private readonly string priceGroupe;
    private readonly DateTime dateOfIssuance;
    public readonly float SlagsPris;

    public Vare(string itemI, string articleDescriptionI, string unitI, float kostPrisEuroI, float priceUnitI, string priceGroupeI, DateTime dateOfIssuanceI) 
    { 
        // Det er sådan her jeg instancere
        item = itemI;
        articleDescription = articleDescriptionI;
        unit = unitI;
        kostPrisEuro = kostPrisEuroI;
        priceUnit = priceUnitI;
        priceGroupe = priceGroupeI;
        dateOfIssuance = dateOfIssuanceI;


        Console.WriteLine("Item Added: "+ item + " " + articleDescription + " " + unit + " " + kostPrisEuro + " " + priceUnit + " " + priceGroupe + " " + dateOfIssuance);


        SlagsPris = SalgsPrisCalc(kostPrisEuro, priceGroupe);


        Console.WriteLine("salgsPris " + SlagsPris + " Dkk" + " Kostpris " + kostPrisDkk + " Dkk");
    }

    float SalgsPrisCalc(float euroPris, string priceGroup)
    {

        kostPrisDkk = euroPris * EuroTODkk;

        //Her udregner jeg salgs prisen ved at lægge for fortjenestes oveni så vi får salgs prisen

        float SalgsPris;
        if (priceGroup == "30%")
        {
            SalgsPris = kostPrisDkk * 1.30f;
        }
        else if (priceGroup == "40%")
        {
            SalgsPris = kostPrisDkk * 1.40f;
        }
        else if (priceGroup == "50%")
        {
            SalgsPris = kostPrisDkk * 1.50f;
        }
        else
        {
            SalgsPris = kostPrisDkk;
        }

        return SalgsPris;
    }
}