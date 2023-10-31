using System;

namespace PferderennenII
{
    class Pferd
    {
        //Konstruktor
        public Pferd(int startNummer, string nameJockey, string namePferd)
        {
            StartNummer = startNummer;
            Jockey = nameJockey;
            NamePferd = namePferd;
            //Eigenschaftwerte für den Beginn der Animation
            Loops = 0;
            Gelaufen = "";
        }

        //Eigenschaften
        public int StartNummer { get; set; }
        public string Jockey { get; set; }
        public string NamePferd { get; set; }
        //Eigenschaften für den Loop im Wettrennen
        public int Speed { get; set; } /* ermittelter Speed für einen Loop */
        public float SpeedNeu {get; set;} /* Summe aller Speed-Werte */
        public float RevSpeedNeu { get; set; } /* Speed-Wert für die Berechnung 
                                                der Animation */
        public float DurchschnittSpeed { get; set; } /* durchschnittliche 
                                                      Geschwindigkeit */
        public string Gelaufen { get; set; } /* Anzeigen der zurückgelegten 
                                              Strecke in der Animation */
        public int Loops { get; set; } /* Anzahl der Loops in der for-Schleife */

        //Methoden
        public void AmStart()
        {
            Console.WriteLine("  Mit der Startnummer [{0}] : [{1}] auf [{2}]", 
                StartNummer, Jockey, NamePferd);
        }

        public void Galopp(int i)
        {
            float reversor = 130;
            float revSpeed;

            /* mit inkrementiertem Wert i aus dem Loop arbeiten */
            if ((i == RevSpeedNeu) & (i < 4000))
            {
                //neue Werte berechnen
                Gelaufen = Gelaufen + "*";
                Speed = SpeedGenerator();
                SpeedNeu = SpeedNeu + Speed;
                revSpeed = reversor - Speed;
                RevSpeedNeu = RevSpeedNeu + revSpeed;
                Loops++;

                /* richtige Zeile aus der Startnummer generieren
                Zeile für pferd1 = 12 -> 11 + Startnummer 
                Zeile für pferd2 = 13 -> 11 + Startnummer */
                Console.SetCursorPosition(0, (11 + StartNummer));

                /* in Zeile schreiben */
                Console.Write("  " + Gelaufen + " ~[{0}]>", StartNummer);
                Thread.Sleep(10);  //Timer in Millisekunden
            }
            /* if (i == 4000) -> Code in else wird sonst bei jedem Loop ausgeführt */
            else if (i == 4000)
            {
                DurchschnittSpeed = SpeedNeu / Loops;
            }
        }

        public void MySpeed()
        {
            /* Wert der Geschwindigkeit in einen String mit zwei Nachkommazahlen 
            umwandeln*/
            string dSpeed = string.Format("{0:f}", DurchschnittSpeed);
            Console.WriteLine("  [{0}] mit der Starnummer [{1}] \n      hatte " +
                "eine durchschnittliche Geschwindigkeit von [{2}] " +
                "km/h !", NamePferd, StartNummer, dSpeed);
        }

        public int SpeedGenerator()
        {
            /* zufällige Auswahl zweier Geschwindigkeiten generieren */
            Random rSpeed = new Random();
            int speed = rSpeed.Next(50, 81);
            return speed;
        }
    }
}
