using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Bingo
{
    static void Main(string[] args)
    {
        Console.WriteLine("Játssz BINGÓ-t!");
        Console.WriteLine("Készülj fel a játékra...");
        Console.WriteLine();

        // új példány
        Bingo game = new Bingo();
        game.Jatssz();
        Console.ReadKey();
    }

    // mérete
    const int Rows = 5;
    const int Cols = 5;


    // tömb
    int[,] card = new int[Rows, Cols];

    // lista (kihúzott számok)
    List<int> drawnNumbers = new List<int>();

    // random számok
    void InitializeCard()
    {
        Random rand = new Random();

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                // véletlen szám 1 és 60 között
                int number;
                do
                {
                    number = rand.Next(1, 61);
                } while (card.Cast<int>().Contains(number)); // ellenőrzés
                card[i, j] = number;
            }
        }
    }

    // kihúzott számok megjelenítése
    void DisplayCard()
    {
        Console.WriteLine("B\tI\tN\tG\tO");
        Console.WriteLine("------------------------------------");
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if (drawnNumbers.Contains(card[i, j]))
                {
                    Console.Write("#\t");
                }
                else
                {
                    Console.Write(card[i, j].ToString().PadLeft(3) + "\t");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("------------------------------------");
    }

    // ellenőrzes hogy vízszintes vagy függőleges 
    bool CheckBingo()
    {
        // sorok ellenőrzés
        for (int i = 0; i < Rows; i++)
        {
            int count = 0;
            for (int j = 0; j < Cols; j++)
            {
                if (drawnNumbers.Contains(card[i, j]))
                {
                    count++;
                }
            }
            if (count == 5)
            {
                Console.WriteLine("Vízszintes Bingó!");
                return true;
            }
        }

        // oszlop ellenőrzée
        for (int j = 0; j < Cols; j++)
        {
            int count = 0;
            for (int i = 0; i < Rows; i++)
            {
                if (drawnNumbers.Contains(card[i, j]))
                {
                    count++;
                }
            }
            if (count == 5)
            {
                Console.WriteLine("Függőleges Bingó!");
                return true;
            }
        }

        return false;
    }

    // játék
    public void Jatssz()
    {
        InitializeCard();
        DisplayCard();

        Console.WriteLine("Kérj számot...");
        Console.WriteLine();

        int ballsDrawn = 0;

        // loop
        while (ballsDrawn < 60)
        {
            // szám (1-60)
            Random rand = new Random();
            int number;
            do
            {
                number = rand.Next(1, 61);
            } while (drawnNumbers.Contains(number)); // ellenőrzés

            Console.WriteLine("A következő szám: " + number);
            drawnNumbers.Add(number);
            ballsDrawn++;

            DisplayCard();

            // van bingó?
            if (CheckBingo())
            {
                Console.WriteLine("GRATULÁLUNK! BINGÓ!");
                return; // kilépés BINGO után
            }

            Console.WriteLine("Nyomjon meg egy gombot a folytatáshoz...");
            Console.ReadKey();
            Console.Clear();
        }

        // dummy
        Console.WriteLine("Játék vége! Nem sikerült Bingót elérni.");
    }
}
