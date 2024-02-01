# ResoniteFix _(Linux Fix)_
Fixes the game trying to load windows dlls, and just thinking its in windows in general  
[Here is how to install it](#how-to-install)  

# Well... not quite...
That is... a start...  
unfortunally Resonite is still brocken :<  

Looks like some stuff is still broken with the rendering  
Some stuff looks glitchy and menus dont work  
_(maybe it has smthn to do with shaders? i have no idea... might look into that later)_  
  
// TODO: Add video showing the visual glitches  
  
And how to fix it?  
Uhm... idk yet... sowwy  
  
# Compiling from sauce
To compile it from source first make sure you have [dotnet](https://learn.microsoft.com/en-us/dotnet/core/install/linux) installed  
1. Clone the repo and cd into it  
```bash
git clone https://github.com/Babakinha/ResoniteFix
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

# How to install
First, install [BepInEx](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.22) _(see here [how to install BepInEx](https://docs.bepinex.dev/articles/user_guide/installation/index.html?tabs=tabid-nix))_  
Then [download](https://github.com/Babakinha/ResoniteFix/releases/tag/v0.0.1) or [compile](#compiling-from-sauce) the mod and put in inside `<ResonitePath>/BepInEx/plugins`  
_(ResonitePath being where u installed the game, just browse local files on steam)_  
  
Thats it, enjoy :3  
