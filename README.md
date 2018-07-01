# Anagrammer 

A .Net Core 2.0 console application which given a text file containing one word per line, prints out all the combinations of words that are anagrams. The result could be ordered by word length or by number of words.

To know if two words are anagrams I only have to sort their chars and then compare if their ordered chars match. I use a dictionary, whose keys are the sorted chars and whose values are the words which are anagrams among. To show the result I only have to retrieve the anagrams from the dictionary.

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
