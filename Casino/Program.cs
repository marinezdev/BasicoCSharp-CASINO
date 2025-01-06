// See https://aka.ms/new-console-template for more information

using System;

bool play = true;
int playerCoins = 0;
int playerSaldoInicial = 0;
int empateCount = 0;
int winDealer = 0;
int winUser = 0;
int playerApuestaHecha = 0;
string playerApuesta = string.Empty;
string userOptionChose = string.Empty;
string juegoResultado = string.Empty;
string message = string.Empty;
Random rnd = new Random();

do
{
    Console.Clear();
    Console.WriteLine("Welcom to the C A S I N O\n");
    Console.WriteLine("Choose an option to play\n" +
                    "  1. Black Jack\n" +
                    "  2. Rock, paper, scissors\n" +
                    "  9. Quit (o escriba la letra 'X')\n" +
                    "100. Buy Coins");

    userOptionChose = Console.ReadLine() ?? string.Empty;
    switch (userOptionChose.ToUpper())
    {
        case "1":
            // Juego de BlackJack
            // El juego se lleva acabo solicitando cartas, sumando cada una de las cartas asignadas.
            // el obejtevo es obtener 21 (en la sumatoria de las cartas)
            // si la sumatoria es mayor a 21 el jugador pierde
            // en caso de que no realice la suma de 21, el jugador que mas cercano este a 21 es el ganador (dealer)
            if (playerCoins <= 0)
            {
                Console.Clear();
                Console.WriteLine("You don't have more coins; pelaase you buy some coins to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("how many coins do you want to bet?");
                playerApuesta = Console.ReadLine() ?? string.Empty;

                if (playerApuesta.ToUpper() == "X")
                {
                    Console.WriteLine("Thanks for play Black Jack");
                    Console.ReadLine();
                }
                else
                {
                    int.TryParse(playerApuesta ?? "0", out playerApuestaHecha);
                    if (playerApuestaHecha == 0 || playerApuestaHecha > playerCoins)
                    {
                        Console.Clear();
                        Console.WriteLine("The bet is not valid, please indicate a correct bet to continue...");
                        Console.ReadLine();
                    }
                    else
                    {
                        int counter = 0;
                        string continuePlaying = string.Empty;

                        while (playerCoins >= playerApuestaHecha || continuePlaying != "X")
                        {
                            int carta = 0;
                            int playerDealer = 0;
                            int playerOne = 0;
                            string playerRespuesta = string.Empty;
                            

                            Console.Clear();
                            Console.WriteLine($"Juego número: {counter + 1}... Creditos disponibles: {playerCoins}... La apuesta realizada es de: {playerApuestaHecha}\n");
                            Console.WriteLine("jugando....\n");
                            Console.WriteLine("Let's playing Black Jack\n ... {input <enter> to play or <X> to exit}");
                            continuePlaying = Console.ReadLine().ToString();

                            if (continuePlaying.ToUpper() != "X")
                            {
                                do
                                {
                                    carta = rnd.Next(1, 13);
                                    playerOne += carta;

                                    // ### Pendiente: Darle valor de 10 a las cartas J, Q & K y un valor de 11 para el Az
                                    // Validamos si ya se pasa de 21 
                                    if (playerOne > 21)
                                    {
                                        playerRespuesta = "No";
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Tu carta Asignada es: {carta}");
                                        Console.WriteLine("Desea obtener otra carta (Si / No)?");
                                        playerRespuesta = Console.ReadLine()?.ToUpper() ?? string.Empty;
                                    }
                                }
                                while (playerRespuesta == "SI" || playerRespuesta == "S");

                                // Generamos el valor para el Dealer
                                playerDealer = rnd.Next(15, 23);
                                if (playerOne > playerDealer && playerOne <= 21)
                                {
                                    message = "Venciste al Dealer... Felicidades!";
                                }
                                else if (playerOne > 21)
                                {
                                    message = "Perdiste contra el Dealer... Te pasaste de 21... lo siento!";
                                }
                                else if (playerOne <= playerDealer)
                                {
                                    message = "Perdiste contra el Dealer (empate)... lo siento!";
                                }
                                else
                                {
                                    message = "Condición no válida...";
                                }
                            }

                            //Console.Clear();
                            Console.WriteLine($"Resultado del juego: \n" +
                                $"Player One: {playerOne}\n" +
                                $"Dealer: {playerDealer}\n");

                            Console.WriteLine(message);
                            Console.WriteLine(" \n tecle <enter> para continuar jugando...");
                            Console.ReadLine();
                            Console.Clear();
                        }

                        //Console.WriteLine($"Adquiriste {coins} monedas.\n teclea <enter para continuar jugando>");
                        //Console.ReadLine();

                        //Console.Clear();
                        //Console.WriteLine("Thaks for play: Rock, paper, scissors");
                        //Console.WriteLine($"You no longer have enough coins to continue betting. The established bet is {playerApuestaHecha} coins.");
                        //Console.WriteLine($"You started with {playerSaldoInicial} coins.");
                        //Console.WriteLine($"Your balance in this game is: {playerCoins}");
                        //Console.WriteLine($"Your record is:\nGames Wins: {winUser}\nGames Lost: {winDealer}");
                        //Console.ReadLine();

                    }
                }
            }
            break;

        case "2":
            // Juego de Piedra Papel o Tijeras
            // El juego se realiza solicitando que el jugador selecciona una de las opciones y de manera aleatoria el dealer (PC) tambien se le asigna una opcion...
            // se realiza la validacion entre las 2 selecciones para ver cual es la ganadora
            // Las reglas del juego son:
            //      Piedra rompe a Tijeras      [gandor: Piedra]
            //      Tijeras corta papel         [gandor: Tijeras]
            //      Papel envuelve a piedra     [gandor: Papel]
            if (playerCoins <= 0)
            {
                Console.Clear();
                Console.WriteLine("You don't have more coins; pelaase you buy some coins to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("how many coins do you want to bet?");
                playerApuesta = Console.ReadLine() ?? string.Empty;

                if (playerApuesta.ToUpper() == "X")
                {
                    Console.WriteLine("Thanks for play Rock, paper, scissors");
                    Console.ReadLine();
                }
                else
                {
                    int.TryParse(playerApuesta ?? "0", out playerApuestaHecha);
                    if (playerApuestaHecha == 0 || playerApuestaHecha > playerCoins)
                    {
                        Console.Clear();
                        Console.WriteLine("The bet is not valid, please indicate a correct bet to continue...");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Let's playing Rock, paper, scissors\n ... {input <enter> to play}");
                        Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Playing...");
                        
                        bool jugando = true;
                        int playerPC = 0;
                        int playerUser = 0;
                        string playerUserOption = string.Empty;
                        string[] opciociones = { "Rock", "Paper", "Scissors" };

                        while (jugando)
                        {
                            Console.WriteLine($"Your balance is {playerCoins} coins, and the bet placed is {playerApuestaHecha} coins");
                            Console.WriteLine("Choose an option:\n" +
                                "1 - Rock\n" +
                                "2 - Paper\n" +
                                "3 - Scissors\n" +
                                "X - to Quit.");
                            playerUserOption = Console.ReadLine() ?? string.Empty;
                            if (playerUserOption.ToUpper() == "X")
                            {
                                jugando = false;
                                Console.Clear();
                                Console.WriteLine("Thaks for play: Rock, paper, scissors");
                                Console.WriteLine($"You no longer have enough coins to continue betting. The established bet is {playerApuestaHecha} coins.");
                                Console.WriteLine($"You started with {playerSaldoInicial} coins.");
                                Console.WriteLine($"Your balance in this game is: {playerCoins}");
                                Console.WriteLine($"Your record is:\nGames Wins: {winUser}\nGames Lost: {winDealer}");
                                Console.ReadLine();
                            }
                            else
                            {
                                bool validacion = true;
                                playerPC = new System.Random().Next(0, 3);
                                int.TryParse(playerUserOption ?? "0", out playerUser);
                                switch (playerUser)
                                {
                                    case 1:
                                        break;

                                    case 2:
                                        break;

                                    case 3:
                                        break;

                                    default:
                                        Console.WriteLine("\n*** La opción elegida es inválida (selección incorrecta)...");
                                        Console.ReadLine();
                                        validacion = false;
                                        break;
                                }

                                if (validacion)
                                {
                                    playerUser--;
                                    Console.WriteLine($"Dealer choosed: {opciociones[playerPC]}");
                                    Console.WriteLine($"Player choosed: {opciociones[playerUser]}");

                                    // realizamos juego;
                                    // 0 = Piedra, 1 = Papel, 3 = Tijeras
                                    if (playerUser == playerPC)
                                    {
                                        juegoResultado = "Empate";
                                        empateCount++;
                                    }
                                    else
                                    {
                                        switch (playerUser)
                                        {
                                            case 0:                         // El usuario selecciono piedra
                                                if (playerPC == 1)          // La PC eligió papel
                                                {
                                                    juegoResultado = "Dealer";
                                                    winDealer++;
                                                    playerCoins = playerCoins - playerApuestaHecha;
                                                }
                                                else
                                                {
                                                    juegoResultado = "Player";
                                                    winUser++;
                                                    playerCoins = playerCoins + playerApuestaHecha;
                                                }
                                                break;

                                            case 1:                         // El usuario selecciono papel
                                                if (playerPC == 2)          // La PC eligió tiejeras
                                                {
                                                    juegoResultado = "Dealer";
                                                    winDealer++;
                                                    playerCoins = playerCoins - playerApuestaHecha;
                                                }
                                                else
                                                {
                                                    juegoResultado = "Player";
                                                    winUser++;
                                                    playerCoins = playerCoins + playerApuestaHecha;
                                                }
                                                break;

                                            case 2:                         // El usuario selecciono tijeras
                                                if (playerPC == 0)          // La PC eligió piedra
                                                {
                                                    juegoResultado = "Dealer";
                                                    winDealer++;
                                                    playerCoins = playerCoins - playerApuestaHecha;
                                                }
                                                else
                                                {
                                                    juegoResultado = "Player";
                                                    winUser++;
                                                    playerCoins = playerCoins + playerApuestaHecha;
                                                }
                                                break;

                                            default:
                                                Console.WriteLine("The option isn't valid...");
                                                break;
                                        }
                                    }

                                    Console.WriteLine($"The winner is: {juegoResultado}\n\n\n");
                                }
                            }

                            if (playerCoins < playerApuestaHecha)
                            {
                                jugando = false;
                                Console.Clear();
                                Console.WriteLine("Thaks for play: Rock, paper, scissors");
                                Console.WriteLine($"You no longer have enough coins to continue betting. The established bet is {playerApuestaHecha} coins.");
                                Console.WriteLine($"You started with {playerSaldoInicial} coins.");
                                Console.WriteLine($"Your balance in this game is: {playerCoins}");
                                Console.WriteLine($"Your record is:\nGames Wins: {winUser}\nGames Lost: {winDealer}");
                                Console.ReadLine();
                            }
                        }
                    }
                }
            }
            break;

        case "100":
            Console.Clear();
            Console.WriteLine(" C A S I N O\nBuy Coins\nHow many coins do you want to buy?");
            playerCoins = int.Parse(Console.ReadLine()?.ToString() ?? "0");
            playerSaldoInicial = playerCoins;
            Console.WriteLine($"Your purchase for {playerCoins} medas was successful.");
            Console.ReadLine();
            break;

        case "X":
        case "9":
            play = false;
            break;

        default:
            Console.Clear();
            Console.WriteLine("La opció elegida no es válida... \nPor favor selecciona una opción permitida o escribe 'X' para termianar de jugar...\n\n\n");
            Console.ReadLine();
            break;
    }

}
while (play);


Console.Clear();
Console.WriteLine("* * * * * C A S I N O * * * * *");
Console.WriteLine("Thanks for play with us");
Console.ReadLine();