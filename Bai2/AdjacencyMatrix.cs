using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    public class AdjacencyMatrix
    {
        // Attribute (thuoc tinh)
        public int SoDinh { get; set; }
        public int[,] Data { get; set; }

        // Constructor
        public AdjacencyMatrix(int soDinh, int[,] data)
        {
            this.SoDinh = soDinh;
            this.Data = data;
        }

        public AdjacencyMatrix()
        {

        }

        // Input and Output

        public bool ReadAdjacencyMatrix(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("This file does not exist.");
                return false;
            }
            string[] lines = File.ReadAllLines(filename);
            SoDinh = Int32.Parse(lines[0]);
            Data = new int[SoDinh, SoDinh];
            for (int i = 0; i < SoDinh; ++i)
            {
                string[] tokens = lines[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < SoDinh; ++j)
                {
                    Data[i, j] = Int32.Parse(tokens[j]);
                }
            }

            return true;
        }
        // cau a va c
        public void ShowAdjacencyMatrix()
        {
            Console.WriteLine(SoDinh);
            for (int i = 0; i < SoDinh; ++i)
            {
                for (int j = 0; j < SoDinh; ++j)
                {
                    Console.Write(Data[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public bool IsSimpleGraph()
        {
            for (int i = 0; i < SoDinh; ++i)
            {
                if (Data[i,i] > 0)
                {
                    Console.WriteLine("Loi: Du lieu nhap vao khong phai la do thi hop le. Li do: Co canh khuyen");
                    return false;
                }
            }

            for (int i = 0; i < SoDinh; ++i)
            {
                for (int j = 0; j < SoDinh; ++j)
                {
                    if (Data[i,j] != Data[j, i])
                    {
                        Console.WriteLine("Loi: Du lieu nhap vao khong phai la do thi hop le. Li do: Do thi co huong.");
                        return false;
                    }

                    if (Data[i,j] > 1)
                    {
                        Console.WriteLine("Loi: Du lieu nhap vao khong phai la do thi hop le. Li do: Da do thi");
                        return false;
                    }
                }
            }
            return true;
        }

        public int[] DemBacCuaDinh_DoThi_VoHuong(AdjacencyMatrix graph) //ĐẾM BẬC ĐỒ THỊ VÔ HƯỚNG
        {
            int[] degree = new int[graph.SoDinh];
            for (int i = 0; i < graph.SoDinh; i++)
            {
                int sum = 0;
                for (int j = 0; j < graph.SoDinh; j++)
                {
                    if (graph.Data[i, j] != 0)
                    {
                        sum = sum + graph.Data[i, j];
                        if (i == j)
                        {
                            sum = sum + graph.Data[i, i];
                        }
                    }
                }
                degree[i] = sum;
            }
            return degree;
        }

        public void CheckCompleteGraph(AdjacencyMatrix g, int[] degree)
        {
            bool complete = IsCompleteGraph(g, degree);

            if (complete)
            {
                Console.WriteLine("Day la do thi day du K" + SoDinh);
            } else
            {
                Console.WriteLine("Day khong phai la do thi day du");
            }
        }

        public bool IsCompleteGraph(AdjacencyMatrix g, int[] degree)
        {
            for (int i = 0; i < degree.Length; i++)
            {
                if (degree[i] != g.SoDinh - 1)
                {
                    return false;
                }
            }
            return true;
        }

        //code cua Trinh
        public bool KiemTraDoThiChinhQuy(AdjacencyMatrix a, int[] degrees)
        {
            for (int i = 1; i < a.SoDinh; i++)
            {
                if (degrees[0] != degrees[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void CheckRegularGraph(AdjacencyMatrix a, int[] degrees)
        {
            bool regular = KiemTraDoThiChinhQuy(a, degrees);

            if (regular)
            {
                Console.WriteLine($"Day la do thi {degrees[0]}-chinh quy");
            } else
            {
                Console.WriteLine("Day khong phai la do thi chinh quy");
            }
        }

        public bool KiemTraDoThiVong(AdjacencyMatrix a, int[] degrees)
        {
            if (KiemTraDoThiChinhQuy(a, degrees) == true && degrees[0] == 2)
            {
                return true;
            }
            else
                return false;
        }

        public void CheckCycleGraph(AdjacencyMatrix a, int[] degrees)
        {
            bool cycle = KiemTraDoThiVong(a, degrees);

            if (cycle)
            {
                Console.WriteLine($"Day la do thi vong C{a.SoDinh}");
            } else
            {
                Console.WriteLine("Day khong phai la do thi vong");
            }
        }
    }
}
