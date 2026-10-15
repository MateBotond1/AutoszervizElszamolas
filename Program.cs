using AutoszervizElszamolas;
List<Szerelo> Lista=new List<Szerelo>();
foreach(string beolvasott in File.ReadAllLines("szerviz.txt"))
{
    string[] adatok=beolvasott.Split(";");
    Szerelo aktualis=new Szerelo();
    aktualis.Nev=adatok[0];
    aktualis.JavitottAutok=int.Parse(adatok[1]);
    aktualis.Munkaora = int.Parse(adatok[2]);
    aktualis.GarancialisJavitasok=int.Parse(adatok[3]);
    Lista.Add( aktualis );
}
Console.WriteLine("Szerelők napi elszámolása:");
int teljesnapiber = 0;
int munkaossz = 0;
int legmagasabbber = 0;
string legjobbdolgozo = "";
int garancialishibanelkul = 0;
for (int i=0; i<Lista.Count; i++)
{
    int bonusz = 0;
    int levonas = 0;

    if (Lista[i].JavitottAutok>=6 && Lista[i].GarancialisJavitasok <= 1) { bonusz = 15000; }
    if (Lista[i].GarancialisJavitasok >= 2) { levonas = 10000; }
    Console.WriteLine($"{Lista[i].Nev}: {Lista[i].JavitottAutok} autó, {Lista[i].Munkaora} óra (Garanciális: {Lista[i].GarancialisJavitasok}) - Munkabér: {(Lista[i].Munkaora * 4000) + (Lista[i].JavitottAutok * 5000) + bonusz - levonas}");
    teljesnapiber += (Lista[i].Munkaora * 4000) + (Lista[i].JavitottAutok * 5000) + bonusz - levonas;
    munkaossz += Lista[i].Munkaora;
    if (((Lista[i].Munkaora * 4000) + (Lista[i].JavitottAutok * 5000) + bonusz - levonas) > legmagasabbber) { legmagasabbber = (Lista[i].Munkaora * 4000) + (Lista[i].JavitottAutok * 5000) + bonusz - levonas; legjobbdolgozo = Lista[i].Nev; }
    if (Lista[i].GarancialisJavitasok == 0) { garancialishibanelkul += 1; }
}
double atlagmunka = (double)munkaossz / Lista.Count;
Console.WriteLine("Összesített statisztika:");
Console.WriteLine($"Szerviz által kifizetett teljes munkabér: {teljesnapiber} Ft");
Console.WriteLine($"Átlagos munkaóra szerelőnként: {atlagmunka:F0} óra");
Console.WriteLine($"Legmagasabb napi bér: {legjobbdolgozo} ({legmagasabbber} Ft)");
Console.WriteLine($"Garanciális hiba nélkül dolgozó szerelők száma: {garancialishibanelkul} fő");