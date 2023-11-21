Documentation for CodeParser
Overview
CodeParser is a tool designed for parsing C# and VB.NET projects. It analyzes source code files and extracts structured information about classes, methods, properties, and more, saving the output in JSON format.

Components
C# Parser (csharpparser):

Program.cs
Parses .cs files in a given directory.
Extracts details about classes, methods, and properties.
Outputs a project_structure.json file with the parsed data.
VB.NET Parser (vbparser):

Program.cs
Parses .aspx and .vb files.
Extracts information about ASPX pages and code-behind classes.
Outputs a project_structure.json file with the parsed data.
Usage
C# Parser:

Set the projectDirectory variable to the path of your C# project.
Run the parser to generate the JSON file with project structure details.
VB.NET Parser:

Set the projectDirectory variable to the path of your VB.NET project.
Run the parser to generate the JSON file with ASPX and VB file details.
Output Format
The output JSON file (project_structure.json) contains structured data about the source code, including class names, method signatures, property details, and more.

Contributing
Contributions to CodeParser are welcome. Please follow the standard GitHub pull request process to submit your changes.
