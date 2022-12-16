using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexExamples
{
    static public class Compare
    {
        static public string CompareInput(string Input1, string Input2)
        {
            double newinput1 = 0;
            double newinput2 = 0;

            double result = 0;
            bool isnumberInput1 = double.TryParse(Input1, out result);
            bool isnumberInput2 = double.TryParse(Input2, out result);


            if (isnumberInput1 == true)//just number compare
            {
                newinput1 = Convert.ToDouble(Input1);
            }
            if (isnumberInput2 == true)
            {
                newinput2 = Convert.ToDouble(Input2);
            }
            if (isnumberInput1 == true && isnumberInput2 == true)
            {
                if (newinput1 < newinput2)
                {
                    return "Input1 smaller than input2";
                }
                else if (newinput1 > newinput2)
                {
                    return "Input1 bigger than input2";
                }
                else
                {
                    return "Input1 equals input2";
                }
            }
            else
            {
                if (isnumberInput2 == false)
                {
                    Regex r3 = new Regex(@"-?\d+(?:\,\d+)?");//60.55<x<90.55  90.55>x>60.55
                    bool isPattern3True = r3.IsMatch(Input2);
                    if (isPattern3True == true)
                    {
                        MatchCollection mc = r3.Matches(Input2);
                        double v1 = 0;
                        double v2 = 0;

                        for (int i = 0; i < mc.Count; i++)
                        {
                            if (i == 0)
                            {
                                v1 = Convert.ToDouble(mc[i].ToString());
                            }
                            else
                            {
                                v2 = Convert.ToDouble(mc[i].ToString());
                            }
                        }

                        bool small = Input2.Contains("<");
                        bool big = Input2.Contains(">");

                        if (small == true)
                        {
                            if (v1 < newinput1 && v2 > newinput1)
                            {
                                return "Input1 is in range of input2";
                            }
                            else
                            {
                                return "Input1 is not in range of input2";
                            }
                        }
                        else if (big == true)
                        {
                            if (v1 > newinput1 && v2 < newinput1)
                            {
                                return "Input1 is in range of input2";
                            }
                            else
                            {
                                return "Input1 is not in range of input2";
                            }
                        }
                        else//100 mL //100 degree etc etc
                        {
                            if (newinput1 <= v1)
                            {
                                return "Input1 smaller than or equal input2";
                            }
                            else if (newinput1 > v1)
                            {
                                return "Input1 bigger than input2";
                            }
                        }
                    }
                    else
                    {
                        return "No suitable pattern found for input2";                                                  
                    }
                    
                }

            }
            return "Comparison format entered incorrectly";
        }

    }
}
