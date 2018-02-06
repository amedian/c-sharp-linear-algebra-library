# Linear algebra (C#)

Provides basic linear algebra solutions as a DLL.

### Target framework

DLL:   .NET Standard 2.0
Tests: .NET Framework 4.6.1

### Prerequisites

The project has no other library dependencies.

### Compiling as DLL using Visual Studio 2017

- Clone the repository to a directory.
- Start Microsoft Visual Studio 2017.
- Go to File > Open > Project/Solution > Select the cloned LinearAlgebra.sln file.
- Go to the Solution Explorer.
- Right click on LinearAlgebra solution > Build
- This should generate an AmedianLinearAlgebra.dll in your target directory.

### Use the generated DLL in your project

- Copy the generated AmedianLinearAlgebra.dll to your project directory.
- Start Microsoft Visual Studio 2017.
- Go to the Solution Explorer.
- Right click on Dependencies > Add reference > Browse > Select the DLL
- You are ready to use the library in your project.

## Running the tests

- Start Microsoft Visual Studio 2017.
- Open Test Explorer (View > Other Windows > Test).
- Go to the Solution Explorer.
- Select the LinearAlgebraTest solution.
- Press "Run all" in Test explorer.
- Tests should run and pass.

## Versioning

I use [SemVer](http://semver.org/) for versioning. For the versions available, see the [releases](https://github.com/amedian/c-sharp-linear-algebra/releases). 

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
