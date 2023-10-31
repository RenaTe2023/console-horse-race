using System;

namespace PferderennenII
{
    class WettFenster : Fenster
    {
        /* Methode 1 = überschriebene abstrakte Methode */
        public override void AngezeigterText()
        {
            /* Varialblen für Pferd- und Jockey-Name generieren */
            string nameJockey = "leer"; /* irgendeinen Anfangswert zuweisen, 
                                           da dieser im Jockey- */
            string namePferd = "leer";  /* bzw. PferdeNameGenerator benötigt wird */
            //Werte für erstes Pferd generieren
            JockeyNameGenerator(nameJockey);
            PferdeNameGenerator(namePferd);
            //Werte an die Variablen übergeben
            nameJockey = JockeyNameGenerator(nameJockey);
            namePferd = PferdeNameGenerator(namePferd);
            //erstes Pferd mit den generierten Werten instanziieren
            Pferd pferd1 = new Pferd(1, nameJockey, namePferd);

            //Werte für zweites Pferd generieren
            JockeyNameGenerator(nameJockey);
            PferdeNameGenerator(namePferd);
            /* Werte an die Variablen übergeben */
            nameJockey = JockeyNameGenerator(nameJockey);
            namePferd = PferdeNameGenerator(namePferd);
            //zweites Pferd mit den generierten Werten instanziieren
            Pferd pferd2 = new Pferd(2, nameJockey, namePferd);

            /* Ausgabetext für die Pferde am Start */
            Console.WriteLine("  Heute im Rennen sind:");
            Console.WriteLine();
            pferd1.AmStart(); //Methode aus der Klasse Pferd
            pferd2.AmStart(); //Methode aus der Klasse Pferd
            Console.WriteLine();

            /* Aufforderung zur Wette */
            Console.WriteLine("  Auf welche Startnummer möchtest Du wetten?");
            Console.Write("  [1] oder [2] ? ");
            /* Validierung der Eingabe zur Wette */
            WetteAbgeben(pferd1, pferd2);
        }

        /* Methode zum Abfragen der Eingabe für die Wette */
        public void WetteAbgeben(Pferd pferd1, Pferd pferd2)
        {
            string eingabeWette;

            //Schleife
            while (true)
            {
                bool korrekteEingabe = true;

                eingabeWette = Console.ReadLine();

                //Ausgabe der Werte für Wette:
                if ((eingabeWette == "1") | (eingabeWette == "2"))
                {
                    string wette = eingabeWette;
                    Fenster rennenFenster = new RennenFenster(pferd1, pferd2, 
                        wette);
                }
                else
                {
                    korrekteEingabe = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Falsche Eingabe!");
                    Console.ResetColor();
                }

                if (korrekteEingabe)
                    break;  /* aus While-Schleife rausspringen, 
                            wenn die Eingabe korrekt war */
            }
        }

        /* Methoden mit Zufallsgeneratoren für die Parameter der Pferde */
        public string JockeyNameGenerator(string nameJockey)
        {
            /* Array mit mehreren Jockeynamen zur 
            zufälligen Auswahl generieren */
            string[] JockeyNamen = new string[]
            {
                "Hans Dampf",
                "Franz Josef",
                "Miss Reiter",
                "Fräulein Schnell",
                "Stallbursche Karli",
                "Ersatz Reiter",
                "Rita Rasch",
                "Mike Slow",
                "Filipp Flink",
                "Rena Ryder",
                "Mizzi Müde"
            };
            bool gleicherName = false;
            while(true)
            { 
                /* zufällige Auswahl zweier Jockeys: */
                Random rJockey = new Random();
                int index = rJockey.Next(0, JockeyNamen.Length);
                string jockeyNameGen = JockeyNamen[index];
                /* verhindern, dass zufällig zweimal der 
                gleiche Name gewählt wird */
                if (jockeyNameGen == nameJockey)
                    gleicherName = true;
                else
                    return jockeyNameGen;
            }
        }
        public string PferdeNameGenerator(string namePferd)
        {
            /* Array mit mehreren Pferdenamen zur 
            zufälligen Auswahl generieren */
            string[] PferdeNamen = new string[]
            {
                "Black Fury",
                "Why Me",
                "Run Run Run",
                "White Blizzard",
                "Schnecki Blue",
                "Ich Will Lieber Chillen",
                "Abendwind",
                "Volle Pulle",
                "No Karacho",
                "Hundert Prozent",
                "Ge Naaaa"
            };
            bool gleicherName = false;
            while (true)
            {
                /* zufällige Auswahl zweier Pferdenamen: */
                Random rPerd = new Random();
                int index = rPerd.Next(0, PferdeNamen.Length);
                string pferdeNameGen = PferdeNamen[index];
                /* verhindern, dass zufällig zweimal der 
                gleiche Name gewählt wird */
                if (pferdeNameGen == namePferd)
                    gleicherName = true;
                else
                    return pferdeNameGen;
            }
        }
    }
}
