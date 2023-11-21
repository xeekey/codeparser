using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using HtmlAgilityPack;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string projectDirectory = "C:\\Users\\khj.LASERTRYK\\Desktop\\repos\\lasernew\\lasertrykwebsites";
        var allFiles = Directory.GetFiles(projectDirectory, "*.*", SearchOption.AllDirectories);

        var pages = new List<object>();

        foreach (var file in allFiles)
        {
            if (file.EndsWith(".aspx"))
            {
                var aspxData = ParseAspxFile(file);
                pages.Add(new { FilePath = file, Page = aspxData });
            }
            else if (file.EndsWith(".vb"))
            {
                var codeBehindData = ParseAspxVbFile(file);
                pages.Add(new { FilePath = file, CodeBehind = codeBehindData });
            }
        }

        string json = JsonConvert.SerializeObject(pages, Newtonsoft.Json.Formatting.Indented);
        SaveJsonToFile(json, projectDirectory);
    }

    static void SaveJsonToFile(string json, string directory)
    {
        string filePath = Path.Combine(directory, "project_structure.json");
        File.WriteAllText(filePath, json);
        Console.WriteLine($"JSON saved to {filePath}");
    }

    static object ParseAspxFile(string filePath)
    {
        var doc = new HtmlDocument();
        doc.Load(filePath);

        var controls = new List<object>();
        var serverControls = doc.DocumentNode.SelectNodes("//*[@runat='server']");

        if (serverControls != null)
        {
            foreach (var control in serverControls)
            {
                var controlType = control.Name;
                var id = control.GetAttributeValue("id", string.Empty);
                var eventHandlers = new Dictionary<string, string>();

                // Extracting event handlers (e.g., OnClick, OnTextChanged, etc.)
                foreach (var attribute in control.Attributes)
                {
                    if (attribute.Name.StartsWith("on", StringComparison.OrdinalIgnoreCase))
                    {
                        eventHandlers.Add(attribute.Name, attribute.Value);
                    }
                }

                controls.Add(new
                {
                    Type = controlType,
                    ID = id,
                    Events = eventHandlers
                });
            }
        }

        return new { Controls = controls };
    }

    static object ParseAspxVbFile(string filePath)
    {
        var code = File.ReadAllText(filePath);
        var syntaxTree = VisualBasicSyntaxTree.ParseText(code);

        var root = syntaxTree.GetRoot();
        var classNodes = root.DescendantNodes().OfType<ClassBlockSyntax>();

        var classes = new List<object>();
        foreach (var classNode in classNodes)
        {
            var className = classNode.ClassStatement.Identifier.ValueText;
            var methods = ParseMethods(classNode);
            var properties = ParseProperties(classNode);

            classes.Add(new
            {
                Name = className,
                Methods = methods,
                Properties = properties
            });
        }

        return new { Classes = classes };
    }

    static List<object> ParseMethods(ClassBlockSyntax classNode)
    {
        var methods = new List<object>();
        foreach (var method in classNode.Members.OfType<MethodBlockSyntax>())
        {
            var methodStatement = method.BlockStatement as MethodStatementSyntax;
            var methodName = methodStatement?.Identifier.ValueText;
            var returnType = methodStatement?.AsClause?.Type.ToString() ?? "Sub";

            var parameters = ParseParameters(method);

            methods.Add(new
            {
                Name = methodName,
                ReturnType = returnType,
                Parameters = parameters,
                Body = method.Statements.ToString() // Simplified representation of the method body
            });
        }
        return methods;
    }

    static List<object> ParseProperties(ClassBlockSyntax classNode)
    {
        var properties = new List<object>();
        foreach (var property in classNode.Members.OfType<PropertyBlockSyntax>())
        {
            var propertyName = property.PropertyStatement.Identifier.ValueText;
            var propertyType = property.PropertyStatement.AsClause?.Type().ToString() ?? "Property";

            properties.Add(new
            {
                Name = propertyName,
                Type = propertyType
            });
        }
        return properties;
    }

    static List<object> ParseParameters(MethodBlockSyntax method)
    {
        var parameters = new List<object>();

        var parameterList = (method.BlockStatement as MethodStatementSyntax)?.ParameterList;
        if (parameterList != null)
        {
            foreach (var param in parameterList.Parameters)
            {
                var paramName = param.Identifier.Identifier.ValueText;
                var paramType = param.AsClause?.Type?.ToString();

                parameters.Add(new
                {
                    Name = paramName,
                    Type = paramType
                });
            }
        }

        return parameters;
    }
}
