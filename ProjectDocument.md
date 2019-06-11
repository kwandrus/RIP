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
A lot of this was learning through trial and error. I was able to grasp a bit of how the canvas system worked through the Pirate project, but what really gave me the most knowledge on the UI interface was just through a lot of mistakes. Some challenging parts of this were differentiating between UI objects and regular ones, positioning these items correctly, and being able to bring it together to create something intuitive and aesthetically pleasing. Most of the HUD elements can be seen in the [gamePlayController](https://github.com/kyle-andrus/RIP/blob/11adb4d1ab86b13b8fd79ccb757365a40eaba350/Assets/Scripts/GamePlayScripts/GamePlayController.cs#L1) script. We wanted the HUD to be visible and clear for the players, so placing all of these components at the very top of the screen was the first thing I thought of. Also, I wanted to match the "pixely" theme we had going on throughout the game, so all of the fonts and images I used also had to abide by these rules.  

#### Death
Whenever the player dies, the death counter goes up by one. The code for the death counter is take the number of deaths the player currently has, and then change the text component of the text object to match what has happened. This can be seen through this portion of the [script](https://github.com/kyle-andrus/RIP/blob/11adb4d1ab86b13b8fd79ccb757365a40eaba350/Assets/Scripts/GamePlayScripts/GamePlayController.cs#L77). Next to the death counter, there's a cute little animated skull that gives the "it's okay if you die" vibe to the players. From this, I briefly touched over some of the animation and game feel aspects for the game. 

#### Score


#### Timer

#### Pickup 

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your own movement scripts that do not use the phyics system?**

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
