## Simple Virtual Machine

As the title says, simple virtual machine written in C#. It contains a lightweight logger class. With this logger class it can log any thing in `System.IO.TextWriter` object.

### Usage

#### Cpu class
`Cpu` is the main class for our Virtual Machine. It loads and runs code you write, also it has some useful debug methods.
It has three `public` methods.

* `Cpu.RunCode(bool)`. The bool variable is for debugging. If you give `true` as argument it will log `ADD`, `SUB`, `MUL` and `DIV` instructions like `[DEBUG] {0} [+-*/] {1} = {2}`.

* `Cpu.LoadCode(int[])`. Simple enough. Loads your new code in to Cpu's `code` variable. Once you add a code in Cpu, then you can run that code as much as you want.

* `Cpu.PrintStack(int = DEFAULT_STACK_PRINT_SIZE)`. This method is prints the Cpu's `stack` variable. Stack changes as you `PUSH` numbers and use `ADD`, `SUB`, `MUL` and `DIV` instructions. It takes a `int` literal for how much variables to print.

Also there are eight `Instructions`.

| Instruction Name | Description |
| :--------------- | ----------- |
| ADD              | Sums top 2 values from stack. |
| SUB              | Substracts top 2 values from stack. |
| MUL              | Multiplies top 2 values from stack. |
| DIV              | Divides top 2 values from stack. (If second number is zero it logs error message) |
| PUSH             | Pushes value comes after that command in to top of the stack. |
| POP              | Pops first value from stack. |
| PRINT            | Prints first value from stack. |
| EXIT             | Exits from the program. |

With these `Instructions` you can make simple program like below.

```Csharp
var cpu = new Cpu();

int[] code = new int[] {
  (int)Instructions.PUSH, 5, // Pushes 5 to the stack
  (int)Instructions.PUSH, 2, // Pushes 2 to the stack
  (int)Instructions.MUL, // Multiplies these 2 values. Result should be 10
  (int)Instructions.PRINT, // Prints 10
  (int)Instructions.EXIT // Do not forget this.
};

cpu.LoadCode(code);
cpu.RunCode(true); // We pass true because we want debugging.

// This code should be log this:
// [DEBUG]: 5 * 2 = 10
// [INFO]: 10
```

#### Logger class
`Logger` class is a `static` class. That means you can use methods without creating a instance of a `Logger` class. `Logger` simplifies debugging and printing informations, warnings or errors in `TextWriter` object. Most common object that inherited from `TextWriter` is `Console.Out` object. It is used when printing console. And if you use `Logger` class without giving `TextWriter` object it takes `Console.Out` by default.

`Logger` class can write logs in `Console` with colors. There is some default colors for `LogLevel`'s.

`LogLevel` is an enum contains `DEFAULT`, `INFO`, `DEBUG`, `WARNING` and `ERROR` values.

`Logger` simply has two public methods but they are overloaded. By that overloading `Logger` class have six `public static` methods.

* `Logger.Write(string, bool = false, bool = true)`. Only writes text in default `TextWriter` object. If you use this method without giving a `LogLevel` it automatically selects `LogLevel.DEFAULT` and calls next method. First `bool` variable is `colored` option, by default it is `false`. If you want to log in to `Console` and you want some colored information you can set this argument to `true`. Second `bool` variable is `writeLogLevel` option. Simply if you want some text without `[DEFAULT|INFO|DEBUG|WARNING|ERROR]`, you can set this argument to `false`. Used in `Cpu.PrintStack(int = DEFAULT_STACK_PRINT_SIZE)`.

* `Logger.Write(string, LogLevel, bool = false, bool = true)`. If you don't want default `[DEFAULT]` `LogLevel`, you can set your own `LogLevel` in there. These `bool` variables is explained in `Logger.Write(string, bool = false, bool = true)` method.

* `Logger.Write(string, LogLevel, TextWriter, bool = false, bool = true`. If you don't want to log in `Console`, you can set your log method. For example you can set `StreamWriter` and you log in a file. These `bool` variables is explained in `Logger.Write(string, bool = false, bool = true)` method.

* `Logger.WriteLine(string, bool = false, bool = true)`. Writes text with `\n` at the end. Also same things at `Logger.Write(string, bool = false, bool = true)` methods.

* `Logger.WriteLine(string, LogLevel, bool = false, bool = true)`. Same things as `Logger.Write(string, LogLevel, bool = false, bool = true)`.

* `Logger.WriteLine(string, LogLevel, TextWriter, bool = false, bool = true)`. Same things as `Logger.Write(string, LogLevel, TextWriter, bool = false, bool = true)`
