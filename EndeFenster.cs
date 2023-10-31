using System;

namespace PferderennenII
{
    class EndeFenster : Fenster
    {
        //Methoden
        /* Überschreiben der abstrakten Methode aus der Basisklasse */
        public override void AngezeigterText()
        {
            Console.WriteLine("\n \n \n"); //3 Leerzeilen
            Console.WriteLine("                *************");
            Console.WriteLine("                *  BYE BYE  *");
            Console.WriteLine("                *************");
            Console.WriteLine("\n \n \n \n"); //4 Leerzeilen
            Console.WriteLine("********************************" +
                "*********** (c) rNaT 2023 * * *");

            System.Threading.Thread.Sleep(2000);    //2 Sekunden Pause

            Environment.Exit(0); //Beenden
        }
    }
}
