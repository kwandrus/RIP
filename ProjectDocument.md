# Game Basic Information #

## Summary ##

You try to escape your past self. A time of addiction and regret.
Yet the shadow of your past continues to pursue you, in hopes of being able to finally take over, once and for all. Blessed with multiple lives, but a finite amount of time, you have to maneuver through creatures of the dark, avoid pitfalls, and resist the temptation of reverting back to your previous self. 

## Gameplay explanation ##

Use WASD or the arrow keys to move around the game. Jump can be also achieved with the spacebar in addition to the "up" buttons previously mentioned. There are "buffs" around the level that may or may not aid the player. The most optimal gameplay strategy to to get through the level quickly, but carefully. Death subtracts points from the overall score. 


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

There are four possible ending screens that lead to the credits. The "GameOver by Time", "GameOver by Alcohol", "GameOver by Cancer", and "GameOver by Win". Each of the "Bad" gameover scenes had a red background, with a giant RIP(the title of our name) in the middle along with how they lost. These were fairly simple scenes that had small animations, color effects, and rotations. UnityEngine.SceneManagement was very helpful for transitioning to desired scenes. 

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

**ICommand** – We utilized the [ICommand interface](https://github.com/kyle-andrus/RIP/blob/master/Assets/Scripts/GamePlayScripts/PlayerScripts/IPlayerCommand.cs) from our first unit to configure the input for our game. The interface allowed for easier manipulation of each command within our code and allowed us to separately code the scripts for each command. Because the gameplay controls are movement-based, using the ICommand made it easier for me and Maxim to simultaneously work on our individual, yet overlapping, roles for the project. I created instances of each scriptable object for right, left, and jumping movement, and the ICommand interface contained ButtonDown, ButtonHold, and ButtonUp functions (so we could use the ADSR envelope). We also had a component for a shoot command that we decided not to implement for our prototype to focus on the completion of more core aspects of the game.

Utilizing the ICommand also allowed us to reconfigure the controls at runtime. We demonstrated this through the implementation of an alcohol collectible, which [randomly scrambles the user’s controls.](https://github.com/kyle-andrus/RIP/blob/5db2337f6e76a6e6a11b6610bad3cb00d4532ad7/Assets/Scripts/GamePlayScripts/PlayerScripts/PlayerInput.cs#L96) This was done by setting each command (left, right, jump) to the scriptable object instance of a random command. The commands were randomly chosen from an array containing all commands to prevent repeated commands to multiple controls, and the random selection was implemented through the Fisher Yates Shuffle, which Maxim found online. Resetting the controls after the collectible wore off was also implemented by setting the commands back to instances of their respective scriptable objects.

**Utilizing Unity’s Input Settings** - I initially planned to use the WASD keycodes to detect if a movement script would be executed, but I decided to instead use the built-in input under Unity’s project settings. [I implemented](https://github.com/kyle-andrus/RIP/blob/5db2337f6e76a6e6a11b6610bad3cb00d4532ad7/Assets/Scripts/GamePlayScripts/PlayerScripts/PlayerInput.cs#L50) the commands with the positive and negative buttons of the horizontal and vertical axes, which were already assigned to WASD by default (the arrow keys can also be used). Using Unity’s input settings potentially allows for more versatile types of input controllers, particularly for game console controllers. We didn’t get around to testing whether a game console controller or joystick could work as a controller, but it is possible using our setup because the input for Unity’s project settings also account for them. I also utilized the Jump input (set to space bar) instead of just the positive vertical button because we found in our gameplay testing sessions that most players instinctively tried to press space bar to jump.

While the mouse could’ve potentially been used as a controller based on its scroll direction, this would have made the playing experience particularly difficult (even though this is the premise of our game!). In class, we discussed how mouse movement gives an infinite number of inputs for our controller, but we only scripted three discrete commands for our game; therefore, the mouse wouldn’t be implemented as a possible controller. We cemented this decision by placing a restart button as a clickable button on the HUD, which would separate the thought of moving the mouse from playing the current game.

**Menu Controls** – Navigating the different menus required different inputs. Tony added buttons to the main menu and loss menus, and [we used a scene manager](https://github.com/kyle-andrus/RIP/blob/5db2337f6e76a6e6a11b6610bad3cb00d4532ad7/Assets/Scripts/gameOverScripts/LoseButtonsController.cs#L41) to load different scenes upon clicking each button (ex. restart button loaded the gameplay scene, credits button loaded the credits scene). We added small time buffers to act as loading/transition times for all buttons except the in-game restart button. This is because an immediate restart gives the player a greater feeling of control and sustains interest by getting back into the action of the game sooner. Because the current state of the game uses the positive and negative axes buttons as controls (arrow keys/WASD), the play button also had to be set as first selected in the main menu canvas to allow for menu navigation using the same buttons. Without the first selected setting, a player couldn’t navigate the menu using the keyboard unless a button was first selected by a mouse click, which would have created a clunkier feel to the game before it even started.

**Scene skip input** – Although cutscenes add to the narrative aspect of the game, it can be repetitive and/or boring to watch the same cutscenes multiple times. Therefore, minor button commands were added to immediately load the next scene. [We allowed users to return to the main menu](https://github.com/kyle-andrus/RIP/blob/master/Assets/Scripts/CreditsScripts/BackToMainMenu.cs) from the credits or winning scenes by pressing any button; these scenes are generally known to not have much interactive potential, so players usually want to have an easy option to quickly skip to the next scene. However, [we set only the jump/space bar](https://github.com/kyle-andrus/RIP/blob/5db2337f6e76a6e6a11b6610bad3cb00d4532ad7/Assets/Scripts/CutsceneScripts/EndingCutscene/EndingCutSceneController.cs#L40) as the input to skip cutscenes so players wouldn’t inadvertently skip the storyline of the game.


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

**Cutscenes** - The narrative is mainly present via the cutscenes before and after the gameplay. The tension in the first cutscene is emphasized by the appearance of a confrontation, coupled with ominous audio. In the second cutscene, subtle elements highlight the dialogue’s messages. For example, for the ending cutscene, [I added a separate script](https://github.com/kyle-andrus/RIP/blob/4049b0dfb10186dac8e7158a15a5acf0dc00dba4/Assets/Scripts/CutsceneScripts/EndingCutscene/EndingTypeWriter1.cs#L12) for the player’s dialogue to increase the delay between each letter displayed. I also added ellipses to present a slower, bolder statement. After the statement, I also made sure the player walked out of the screen at a [slower pace](https://github.com/kyle-andrus/RIP/blob/4049b0dfb10186dac8e7158a15a5acf0dc00dba4/Assets/Scripts/CutsceneScripts/EndingCutscene/EndingWalk.cs#L80), which would show he is more relaxed and truly changed like his dialogue stated. This delay wasn’t blatant yet was still enough for players to notice (like the human recognition of slight timing differences we learned about in the ADSR unit).

**Collectibles** - The narrative is also present in the gameplay via a collectibles system. We added alcohol and cigarettes as collectibles, each of which had a short-term benefit but long-term consequence. Collecting (consuming) alcohol gave the player temporary invincibility, but their controls would be randomized, which ultimately detriments the player due to their strict time pressure. Cigarettes give the player a short amount of additional time, but they must now also collect more cigarettes within a short amount of time or immediately lose. In both cases, collecting too many of one kind will cause the player to lose. We tried to keep a realistic narrative by creating consumable effects similar in nature to real life, and the collectibles forced the player’s actions to parallel the main character’s (the player gradually learns that the short-term benefits aren’t worth it and must change to win the game).


## Press Kit and Trailer

[Trailer](https://youtu.be/lx1-ISlhUis).
Here is the music I used for the trailer:
[Music 1](https://www.youtube.com/watch?v=-xpqcOCNHjw).
[Music 2](https://www.youtube.com/watch?v=9gvwhl505-o).

[Press Kit](https://github.com/kyle-andrus/RIP/blob/master/PressKit/presskitty.md). 
These are some sources that gave me inspiration for my press kit: 
[Source 1](http://www.aegisthegame.com/press-kit.html).
[Source 2](https://www.youtube.com/watch?v=0mqnz9QfFck).

For my trailer, I wanted to start it with a cutscene that had some relevant dialogue and then be able to end the trailer with another cutscene that wraps up the whole game. I then put in some gameplay as the meat of my trailer, showing the viewers cool features, different end screens, and a lot of death(which is a main theme for our game). The multiple ways to die was showcased throughout the trailer, making the game seem very difficult (which may entice some of the viewers looking for a challenge). The audio that was chosen is different from the actual gameplay because I thought it fit the trailer much better; music really does wonders to a video. 

As for my press kit, I had an about us section, lore for the game, screenshots, characters, and a team page. I also had a section on the left side of the first page that gave some information about the developer, publisher, price, etc. about the game. My color scheme for the press kit matched actual game itself, with purple being the primary color that was used. The screenshots I chose were very relevant to the game - the overall story, avoiding creatures, and of course, death. I gave descriptions for each of these elements. I also threw in the main characters for the game and gave each one of them some personality. My favorite page in the press kit is the "Team" page which showed all of us and what we contributed to the game. It was really bittersweet completing this page because of all the hardwork we put in and how the game finally turned out. 




## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
