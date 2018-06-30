# Anagrammer 

A .Net Core 2.0 console application which given a text file containing one word per line, prints out all the combinations of words that are anagrams.

## Build the solution

```
dotnet build Anagrammer.sln
```

## Run then application

It accepts one and only one argument with the full path to the text file which contains the words.

To run the application you can execute:

```
cd Anagrammer\bin\Debug\netcoreapp2.0

dotnet anagrammer.dll file_path
```

## Run the tests

```
cd Anagrammer.Test
dotnet test Anagrammer.Test.csproj
```
