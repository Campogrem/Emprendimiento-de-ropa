public class Program
{
    public static void Main(string[] args)
    {
        // Creamos el contexto con los artículos disponibles y su cantidad
        Dictionary<string, int> availableItems = new Dictionary<string, int>
        {
            { "Camiseta", 10 },
            { "Pantalón", 5 },
            { "Medias", 0 }
        };
        ClothingContext context = new ClothingContext(availableItems);
        // se le pide al ususario el  que ingrese la seccion que desea ver.
        Console.WriteLine("Secciones disponibles: Camisetas, Pantalones, Medias");
        Console.Write("Ingrese la sección que desea ver: ");
        string section = Console.ReadLine();

        // Creamos la expresión para verificar la disponibilidad de la sección seleccionada
        IExpression sectionExpression = new ItemAvailabilityExpression(section);

        // Evaluamos la expresión para saber la seccion esta disponible
        bool sectionAvailable = context.Evaluate(sectionExpression);

        if (sectionAvailable)
        {
            int quantity = context.GetItemQuantity(section);

            if (quantity > 0)
            {
                Console.WriteLine("Cantidad de unidades disponibles de {0}: {1}", section, quantity);
            }
            else
            {
                Console.WriteLine("No hay unidades disponibles de {0}", section);
            }
        }
        else
        {
            Console.WriteLine("La sección {0} no está disponible", section);
        }
    }
}