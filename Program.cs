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
