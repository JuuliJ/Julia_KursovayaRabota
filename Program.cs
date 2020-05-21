using System;
namespace ConsoleApp2
{
    class stroka
    {
        protected string str;
        protected int dlina;
        public stroka(string l)
        {
            str = l;
            char[] a = str.ToCharArray();
            length();
            if (dlina>8)
                throw new Exception("Ошибка!");
            for (int i = 0; i > a.Length; i++)
            {
                if (a[i] != '0' || a[i] != '1')
                    throw new Exception("Ошибка! Строка может содержать только символы '0' или '1'");
            }
        }
        public stroka(char a)
        {
            str = Convert.ToString(a);
        }
        public stroka()
        { }
        public void length ()
        {
            dlina=str.Length;
        }
        public void chistka()
        {
            this.str = null;
            this.dlina = 0;
        }

    }
    class bit_stroka : stroka
    {
       
        public bit_stroka(string l) : base(l)
        {
            
        }
        ~bit_stroka()
        {
        }
        public static bit_stroka operator +(bit_stroka m1, bit_stroka m2)
        {
            bit_stroka s = new bit_stroka("00000000");
            char[] a = s.str.ToCharArray();
            for (int i = m1.str.Length - 1; i >= 0; i--)
                a[i] = Convert.ToString(Convert.ToInt32(Convert.ToString(m1.str[i])) + Convert.ToInt32(Convert.ToString(m2.str[i])))[0];
            for (int i = m1.str.Length - 1; i > 0; i--)
            {
                if (a[i] == '2')
                {
                    a[i - 1] = Convert.ToString(Convert.ToInt32(Convert.ToString(a[i - 1])) + 1)[0];
                    a[i] = '0';
                }
                if (a[i] == '3')
                {
                    a[i - 1] = Convert.ToString(Convert.ToInt32(Convert.ToString(a[i - 1])) + 1)[0];
                    a[i] = '1';
                }
            }
            string g = "";
            for (int i = 0; i < a.Length; i++)
                g += a[i];
            s.str = g;
            return s;
        }
        public bool Equals(bit_stroka other)
        {
            return str == other.str;
        }
        public static bit_stroka dop_kod(bit_stroka m1)
        {
            char[] a = m1.str.ToCharArray();
            if (a[0]=='1')
            {
                for (int i = a.Length - 1; i > 0; i--)
                {
                    if (a[i] == '0')
                        a[i] = '1';
                    else
                        a[i] = '0';
                }
                a[a.Length-1] = Convert.ToChar(Convert.ToInt32(a[a.Length - 1]) + 1);
                for (int i = a.Length - 1; i >= 0; i--)
                {
                    if (a[i] == '2')
                    {
                        a[i - 1] = Convert.ToChar(Convert.ToInt32(a[i-1]) + 1);
                        a[i] = '0';
                    }
                   
                }

            }
            string g = "";
            for (int i = 0; i < a.Length; i++)
                g += a[i];
            m1.str = g;
            return m1;
        }
        public static bit_stroka prisvaivanie(string str)
        {
            bit_stroka m1 = new bit_stroka(str);
            return m1;
        }

        class Program
        {
            static void Main(string[] args)
            {
                bit_stroka m1, m2, m3;
            label1:
                try
                {
                    string n, m;
                    Console.Write("Введите первую строку: ");
                    n = Console.ReadLine();
                    m1 = bit_stroka.prisvaivanie(n);
                    Console.Write("Введите вторую строку: ");
                    m = Console.ReadLine();
                    m2 = bit_stroka.prisvaivanie(m);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    goto label1;
                }
                m1 = bit_stroka.dop_kod(m1);
                m3 = m1 + m2;
                Console.WriteLine("Строки равны?{0}",m1.Equals(m2));
                Console.WriteLine("Строка 1:{0}\nСтрока 2:{1}\nСумма строк:{2}", m1.str, m2.str, m3.str);
                Console.ReadLine();
            }
        }
    }
}




 