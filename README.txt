Rudeco - Acronym of the words RUntime DEbug COnsole.
Poy - Portmantenau of the words "Programming", and "Toy".

Description

  POY:

  Poy is small interpreted language.
  Poy is initially created for Rudeco, Runtime Debug Console.
  Poy and Rudeco is written in C# and built for Unity game engine.

  Poy has small documentation, that is provided inside the console,
  by using documentation commands that starts with "doc_".

  RUDECO:

  Rudeco is console that can be included inside the unity game.
  It can be exapanded with custom commands,
  that can manipulate the gameplay.
  Rudeco can be used for testing, but it's other purpose is also
  to give player more control over the game, and mess around with it.

Installation

  Copy this folder and it's contents into "Assets" folder inside desired
  Unity project folder.

Usage

  Add Rudeco prefab into the scene,
  and press F1 to open it when the game is on.
  
Creating expansions with custom commands

  Create C# class inside the custom commands folder, and inherit the class
  from CustomCommand class. Further documentation on how to create
  custom command, read the README.txt inside the CustomCommands folder.