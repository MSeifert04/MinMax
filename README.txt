To use this:

- Copy everything to a new directory.
- Replace all occurrences of "ClassLibrary" with the new package name (name and contents of the files).

If any of the following NuGet packages is updated the paths in the builds tasks need to be adjusted:

- xunit.runner.console
- OpenCover
- ReportGenerator
- docfx.console

Builds:

- Coverage: Executes the tests and generates a coverage report in "tests\bin\Coverage\net472\Coverage\HTML".
- Documentation: Generates the documentation in "docs\_site".
- Tests: Runs all tests.
- In any build a NuGet package for the library is build in either "src\bin\Release" (Release configuration) or "src\bin\Debug" (any other configuration).

Runnable projects:

- Samples: Execute the project samples (can be done in either "Debug" or "Release" mode).
- Benchmarks: Execute the project benchmarks (should be done in "Release" mode).
