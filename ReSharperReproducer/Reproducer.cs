//
// This file contains a reproducer for a ReSharper bug.
//
using System;

namespace ReSharperReproducer
{
    public sealed class MyTestClass
    {
        public MyTestClass Append(ConsoleColor? color, string value)
        {
            return this;
        }

        public void MethodWithLocalFunction(object operand1)
        {
            // ReSharper disable once UnusedLocalFunctionReturnValue
            MyTestClass MyLocalFunction(object operand) // <-- missing "Local function can be made static"
            {
                switch (operand)
                {
                    case string uncoloredString:
                        return new MyTestClass().Append(color: null, uncoloredString);
                }

                throw new Exception();
            }

            MyLocalFunction(operand1);
        }
    }
}
