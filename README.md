# Linear algebra (C#)

Provides basic linear algebra solutions. Currently implements a 2D float matrix with basic operations.

## Examples

Operations with scalars (+, -, *)
```c#
Matrix m = new Matrix(new float[,] {{4, -5, 2.5}, {-2, 3.5, 6}});

Console.WriteLine(m * 2); // Console.WriteLine(2 * m);

Output:
[8 -10 5]
[-4 7 12]
```

Transpose matrix
```c#
Matrix m = new Matrix(new float[,] {{4, -5, 2.5}, {-2, 3.5, 6}});

Console.WriteLine(~m);

Output:
[4 -2]
[-5 3.5]
[2.5 6]
```

Multiplying with matricies
```c#
Matrix m = new Matrix(new float[,] {{4, -5}, {-2, 3.5}});
Matrix m2 = new Matrix(new float[,] {{-2, -7, -3}, {2.5, 5, 4}});

Console.WriteLine(m * m2);

Output:
[-20.5 -53 -32]
[12.75 31.5 20]
```

Multiplying with matricies (elementwise - non-standard multiplying)
```c#
Matrix m = new Matrix(new float[,] {{1, 2}, {3, 4}});
Matrix m2 = new Matrix(new float[,] {{10, 20}, {30, 40}});

Console.WriteLine(m.ElementwiseMultiply(m2));

Output:
[10 40]
[90 160]
```

Addition, subtraction
```c#
Matrix m = new Matrix(new float[,] {{4, -5, 2.5}, {-2, 3.5, 6}});
Matrix m2 = new Matrix(new float[,] {{-2, -7, -3}, {2.5, 5, 4}});

Console.WriteLine(m + m2);
Console.WriteLine();
Console.WriteLine(m - m2);

Output:
[2 -1.5 8.5]
[0.5 -2 1]

[6 -8.5 -3.5]
[-4.5 -12 -7]
```

Conditions (uses Double.Epsilon)
```c#
Matrix m = new Matrix(new float[,] {{4, -5, 2.5}, {-2, 3.5, 6}});
Matrix m2 = new Matrix(new float[,] {{8, -10, 5}, {-4, 7, 12}});

Console.WriteLine(m == m2);
Console.WriteLine();
Console.WriteLine(m2 == m * 2);

Output:
false

true
```

Applying custom functions on each matrix element
```c#
class CustomMatrixFunction : IMatrixFunction
{
	public float Calculate(int rowIndex, int columnIndex, float element)
	{
		return element * 2 + 1;
	}
}

Matrix m = new Matrix(new float[,] {{4, -5, 2.5}, {-2, 3.5, 6}});
IMatrixFunction f = new CustomMatrixFunction();

Console.WriteLine(m * f);

Output:
[9 -9 6]
[-3 8 13]
```

## Specification

| Project | Target framework | Prerequisites |
| --- | --- | --- |
| LinearAlgebra | .NET Standard 2.0 | No dependency |
| LinearAlgebraTest | .NET Framework 4.6.1 | MSTest.TestAdapter.1.1.18, MSTest.TestFramework.1.1.18 |


### Compiling to DLL using Visual Studio 2017

- Clone the repository to a directory.
- Start Microsoft Visual Studio 2017.
- Go to File > Open > Project/Solution > Select the cloned LinearAlgebra.sln file.
- Go to the Solution Explorer.
- Right click on LinearAlgebra solution > Build
- This should generate an AmedianLinearAlgebra.dll in your target directory.

Alternativly

- Clone the repository to a directory.
- Go to this directory.
```
dotnet build LinearAlgebra
```

### Use the generated DLL in your project

- Copy the generated AmedianLinearAlgebra.dll to your project directory.
- Start Microsoft Visual Studio 2017.
- Go to the Solution Explorer.
- Right click on Dependencies > Add reference > Browse > Select the DLL
- You are ready to use the library in your project.

### Running the tests

- Start Microsoft Visual Studio 2017.
- Open Test Explorer (View > Other Windows > Test).
- Go to the Solution Explorer.
- Select the LinearAlgebraTest solution.
- Press "Run all" in Test explorer.
- Tests should run and pass.

Alternativly

- Clone the repository to a directory.
- Go to this directory.
```
dotnet test LinearAlgebraTest
```

Note: NuGet dependency packages have to be restored in this case

## Versioning

I use [SemVer](http://semver.org/) for versioning. For the versions available, see the [releases](https://github.com/amedian/c-sharp-linear-algebra/releases). 
- patch: small modification which does not change any public/protected method's signature and business contract
- minor: a modification which does not change any public method's signature and business contract
- major: be prepared to any kind of change :)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
