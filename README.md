# CSharpCodingChallenge
This is a solution of a C Sharp Coding Challenge

<!-- TABLE OF CONTENTS -->
### Table of Contents
  <ol>
    <li>
      <a href="#the-challenge">The Challenge</a>
      <ul>
        <li><a href="#prompt">Prompt</a></li>
        <li><a href="#examples">Examples</a></li>
      </ul>
    </li>
    <li>
      <a href="#solution">Solution</a>
      <ul>
        <li><a href="#assumptions">Assumptions</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li>
            <a href="#prerequisite">Prerequisite</a>
        </li>
        <li>
            <a href="#installation">Installation</a>
            <ul>
                <li>
                    <a href="#with-visual-studio">With visual Studio</a>
                </li>
                <li>
                    <a href="#with-cli">With CLI</a>
                </li>
            </ul>
        </li>
      </ul>
    </li>
  </ol>



# The Challenge
Here is an old phone keypad with alphabetical letters, a backspace
key, and a send button.

Each button has a number to identify it and pressing a button multiple times will cycle through the letters on it allowing each button to represent more than one letter.

For example, pressing 2 once will return ‘A’ but pressing twice in
succession will return ‘B’.

You must pause for a second in order to type two characters from the same button after
each other: “222 2 22” -> “CAB”.

## Prompt
Please design and document a class of method that will turn any input to OldPhonePad 
into the correct output.

Assume that a send “#” will always be included at the end of every input.

The method belwo is needed to be completed
```cs
public static String OldPhonePad( string input) {
// Please write your implementation here!
}
```



## Examples
OldPhonePad(“33#”) => output: E

OldPhonePad(“227*#”) => output: B

OldPhonePad(“4433555 555666#”) => output: HELLO

OldPhonePad(“8 88777444666*664#” ) => output: ?????


# Solution
Some assumptions were made, 

## Assumptions
- A space(“ “) on the given string means a 1-second pause.

- Returned letters are always Uppercase letters.

- From the sign of button 0, It is assumed that it returns a space (“ “), and if it is pressed multiple times consecutively(without any 1-second pause), all will result in only one single space.

- If there are multiple '#' Characters, then they are ignored(except the last one)

- If there are input Characters other than digits, ‘*’, and ‘#’, they are simply ignored.


# Getting Started

## Prerequisite
- .NET 9 is needed to be installed in the target machine
- (Optional) Visual Studio 17 or other IDE/Editor that can run C# code


## Installation
Download/Clone the repository. 

There are two projects,  

1. CSharpCodingChallenge: It is the main project(.NET CLI Project). This contains a class "OldPhoneKeyPad" where the method **"OldPhonePad"** is implemented.
2. CSharpCodingChallenge.Tests: It is the test project(.NET xUnit Project). It contains a **OldPhonePadTests** where the test codes are written.

### With Visual Studio
Open the .sln file and Run the CSharpCodingChallenge project. It will start a CLI and ask for input. 

Give the input string and it will calculate and print the output in the CLI. 


For **tests**, do "Run Tests" by right clicking the project  CSharpCodingChallenge.Tests which will run all the tests. 


### With CLI

Open the console on the directory where the .sln file exists.

For the main project run the following command. 

```console
dotnet build
dotnet run --project=CSharpCodingChallenge\CSharpCodingChallenge.csproj
```

For **tests** run the following command

```console
dotnet test
```