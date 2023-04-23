# Unity3D Development Assessment

## Specifications
**Unity Version**: 2021.3.15f1

**Build**: `Build/amulder_WhackAMole.apk`

**Build Platform**: Android

**Build Tested**: Samsung Galaxy S22, Android 13

## Project Structure
### Code
Script folder consists of two folders: `Core` and `WhackAMole`. Anything defined in `Core` is meant to serve as a game agnostic framework to be used by concrete implementations. `WhackAMole` contains the code used to create the actual whack a mole game.

### Setup
The `Game` scene contains a single `WhackAMoleBehaviour` that serves as the entry point for the game. The `WhackAMoleGame` class creates all dependencies through the use of factories. Factories will create instances for almost anything in the game, including prefabs through a `MonoFactory`. This factory will load assets from the Resources folder. The `WhackAMoleController` ties together some gameplay elements, mainly switching between screens when needed.

Almost everything was build using a presenter and view approach. Presenters are classes that control logic and will update their view when a visual aspect needs to be updated. Every view derives from `MonoView` which is a MonoBehaviour. Models were left out for the sake of simplicity.

### Features
 - Instance creation with dependencies through factories;
 - Presenter and view for separating logic and visuals;
 - Signal events for more flexibility and more loosely coupled classes;
 - Simple `GameCanvas` class that that supports showing and hiding game screens.

## Further Improvements
 - Creation of views is limited to the Resources folder;
	 - There is currently no way  to use an existing GameObject instance from the scene as a view.
	 - Paths and names are hardcoded in scripts.
 - The dependency injection approach used is quite rudimentary;
	 - It's somewhat complex to make sure all dependencies are added in the correct order.
	 - There is no support for circular dependencies due to this.
 - Add examples of different gameplay elements to showcase flexibility of the code structure.
