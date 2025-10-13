[[Thing]]s are very dependant on a depth-unlimited tree structure to exist in the hierarchy. However, JSON serialisation processes which Things are loaded from files with don't really like this, so we have to make an intermediary class that can be serialised nicely, which we can then turn into proper Things after the data is loaded. Fabricates play this role. They act as a list of Things, but each with identifiers and indexes to which other Things they possess as parents or children.

In order to use the serialisation processes dotnet provides us with, we'll need some subclasses as well.

## Attributes

| Attribute          | type                | purpose                                                                          |
| ------------------ | ------------------- | -------------------------------------------------------------------------------- |
| `fabricateThings`  | `FabricateThing[]`  | Stores all [[FabricateThing]]s to use in the generation/deconstruction process.  |
| `fabricateScripts` | `FabricateScript[]` | Stores all [[FabricateScript]]s to use in the generation/deconstruction process. |

## Methods

### Generation
#### `static Thing Load(string path, Thing parent = Engine.Root)`

This generates a Thing and its children from the fabricate stored at the given path, and adds it to the scene hierarchy unless a parent is deliberately unspecified.

### Deconstruction
#### `static void Save(string path)`

Goes through a Thing and its children's properties and deconstructs them to a JSON-based Frabicate file. By standard, these files should end in `.fabricate`