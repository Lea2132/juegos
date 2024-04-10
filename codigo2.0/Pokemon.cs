using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

public class Pokemon : IPokemon
{
    Random rand = new Random();
    private String nombre;
    private String tipo;
    private double salud;
    private int[] Vectorataques = new int[3]; //creacion del vector que almacena los valores de los ataques
    private int[] defensas = new int[2]; //creacion del vector que almacena los valores de las defensas
    private double[] mAtaque = { 1, 0, 1.5 }; //numeros para multiplicar el ataque
    private double[] mDefensa = { 1, 0.5 }; //numeros para multiplicar la defensa

    public Pokemon(String nombre, String tipo, double salud)
    { //metodo de insercion de datos del pokemon
        this.nombre = nombre;
        this.tipo = tipo;
        this.salud = salud;
    }

    public void Rellenodevectores()
    {
        //primero llenamos el vector ataques
        for (int i = 0; i < Vectorataques.Length; i++)
        {
            Vectorataques[i] = rand.Next(0, 41); // se rellenan los 3 campos del vector ataque con puntajes entre 0 y 40
        }
        for (int i = 0; i < Vectorataques.Length; i++)
        {
            Console.WriteLine("el numero random de ataque es:" + Vectorataques[i]);
        }

        //luego relleno del vector defensas
        for (int i = 0; i < defensas.Length; i++)
        {
            defensas[i] = rand.Next(10, 36); //se rellenan los 2 campos del vector defensas con puntajes entre 10 y 35
        }
        for (int i = 0; i < defensas.Length; i++)
        {
            Console.WriteLine("el numero random de defensa es:" + defensas[i]);
        }
    }

    //mostrar los datos de pokemon
    public void Mostrar()
    {
        Console.WriteLine(
            $"El nombre del pokemon es {this.nombre} "
                + $" el tipo es: {this.tipo} "
                + $" y su salud es: {this.salud}"
        );
    }

    //metodo para sacar el numero del ataque
    public double numeroAtaque()
    {
        double atak = Vectorataques[rand.Next(0, 3)] * mAtaque[rand.Next(0, 3)]; //le decimos que el ataque va a ser cualquier de los almacenados
        return atak;
    }

    //metodo de defensa para sacar el numero de la defensa
    public double numeroDefensa()
    {
        double defenk = defensas[rand.Next(0, 2)] * mDefensa[rand.Next(0, 2)]; //le decimos que la defensa va a ser cualquiera de los almacenados
        return defenk;
    }

    //metodo para atacar al otro pokemon el cual llamamos "enemigo"
    public void Atacar(Pokemon Enemigo)
    {
        double numAtaque = numeroAtaque();
        double numEnemigoDefensa = Enemigo.numeroDefensa();
        double total = 0;

        if (numAtaque == numEnemigoDefensa)
        {
            Console.WriteLine("el ataque y la defensa son iguales entonces se anulan");
        }
        else
        {
            if (numAtaque > numEnemigoDefensa)
            {
                total = numAtaque - numEnemigoDefensa;
                Console.WriteLine(
                    $"el pokemon {this.nombre} atacó a el pokemon {Enemigo.nombre} con {total}"
                        + $" de ataque"
                );
                Enemigo.setSalud(Enemigo.getSalud() - total); //Aca estamos editando la salud del pokemon enemigo
            }
            else
            {
                double contraataque = numEnemigoDefensa - numAtaque;
                Console.WriteLine(
                    "fue mayor la defensa entonces el enemigo contrataco con " + contraataque
                );
                setSalud(getSalud() - contraataque); //aca editamos la salud del pokemon que atacó, porque la defensa del otro supero su ataque
            }
        }
    }

    public double getSalud()
    {
        return salud;
    }

    public void setSalud(double vida)
    {
        this.salud = vida;
    }
}
