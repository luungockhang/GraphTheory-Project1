using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory_Project1
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
                    Console.Write(Data[i,j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void XuatSoDinhDoThi()
        {
            Console.WriteLine("So dinh cua do thi: " + SoDinh);
        }

        // Business

        // cau b
        public bool IsUndirectedGraph()
        {
            for (int i = 0; i < SoDinh; ++i)
            {
                for (int j = 0; j < SoDinh; ++j)
                {
                    if (Data[i, j] != Data[j, i])
                    {
                        Console.WriteLine("Do thi co huong");
                        return false;
                    }
                }
            }
            Console.WriteLine("Do thi vo huong");
            return true;
        }

        // cau d
        public void CalculateNumberOfEdge(bool undirected)
        {
            int sum = 0;
            int khuyen = 0;
            for (int i = 0; i < SoDinh; ++i)
            {
                for (int j = 0; j < SoDinh; ++j)
                {
                    if (i != j)
                    {
                        sum += Data[i, j];
                    }
                }
            }

            for (int i = 0; i < SoDinh; ++i)
            {
                khuyen += Data[i, i];
            }
            

            if (undirected)
            {
                Console.WriteLine($"So canh cua do thi: {sum/2 + khuyen}");
            } else
            {
                Console.WriteLine($"So canh cua do thi: {sum + khuyen}");
            }
        }
        // cau e
        public int DemCapDinhXuatHienCanhBoi(AdjacencyMatrix a)
        {
            int s = 0;
            for (int i = 0; i < a.SoDinh; i++)
            {
                for (int j = 0; j < a.SoDinh; j++)
                {
                    if (a.Data[i, j] > 1 && a.Data[j, i] > 1)
                    {
                        s++;
                    }
                }
            }
            Console.WriteLine("So cap dinh xuat hien canh boi: " + s/2);
            return s / 2;
        }

        //  cau e
        public int DemCanhKhuyen(AdjacencyMatrix a)
        {
            int s = 0;
            for (int i = 0; i < a.SoDinh; i++)
            {
                if (a.Data[i, i] == 1)
                {
                    s++;
                }
            }
            Console.WriteLine("So canh khuyen: " + s);
            return s;
        }

        

        
        // cau f
        public int DemDinhTreo(AdjacencyMatrix g, int[] degrees)
        {
            int count = 0;
            for (int i = 0; i < g.SoDinh; i++)
            {
                if (degrees[i] == 1)
                {
                    count++;
                }
            }
            Console.WriteLine("So dinh treo: " + count);
            return count;
        }
        // cau f
        public int DemDinhCoLap(AdjacencyMatrix g, bool undirected, int[] degrees)
        {
            if (undirected)
            {
                Console.WriteLine("So dinh co lap: 0");
                return 0;
            }
            int count = 0;
            for (int i = 0; i < g.SoDinh; i++)
            {
                if (degrees[i] == 0)
                {
                    count++;
                }
            }
            Console.WriteLine("So dinh co lap: " + count);
            return count;
        }

        // cau g
        public int[] DemBacCuaDinh_DoThi_VoHuong(AdjacencyMatrix a) //ĐẾM BẬC ĐỒ THỊ VÔ HƯỚNG
        {
            int[] bac = new int[a.SoDinh];
            for (int i = 0; i < a.SoDinh; i++)
            {
                int s = 0;
                for (int j = 0; j < a.SoDinh; j++)
                {
                    if (a.Data[i, j] != 0)
                    {
                        s = s + a.Data[i, j];
                        if (i == j)
                        {
                            s = s + a.Data[i, i];
                        }
                    }
                }
                bac[i] = s;
            }
            XuatBacCuaDinh_VH(bac);
            
            return bac;
        }

        public void XuatBacCuaDinh_VH(int[] degrees)
        {
            Console.WriteLine("Bac cua tung dinh:");
            for (int i = 0; i < degrees.Length; i++)
            {
                Console.Write($"{i}({degrees[i]})");
            }
            Console.WriteLine();
        }
        
        public void XuatBacCuaDinh_CH(int[] inDegrees, int[] outDegrees)
        {
            Console.WriteLine("(Bac vao - bac ra) cua tung dinh:");
            for (int i = 0; i < inDegrees.Length; i++)
            {
                Console.Write($"{i}({inDegrees[i]}-{outDegrees[i]}) ");
            }
            Console.WriteLine();
        }

        public int[] DemBacRa(AdjacencyMatrix a) //ĐẾM BẬC RA
        {
            int[] bacRa = new int[a.SoDinh];
            for (int i = 0; i < a.Data.GetLength(1); i++)
            {
                int s_ra = 0;
                for (int j = 0; j < a.Data.GetLength(0); j++)
                {
                    if (a.Data[i, j] != 0)
                    {
                        s_ra = s_ra + a.Data[i, j];
                    }
                }
                bacRa[i] = s_ra;
            }
            return bacRa;
        }
        public int[] DemBacVao(AdjacencyMatrix a) //ĐẾM BẬC VÀO
        {
            int[] BacVao = new int[a.SoDinh];
            for (int i = 0; i < a.Data.GetLength(0); i++)
            {
                int s_vao = 0;
                for (int j = 0; j < a.Data.GetLength(1); j++)
                {
                    if (a.Data[j, i] != 0)
                    {
                        s_vao = s_vao + a.Data[j, i];
                    }
                }
                BacVao[i] = s_vao;
            }
            return BacVao;
        }

        // cau h
        public void XacDinhLoaiDoThi(bool undirected, int soCanhBoi, int soKhuyen)
        {
            if (undirected)
            {
                if (soCanhBoi > 0)
                {
                    if (soKhuyen > 0)
                    {
                        Console.WriteLine("Gia do thi");
                        return;
                    }
                    Console.WriteLine("Da do thi vo huong");
                    return;
                }
                Console.WriteLine("Don do thi vo huong");
                return;
            } else
            {
                if (soCanhBoi > 0)
                {
                    Console.WriteLine("Da do thi co huong");
                    return;
                }
                Console.WriteLine("Do thi co huong");
                return;
            }
        }
    }

}