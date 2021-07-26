# Unity Ducks
Comparison Unity projects for [my tests of Godot's performance](https://github.com/Fourjays/godot_ducks). The test is aimed at testing Unity's capabilities with large numbers of moving entities for my own needs, and shouldn't be used as a reliable benchmark of performance for all situations.

Each example spawns a number of Duck sprites at the start on a 2D tilemap with collision. Each entity will move once per second, checking for collisions before it moves.

The two methods of instancing entities used here are:
- **Instanced**: Each `Duck` scene is responsible for its own movement and collision checks.
- **Managed**: The `DuckManager` is responsible for each `Duck` scene's movement and collision checks.

The number of ducks spawned can be controlled through the `DuckManager` properties in the inspector panel.

## Results
| Ducks Spawned       | 2500 | 5000 | 7500 | 10000 | 20000 | 30000 | 40000 | 50000 | 60000 | 80000 | 120000 |
|---------------------|------|------|------|-------|-------|-------|-------|-------|-------|-------|--------|
| Instanced FPS       | 420  | 300  | 230  | 200   | 110   | 80    | 60    | 50    | 40    | 30    | 15     |
| Managed FPS         | 570  | 480  | 400  | 360   | 270   | 220   | 190   | 160   | 140   | 80    | 40     |

*Test System: AMD Ryzen 2600x, 16GB RAM, GTX1070*

All results are from editor play. Exported builds would likely be faster still. Unity is impacted more by the number of entities within the camera bounds than Godot, with performance often improving significantly when entities move outside of the camera bounds.


## Credits
- Sprites and fonts by [Kenney.nl](https://kenney.nl/), licensed under [Creative Commons Zero (CC0)](http://creativecommons.org/publicdomain/zero/1.0/).
