# Developer Notes

## Build Tasks

If any of the following NuGet packages is updated the paths in the builds tasks (and scripts) need
to be adjusted:

- xunit.runner.console
- OpenCover
- ReportGenerator
- docfx.console

The paths also need to be checked if there is a change in the target-framework.

Updating the ``docfx.console`` will also try to overwrite some files in the documentation project.
These need to be reviewed if these are applicable.

## Builds

- Coverage: Executes the tests and generates a coverage report in ".coverage".
- Documentation: Generates the documentation in ".docs".
- Tests: Runs all tests.
- In any build a NuGet package for the library is build in either "src\bin\Release"
  (Release configuration) or "src\bin\Debug" (any other configuration).

## Projects

- Samples: Execute the project samples (can be done in either "Debug" or "Release" mode).
- Benchmarks: Execute the project benchmarks (should be done in "Release" mode).

## Solution folders: scripts, linqpad-samples

The solution folders should be kept in sync with the directory contents. In Visual Studio this is
easiest if the file is created in the "Folder View" and then added as "Existing Item" in the
"Solution View".

## Updating the documentation

The documentation is hosted using GitHub Pages on a separate branch `gh-pages`.
To update the shown documentation simply build the "Documentation" project and
then copy the content of the `.docs` folder to the `gh-pages` branch.
