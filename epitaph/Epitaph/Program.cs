using System.ComponentModel.Design.Serialization;
using Epitaph;


new Stract(name: "Root", root: true);

Console.WriteLine(Engine.root);

Stract testStract = new Stract(name: "hello");

foreach (Stract child in Engine.root.GetChildren())
{
    Console.WriteLine(child.name);
}