# Toy Robot Challenge

My solution to the Toy Robot Challenge using C#.

## Toy Robot Challenge Ground Rules

See: [What is the Toy Robot Challenge](./Documentation/WhatIsToyRobot.md)

### Variation Choices

#### Taking Input

As the challenge invites the developer to use either a file or STDIN, I've elected to follow the UNIX convention, and run via STDIN. Input files may be fed in using the `<` operator in most standard shells, including Windows Powershell.

I have chosen to allow only one command per line, simply to make the task of delimiting commands more simple. With extra time, I may choose to implement a more flexible command delimitation system or perhaps a grammar tree for parsing a list of commands that isn't so clearly delimited.

Argument delimiters may take the form of both `',' and ', '`. IE: `PLACE 3,4, WEST` is a valid command.

The user may specify certain parameters in the command line arguments with the following conventions:

`--bounds xUpper yUpper [xLower yLower]` controls the initial dimensions of the board. Defaults to (0,0) -> (5,5) if not set. `xLower` and `yLower` are optional, but must be provided together. It is not required that Upper > Lower.

`--nocase` indicates that commands can ignore the initial uppercase requirement of the challenge.

#### Helper Commands

I've elected to add a `PRINT` command to the list of valid inputs, which will not control the robot, but output the following text.
The command should be followed by an enquoted string, ie in the form:

```
PRINT "Expected Output: 2,3,EAST"
```

This should allow test inputs to be validated by eye without opening the test data.

## Development Environment

This implementation of the Toy Robot Challenge was created in [Visual Studio 2019 Community Edition](), using C# 8 running on Dotnet Core 3.1.
Dotnet Core 3.1 is the latest long-term support version of Dotnet (as of February 2021.)

Download the [Dotnet Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet/3.1) to run this application in the development environment.

## Building the Executable

This application can be built as a self-contained dotnet console application.

1. Open the `ToyRobotChallenge.sln` file in Visual Studio 2019

2. Right Click on "ToyRobotChallenge.csproj" in the Solution Explorer and select "Publish"

   <img src="Documentation\ReadmeImages\SelectPublish.PNG" alt="SelectPublish" style="zoom:100%;" />

3. Ensure "Self-Contained x86 Profile" is selected. This will allow compatibility with the majority of non-M1-Mac devices. Hit "Edit" to change the Target Location if desired.

   <img src="Documentation\ReadmeImages\x86Publish.PNG" alt="x86Publish" style="zoom:80%;" />

   1. Change the value of "Target Runtime" to your machine's CPU Architecture if applicable. You may click the `...` button (see below in red) to change the output location.

      <img src="Documentation\ReadmeImages\EditTarget.PNG" alt="EditTarget" style="zoom:80%;" />

   2. Click `Save` to save changes.

4. Click `Publish` to publish the application as an executable.


## Running the Application

This Application can be run in the development environment from Visual Studio, or from the self-contained executable created in the section: Building the Executable

### Running from Visual Studio

1. Open the `ToyRobotChallenge.sln` file in Visual Studio.

2. Look to the top of the window and ensure `ToyRobotChallenge` is selected in the project runner.

   <img src="Documentation\ReadmeImages\ChooseProject.PNG" alt="ChooseProject" style="zoom:100%;" />

3. Choose either Debug or Release mode for the development project runner.

   <img src="Documentation\ReadmeImages\DebugReleaseMode.PNG" alt="DebugReleaseMode" style="zoom:100%;" />

   - Debug mode will output the parsed command before a command is executed, and the state of the robot after the command is executed.

   - Release Mode will only output the robot state when `REPORT` is issued.

4. Hit `|> ToyRobotChallenge` to run the project in interactive mode in a separate terminal window. Commands can be issued individually from the keyboard.

   <img src="Documentation\ReadmeImages\HitPlay.PNG" alt="HitPlay" style="zoom:100%;" />

#### Changing Visual Studio Command Line Variables

The runtime commandline arguments for Visual Studio can be altered, allowing the board bounds or case sensitivity mode to be changed.

1. Click the little arrow next to  `|> ToyRobotChallenge`  in the project runner and hit "ToyRobotChallenge Debug Properties".

   <img src="Documentation\ReadmeImages\DebugProperties.PNG" alt="DebugProperties" style="zoom:100%;" />

2. Under "Application Arguments", insert the arguments you wish to run the program with. This simulates a real command line, so each argument should be separated by a space. In this example, "nocase" mode has been specified.

   <img src="Documentation\ReadmeImages\InsertArgs.PNG" alt="InsertArgs" style="zoom:80%;" />

3. Hit `ctrl + S` to save.

Running the application via the project runner will now set this argument by default. You need to re-alter this window to change this behaviour.

### Running from Command Line

The application can also be run from the Command Line. Note that for these examples, the working directory is set to the root of the `ToyRobotChallenge` repo, and the application has been built in `ToyRobotChallenge\builds`.

**Note** I am using Powershell on Windows. The directory delimiter will be `/` instead of `\` on a linux machine.

1. Enter the path to your built application directory in the command line and hit enter, example:

   ```powershell
   .\ToyRobotChallenge\builds\ToyRobotChallenge.exe
   ```

   <img src="Documentation\ReadmeImages\PowershellStandardDirections.PNG" alt="PowershellStandardDirections" style="zoom:75%;" />

2. Operate the program interactively by inputting commands.

   <img src="Documentation\ReadmeImages\WorkingExample.PNG" alt="WorkingExample" style="zoom:80%;" />

3. Hit `CTRL + C` (on windows) to exit.

#### Setting Parameters

Parameters can be set by simply adding command line arguments to the end of the execution path. Examples:

```powershell
.\ToyRobotChallenge\builds\ToyRobotChallenge.exe --nocase
```

```powershell
.\ToyRobotChallenge\builds\ToyRobotChallenge.exe --bounds 10 15
```
```powershell
.\ToyRobotChallenge\builds\ToyRobotChallenge.exe --bounds 10 15 0 0 --nocase
```

#### Inserting Test Data Files

Files can be read into the program by using the `<` operator. 

**Note** that in some versions of powershell, simply using the `<` operator will result in an error like "This operator has been reserved for future use". This can be overcome by wrapping the command in the following syntax:

```powershell
cmd /c '<Initial Command>'
```

<img src="Documentation\ReadmeImages\InsertingData.PNG" alt="InsertingData" style="zoom:80%;" />

This is not a limitation when using Windows Command Prompt or any Linux Shell.

**NOTE ** that this method of input will not write the commands to the screen.

#### Test Data files with custom parameters

To run in command line mode with custom parameters, the input redirect `<` needs to be placed after the command.

Examples:

```powershell
.\ToyRobotChallenge\builds\ToyRobotChallenge.exe --bounds 10 15 0 0 --nocase < TestData.txt
```

Or in powershell:

```powershell
cmd /c ''.\ToyRobotChallenge\builds\ToyRobotChallenge.exe --bounds 10 15 0 0 --nocase < TestData.txt'
```

## Unit Tests

Unit Testing has been created using the NUnit Test Framework.
These can be run in Visual Studio. The NUnit Test Adaptor extension for Visual Studio is recommended.

1. Open the  `ToyRobotChallenge.sln` file in Visual Studio.

2. Open the `Test Explorer` window. You can search for this in the top search bar if it isn't visible.

3. Hit the "Run All" button to run all unit tests.

   <img src="Documentation\ReadmeImages\RunAllTests.PNG" alt="RunAllTests" style="zoom:100%;" />