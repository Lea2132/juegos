

public class Program
{
    public static void Main(String[] args)
    {
        //Creamos las 2 instancias
        Pokemon pokemon1 = new Pokemon("Pikachu", "Electrico", 100);
        Pokemon pokemon2 = new Pokemon("Charizard", "Fuego", 100);

        Console.WriteLine("ataques y defensas del pokemon 1");
        pokemon1.Rellenodevectores();
        Console.WriteLine("ataques y defensas del pokemon 2");
        pokemon2.Rellenodevectores();

        Console.WriteLine("pokemon 1");
        pokemon1.Mostrar();
        Console.WriteLine("pokemon 2");
        pokemon2.Mostrar();

        for (int i = 0; i < 3; i++)
        {
            if (pokemon1.getSalud() > 0 && pokemon2.getSalud() > 0)
            {
                Console.WriteLine("*******NUMERO DE TURNO*******" + (i + 1));
                Console.WriteLine("ataca picachu");
                pokemon1.Atacar(pokemon2);
                pokemon2.Mostrar();
                pokemon1.Mostrar();
                Console.WriteLine("ataca charizard");
                pokemon2.Atacar(pokemon1);
                pokemon2.Mostrar();
                pokemon1.Mostrar();
            }
            else
            {
                Console.WriteLine("uno de los poquemones murio antes de terminar la pelea X_X");
            }
        }

        if (pokemon1.getSalud() == pokemon2.getSalud())
        {
            Console.WriteLine("es un empate");
        }
        else
        {
            if (pokemon1.getSalud() > pokemon2.getSalud())
            {
                Console.WriteLine("el ganador es Picachu");
            }
            else
            {
                Console.WriteLine("el ganador es Charizard");
            }
        }
    }
}
