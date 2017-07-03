namespace Bat.Vm {
    public class Cpu {
        public const int DEFAULT_STACK_SIZE = 1000;
        
        private int[] stack = new int[DEFAULT_STACK_SIZE];

        public void RunCode(int[] code) {
            int instructionPointer = 0;
            int stackPointer = -1;

            int a;
            int b;
            int result;

            Instructions opcode = (Instructions)code[instructionPointer];

            while (opcode != Instructions.EXIT) {
                instructionPointer++;

                switch (opcode) {
                    case Instructions.ADD:
                        b = stack[stackPointer--];
                        a = stack[stackPointer--];
                        result = a + b;
                        stack[++stackPointer] = result;
                        break;
                    case Instructions.SUB:
                        b = stack[stackPointer--];
                        a = stack[stackPointer--];
                        result = a - b;
                        stack[++stackPointer] = result;
                        break;
                    case Instructions.MUL:
                        b = stack[stackPointer--];
                        a = stack[stackPointer--];
                        result = a * b;
                        stack[++stackPointer] = result;
                        break;
                    case Instructions.PUSH:
                        stack[++stackPointer] = code[instructionPointer++];
                        break;
                    case Instructions.POP:
                        --stackPointer;
                        break;
                }

                opcode = (Instructions)code[instructionPointer];
            }
        }
    }
}
