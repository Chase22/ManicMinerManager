# Maniac Miner Manager

## About
This little console program is primarily written in order to be able to easily manage experimental builds of manic miner. It allows you to easily syncrhonise levels with new versions of the game

## Usage
* Download the [latest release](https://github.com/Chase22/ManicMinerManager/releases/latest) from the github page
* Create a folder containing the executable, the current version of ManicMiner and an optional Levels folder
  * Folder
    * ManicMinerManager.exe
    * ManicMinersXXXX-XX-XX
    * Levels
* Execute ManicMinerManager.exe. It will synchronize your Levels folder with the ManicMiner Installation and start the Game

If everything goes right you will only briefly see a console window popping up and then the game will launch.

## Levels Folder
The Levels folder can contain a number of .dat files for custom levels. These will be copied over to any ManicMiner installation you have before launch. Making sure that all custom levels are available in all installations.

## Installations
A ManicMiner installation is any folder which name startes with "ManicMiner" and who contains a "ManicMiner.exe" file. There can be multiple installations at the same time. In that case, the manager will copy all custom levels to all installations and show a menu to select which installation to launch.

## Updating ManicMiner
An autoupdate for ManicMiner is planned, but until then manual updates can easily be done by deleting the old installation, extracting the new one into the folder and restarting the manager.exe. This will copy all levels over to the new installation and launch it.

## Roadmap
- [X] Launch ManicMiner through the Manager
- [X] Handle multiple installations of ManicMiner
- [X] Syncronise Custom Levels
- [ ] Autoupdate to the newest stable or experimental build
