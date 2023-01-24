namespace Curs11
{
    class Program
    {
        static void Main()
        {
            Engine.LoadFromFile(@"../../TextFile1.txt");
            AlgGenetic demo = new AlgGenetic();
            demo.InitPop();
            for (int i = 0; i < 1000000; i++) //alegem timpul de evolutie un milion
            {
                demo.SortPop();
                demo.SelectPop();
                demo.UpdatePop();
            }
            demo.SortPop(); //dupa aceasta sortare, prinmul individ e solutia noastra
            demo.View();
        }
    }
}
