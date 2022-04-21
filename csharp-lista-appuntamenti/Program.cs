// See https://aka.ms/new-console-template for more information

using ListaAppuntamenti;
List<ListaAppuntamenti> listaAppuntamenti = new List<ListaAppuntamenti>();

Console.WriteLine("La mia Agenda - Benvenuto!");
Console.WriteLine("Desideri aggiungere un appuntamento? Si/No");

{ int numeroDiAppuntamenti = 0;
  bool numeroDiAppuntamentiCorretto = false;
    while (numeroDiAppuntamentiCorretto) {
        if (int.TryParse(Console.ReadLine(), out int result))
        {
            numeroDiAppuntamenti = result;
            numeroDiAppuntamentiCorretto = true;
        }
        else
        {
            Console.WriteLine("Inserisci un numero");
        }
    }

    for (int i = 0; i < numeroDiAppuntamenti; i++)
    {
        Console.WriteLine("Appuntamento numero " + (i + 1));
        Console.WriteLine("Aggiungi il nome del tuo appuntamento: ");
        string nomeAppuntamento = Console.ReadLine();
        Console.WriteLine("Aggiungi il luogo del tuo appuntamento: ");
        string localitaAppuntamento = Console.ReadLine();

        bool dataCorretta = false;
        while (!dataCorretta)
        {
            DateTime dataOraAppuntamento = DateTime.Now;
            bool formatoDataCorretto = false;

            while (formatoDataCorretto)
            {
                Console.WriteLine("Aggiungi data e ora del tuo appuntamento: [gg/mm/aaaa hh:mm]");

                try
                {
                    dataOraAppuntamento = DateTime.Parse(Console.ReadLine());
                    formatoDataCorretto = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Il formato della data non è corretto");
                }
            }
            
            try
            {
                listaAppuntamenti.Add(new Appuntamenti(nomeAppuntamento, localitaAppuntamento, dataOraAppuntamento));
                dataCorretta = true;
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

foreach (Appuntamenti appuntamento in listaAppuntamenti)
    {
        appuntamento.ToString();
    }

