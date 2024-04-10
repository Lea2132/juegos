using GPC.interfaz;
namespace GPC.Program;
class Program
{
    static void Main(string[] args)
    {
        // Crear jugadores con nombre y rendimiento aleatorio
        List<Jugador> listaJugadores = new List<Jugador>();
        Random rnd = new Random();
        string[] nombresJugadores = { "Leonardo", "El leandro", "el profe juan", "Kobe", "Lebron", "Harden" };
        foreach (string nombre in nombresJugadores)
        {
            int rendimiento = rnd.Next(1, 11); // Generar un rendimiento aleatorio entre 1 y 10
            listaJugadores.Add(new Jugador(nombre, rendimiento));
        }

        // Crear equipos
        Equipo equipo1 = new Equipo("Equipo 1");
        Equipo equipo2 = new Equipo("Equipo 2");

        // Mecánica de selección aleatoria de jugadores
        IMecanicaSeleccion mecanicaSeleccion = new MecanicaAleatoria(listaJugadores);

        // Agregar jugadores a los equipos
        while (equipo1.CantidadJugadores < 3)
        {
            Jugador jugador = mecanicaSeleccion.SeleccionarJugador();
            equipo1.AgregarJugador(jugador);
        }
        while (equipo2.CantidadJugadores < 3)
        {
            Jugador jugador = mecanicaSeleccion.SeleccionarJugador();
            equipo2.AgregarJugador(jugador);
        }

        // Mostrar los jugadores de cada equipo
        Console.WriteLine("Jugadores del Equipo 1:");
        equipo1.ListarJugadores();
        Console.WriteLine("Jugadores del Equipo 2:");
        equipo2.ListarJugadores();

        // Determinar el ganador
        if (equipo1.TotalRendimiento() > equipo2.TotalRendimiento())
        {
            Console.WriteLine($"El ganador es el {equipo1.Nombre}");
        }
        else if (equipo2.TotalRendimiento() > equipo1.TotalRendimiento())
        {
            Console.WriteLine($"El ganador es el {equipo2.Nombre}");
        }
        else
        {
            Console.WriteLine("El prtido terminó en empate!");
        }
    }
}
class Jugador
{
    private string nombre;
    private int rendimiento;

    public Jugador(string nombre, int rendimiento)
    {
        this.nombre = nombre;
        this.rendimiento = rendimiento;
    }

    public string Nombre { get { return nombre; } }
    public int Rendimiento { get { return rendimiento; } }
}
class Equipo
{
    private string nombre;
    private List<Jugador> jugadores;

    public Equipo(string nombre)
    {
        this.nombre = nombre;
        this.jugadores = new List<Jugador>();
    }

    public string Nombre { get { return nombre; } }
    public int CantidadJugadores { get { return jugadores.Count; } }

    public void AgregarJugador(Jugador jugador)
    {
        if (CantidadJugadores < 3)
        {
            jugadores.Add(jugador);
        }
        else
        {
            Console.WriteLine($"El equipo {Nombre} ya tiene 3 jugadores.");
        }
    }

    public int TotalRendimiento()
    {
        int total = 0;
        foreach (Jugador jugador in jugadores)
        {
            total += jugador.Rendimiento;
        }
        return total;
    }

    public void ListarJugadores()
    {
        foreach (Jugador jugador in jugadores)
        {
            Console.WriteLine($"Nombre: {jugador.Nombre}, Rendimiento: {jugador.Rendimiento}");
        }
    }
}

class MecanicaAleatoria : IMecanicaSeleccion
{
    private List<Jugador> jugadoresDisponibles;
    private Random rnd;

    public MecanicaAleatoria(List<Jugador> jugadoresDisponibles)
    {
        this.jugadoresDisponibles = jugadoresDisponibles;
        this.rnd = new Random();
    }

    public Jugador SeleccionarJugador()
    {
        int indice = rnd.Next(jugadoresDisponibles.Count);
        Jugador jugadorSeleccionado = jugadoresDisponibles[indice];
        jugadoresDisponibles.RemoveAt(indice);
        return jugadorSeleccionado;
    }
}