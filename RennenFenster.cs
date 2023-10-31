using System;

namespace PferderennenII
{
    class RennenFenster : Fenster
    {
        /* eigener Konstruktor für den separaten Baustein 
        AusgabeTextWette -> Objekt pferd1, pferd2 und den 
        Wert für die Wette übergeben */
        public RennenFenster(Pferd pferd1, Pferd pferd2, 
            string wette)
        {
            AusgabeTextWette(pferd1, pferd2, wette); /* Aus Basisklasse 
                                                     Fenster */
            StartSchuss();
            bool wertErreicht = false;
            Fenster loopFenster = new LoopFenster(pferd1, pferd2, wette);
        }
        /* Methoden: 1. überschriebene abstrakte Methode mit kurzem Text */
        public override void AngezeigterText()
        {
            Console.WriteLine("  Am Start warten bereits:");
            Console.WriteLine();
        }
        /* 2. eigene Methode für den Text zum Startschuss */
        public void StartSchuss()
        {
            //Weiterer Text: Aufforderung zum Startschuss
            Console.WriteLine();
            Console.WriteLine("  Die Wette gilt!");
            Console.WriteLine();
            Console.WriteLine("  Du darfst den Startschuss geben!");
            Console.WriteLine("  Drücke eine beliebige Taste! GO GO GO:");
            Console.ReadKey();
        }
    }
}
