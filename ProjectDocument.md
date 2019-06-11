# Game Basic Information #

## Summary ##

You try to escape your past self. A time of addiction and regret.
Yet the shadow of your past continues to pursue you, in hopes of being able to finally take over, once and for all. Blessed with multiple lives, but a finite amount of time, you have to maneuver through creatures of the dark, avoid pitfalls, and resist the temptation of reverting back to your previous self. 

## Gameplay explanation ##

**In this section, explain how the game should be played. Treat this like a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**




# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based off the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your own relevant information. Liberally use the template when necessary and appropriate.

## User Interface

**Main Menu:**
I created the main menu scene for our game. It's main components are the "Play" and "Credits" buttons that lead to the appropriate scenes, the title, and an auto scrolling camera that pans the background image. I made use of TextMeshPro from the asset store which allowed me to further customize the text (cool font and gradient options). The buttons have a subtle highlight when the cursor moves over it and reverses the text as well. The [auto scrolling camera](https://github.com/kyle-andrus/RIP/blob/8e5a8976b6a033d1d859e65cc8830f5375600c47/Assets/Scripts/menuScripts/cameraScroll.cs#L1) eventually stops when the end of the background image is reached. I used Brackeys' awesome [tutorial](https://www.youtube.com/watch?v=zc8ac_qUXQY&t=1s) as a reference when designing this scene.   


**Cutscene:**
Created the structure for what a cutscene would look like. The player and enemy moved into the scene and spoke through textbubbles. The text had a "typewriter" effect to it which was based off of [this video](https://www.youtube.com/watch?time_continue=201&v=1qbjmb_1hV4). Andrew and I worked closely together on this part of the game since narrative had a big factor in this area. 

_**Gameplay (Death, Score, Timer, Pickup)**_: 
A lot of this was learning through trial and error. I was able to grasp a bit of how the canvas system worked through the Pirate project, but what really gave me the most knowledge on the UI interface was just through a lot of mistakes. Some challenging parts of this were differentiating between UI objects and regular ones, positioning these items correctly, and being able to bring it together to create something intuitive and aesthetically pleasing. Most of the HUD elements can be seen in the [gamePlayController](https://github.com/kyle-andrus/RIP/blob/11adb4d1ab86b13b8fd79ccb757365a40eaba350/Assets/Scripts/GamePlayScripts/GamePlayController.cs#L1) script. We wanted the HUD to be visible and clear for the players, so placing all of these components at the very top of the screen was the first thing I thought of. Also, I wanted to match the "pixely" theme we had going on throughout the game, so all of the fonts and images I used also had to abide by these rules. The gameplay scene was where I was really able to strengthen my Unity knowledge; I was able to see how all the scripts and objects worked together. Being able to pull necessary components from each one and using them accordingly, I not only gained more expertise in UI, but also in every other role as well. 

**Death:**
Whenever the player dies, the death counter goes up by one. The code for the death counter is take the number of deaths the player currently has, and then change the text component of the text object to match what has happened. This can be seen through this portion of the [script](https://github.com/kyle-andrus/RIP/blob/11adb4d1ab86b13b8fd79ccb757365a40eaba350/Assets/Scripts/GamePlayScripts/GamePlayController.cs#L77). Next to the death counter, there's a cute little animated skull that gives the "it's okay if you die" vibe to the players. From this, I briefly touched over some of the animation and game feel aspects that was taught in this class. 

**Score and Timer:**
The score of the player continously decreases relative to the time. When the player dies, both the score and time stops ticking down. Both of these are implemented using Time.deltatime, decreasing by one every second only when the player is in a "playing" state. The script for both of these is found in the [gamePlayController](https://github.com/kyle-andrus/RIP/blob/11adb4d1ab86b13b8fd79ccb757365a40eaba350/Assets/Scripts/GamePlayScripts/GamePlayController.cs#L76). Every time the player dies, the score decreases by 100 each time. Once the time hits 0, the game transitions to the "Time Up" game over scene. 

**Pickup:**
Whenever the player picks up an alcohol bottle or cigarette, the small text appears on the screen displaying "+1 (whatever item)". This was done in various parts of the playerController script, which can be seen [here](https://github.com/kyle-andrus/RIP/blob/ae2939d2a30147a5f2da685627e13917108c6a3f/Assets/Scripts/GamePlayScripts/PlayerScripts/PlayerController.cs#L49), [here](https://github.com/kyle-andrus/RIP/blob/ae2939d2a30147a5f2da685627e13917108c6a3f/Assets/Scripts/GamePlayScripts/PlayerScripts/PlayerController.cs#L186), and [here](https://github.com/kyle-andrus/RIP/blob/ae2939d2a30147a5f2da685627e13917108c6a3f/Assets/Scripts/GamePlayScripts/PlayerScripts/PlayerController.cs#L124). This small addition helps the players solidify the fact he/she just picked up something and makes it easier for them to keep track of how many they have already picked up. One of the cooler pick-up effects comes from the alcohol. I threw in a camera shake-up that mimics what it's like to be drunk using Caleb's [itemWobble](https://github.com/kyle-andrus/RIP/blob/ae2939d2a30147a5f2da685627e13917108c6a3f/Assets/Scripts/GamePlayScripts/ItemWobbleAnimation.cs#L1) script and played around with the animation curve. Some really cool effects can be achieved with different patterns in the lines. 

_**Endings**_: 

There are four possible ending screens that lead to the credits. The "GameOver by Time", "GameOver by Alcohol", "GameOver by Cancer", and "GameOver by Win". Each of the "Bad" gameover scenes had a red background, with a giant RIP(the title of our name) in the middle along with how they lost. These were fairly simple scenes that had small animations, color effects, and rotations. 

**GameOver Time:**
When the time ran out during gameplay, the player is redirected to this scene. There is a tiny clock moving across the screen using this [script](https://github.com/kyle-andrus/RIP/blob/ae2939d2a30147a5f2da685627e13917108c6a3f/Assets/Scripts/gameOverScripts/timeMove.cs#L1). The transform.translate was one of the very first things we've learned in the class. 

**GameOver Alcohol:**
When the player dies from overconsumption of alcohol, he/she is redirected to this scene. It starts to rain alcohol via this [script](https://github.com/kyle-andrus/RIP/blob/ae2939d2a30147a5f2da685627e13917108c6a3f/Assets/Scripts/gameOverScripts/alcoholRain.cs#L1). This was also from project 1, making use of object instantiation/destruction and position. 

**GameOver Cancer:** 
When the player gets addicted to cigarettes, he/she is redirected to this scene. There was a bit of animation in this scene that I played around with. 

**GameOver Win:**
If the player reaches the end, they are first redirected to a small cutscene, and then this scene. Here, the color of the background periodically changes and the title moves around. It's like a party simulator. This uses the getComponent, Color, and Random aspects of Unity. [Script](https://github.com/kyle-andrus/RIP/blob/54a9fb59bf9f1c39347130961945c9b7bbe644ac/Assets/Scripts/backColorChange.cs#L1). 

**Credits:**
In the credits, all of our names are shown in the middle of the screen one at a time. Camera position and Vector3.MoveTowards were useful here. There were 5 scripts, here is [one](https://github.com/kyle-andrus/RIP/blob/ae2939d2a30147a5f2da685627e13917108c6a3f/Assets/Scripts/CreditsScripts/tonyController.cs#L1) of them. I got the idea of MoveTowards from [here](https://answers.unity.com/questions/570573/how-do-i-slowly-translate-a-object-to-a-other-obje.html). 


## Movement/Physics

### Movement
_ADSR Envelope_ - The game takes the input from the keyboard and uses a modified version of the class example of the [ADSR envelope](https://github.com/kyle-andrus/RIP/blob/a2367b6b42e8d6ebe715cff18e76aa558fa38d1c/Assets/Scripts/GamePlayScripts/PlayerScripts/ADSRManager.cs#L128) to move the character on the screen. We decided to use the ADSR envelope for a more stylized experience with movement and based the curves off of the Jump Man curves. We elected to use those curves as reference after gameplay testing showed that our previous movements were too slippery. Several enum states and subsequent state checks had to be added into the code to ensure that the ADSR envelope was calculated correctly and the player moved as intended. A [Direction state](https://github.com/kyle-andrus/RIP/blob/a2367b6b42e8d6ebe715cff18e76aa558fa38d1c/Assets/Scripts/GamePlayScripts/PlayerScripts/ADSRManager.cs#L35) was added to keep track of whether or not the player was moving horizontally. This ensured that the ADSR manager would not [prematurely switch](https://github.com/kyle-andrus/RIP/blob/a2367b6b42e8d6ebe715cff18e76aa558fa38d1c/Assets/Scripts/GamePlayScripts/PlayerScripts/ADSRManager.cs#L163) to the release phase when the player was moving in the sustain phase and would only switch to release when the player stopped pressing an input direction. 

_GroundCheck_ - Initially, a ground check script was implemented using colliders but it eventually was changed to a [velocity](https://github.com/kyle-andrus/RIP/blob/54a9fb59bf9f1c39347130961945c9b7bbe644ac/Assets/Scripts/GamePlayScripts/PlayerScripts/GroundCheck.cs#L23) method since we were having issues with the collisions of our GroundCheck collider and the tile colliders that made up the stage. 

_Movement Shuffling_ - Control randomization was added as an effect of drunkenness. This was achieved by initially storing the original, correct movement into an array and using the [Fisher-Yates shuffle](https://stackoverflow.com/questions/9592166/unique-number-in-random/9593077#9593077) to shuffle the controls within the array when the player is in the drunk state. The movements are then [reassigned](https://github.com/kyle-andrus/RIP/blob/a2367b6b42e8d6ebe715cff18e76aa558fa38d1c/Assets/Scripts/GamePlayScripts/PlayerScripts/PlayerInput.cs#L119) and eventually [reset](https://github.com/kyle-andrus/RIP/blob/a2367b6b42e8d6ebe715cff18e76aa558fa38d1c/Assets/Scripts/GamePlayScripts/PlayerScripts/PlayerInput.cs#L131) when the drunkenness effect has worn off.

### Physics
_[FixedUpdate()](https://github.com/kyle-andrus/RIP/blob/54a9fb59bf9f1c39347130961945c9b7bbe644ac/Assets/Scripts/GamePlayScripts/PlayerScripts/ADSRManager.cs#L53)_ - We were having bugs with the player becoming jittery when colliding into a wall in the level. This was fixed by changing `Update()` to `FixedUpdate()` and with that, the update cycle synced up with the physics more smoothly and the jittering was solved.

_[RigidBody2D](https://github.com/kyle-andrus/RIP/blob/54a9fb59bf9f1c39347130961945c9b7bbe644ac/Assets/Scripts/GamePlayScripts/PlayerScripts/PlayerJump.cs#L24)_ - The player in the game is implemented with a `RigidBody2D` to take advantage of Unity’s built-in physics system. All vertical movement (i.e. jumping and falling) are hooked up with the physics system via the RigidBody. Jumping was implemented by adding an upward force with Unity’s  `AddForce()` [function](https://github.com/kyle-andrus/RIP/blob/54a9fb59bf9f1c39347130961945c9b7bbe644ac/Assets/Scripts/GamePlayScripts/PlayerScripts/PlayerJump.cs#L31) and gravity did the work to bring the player back down to the ground. There is [no implementation around variable jumps](https://github.com/kyle-andrus/RIP/blob/54a9fb59bf9f1c39347130961945c9b7bbe644ac/Assets/Scripts/GamePlayScripts/PlayerScripts/PlayerJump.cs#L10) (short jumps vs long jumps) but the more precise jumps can still be made.

_Colliders_ - The player and everything they interact with has an associated collider. The stage is made up of Tile Colliders, the enemies have Polygon Colliders, and the items have Box Colliders. Within the code, [checks](https://github.com/kyle-andrus/RIP/blob/54a9fb59bf9f1c39347130961945c9b7bbe644ac/Assets/Scripts/GamePlayScripts/PlayerScripts/PlayerController.cs#L96) are performed to see what the player is colliding with and how to proceed depending on what they collide into. 

Enemies, the ground, and walls all act as regular colliders when there is a collision between them and a player, they will not let the other go through them.

On the other hand, items and checkpoints are treated as [triggers](https://github.com/kyle-andrus/RIP/blob/54a9fb59bf9f1c39347130961945c9b7bbe644ac/Assets/Scripts/GamePlayScripts/PlayerScripts/PlayerController.cs#L119). This is because there is no need for the physics aspects of colliders to come into play when these objects are collided with. They are there to [detect overlap](https://forum.unity.com/threads/collision-vs-trigger.30174/#post-196535).
## Animation and Visuals

**List your assets including their sources, and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio

**List your assets including their sources, and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**oDocument how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
