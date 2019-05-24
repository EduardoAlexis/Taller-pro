/// <summary>
/// Estrucuturas del zombie y el villager
/// </summary>
public struct InformacionZombie
{
    public string sabor;
    public string nombre;
    public int edad;
}
public struct InformacionVillager
{
    public string nombre;
    public int edad;

    static public implicit operator InformacionZombie(InformacionVillager c)
    {
        InformacionZombie z = new InformacionZombie();
        z.sabor = "Cerebros";
        z.edad = c.edad;
        z.nombre = "Zombie " + c.nombre;
        return z;
    }
}
