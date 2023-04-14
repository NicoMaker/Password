int s = 0, numerop = 0;

const int Vettore = 30000000;
string[] utenti = new string[Vettore];
string[] password = new string[Vettore];

do
{
    s = Informazioni(s);
    switch(s)
    {
        case 1:
            numerop = Password.InserisciNumeroPassword(utenti);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("password da generare --> " + numerop);
            Console.WriteLine("");
            break;

        case 2:
            Console.WriteLine("");
            Password.Crea(numerop, utenti, password);
            Console.WriteLine("");
            break;

        case 3:
            Console.WriteLine("");
            Password.Visualizza(numerop, utenti, password);
            Console.WriteLine("");
            break;

        case 4:
            Console.WriteLine("");
            numerop = Password.InserisciALtriUtenti(numerop, utenti, password);
            Console.WriteLine("");
            break;

        case 5:
            Console.WriteLine("");
            Password.ControllaPassword(numerop, utenti, password);
            Console.WriteLine("");
            break;

        case 6:
            Console.WriteLine("");
            Password.ControllaNomeUtente(numerop, utenti, password);
            Console.WriteLine("");
            break;
    }

} while (s != 0 && s <= 6);

int Informazioni(int s)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("");
    Console.WriteLine("<------------------------------------------------------------------- BENVENUTI NEL MIO MENU' ------------------------------------------------------------->");
    Console.WriteLine("");
    InformazioniPassword();
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("0 e numeri maggiori di 6. USCITA");
    Console.WriteLine("");
    Console.WriteLine("<-------------------------------------------------------------------------------------------------------------------------------------------------------->");
    Console.WriteLine("");

    Console.Write("INSERISCI SCELTA  --->  ");
    s = Convert.ToInt32(Console.ReadLine());

    return s;
}

void InformazioniPassword()
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("1. INSERISCI QUANTE PASSWORD GENERARE");
    Console.WriteLine("2. GENERA PASSWORD");
    Console.WriteLine("3. VISULIZZA ELENCO PASSWORD UTENTI");
    Console.WriteLine("4. INSERISCI ALTRI UTENTI");
    Console.WriteLine("5. VISULIZZA INSERENDO LA PASSWORD DI CHE UTENTE E' SE NO NON E' DI NESSUNO");
    Console.WriteLine("6. VISUALIZZA LA PASSWORD DELL'UTENTE SE NON ESISTE DI NON ESISTE");
}