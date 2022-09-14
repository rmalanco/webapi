
// inyección de dependencias
// Se utiliza para inyectar dependencias en el controlador
// las dependencias se inyectan en el constructor del controlador
// se utiliza la palabra reservada "new" para crear un objeto de la clase que se va a inyectar
// se utiliza la palabra reservada "this" para referenciar el objeto que se va a inyectar
// se utiliza la palabra reservada "nameof" para referenciar el nombre de la clase que se va a inyectar

// se crea una nueva clase llamada "helloWorldService" en la carpeta "Services"
public class helloWorldService : IHelloWorldService // se hace la implementación de la interfaz "IHelloWorldService"
{
    // se crea un metodo que retorna un string
    public string GetHelloWorld()
    {
        // se retorna un string
        return "Hello World";
    }
}
// se crea una nueva clase llamada "helloWorldService" en la carpeta "Services"
// esta es una interfaz que se utiliza para inyectar dependencias
public interface IHelloWorldService
{
    string GetHelloWorld();
}