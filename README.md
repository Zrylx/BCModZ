<div align="center">
	<img src="https://i.imgur.com/lyJevmd.png" alt="BCModZ Banner">
    <h1>BCModZ</h1>
</div>



<p align="center">
<a href="#-key-features">Key Features</a> - 
<a href = "#-getting-started">Getting Started</a> -
<a href = "#-how-it-works">How It Works</a> -
<a href = "#-common-problem-fix">Common Problem Fix</a> -
<a href = "#-software-design">Software Design</a> -
<a href = "#-contributing">Contributing</a> -
<a href = "#-license">License</a> -
<a href = "#-donate">Donate</a>
</p>

<div align="center">
	<img src="https://img.shields.io/github/downloads/zrylx/BCModZ/total"/>
	<img src="https://img.shields.io/github/v/release/zrylx/BCModZ"/>
	<img src="https://img.shields.io/github/stars/zrylx/BCModZ"/>
</div>

<p align=center>🎮<i><b>BeamNG.drive Career Mode Modifier</b></i></p>

**BCModZ** is a desktop tool designed for BeamNG.drive players to modify career mode values, such as **money**, **XP**, and **vouchers**. Since career mode is single-player, using BCModZ is **safe**, **ethical**, and **ban-free**. If you need any help with the program, please feel free to [create a ticket in the Discord server](https://discord.gg/Zm9JzKvzyg) and send me your log file. 

---

### 🟣 **Key Features**
- **Modify Career Attributes**:
	Easily adjust:
	- 💵 **Money**.
	- 🛠️ **XP** for various jobs like Labourer, Adventurer, Motorsports, and Specialized.
	- 🎟️ **Vouchers** and more.

- **Completely Safe**:
🚫 No bans - this tool only modifies BeamNG.drive career mode values which is single player. 

### 🟣 **Getting Started**
1. **Backup**: Before performing any modifications to your career profile, please back up the **"saves"** folder located at: ```C:\Users\[your-username]\AppData\Local\BeamNG.drive\0.34\settings\cloud```. 
2. **Download**: Grab the latest release from the [releases page](https://github.com/Zrylx/BCModZ/releases) or clone this repository and build the solution.
3. **Run the software**: Open the ```.exe``` file to launch the software. 
4. **Enter career profile**: Type in the name of the career profile you would like to modify in the text box and click next.
5. **Most importantly**: Have fun! 🚀
 
### 🟣 **How It Works**
BCModZ works by **directly modifying** the ```playerAddtributes.json``` file, which is where BeamNG.drive stores all your career mode progress. This file contains information about things like your money, XP, and vouchers. If something goes wrong during the modification process, BCModZ will notify you and always log the issue so you know what happened.

### 🟣 **Common Problem Fix**
A very common issue I have seen users mentioning is that when you use **RLS Career Mode Overhaul**, your money value is reverted upon loading the career profile. To fix this, please do the following:
1. Open BeamNG.drive and load up your career profile.
2. Press the tilde key (`/~) - it is located right under the esc key. This should bring up the game console. 
3. Paste in this command: ```career_modules_playerAttributes.addAttributes({money=1000}, {tags={"gameplay"}, label="Magic"}) ```. This will add 1000 cash to your career profile. 
4. After doing so, according to users in the Discord server, BCModZ works with RLS Career Mode Overhaul. 
5. If this works for you please let me know in the [server](https://discord.gg/Zm9JzKvzyg)!

### 🟣 **Software Design**
<div align="center">
<img src="https://i.imgur.com/0u9lPSq.jpg">
</div>

### 🟣 **Contributing**
Contributions are welcome! Fork this repository, make your changes, and submit a pull request to help improve BCModZ.

### 🟣 **License**
This project is licensed under the [GNU General Public License v3.0 (GPL-3.0)](https://github.com/Zrylx/BCModZ?tab=GPL-3.0-1-ov-file#readme). This means that you are free to use, modify, and distribute this software under the terms of the GPL-3.0. However, **any modifications or derived works must also be licensed under the same GPL-3.0 license and include the source code**. For more details, please refer to the [LICENSE](https://github.com/Zrylx/BCModZ?tab=GPL-3.0-1-ov-file#readme) file. 

### 🟣 **Donate**
I'm a solo profit-free developer creating softwares for completely free. If you would like to support me, any donations would be highly appreciated! 💜
<div align="center">
	<a href="https://buymeacoffee.com/zrylx">
		<img src="https://miro.medium.com/v2/resize:fit:1090/0*lHgOW3tB_MfDAlBf.png" width="150">
	</a>
</div>

---
