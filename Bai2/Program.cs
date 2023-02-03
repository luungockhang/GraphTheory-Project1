namespace Bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "D:\\input.txt"; // Vui long sua duong dan tai day

            AdjacencyMatrix g = new AdjacencyMatrix();
            g.ReadAdjacencyMatrix(filename); 
            g.ShowAdjacencyMatrix();

            bool isSimple = g.IsSimpleGraph();
            if (isSimple)
            {
                int[] degrees = g.DemBacCuaDinh_DoThi_VoHuong(g);
                g.CheckCompleteGraph(g, degrees);
                g.CheckRegularGraph(g, degrees);
                g.CheckCycleGraph(g, degrees);
            }
        }
    }
}