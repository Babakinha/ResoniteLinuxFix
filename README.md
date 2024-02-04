# ResoniteFix _(Linux Fix)_
Fixes issues making it actually possible to run on linux :3  
[Here is how to install it](#how-to-install)  
  
# How to install
First, install [BepInEx](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.22) _(see here [how to install BepInEx](https://docs.bepinex.dev/articles/user_guide/installation/index.html?tabs=tabid-nix))_  
Then [download](https://github.com/Babakinha/ResoniteLinuxFix/releases/tag/v0.0.2) or [compile](#compiling-from-sauce) the mod and put in inside `<ResonitePath>/BepInEx/plugins`  
_(ResonitePath being where u installed the game, just browse local files on steam)_  
  
Thats it, enjoy :3  
  
# Compiling from sauce
To compile it from source first make sure you have [dotnet](https://learn.microsoft.com/en-us/dotnet/core/install/linux) installed  
1. Clone the repo and cd into it  
```bash
git clone https://github.com/Babakinha/ResoniteLinuxFix
cd ResoniteFix
```
2. Set the path of where u installed resonite like this:  
```bash
export ResonitePath="~/.local/share/Steam/steamapps/common/Resonite"
```
3. Build it using dotnet _(u prob want to use Release mode)_  
```bash
dotnet build --configuration Release
```
  
The dll will be stored in `bin/Release/netstandard2.1/ResoniteFix.dll`  
If u already installed BepInEx u can just do  
```bash
cp bin/Release/netstandard2.1/ResoniteFix.dll $ResonitePath/BepInEx/plugins
```
