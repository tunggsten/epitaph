Things are the fundamental building blocks of stuff in Epitaph. They're a class which acts as an abstract point in space in the scene which you can expand upon by combining them and attaching scripts.

## Attributes

| Attribute        | Type                        | Purpose                                                                                                     |
| ---------------- | --------------------------- | ----------------------------------------------------------------------------------------------------------- |
| `name`           | `string`                    | Acts as an identifier or title for this Thing.                                                              |
| `transformation` | `Matrix4`                   | Represents the thing's position, orientation and skew in objective space.                                   |
| `parent`         | `Thing`                     | Reference to the Thing's parent, which it acts relative to.                                                 |
| `children`       | `List<Thing>`               | List of references to all Things that are children of this Thing.                                           |
| `tags`           | `List<string>`              | List of strings attached to the Thing which the user can use for their gameplay logic.                      |
| `scripts`        | `List<Script>`^[[[Script]]] | List of [[Script]]s which should be ran when appropriate (on every frame/physics update/instantiation etc). |
| `state`          | `bool`                      | Tells the engine if it should acknowledge this Thing and its childrens' existence.                          |

## Methods
### Transformation tools

#### `void Translate(Vector3 translation, Space space = Space.Objective)`

Translates the Thing along the given translation using `space`^[[[Space]]]'s relativity.

#### `void Transform(Matrix4 transformation, Space space = Space.Objective)`

Applies the given transformation to the Thing's transformation using `space`^[[[Space]]]'s relativity.

#### `void Scale(Vector3 scale, Space space = Space.Objective)`

Applies the given scale to the Thing's transformation using `space`^[[[Space]]]'s relativity.

#### `void Rotate(Vector3 euler, Space space = Space.Objective)`

Rotates the Thing and all of its children around each x, y and z axis by each respective angle in radians.

### Hierarchy functions

#### `void AddChild(Thing child)`

Transfers parentship of `child` to this Thing. To do this, it removes `child` from its parent's `children` attribute, reassigns `child`'s parent to this Thing, and adds `child` to this Thing's `children` attribute.

#### `void SetParent(Thing parent)`

Transfers parentship of this Thing to `parent`. It works by calling `parent.AddChild(this)`.

### Name functions

#### `Thing GetChildWithName(string name)`

Returns the first child with the name `name`.

#### `List<Thing> GetChildrenWithName(string name)`

Returns all direct children of this Thing with the name `name`.

#### `Thing GetDescendantWithName(string name)`

Returns the first descendant of this Thing with the name `name`.

#### `List<Thing> GetDescendantsWithName(string name)`

Returns all descendants of this Thing with the name `name`.

### Tag functions

#### `Thing GetChildWithTag(string tag)`

Returns the first child that has the tag `tag`.

#### `List<Thing> GetChildrenWithTag(string tag)`

Returns all direct children of this Thing with the tag `tag`.

#### `Thing GetDescendantWithTag(string tag)`

Returns the first descendant of this Thing with the tag `tag`.

#### `List<Thing> GetDescendantsWithTag(string tag)`

Returns all descendants of this Thing which possess the tag `tag`.

### Scripting Functions

#### `UpdateFrame(float frameDelta)`

Calls [[Script#`void UpdateFrame(float timeDelta)`]] on all active [[Script]]s attached to this Thing, and then it calls `UpdateFrame` on all of this Thing's active children.

#### `UpdateFixed(float fixedFrameDelta)`

Calls [[Script#`void UpdateFixed(float fixedTimeDelta)`]] on all active [[Script]]s attatched to this Thing, and then it calls `UpdateFrame` on all of this Thing's active children.

#### UpdateFrameLate(float frameDelta)`
Calls [[Script#`void UpdateFrameLate(float timeDelta)`]] on all active [[Script]]s attatched to this Thing, and then it calls `UpdateFrame` on all of this Thing's active children.

#### `UpdateFixedLate(float fixedFrameDelta)`
Calls [[Script#`void UpdateFixedLate(float fixedTimeDelta)`]] on all active [[Script]]s attatched to this Thing, and then it calls `UpdateFrame` on all of this Thing's active children.

### State functionality

#### `SetState(bool state)`
Assigns the current state of this Thing. If `true`, this Thing will be acknowledged by the [[Engine]] in its hierarchy traversals, except for when children are translated to keep them in a fixed transform relative to their parent. Otherwise, it will be excluded.