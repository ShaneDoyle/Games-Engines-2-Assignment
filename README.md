# Games-Engines-2-Assignment
## Initial Storyboard:
![alt text](https://raw.githubusercontent.com/ShaneDoyle/Games-Engines-2-Assignment/master/Storyboard.png)

## Student:
**Name:** Shane Doyle  
**Student Number:** C15440858  
**Course Number:** DT211C/4

## Description of the Assignment:
This assignment recreates many of the iconic scenes found in the movie _"2001: A Space Odyssey"_. These scenes use a combination of different movement behaviours, audio tracks, camera scripts and extremely smooth scene transitions in order to create an immersive and eerie cinematic experience that any 2001 fan will love.  
Some of the scenes are extremely close to the movie and some of the scenes are more my own interpretation. This was necessary as it would have been impossible to show off certain behaviours and scripts if every frame was an exact remake of the movie.

## Instructions:
No tutorial or instructions needed. The whole assignment is automated and will progress through each scene automatically. Simply click start and enjoy!

## How it works:
The best way to demonstrate how this Assignment works is by talking about each scene and what components it is made of.

### Dawn of Man (Scene 1):
In this scene, we observe the early form of man, taking place thousands of years ago. Two final tribes of man clash with each other for the title of being the last remaining tribe of man remaining. This tribe will go on to colonise the rest of Earth into the civilisation we know today. This milestone in history is represented by the monolith seen in this scene.  There are a variety of components that make this scene function, such as:
#### MonkeyLeader.cs
This is the script that is used to control the monkeys. There are a total of 6 different states that the monkeys can have. These states are:  
* **Pursue** - The monkey will select a random enemy target and move towards it. 
* **Attack** - When the monkey gets within close enough range to his target, he will attack and try inflict damage to it. If the target is within his reach, it will take damage. After this attack, he will enter the flee state.
* **Flee** - The monkey will flee away from his current target, while looking at him. After a random period of time, the monkey will randomly select a new target and will pursue this target.
* **Death** - When the monkey has 0 health points, the monkey will collapse and die. Dead monkeys can't be targetted.
* **Strafe** - Periodically, the monkeys will strafe. Strafing is a movement action that allows the monkey to sway left and right while also moving to a location. How long and how often the monkey strafes is random.
* **Idle** - Monkeys do nothing. Unused.  
  
When all these behaviours are combined together along with multiple monkeys, it creates an interesting and random battle simulation. This scene is entirely different each time it is played.
#### Animations:
Depending on what state the monkey is in will depend on what animation the monkey plays. This is achieved through the Unity Animation Tree. Simply put, each animation will play for a set period of time and only one animation may be active at a time.  
#### Misc:
There are a variety of other scripts that handle how the scene functions. Once all enemy monkeys have been defeated, the scene will create a canvas with a fade out transition and upon completion of the fadeout, it will use the _"SceneController"_ script to load the next level. This script will be discussed later under the _"General Scripts"_ heading.  
  
### 2001 AD (Scene 2):
This scene takes place over Earth's atmosphere as we watch the Space Station orbit around the Earth. We also observe the Orion ship preparing to land inside the Space Station. This scene focuses on camera shots, deceptive angles and scene swapping, rather than complex behaviours. This means we can watch the Orion ship smoothly and gradually prepare to land in the ship and create a beautiful and elegant scene. The backgrounds found in this scene do not use a skybox, but rather use a plane with an image on it. The plane is then moved through translation or rotation, giving the illusion of depth and this works better than using a skybox. The plane is placed at such an angle that makes it appear to be a background with depth, but in reality, it is simply a plane with an image on it. This scene is broken down into 6 smaller scenes, that transition smoothly into each other.
#### Seek:
The Space Station and the Orion use Seek behaviours to move in this scene. As previously stated, this scene focuses more on appearance and scene management, rather than complex behaviours, so all the ship _movements_ could be achieved with only this script.  
#### Rotation Scripts:
The Space Station in each scene rotates. Additionally, in some scenes the Orion is also spinning as it is preparing to land inside the Space Station. In camera shots that take place inside the ships, rotation takes place on the backgrounds in order to give the illusion that the ship is spinning.
#### Translation Scripts:
Some background require moving in a single direction, either up, down, left or right. If a background needs to move, a script was created for that background to make it translate in world space in a certain direction.

### Objective: Rescue Frank (Scene 3):
In this scene, HAL has unexpectedly opened the pod bay doors, causing Frank to be sucked out and exposed to the dangerous atmosphere of Space, killing him. David must now go and retrieve the corpse as it floats around in Space, using one of the EVA Pod ships on board. This scene makes use of a path following behaviour and a camera snapping script, to capture intruguing and interesting angles of the rescue mission.

#### PathFollow.cs:
The EVA Pod follows a set path around the Discovery ship in order to reach Frank. The EVA Pod will accelerate towards a point and this acceleration is capped by the speed variable. As the EVA Pod reaches it's target point, it will slow down and upon reaching a certain distance, will stop for a few moments. The EVA Pod will then gradually look at the next target point and slowly accelerate towards that. This is repeated until all points are reached. Each target point is stored in a Vector3 array that the EVA Pod can easily loop through.
Lerping movement was fine to use here as damping was not needed for this path following behaviour.

#### EVAPod.cs:
This is a script to manage the behaviour of the EVA Pod. It manages when to play certain sounds such as interacting with HAL at the end of the scene. In addition, when it makes contact with Frank, it will set a child object and disable the world object in order to give the impression that the EVA Pod is collecting and holding the body.
This script is used to move to the next scene, as timing it manually with the _"SceneController"_ script was too hard to time correctly. The script inherits variables from the _"PathFollow"_ script in order to keep track of what target the EVA Pod is on. This made it very easy to call a timer after a certain point is reached, in this case, when the EVA Pod reaches the pod bar door at the end.

#### Scene9Camera.cs:
Similar the _"PathFollow"_ script, this script also contains a Vector3 array which contains points that the camera will go to. However, it will periodically teleport to each point, rather than gradually going to it. Upon each teleport, the camera will also look at the EVA Pod's current position. These locations have been manually selected give the best shots of the EVA Pod and the environment.

### The Star Gate (Scene 4):
The Star Gate is a visual sequence that engulfs the viewer by blasting them with a variety of different textures and visuals. The viewer goes on a journey through the Star Gate, gradually getting faster and faster until they reach the end of the visual sequence. After the sequence ends, we then view the Earth & Moon, followed by the Star Child, who illustrates a new leap for all of mankind.

#### StarGate.cs:
This script manages each gate (left & right) of the Star Gate. Each gate is a plane with a texture on it. The script holds an array of different textures that the gates will cycle through. Every 20 seconds, a screaming David will appear on screen, which will trigger a new texture to be loaded and a new angle to be selected. Upon each new texture load, the field of view of the camera will increase.  
When the last scream and texture are reached, a close up of David's eye is shown in a video, as he reaches the end of the Star Gate, only to be suddenly abrupted with a flash of light, and an eerie silence. 
After this, begins the Star Child scene.

### General Scripts:
These are scripts that are used in each scene and since they are so broad, they can be applied to any scene.

#### AudioDontDelete.cs:
A very straight forward script that when attached to an audio source, will cause it to not be deleted upon loading a new scene. This allows music to transition over to new scenes.

#### Seek.cs:
This behaviour is used in many of the slow moving assets, such as the Space Station, Orion and even the Star Child. It implements the seek behaviour.

#### SceneController.cs
A very important script that makes transitioning between each scene smooth. The script takes in two variables, one for a wait time and one for a scene number. The script will wait the definied wait time and then load the definied scene number. This is a very useful script for timed cinematics, such as the "Waltz" scene.

## What I am most proud of in the Assignment:
I am most proud of how visually appealing this Assignment looks and how accurate it is to the movie, especially the "Waltz" scene. This scene is incredibly accurate to the movie and each scene seemlessly loads into the next.  
Visually, it looks great. This is partially due to the models I was able to find but even with gorgeous models, without effective scripting, they would not look appealing. I was able to provide very smooth scripting to bring these models to life and combine it with slick camera management to create immersive cinematic scenes.

## Video!
[![YouTube](https://i9.ytimg.com/vi/wgLdWPeAWMo/mqdefault.jpg?sqp=CNzVwuYF&rs=AOn4CLC2Hy8-oQwuxbz9Bc1mExGaig5dMQ&time=1557179110630)](https://www.youtube.com/watch?v=wgLdWPeAWMo&)
