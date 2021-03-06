# VB (`Language.Vb`)

**Visual Basic** has been implemented with the VB [CodeDom](https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/using-the-codedom).

[Implementation](https://github.com/mrousavy/Fiddle/tree/master/Fiddle.Compilers/Implementation/VB) / [Compiler](https://github.com/mrousavy/Fiddle/blob/master/Fiddle.Compilers/Implementation/VB/VbCompiler.cs)

## Completeness

- [x] Syntax highlighting
- [x] Compilation
- [x] Execution
- [x] Console ouput
- [x] Return values
- [x] Diagnostics
- [x] Errors

Keep in mind that every VB fiddle code has to be written like the following:

```vb
Public Module [MName]
    Public [Function or Sub]
	    ' ...
    End [Function or Sub]
End Module
```

Where `[MName]` is any Module name (eg: `Main`), and `[Function or Sub]` can be either a returning function ([`Function`](https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/procedures/function-procedures)) or a void function ([`Sub`](https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/procedures/sub-procedures)). The **first found method will be the entry point.**

[Example code](https://github.com/mrousavy/Fiddle/blob/master/Fiddle.Compilers/Implementation/VB/VbDemo.vb) | [Projects](https://github.com/mrousavy/Fiddle/projects)

## Globals
You can use the following **Globals/Variables** inside your code:

* `Random` (**object**, .NET `System.Random`, [msdn](https://msdn.microsoft.com/en-us/library/system.random(v=vs.110).aspx)): **Create random numbers** with [`Random.Next(..)`](https://msdn.microsoft.com/en-us/library/system.random.next(v=vs.110).aspx)

* `Console` (**object**, .NET `System.IO.StringWriter`, [msdn](https://msdn.microsoft.com/en-us/library/system.io.stringwriter(v=vs.110).aspx)): **Write to Console** with [`Console.WriteLine(string)`](https://msdn.microsoft.com/en-us/library/system.console.writeline(v=vs.110).aspx) or [`Console.Write(string)`](https://msdn.microsoft.com/en-us/library/system.console.write(v=vs.110).aspx)

* `CurrentThread` (**object**, .NET `System.Threading.Thread`, [msdn](https://msdn.microsoft.com/en-us/library/system.threading.thread(v=vs.110).aspx)): The thread this got initialized on (**mostly UI Thread**), can be used to access all properties or functions from a [`System.Threading.Thread`](https://msdn.microsoft.com/en-us/library/system.threading.thread(v=vs.110).aspx).

* `Editor` (**object**, Fiddle `Fiddle.UI.Editor` (from `System.Windows.Window`, [msdn](https://msdn.microsoft.com/en-us/library/system.windows.window(v=vs.110).aspx))): Fiddle's Editor window, can be used to access all [`UIElements`](https://msdn.microsoft.com/en-us/library/system.windows.uielement(v=vs.110).aspx), properties, public functions or functions derived from `System.Windows.Window`. ([Editor XAML code](https://github.com/mrousavy/Fiddle/blob/master/Fiddle.UI/Editor.xaml), [Editor source code](https://github.com/mrousavy/Fiddle/blob/master/Fiddle.UI/Editor.xaml.cs))

* `App` (**object**, .NET `System.Windows.Application`, [msdn](https://msdn.microsoft.com/en-us/library/system.windows.application(v=vs.110).aspx)): Fiddle's calling `Application`/`App`, can be used to access all properties or functions derived from [`System.Windows.Application`](https://msdn.microsoft.com/en-us/library/system.windows.application(v=vs.110).aspx))

* `RunUi(Action)` (**function**, `void Invoke(Action)`, [declaration](https://github.com/mrousavy/Fiddle/blob/master/Fiddle.UI/FiddleGlobals.cs#L42)): A function with an anonymous function or [`Action`](https://msdn.microsoft.com/en-us/library/018hxwa8(v=vs.110).aspx) as a parameter **to execute code on the UI Thread**. This is **required for getting/setting properties or calling functions from `Editor` or `App`** because those are **not thread safe**. Example:

```cs
RunUi(Sub() Editor.Hide());
```

## Properties
- `string[] imports`: A list of assemblies to be referenced and imported by the script
