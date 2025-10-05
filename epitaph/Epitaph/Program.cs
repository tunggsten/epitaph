using System.ComponentModel.Design.Serialization;
using Epitaph;


new Thing(name: "Root", root: true);

Thing testThing = new Thing(name: "hello");
Thing testThing2 = new Thing(name: "goodbye", parent: testThing);
Thing testThing3 = new Thing(name: "im pegging that man at the back of the bus", parent: testThing);

foreach (Thing child in testThing.children)
{
    Console.WriteLine($"thing's child is called {child.name}");
}

foreach (Thing child in Engine.root.GetSubthings())
{
    Console.WriteLine(child.name);
}