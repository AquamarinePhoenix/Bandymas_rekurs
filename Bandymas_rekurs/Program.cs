using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Lab_1
{
    class Miestai
    {
        private string miest;
        public Miestai(string miest)
        {
            this.miest = miest;
        }
        public string Miest_1() { return miest; }
    }
    class Marsrutas
    {
        private string pr, pab;
        private int km;

        public Marsrutas(string pr, string pab, int km)
        {
            this.pr = pr;
            this.pab = pab;
            this.km = km;
        }

        public string Pr_1() { return pr; }
        public string Pab_1() { return pab; }
        public int Km_1() { return km; }
    }

    internal class Program
    {
        const string Fail = "Duom_1.txt";
        //const string Fail_rez = "Duom_1_rez.txt";
        const int VS = 10;
        const int KS = 50;
        static void Main(string[] args)
        {
            int m, n, pr, pab,prad1,index1=0;
            string x1, x2;

            Miestai[] Mt = new Miestai[VS];
            Marsrutas[] Mr = new Marsrutas[KS];
            Nuskaitymas(Fail, Mt, Mr, out m, out n, out x1, out x2, out pr, out pab);
            //Isvedimas(Mt, Mr, m, n,x1,x2);
            int[,] mas = new int[m, m];
            int[] rezai = new int[50];
            Konvertavimas(mas, Mt, Mr, m, n);
            prad1 = 0;
            for (int i = 0; i < 50; i++)
            {
                rezai[i] = 0;
            }
            Metodas_taikome(m,mas,prad1,pab,rezai,index1);
            //Metodas_2(m,mas,pab,rezai,index1,prad1);
        }
        static void Konvertavimas(int[,] mas, Miestai[] Mt, Marsrutas[] Mr, int m, int n)
        {

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = 0;
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Mt[i].Miest_1() == Mr[j].Pr_1())
                    {
                        for (int k = 0; k < m; k++)
                        {
                            if (Mt[k].Miest_1() == Mr[j].Pab_1())
                            {
                                mas[i, k] = Mr[j].Km_1();
                                mas[k, i] = mas[i, k];                                
                            }
                        }
                    }
                }
            }
            for (int i=0; i<m;i++)
            {
                Console.Write("|| ");
                for (int j = 0; j < m; j++)
                {
                    
                    Console.Write(" {0, 2:d} ", mas[i, j]);
                    
                }
                Console.Write(" ||");
                Console.WriteLine();
            }
            
        }
        static void Nuskaitymas(string fv, Miestai[] Mt, Marsrutas[] Mr, out int m, out int n, out string x1, out string x2, out int pr, out int pab)
        {

            using (StreamReader sr = new StreamReader(fv))
            {
                string line;
                string pradzia, pabaiga;
                int kilometrai;
                pr = 0;
                pab = 0;
                line = sr.ReadLine();
                string[] parts;
                parts = line.Split(' ');
                m = int.Parse(parts[0]);
                n = int.Parse(parts[1]);

                for (int i = 0; i < m; i++)
                {
                    line = sr.ReadLine();

                    Mt[i] = new Miestai(line);
                }
                line = sr.ReadLine();
                parts = line.Split(' ');
                x1 = parts[0].ToString();
                x2 = parts[1].ToString();

                for (int i = 0; i < m; i++)
                {
                    if (x1 == Mt[i].Miest_1())
                    {
                        pr = i;
                    }
                    if (x2 == Mt[i].Miest_1())
                    {
                        pab = i;
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    line = sr.ReadLine();
                    parts = line.Split(' ');
                    pradzia = parts[0].ToString();
                    pabaiga = parts[1].ToString();
                    kilometrai = int.Parse(parts[2]);
                    Mr[i] = new Marsrutas(pradzia, pabaiga, kilometrai);
                }
            }
        }
        static void Isvedimas(Miestai[] Mt, Marsrutas[] Mr, int m, int n, string x1, string x2)
        {
            for (int i = 0; i < m; i++)
                Console.WriteLine(Mt[i].Miest_1());
            for (int i = 0; i < n; i++)
                Console.WriteLine("{0}, {1}, {2}", Mr[i].Pr_1(), Mr[i].Pab_1(), Mr[i].Km_1());
        }
        static bool Metodas_taikome(int m, int[,] mas, int prad1, int pab,int[] rezai,int index1)
        {
            for (int j=0; j<m;j++)
            {                
                if (mas[prad1, j] != 0)
                    return true;
                
                if (true)
                {
                    rezai[index1] += mas[prad1, j];
                    if (j != pab)
                    {
                        prad1 = j;
                        Metodas_taikome(m, mas, prad1, pab, rezai, index1); 
                    }
                    else if (prad1 + 1 <= m)
                        Metodas_taikome(m, mas, prad1 + 1, pab, rezai, index1 + 1);               
                }
                
            }
            return false;
        }
        static void Metodas_2(int m, int[,] mas, int pab, int[] rezai, int index1, int prad1)
        {
            for (int i=0;i<m;i++)
            {
                for (int j=0;j<m;j++)
                {
                    if (mas[i,j]!=0&&j!=pab)
                    {
                        rezai[index1] += mas[i, j];
                        prad1 = j;
                        Metodas_2(m, mas, pab, rezai, index1,prad1);
                    }
                    if (mas[i, j] != 0 && j == pab)
                    {
                        rezai[index1] += mas[i, j];
                    }
                }
            }
        }
    }
}


