namespace GraphTheory_Project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdjacencyMatrix g = new AdjacencyMatrix();
            g.ReadAdjacencyMatrix("D:\\input.txt");
            g.ShowAdjacencyMatrix();
            bool undirected = g.IsUndirectedGraph();
            g.XuatSoDinhDoThi();
            g.CalculateNumberOfEdge(undirected);
            int soCapDinhXuatHienCanhBoi = g.DemCapDinhXuatHienCanhBoi(g);
            int soCanhKhuyen = g.DemCanhKhuyen(g);

            int[] degrees = new int[g.SoDinh];
            int[] inDegrees = new int[g.SoDinh];
            int[] outDegrees = new int[g.SoDinh];

            if (undirected)
            {
                degrees = g.DemBacCuaDinh_DoThi_VoHuong(g);
            } else
            {
                inDegrees = g.DemBacVao(g);
                outDegrees = g.DemBacRa(g);
                g.XuatBacCuaDinh_CH(inDegrees, outDegrees);
            }
            int soDinhTreo = g.DemDinhTreo(g, degrees);
            int soDinhCoLap = g.DemDinhCoLap(g, undirected, degrees);
            g.XacDinhLoaiDoThi(undirected, soCapDinhXuatHienCanhBoi, soCanhKhuyen);
        }

    }

}