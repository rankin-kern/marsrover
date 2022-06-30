# Mars Rover Challenge
A C# implementation of https://code.google.com/archive/p/marsrovertechchallenge/

## Instructions to build and run
Open the marsrover.sln file in Visual Studio. From the build menu, select Build Solution. Then run either inside Visual Studio by pressing the Play button or selecting Start from the Debug menu, or find the marsrover executable in your build output directory and run it from there.

## Instructions to run unit tests
Unit tests are implemented using the NUnit framework. If NUnit is not installed, open Visual Studio and go to Tools -> NuGet Package Manager. Find and install the NUnit and NUnit.Console packages. After that, Debug -> Run Unit Tests should run the tests after the solution is built.

## Usage
Input is entered into the program using the command line, pressing enter after each line. Valid input is to first enter the size of the plateau as two numbers separated by a space (e.g. 5 5). Then rover locations (such as 1 1 E) and instructions (such as LLMRM) can be entered. When all rover locations and instructions have been entered, the user can press 'r' followed by enter to run the commands and see the updated rover positions.

## Assumptions
The challenge instructions don't specifically describe how to handle instructions that would either cause a rover to move off the plateau or collide with another rover. The assumption made in this implementation is that if a move instruction (move forward one space in the current direction) would collide with another rover or go beyond the edge of the plateau, the rover should remain in the same location and move on to the next instruction in the input, if there is one. 

## Final thoughts
For future iteration, if I had more time, I would like to further decouple the UI strings used in the interactive console from the logic (as in the commands that return strings currently). That way the underlying logic could be used for a different UI or input mechanism such as a form, REST APIs, etc.

For feature enhancements, I think it would be cool to add functionality to tell you if the given rover inputs have explored the entire plateau (or what percentage has been explored so far). A definition of 'explored' would have to be made - does a rover 'see' all squares in the current direction or does it have a maximum range? 
