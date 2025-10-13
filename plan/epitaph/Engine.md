Engine is the class that handles the entire game. You probably shouldn't modify this unless you have a good or entertaining reason to.

## Gist

What the Engine actually does is multifaceted, but for now, it:

- keeps track of the scene hierarchy
- records how long it took to process the previous frame
- executes engine functions in scripts when appropriate
- 

## Attributes

| Attribute              | Type                 | Purpose                                                                                                                                                                                                 |
| ---------------------- | -------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `root`^[[[Root]]]      | `Thing` ^[[[Thing]]] | The top of the scene hierarchy. You should probably not modify this.                                                                                                                                    |
| `timeDelta`            | `float`              | The time it took to process the previous frame.                                                                                                                                                         |
| `fixedTimeDelta`       | `float`              | The time passed since the last fixed update cycle.^[This is not a constant value! The fixed update cycle tries to meet the specified frequency as best it can, but there will always be discrepancies.] |
| `fixedUpdateFrequency` | `float`              | This is the number of fixed update cycles the engine aims to perform per second.                                                                                                                        |

