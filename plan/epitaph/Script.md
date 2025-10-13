Scripts are classes with functions the engine calls at certain times. When you make gameplay code to attach to a [[Thing]], your class should inherit from Script so the [[Engine]] knows it can expect certain methods to exist when it runs your code.

## Attributes

| Attribute | Type   | Purpose                                                                      |
| --------- | ------ | ---------------------------------------------------------------------------- |
| `state`   | `bool` | Tells the [[Engine]] whether it should bother running this script.           |
| `begun`   | `bool` | Tells the [[Engine]] for an instance of this script if it's been run before. |
| `thing`   | Thing` | The [[Thing]] this script is attached to.                                    |

### Methods

#### `void Begin()`

Called by the [[Engine]] on any enabled instance of this script when it is ran for the first time. It's a good place to put setup logic for whatever you're making.

#### `void UpdateFrame(float timeDelta)`

Called by the [[Engine]] on enabled instances of this script whenever it performs an update cycle every frame. This is where you'll do most of your game's logic.

#### `void UpdateFrameLate(float timeDelta)`

Functionally similar to `UpdateFrame` except it's only called by the [[Engine]] after all the standard `UpdateFrame` calls have completed. Good for camera logic, or anything else where everything should be in the correct, updated place by the time it's run.

#### `void UpdateFixed(float fixedTimeDelta)`

Called by the [[Engine]] whenever a fixed update cycle is reached. This will be less than once per every frame and will try to be as close to a fixed frequency as possible (hence the name). Generally involved in [[Physics]] logic.

#### `void UpdateFixedLate(float fixedTimeDelta)`

Similar to `UpdateFixed` but it's called by the [[Engine]] on each fixed update cycle after all `UpdateFixed` calls have completed.