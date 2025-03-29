using Exercise2;

internal class Program
{
    private static void Main(string[] args)
    {


        KontenerPlynyL x = new KontenerPlynyL(50, 100, 100, 50, "L", 50, true);

        try
        {
            x.zaladujKontener(500);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


       KontenerChlodniczyC a = new KontenerChlodniczyC(100,100,1000,100,"C",100,100);

        a.addProduct("Banan", 10);
        a.loadProducts("Banan", 0);

        Kontenerowiec abc = new Kontenerowiec("test", 50, 20, 10000);

        abc.zaladujKontener(a);

        abc.wypiszInformacjeOStatku();


    }
}