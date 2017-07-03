using System;
using Bat.Vm;

namespace test {
    class Program {
        static void Main(string[] args) {
            Cpu cpu = new Cpu();
            int[] code = new int[] {
                (int)Instructions.PUSH, 5,
                (int)Instructions.PUSH, 2,
                (int)Instructions.MUL,
                (int)Instructions.PUSH, 10,
                (int)Instructions.ADD,
                (int)Instructions.PUSH, 2,
                (int)Instructions.DIV,
                (int)Instructions.PRINT,
                (int)Instructions.EXIT
            };

            cpu.LoadCode(code);

            cpu.RunCode(true);
            cpu.PrintStack();

            Console.ReadKey();
        }
    }
}
