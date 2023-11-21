using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

class Program
{
    static void Main(string[] args)
    {
        //string projectDirectory = args[0];
        var projectDirectory = "C:\\Users\\khj.LASERTRYK\\source\\repos\\csharpparser";
        var allFiles = Directory.GetFiles(projectDirectory, "*.cs", SearchOption.AllDirectories);

        var allClasses = new List<object>();

        foreach (var file in allFiles)
        {
            var code = File.ReadAllText(file);
            var syntaxTree = CSharpSyntaxTree.ParseText(code);

            var root = syntaxTree.GetRoot();
            var classNodes = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

            foreach (var classNode in classNodes)
            {
                var classDetails = new
                {
                    Class = new
                    {
                        Name = classNode.Identifier.ValueText,
                        Methods = ParseMethods(classNode),
                        Properties = ParseProperties(classNode)
                    }
                };
                allClasses.Add(classDetails);
            }
        }

        string json = JsonConvert.SerializeObject(allClasses, Formatting.Indented);
        SaveJsonToFile(json, projectDirectory);
    }

    static void SaveJsonToFile(string json, string directory)
    {
        string filePath = Path.Combine(directory, "project_structure.json");
        File.WriteAllText(filePath, json);
        Console.WriteLine($"JSON saved to {filePath}");
    }

    static List<object> ParseMethods(ClassDeclarationSyntax classNode)
    {
        var methods = new List<object>();
        foreach (var method in classNode.Members.OfType<MethodDeclarationSyntax>())
        {
            methods.Add(new
            {
                Name = method.Identifier.ValueText,
                ReturnType = method.ReturnType.ToString(),
                Parameters = ParseParameters(method),
                Body = method.Body?.ToString() ?? "null"
            });
        }
        return methods;
    }

    static List<object> ParseProperties(ClassDeclarationSyntax classNode)
    {
        var properties = new List<object>();
        foreach (var property in classNode.Members.OfType<PropertyDeclarationSyntax>())
        {
            properties.Add(new
            {
                Name = property.Identifier.ValueText,
                Type = property.Type.ToString()
            });
        }
        return properties;
    }

    static List<object> ParseParameters(MethodDeclarationSyntax method)
    {
        var parameters = new List<object>();
        foreach (var param in method.ParameterList.Parameters)
        {
            parameters.Add(new
            {
                Name = param.Identifier.ValueText,
                Type = param.Type.ToString()
            });
        }
        return parameters;
    }
}
