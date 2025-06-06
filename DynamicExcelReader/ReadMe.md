# Dynamic Excel Reader
By Zube Pierre Basali

## Introduction
This is a simple console app to read data dynamically on an unique excel sheet.

## How does it works
The app read the first rows as headers and store them.<p>
Then the other subsequent filled rows are read and store to a Key-Value Pair Dictionnary with the headers<br>
- (header = Key, rowValue = Value ).<p>

An sqlite database is then created and store the key-value pairs as Json strings.<br>
Then the data is retrieved from the database, put into a table, and displayed to the user.

## How to use it
Three data samples are given in this folder.<p>
To change wich data must be read, change the value under the comments in the Controller.cs file, in the GetFilePath() function.<p>
No inputs are needed, the app just asks to press enter before printing the results and before leaving.

## Thought and Remarks
- This is a simple solution for basics Excel sheets.
- Other methods were tried to achieve this, mainily trying to create a type dynamically on runtime,
	But a few problems prevent this solution to work with my knowledge:
    - The type creation is possible but it couldn't be read by EntityFramework.
	- The type is usable for other purpose but it's not practical and efficient to use<br>
	both at coding time and at runtime.
	- Two methods were tried to create the type properties:
    	- Create each property in a type creator
		- Put them in a json and try to create them from the json

## Resources
- Excel Sample Data for Practice or Training Example: [Link](https://www.contextures.com/xlsampledata01.html)
- Excel Reader in C#: [Link](https://github.com/ZubePB/ExcelReader)