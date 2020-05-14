using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datehelper
{
    delegate void EinfacheDelegate();
    delegate void DelegateMitPara(string text);
    delegate long CalcDelegate(int ppppp, int bzzzzz);

    class HalloDelegate
    {
        public HalloDelegate()
        {
            EinfacheDelegate meineDele = EinfacheMethode;
            Action meineDeleAlsAction = EinfacheMethode;
            Action meineDeleAlsActionAno = delegate () { Console.WriteLine("Ich habe keinen Namen"); };
            Action meineDeleAlsActionAno2 = () => { Console.WriteLine("Ich habe keinen Namen"); };
            Action meineDeleAlsActionAno3 = () => Console.WriteLine("Ich habe keinen Namen");


            DelegateMitPara deleMitPara = MethodePara;
            Action<string> paraAlsAction = MethodePara;
            DelegateMitPara deleMitParaAno = (string txt) => { Console.WriteLine(txt); };
            Action<string> deleMitParaAno2 = (txt) => Console.WriteLine(txt);
            DelegateMitPara deleMitParaAno3 = x => Console.WriteLine(x);

            CalcDelegate calcDele = Minus;
            Func<int, int, long> calcFunc = Sum;
            CalcDelegate calcDeleAno = (int x, int y) => { return x + y; };
            CalcDelegate calcDeleAno2 = (x, y) => { return x + y; };
            CalcDelegate calcDeleAno3 = (x, y) => x + y;

            List<string> texte = new List<string>();
            texte.Where(x => x.StartsWith("b"));
            texte.Where(Filter);

            long res = calcDele.Invoke(56, 23);
        }

        private bool Filter(string arg)
        {
            if (arg.StartsWith("b"))
                return true;
            else
                return false;
        }

        private long Minus(int a, int b)
        {
            return a + b;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }


        private void MethodePara(string msg)
        {
            Console.WriteLine(msg);
        }

        void EinfacheMethode()
        {
            Console.WriteLine("Hallo");
        }
    }
}
