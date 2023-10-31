using System;

namespace PferderennenII
{
    class StartFenster : Fenster
    {
        /* kein eigener Konstruktor, da alle nötigen Bausteine im 
        Konstruktor der Basisklasse enthalten sind */

        //Methoden
        /* 1. Überschreiben der abstrakten Methode aus der Basisklasse */
        public override void AngezeigterText()
        {
            Console.WriteLine("  Willkommen beim Pferderennen!");
            Console.WriteLine("  Bitte wähle eine Aktion aus:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   [1] Spielen");
            Console.WriteLine("   [2] Beenden");
            Console.WriteLine();
            Console.ResetColor();

            ValidateEingabe();
        }
        /* Methode zum Validieren der Eingabe */
        private void ValidateEingabe()
        {
            string eingabe;
            /* Variable zum Zählen von Eingabefehlern */
            int eingabefehler = 0;
            //Schleife
            while (true)
            {
                bool korrekteEingabe = true;

                eingabe = Console.ReadLine();

                switch (eingabe)
                {
                    case "1":
                        //nächstes Fenster aufrufen
                        Fenster wettFenster = new WettFenster();
                        break;
                    case "2":
                        //nächstes Fenster aufrufen
                        Fenster endeFenster = new EndeFenster();
                        break;
                    default:
                        korrekteEingabe = false;
                        eingabefehler++;
                        //Fehlermeldung
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Falsche Eingabe!");
                        Console.ResetColor();
                        if (eingabefehler >= 5) /* zusätzlicher Satz ab 
                                                 5 falschen Eingaben */
                        {
                            //Fehlermeldung Zusatz
                            Console.WriteLine("Du musst 1 zum Starten oder 2 " +
                                "zum Beenden eingeben ;-)");
                        }
                        break;
                }

                if (korrekteEingabe)
                    break;  /* aus While-Schleife rausspringen, 
                            wenn die Eingabe korrekt war */
            }
        }
    }
}
