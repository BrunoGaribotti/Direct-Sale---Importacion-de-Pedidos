using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class TGFunc
    {
        public int CodeConverter(int position, string code)
        {
            int CodeConverter = 0;

            List<string> vPosition1 = new List<string>();
            vPosition1.Add("74");
            vPosition1.Add("75");
            vPosition1.Add("76");
            vPosition1.Add("77");
            vPosition1.Add("70");
            vPosition1.Add("71");
            vPosition1.Add("72");
            vPosition1.Add("73");
            vPosition1.Add("7C");
            vPosition1.Add("7D");
            List<string> vPosition2 = new List<string>();
            vPosition2.Add("07");
            vPosition2.Add("06");
            vPosition2.Add("05");
            vPosition2.Add("04");
            vPosition2.Add("03");
            vPosition2.Add("02");
            vPosition2.Add("01");
            vPosition2.Add("00");
            vPosition2.Add("0F");
            vPosition2.Add("0E");

            List<string> vPosition3 = new List<string>();
            vPosition3.Add("43");
            vPosition3.Add("42");
            vPosition3.Add("41");
            vPosition3.Add("40");
            vPosition3.Add("47");
            vPosition3.Add("46");
            vPosition3.Add("45");
            vPosition3.Add("44");
            vPosition3.Add("4B");
            vPosition3.Add("4A");

            List<string> vPosition4 = new List<string>();
            vPosition4.Add("7B");
            vPosition4.Add("7A");
            vPosition4.Add("79");
            vPosition4.Add("78");
            vPosition4.Add("7F");
            vPosition4.Add("7E");
            vPosition4.Add("7D");
            vPosition4.Add("7C");
            vPosition4.Add("73");
            vPosition4.Add("72");

            List<string> vPosition5 = new List<string>();
            vPosition5.Add("51");
            vPosition5.Add("50");
            vPosition5.Add("53");
            vPosition5.Add("52");
            vPosition5.Add("55");
            vPosition5.Add("54");
            vPosition5.Add("57");
            vPosition5.Add("56");
            vPosition5.Add("59");
            vPosition5.Add("58");
            List<string> vPosition6 = new List<string>();
            vPosition6.Add("7E");
            vPosition6.Add("7F");
            vPosition6.Add("7C");
            vPosition6.Add("7D");
            vPosition6.Add("7A");
            vPosition6.Add("7B");
            vPosition6.Add("78");
            vPosition6.Add("79");
            vPosition6.Add("76");
            vPosition6.Add("77");
            List<string> vPosition7 = new List<string>();
            vPosition7.Add("07");
            vPosition7.Add("06");
            vPosition7.Add("05");
            vPosition7.Add("04");
            vPosition7.Add("03");
            vPosition7.Add("02");
            vPosition7.Add("01");
            vPosition7.Add("00");
            vPosition7.Add("0F");
            vPosition7.Add("0E");
            List<string> vPosition8 = new List<string>();
            vPosition8.Add("65");
            vPosition8.Add("64");
            vPosition8.Add("67");
            vPosition8.Add("66");
            vPosition8.Add("61");
            vPosition8.Add("60");
            vPosition8.Add("63");
            vPosition8.Add("62");
            vPosition8.Add("6D");
            vPosition8.Add("6C");

            switch (position)
            {
                case 1:
                    CodeConverter = vPosition1.IndexOf(code); break;
                case 2:
                    CodeConverter = vPosition2.IndexOf(code); break;
                case 3:
                    CodeConverter = vPosition3.IndexOf(code); break;
                case 4:
                    CodeConverter = vPosition4.IndexOf(code); break;
                case 5:
                    CodeConverter = vPosition5.IndexOf(code); break;
                case 6:
                    CodeConverter = vPosition6.IndexOf(code); break;
                case 7:
                    CodeConverter = vPosition7.IndexOf(code); break;
                case 8:
                    CodeConverter = vPosition8.IndexOf(code); break;
            }

            return CodeConverter;
        }

        public string DocNumberEncrypt(string pNumber)
        {
            string DocNumberEncrypt = "";
            string sText = "";
            string sAux = "";
            string sConv = "";
            int i = 0;

            sText = pNumber.PadLeft(8, '0');

            for (i = 0; i < 8; i++)
            {
                sAux = CharConverter(i, int.Parse(sText.Substring(i, 1)));
                sConv = sConv + sAux;
            }


            DocNumberEncrypt = sConv;

            return DocNumberEncrypt;
        }

        private string CharConverter(int iPosition, int iNumber)
        {
            string[] vPosition1 = { "74", "75", "76", "77", "70", "71", "72", "73", "7C", "7D" };

            string[] vPosition2 = { "07", "06", "05", "04", "03", "02", "01", "00", "0F", "0E" };

            string[] vPosition3 = { "43", "42", "41", "40", "47", "46", "45", "44", "4B", "4A" };

            string[] vPosition4 = { "7B", "7A", "79", "78", "7F", "7E", "7D", "7C", "73", "72" };

            string[] vPosition5 = { "51", "50", "53", "52", "55", "54", "57", "56", "59", "58" };

            string[] vPosition6 = { "7E", "7F", "7C", "7D", "7A", "7B", "78", "79", "76", "77" };

            string[] vPosition7 = { "07", "06", "05", "04", "03", "02", "01", "00", "0F", "0E" };

            string[] vPosition8 = { "65", "64", "67", "66", "61", "60", "63", "62", "6D", "6C" };

            string CharConverter = "";

            switch (iPosition + 1)
            {
                case 1:
                    CharConverter = vPosition1[iNumber]; break;
                case 2:
                    CharConverter = vPosition2[iNumber]; break;
                case 3:
                    CharConverter = vPosition3[iNumber]; break;
                case 4:
                    CharConverter = vPosition4[iNumber]; break;
                case 5:
                    CharConverter = vPosition5[iNumber]; break;
                case 6:
                    CharConverter = vPosition6[iNumber]; break;
                case 7:
                    CharConverter = vPosition7[iNumber]; break;
                case 8:
                    CharConverter = vPosition8[iNumber]; break;
                //case 9:
                //    CharConverter = vPosition9[iNumber]; break;
                //case 0:
                //    CharConverter = vPosition0[iNumber]; break;
            }
            return CharConverter;
        }

        public string DocNumberDecrypt(string pNumber)
        {

            string sText;
            int sAux;
            int iPos = 0;
            string sConv = "";
            int i;

            string DocNumberDecrypt = "";

            sText = pNumber.PadLeft(16, '0');

            if (sText.Length / 2 != 0)
            {
                sText = "0" + sText;
            }

            for (i = 1; i < sText.Length; i += 2)
            {
                iPos = iPos + 1;
                sAux = CodeConverter(iPos, sText.Substring(i, 2));
                sConv = sConv + sAux.ToString();
            }

            DocNumberDecrypt = sConv;

            return DocNumberDecrypt;
        }

    }
}
