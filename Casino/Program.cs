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

do
{
    Console.Clear();
    Console.WriteLine("Welcom to the C A S I N O\n");
    Console.WriteLine("Selecciona una opcion de juego\n" +
                    "  1. Black Jack\n" +
                    "  2. Piedra Papel o Tiejeras\n" +
                    "  9. Para terminar de jugar (o escriba la letra 'X')\n" +
                    "100. Comprar monedas");

    userOptionChose = Console.ReadLine() ?? string.Empty;
    switch (userOptionChose.ToUpper())
    {
        case "1":
            //TODO: Pendiente: [funcionalidad] Agregar juego de Black Jack
            break;

        case "2":
            if (playerCoins <= 0)
            {
                Console.Clear();
                Console.WriteLine("No cuenta con moneda para jugar, por favor compre algunas para poder jugar...");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Cuantas monedas deseas apostar?\n ... {por favor, indique un numero entero mayor a cero; o escriba 'X' si desea salir del juego}");
                playerApuesta = Console.ReadLine() ?? string.Empty;

                if (playerApuesta.ToUpper() == "X")
                {
                    Console.WriteLine("Gracias por jugar Piedras, Papel o Tejeras");
                    Console.ReadLine();
                }
                else
                {
                    int.TryParse(playerApuesta ?? "0", out playerApuestaHecha);
                    if (playerApuestaHecha == 0 || playerApuestaHecha > playerCoins)
                    {
                        Console.Clear();
                        Console.WriteLine("La apuesta no es válida, por favor indique una apuesta de monedas correcta (mayor a cero y menor a la cantidad de monedas que tiene actualmente)");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Juguemos Piedra, Papel o Tijeras\n ... {teclee <enter> para iniciar el juego}");
                        Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Jugando...");
                        
                        bool jugando = true;
                        int playerPC = 0;
                        int playerUser = 0;
                        string playerUserOption = string.Empty;
                        string[] opciociones = { "Piedra", "Papel", "Tijeras"};

                        while (jugando)
                        {
                            

                            Console.WriteLine($"Tu saldo en monedas es: {playerCoins} y la apuesta es de: {playerApuestaHecha}");
                            Console.WriteLine("Elige una opción:\n" +
                                "1 - Piedra\n" +
                                "2 - Papel\n" +
                                "3 - Tijeras\n" +
                                "X - para salir del juego.");
                            playerUserOption = Console.ReadLine() ?? string.Empty;
                            if (playerUserOption.ToUpper() == "X")
                            {
                                jugando = false;
                                Console.Clear();
                                Console.WriteLine("Gracias por jugar Piedra, Papel o Tijeras");
                                Console.WriteLine($"Ya no cuenta con las monedas sufientes para continuar apostando\nLa apuesta establecida es de {playerApuestaHecha} monedas");
                                Console.WriteLine($"Su saldo inicial fue de: {playerSaldoInicial}");
                                Console.WriteLine($"Su saldo final en este juego es de: {playerCoins}");
                                Console.WriteLine($"Su record es:\nTotal de juegos Ganados: {winUser}\nTotal de juegos Perdidos: {winDealer}");
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
                                    Console.WriteLine($"El Dealer eligió: {opciociones[playerPC]}");
                                    Console.WriteLine($"El Jugador eligió: {opciociones[playerUser]}");

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
                                                    juegoResultado = "Delear";
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
                                                    juegoResultado = "Delear";
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
                                                    juegoResultado = "Delear";
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
                                                Console.WriteLine("Conjunto de opciones no evaluada...");
                                                break;
                                        }
                                    }

                                    Console.WriteLine($"El ganador del juego es: {juegoResultado}\n\n\n");
                                }
                            }

                            if (playerCoins < playerApuestaHecha)
                            {
                                jugando = false;
                                Console.Clear();
                                Console.WriteLine("Gracias por jugar Piedra, Papel o Tijeras");
                                Console.WriteLine($"Ya no cuenta con las monedas sufientes para continuar apostando\nLa apuesta establecida es de {playerApuestaHecha} monedas");
                                Console.WriteLine($"Su saldo inicial fue de: {playerSaldoInicial}");
                                Console.WriteLine($"Su saldo final en este juego es de: {playerCoins}");
                                Console.WriteLine($"Su record es:\nTotal de juegos Ganados: {winUser}\nTotal de juegos Perdidos: {winDealer}");
                                Console.ReadLine();
                            }
                        }
                    }
                }
            }
            break;

        case "100":
            Console.Clear();
            Console.WriteLine(" C A S I N O\nCompra de monedas\nCuántas monedas quiere comprar?\n ... {por favor, indique un numero entero mayor a cero}");
            playerCoins = int.Parse(Console.ReadLine()?.ToString() ?? "0");
            playerSaldoInicial = playerCoins;
            Console.WriteLine($"Su compra por {playerCoins} monedas; se realizó correctamente.");
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