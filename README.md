# Toy Robot Challenge

My solution to the Toy Robot Challenge using C#.

## Toy Robot Challenge Ground Rules

See: [What is the Toy Robot Challenge](./Documentation/WhatIsToyRobot.md)

### Variation Choices

#### Taking Input

As the challenge invites the developer to use either a file or STDIN, I've elected to follow the UNIX convention, and run via STDIN. Input files may be fed in using the `<` operator in most standard shells, including Windows Powershell.

I have chosen to allow only one command per line, simply to make the task of delimiting commands more simple. With extra time, I may choose to implement a more flexible command delimitation system.

The user may specify certain parameters in the command line arguments with the following conventions:

`--size x y` controls the initial size of the board. Defaults to 5 x 5 if not set.

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

> Visual Studio Publish as Folder Application instructions

## Running the Application

This Application can be run in the development environment from Visual Studio, or from the self-contained executable created in the section: Building the Executable

### Running from Visual Studio

> Running from Visual Studio Instructions

### Running from Command Line

> Running from Command Line instructions

## Unit Tests

Unit Testing has been created using the NUnit Test Framework.
These can be run in Visual Studio. The NUnit Test Adaptor extension for Visual Studio is recommended.