using System;

namespace PferderennenII
{
    class LoopFenster : Fenster
    {
        /* Konstruktor: Objekt pferd1, pferd2 und den Wert für 
        die Wette übergeben*/
        public LoopFenster(Pferd pferd1, Pferd pferd2, string wette)
        {
            AusgabeTextWette(pferd1, pferd2, wette);
            RennLoop(pferd1, pferd2, wette);
            GewonnenVerloren(pferd1, pferd2, wette);
            AusgabeSpeed(pferd1, pferd2);
            Console.WriteLine();
            Console.Write("Drücke eine beliebige Taste um wieder " +
                "ins Hauptmenü zu kommen: ");
            Console.ReadKey(); 
            Fenster startFenster = new StartFenster(); /* zurück zum 
                                                       Startfenster */
        }
        /* 1. überschriebene abstrakte Methode mit kurzem Text */
        public override void AngezeigterText()
        {
            Console.WriteLine("  Es sind gestartet:");
            Console.WriteLine();
        }

        /* 3. Methode für die Animation des Rennens */
        public void RennLoop(Pferd pferd1, Pferd pferd2, string wette)
        {
            /* Werte der Eigenschaften der Pferde für den 
            Ablauf des Rennens generieren */
            pferd1.SpeedNeu = pferd1.SpeedGenerator();
            pferd2.SpeedNeu = pferd2.SpeedGenerator();
            /* Speed-Werte für die Animation umkeren, da das schnellere
            Pferd sonst langsamer dargestellt wird */
            pferd1.RevSpeedNeu = 130 - pferd1.SpeedNeu;
            pferd2.RevSpeedNeu = 130 - pferd2.SpeedNeu;

            Console.CursorVisible = false; /* Cursor unsichtbar stellen */

            /* Loop für die Animation */
            for (int i = 1; i <= 4000; i++)
            {
                //erste Zeile
                TextFarbWechsel1(wette);
                pferd1.Galopp(i); /* Methode aus der Klasse Pferd() */

                //zweite Zeile
                TextFarbWechsel2(wette);
                pferd2.Galopp(i); /* Methode aus der Klasse Pferd() */
            }

            /* Weg des Siegerpferdes um 1 * verlängern, da bei sehr kleinen
             Unterschieden beide Strecken gleich lang angezeigt werden */
            if (pferd1.Gelaufen == pferd2.Gelaufen)
            {
                if (pferd1.DurchschnittSpeed > pferd2.DurchschnittSpeed)
                {
                    pferd1.Gelaufen = pferd1.Gelaufen + "*";
                    TextFarbWechsel1(wette);
                    Console.SetCursorPosition(0, (11 + pferd1.StartNummer));
                    Console.Write("  " + pferd1.Gelaufen + 
                        " ~[{0}]>", pferd1.StartNummer);
                }
                else
                {
                    pferd2.Gelaufen = pferd2.Gelaufen + "*";
                    TextFarbWechsel2(wette);
                    Console.SetCursorPosition(0, (11 + pferd2.StartNummer));
                    Console.Write("  " + pferd2.Gelaufen + 
                        " ~[{0}]>", pferd2.StartNummer);
                }
            }


            Console.ResetColor();
            Console.WriteLine();
            Console.CursorVisible = true; /* Cursor sichtbar stellen */
            Console.WriteLine();
            Console.WriteLine();
        }

        /* 4. Berechnen Gewonnen - Verloren */
        public void GewonnenVerloren(Pferd pferd1, Pferd pferd2, string wette)
        {
            bool wetteGewonnen = false;
            bool zweiSieger = false;
            float speed1 = pferd1.DurchschnittSpeed; 
            float speed2 = pferd2.DurchschnittSpeed; 

            if (speed1 == speed2)
                zweiSieger = true;
            else if (speed1 < speed2)
            {
                if (wette == "2")
                    wetteGewonnen = true;
            }  
            else if (speed1 > speed2)
            {
                if (wette == "1")
                    wetteGewonnen = true;
            } 
            else
                wetteGewonnen = false;
            //Ausgabe Text
            Console.ForegroundColor = ConsoleColor.Red;
            if (zweiSieger)
                TextZweiSieger();
            if (wetteGewonnen & !zweiSieger)
                TextGewonnen();
            else if(!wetteGewonnen & !zweiSieger)
                TextVerloren();
            Console.ResetColor();
            Console.WriteLine();
        }

        /* 5. Ausgabe der Geschwindigkeiten */
        public void AusgabeSpeed(Pferd pferd1, Pferd pferd2)
        {
            Console.WriteLine();
            pferd1.MySpeed(); /* Methode aus der Klasse Pferd() */
            Console.WriteLine();
            pferd2.MySpeed(); /* Methode aus der Klasse Pferd() */
        }
    }
}
