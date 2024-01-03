# FurnitureAR

A simple AR application created in Unity for the course "Virtual Intelligent Systems" at UPM.

## Instructions

After the starting the app three buttons can be found on the button of the screen. That is for the furniture selection. By pressing a certain furniture is selected. By tapping on the screen the selected furniture will be spawned. Normally it should be able for the user to select, move and rotate the furniture but somehow we messed up with the code and could not fix it anymore.

## Approaches & Troubleshooting

We had a lot of problems throughout the development since we think that the AR foundation functionality did not work properly for us. We tried to first implement the object placement with a script named "PlaceObject". There we already spent a lot of time figuring out why the InputSystem did not work as expected. As you can see the onEnable() function was triggered manually by us because for no reason the function is not automatically triggered as it should. After having this workaround we then had problems with the modification of the object wherefore we switched to use XR Interaction Manager.

When we first used the XR Interaction Manager everything worked as expected. It was also way easier to add AR Transform functionality through the components AR Translation Interactable and AR Rotation Interactable. We proceeded on implementing the Canvas and the different furniture which was no problem but after creating the build we figured that the transforming and rotating the furnitures were not possible anymore. We tried to fix that but checking all the properties in the different components of the game objects and also created prefabs in order to fill in the Interaction Manager and XR Origin property in the components for the other prefabs. After hours of debugging we still couldn't figure it out but starting from scratch would take too much time. That's why we want to at least submit our current status of the project.

## Game Objects

Inside the SampleScene the following important gameObjects can be found:

- XR Origin (XR Rig): is the center of the XR Scene.
- AR Session: connects all VR objects with the real world.
- XR Interaction Manager: manages interactions.
- AR Placement Interactable: enables the user the place objects in the XR Scene.
- Canvas: contains the UI with the buttons.


## Project Structure

Inside the assets folder the following subfolders can be found:

- Materials: contains all our self-created materials.
  - outline_mat: was used in order to mark the object that is selected
- Prefabs: contains all the prefabs that can be used to create multiple gameObjects with the same attributes.
  - Couch 1
  - Couch 2
  - Couch 3
  - XR Interaction Manager (created in order to fix our problem but unsuccessfully)
  - XR Origin (XR Rig) (created in order to fix our problem but unsuccessfully)
- Raw Files: Files of the furnitures in .fbx
- Scripts: contains all the scripts.
  - FurnitureManager: handles the button clicks to switch between the furnitures.
  - PlaceObject: to place an object into the scene. Is unused since the app uses the interaction manager now.
