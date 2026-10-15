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
for (int i=0; i<Lista.Count; i++)
{
    int bonusz = 0;
    int levonas = 0;

    if (Lista[i].JavitottAutok>=6 && Lista[i].GarancialisJavitasok <= 1) { bonusz = 15000; }
    if (Lista[i].GarancialisJavitasok >= 2) { levonas = 10000; }
    Console.WriteLine($"{Lista[i].Nev}: {Lista[i].JavitottAutok} autó, {Lista[i].Munkaora} óra (Garanciális: {Lista[i].GarancialisJavitasok}) - Munkabér: {(Lista[i].Munkaora * 4000) + (Lista[i].JavitottAutok * 5000) + bonusz - levonas}");
    
}