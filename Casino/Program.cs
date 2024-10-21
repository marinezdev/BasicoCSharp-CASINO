// See https://aka.ms/new-console-template for more information

using System;

bool play = true;
int playerCoins = 0;
int playerApuestaHecha = 0;
string playerApuesta = string.Empty;
string userOptionChose = string.Empty;


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
                        Console.WriteLine($"*** La apuesta del juego es: {playerApuestaHecha}");

                        bool jugando = true;
                        int playerPC = 0;
                        string playerUserOption = string.Empty;
                        while (jugando)
                        {
                            playerPC = new System.Random().Next(1, 3);
                            Console.WriteLine("Elige una opción:\n" +
                                "1 - Piedra\n" +
                                "2 - Papel\n" +
                                "3 - Tijeras\n" +
                                "X - para salir del juego.");
                            playerUserOption = Console.ReadLine() ?? string.Empty;
                            if (playerUserOption.ToUpper() == "X")
                            {
                                Console.Clear();
                                Console.WriteLine("Gracias por jugar Piedra, Papel o Tijeras");
                                Console.WriteLine("Su saldo inicial fue de: SALDOINICIAL");
                                Console.WriteLine("Su saldo final en este juego es de: {playerCoins} monedas.");
                                Console.WriteLine("Su record es:\nTotal de juegos Ganados: TOTALGANADOS\nTotal de juegos Perdidos: TOTALPERDIDOS");
                                Console.ReadLine();
                            }
                            
                            if (playerCoins <= playerApuestaHecha)
                            {
                                jugando = false;
                                Console.Clear();
                                Console.WriteLine("Gracias por jugar Piedra, Papel o Tijeras");
                                Console.WriteLine($"Ya no cuenta con las monedas sufientes para continuar apostando\nLa apuesta establecida es de {playerApuestaHecha}");
                                Console.WriteLine("Su saldo inicial fue de: SALDOINICIAL");
                                Console.WriteLine("Su saldo final en este juego es de: SALDOFINAL");
                                Console.WriteLine("Su record es:\nTotal de juegos Ganados: TOTALGANADOS\nTotal de juegos Perdidos: TOTALPERDIDOS");
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