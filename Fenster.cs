using System;

namespace PferderennenII
{
    abstract class Fenster
    {
        /* Konstruktor -> alles Enthaltene wird beim Instanziieren eines
        neuen Objektes aus einer erbenden Kindklasse automatisch ausgeführt */
        public Fenster()
        {
            Console.Clear(); //Inhalt des alten Fensters löschen
            Ueberschrift();
            AngezeigterText();
        }

        //Methoden
        /* 1. virtuelle Methode für die Überschift */
        public virtual void Ueberschrift()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("      #####################################" +
                "### # # # # # # * * * * *");
            Console.ResetColor();
            Console.WriteLine("    ########## PFERDERENNEN ############" +
                "### # # # # # # * * * *");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("#####################################" +
                "### by rNaT # # * * *");
            Console.ResetColor();
            Console.WriteLine();
        }
        
        /* 2. abstrakte Methode für den folgenden Text
        # diese Methode muss in allen erbenden Klassen enthalten sein 
        # Code wird erst in der erbenden Klasse geschrieben */
        public abstract void AngezeigterText();

        /* 3. weitere öffentliche Methoden für Bausteine, die 
        mehrfach benötigt werden */
        public void TextFarbWechsel1(string wette)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (wette == "1")
                Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public void TextFarbWechsel2(string wette)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (wette == "2")
                Console.ForegroundColor = ConsoleColor.Cyan;
        }

        /* Methode für die farbige Startliste und die Pferde am Start */
        public void AusgabeTextWette(Pferd pferd1, Pferd pferd2, string wette)
        {
            /* Anzeigen der Pferde in verschiedener Farbe 
            je nach Wette: Cyan = Wette, Grün = Gegner */
            TextFarbWechsel1(wette); //Methode aus der Basisklasse Fenster()
            pferd1.AmStart(); //Methode aus der Klasse Pferd()
            TextFarbWechsel2(wette); //Methode aus der Basisklasse Fenster()
            pferd2.AmStart(); //Methode aus der Klasse Pferd()
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  Du wettest auf Startnummer [" + wette + "]");
            Console.WriteLine();

            //Icons für die Pferde in verschiedener Farbe
            TextFarbWechsel1(wette); //Methode aus der Basisklasse Fenster()
            Console.WriteLine("  ~[1]>");
            TextFarbWechsel2(wette); //Methode aus der Basisklasse Fenster()
            Console.WriteLine("  ~[2]>");
            Console.ResetColor();
        }
        public void TextGewonnen()
        {
            Console.WriteLine("            *****************************");
            Console.WriteLine("            *      Juhuuu! Du hast      *");
            Console.WriteLine("            *    ! G E W O N N E N !    *");
            Console.WriteLine("            *  Herzlichen Glückwunsch!  *");
            Console.WriteLine("            *****************************");
        }
        public void TextVerloren()
        {
            Console.WriteLine("       **************************************");
            Console.WriteLine("       *      Du hast leider verloren!      *");
            Console.WriteLine("       *              Kopf hoch!            *");
            Console.WriteLine("       *  Das war nicht das letzte Rennen!  *");
            Console.WriteLine("       **************************************");
        }
        public void TextZweiSieger()
        {
            Console.WriteLine("            *****************************");
            Console.WriteLine("            *    Woooow! Alle haben     *");
            Console.WriteLine("            *    ! G E W O N N E N !    *");
            Console.WriteLine("            *    Es gibt zwei Sieger    *");
            Console.WriteLine("            *****************************");
        }
    }
}
