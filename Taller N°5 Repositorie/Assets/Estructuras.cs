/// <summary>
/// Estrucuturas del zombie y el ciudadano
/// </summary>
public struct zomboidinfo
{
    public string antojo;
    public string nombre;
    public int edad;
}
public struct Civitasinfo
{
    public string nombre;
    public int edad;

    static public implicit operator zomboidinfo(Civitasinfo c)
    {
        zomboidinfo z = new zomboidinfo();
        z.antojo = "Cerebros";
        z.edad = c.edad;
        z.nombre = "Zombie " + c.nombre;
        return z;
    }
}
