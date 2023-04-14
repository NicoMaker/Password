using Multifunzione;
using System.Text;

public class Password
{
    public static int InserisciNumeroPassword(string[] utenti)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(" ");
        Console.Write("inserisci quante password vuoi generare ---> ");
        int numero = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.DarkGreen;

        for (int i = 1; i <= numero; i++)
        {
            Console.Write($"inserisci {i} utente --> ");
            utenti[i] = Console.ReadLine();
        }
        return numero;

    }
    public static void Crea(int numero, string[] utenti, string[] password)
    {

        Console.WriteLine("");

        for (int i = 1; i <= numero; i++)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"{i} utente è ---> {utenti[i]}");
        }

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("");
        Console.WriteLine("Password da generare --> " + numero);
        Console.WriteLine("");

        int misura;
        const int Vettore = 30000000;
        int[] numeri_casuali = new int[Vettore];

        string pass = @"0123456789ABCDEFGHIJKLMNOPQRSTUVXWYZabcdefghijklmnopqrstuvwxyz@#+-!\\|&%()*/", lettera = "";
        for (int i = 1; i <= numero; i++)
        {

            Console.WriteLine("");

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"inserisci misura password di {utenti[i]} almeno 8 caratteri ---> ");
                misura = Convert.ToInt32(Console.ReadLine());

            } while (misura < 8);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("");
            Console.Write("password  di " + utenti[i] + " è --> ");

            for (int j = 1; j <= misura; j++)
            {
                Random r = new Random();
                int casuale = r.Next(0, pass.Length);
                numeri_casuali[j] = casuale;

                if (j > 0)
                {
                    while (numeri_casuali[j] == numeri_casuali[j - 1])
                    {
                        if (numeri_casuali[j] > 9)
                        {
                            casuale = r.Next(0, pass.Length);
                            numeri_casuali[j] = casuale;
                        }
                    }
                }

                lettera += pass[casuale];
                password[i] = lettera;
                Console.Write(pass[casuale]);

            }
            lettera = "";
            Console.WriteLine("");
        }

    }

    public static void Visualizza(int numero, string[] utenti, string[] password)
    {
        StampaPassSuText PassText;
        PassText = new StampaPassSuText("Password.txt");
        PassText.Cancella();

        Console.ForegroundColor = ConsoleColor.DarkMagenta;

        Console.WriteLine("---------- ELENCO UTENTI CON PASSWORD ----------");
        Console.WriteLine("");

        PassText.Scrivi("---------- ELENCO UTENTI CON PASSWORD ----------");
        PassText.Scrivi(" ");

        for (int i = 1; i <= numero; i++)
        {
            Console.WriteLine($"utente {utenti[i]} password ----> {password[i]}");
            PassText.Scrivi($"{i} utente {utenti[i]} password ----> {password[i]}");
        }

        VisualizzaPasswordInHTML(numero, utenti, password);
    }

    private static void VisualizzaPasswordInHTML(int numero, string[] utenti, string[] password)
    {
        File.Delete("Password.html");

        var sb = new StringBuilder();
        sb.Append(@"<!DOCTYPE html>
        <html>
                <head>
                <link href=""https://fonts.googleapis.com/css2?family=Roboto:wght@100&display=swap"" rel=""stylesheet"">
                <title> Password </title>
                <link rel=""stylesheet"" href=""Parte_Grafica.css"">
                <link rel=""preconnect"" href=""https://fonts.googleapis.com"">
                <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin>
                <link href=""https://fonts.googleapis.com/css2?family=Dancing+Script:wght@500&display=swap"" rel=""stylesheet"">
                <link rel=""preconnect"" href=""https://fonts.googleapis.com"">

                <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin>
                <link href=""https://fonts.googleapis.com/css2?family=Hubballi&display=swap"" rel=""stylesheet"">

                <link rel=""preconnect"" href=""https://fonts.googleapis.com"">
                <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin>
                <link href=""https://fonts.googleapis.com/css2?family=Roboto:wght@300&display=swap"" rel=""stylesheet"">

                <link rel=""preconnect"" href=""https://fonts.googleapis.com"">
                <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin>

                </head>
                <body>"
        );

        sb.Append("<h1> Le Password sono le Seguenti </h1>");
        sb.Append("<img class=\"Immagine\" src=\"password.jpg\">");

        sb.Append("<br>");

        sb.Append(@" <table>
                    <tr>
                        <td>
                            Nome Utente
                        </td>
                        <td>
                            Password
                        </td>
                    </tr>
        ");

        for (int i = 1; i <= numero; i++)
        {
            sb.AppendFormat(@"
                <tr>
                        <td>
                            {0} 
                        </td>

                        <td>
                            {1}
                        </td>
                  </tr>
            ", utenti[i], password[i]);
        }

        sb.Append(@"
               </table>
               </body>
               </html>
        ");

        File.WriteAllText("Password.html", sb.ToString());

    }

    public static void ControllaPassword(int numero, string[] utenti, string[] password)
    {
        string inserisci = "";
        int conta = 0;


        Console.ForegroundColor = ConsoleColor.DarkYellow;

        Console.WriteLine("");
        Console.Write("inserisci password che vuoi vedere di che utente è --> ");
        inserisci = Console.ReadLine();
        Console.WriteLine("");
        conta = 0;

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        for (int i = 1; i <= numero; i++)
        {
            if (password[i] == inserisci)
            {
                Console.WriteLine($"la password che hai inserito {inserisci} e' di ---> {utenti[i]}");
                conta = 1;
            }

        }
        if (conta == 0)
        {
            Console.WriteLine($"la password che hai inserito {inserisci} non è di nessuno");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("");
            Console.WriteLine("---------- LE PASSWORD POSSONO ESSRE LE SEGUENTI ----------");
            Console.WriteLine("");

            for (int i = 1; i <= numero; i++)
                Console.WriteLine($"utente {utenti[i]} password ---> {password[i]}");

        }

    }

    public static int InserisciALtriUtenti(int numero, string[] utenti, string[] password)
    {
        int misura;
        const int Vettore = 30000000;
        int[] numeri_casuali = new int[Vettore];

        string pass = @"0123456789ABCDEFGHIJKLMNOPQRSTUVXWYZabcdefghijklmnopqrstuvwxyz@#+-!\\|&%()*/", lettera = "";


        Console.ForegroundColor = ConsoleColor.DarkRed;

        Console.Write("inserisci quante utenti vuoi aggiungere ---> ");
        int inserisci = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");

        for (int i = numero + 1; i <= numero + inserisci; i++)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"inserisci nome {i} utente ---> ");
            utenti[i] = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkRed;
        }

        for (int i = numero + 1; i <= numero + inserisci; i++)
        {
            Console.WriteLine("");

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"inserisci misura password di {utenti[i]} almeno 8 caratteri ---> ");
                misura = Convert.ToInt32(Console.ReadLine());

            } while (misura < 8);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("");
            Console.Write("password  di " + utenti[i] + " è --> ");

            for (int j = 1; j <= misura; j++)
            {
                Random r = new Random();
                int casuale = r.Next(0, pass.Length);
                numeri_casuali[j] = casuale;

                if (j > 0)
                {
                    while (numeri_casuali[j] == numeri_casuali[j - 1])
                    {
                        if (numeri_casuali[j] > 9)
                        {
                            casuale = r.Next(0, pass.Length);
                            numeri_casuali[j] = casuale;
                        }
                    }
                }

                lettera += pass[casuale];
                password[i] = lettera;
                Console.Write(pass[casuale]);

            }
            lettera = "";
            Console.WriteLine("");
        }

        numero += inserisci;


        return numero;

    }

    public static void ControllaNomeUtente(int numero, string[] utenti, string[] password)
    {
        string pass = @"0123456789ABCDEFGHIJKLMNOPQRSTUVXWYZabcdefghijklmnopqrstuvwxyz@#+-!\\|&%()*/", lettera = "";
        int conta = 0, misura;
        const int Vettore = 30000000;
        int[] numeri_casuali = new int[Vettore];

        Console.ForegroundColor = ConsoleColor.DarkYellow;

        Console.Write("inserisci nome utente da controllare --> ");
        string nome = Console.ReadLine();
        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.DarkGreen;

        for (int i = 1; i <= numero; i++)
        {
            if (nome == utenti[i])
            {
                Console.WriteLine($"L'utente {nome} ha la password --> {password[i]}");
                conta = 1;
            }
        }

        Console.ForegroundColor = ConsoleColor.DarkRed;

        if (conta == 0)
        {
            Console.WriteLine($"non esiste l'utente {nome}");
            Console.WriteLine("");

            Console.WriteLine("---- GLI UTENTI SONO I SEGUENTI ----");
            Console.WriteLine("");

            for (int i = 1; i <= numero; i++)
                Console.WriteLine($"utente {utenti[i]} ---> {password[i]}");
        }
    }
}