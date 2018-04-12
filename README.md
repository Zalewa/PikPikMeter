PikPikMeter
===========

PikPikMeter is a network traffic meter program for MS Windows that shows
current network traffic (upload and download speed) and paints traffic
graph from it showing the most recent history. That's it. Nothing else.

![Screenshot](screen1.jpg)

Configuration
-------------

Config file is stored in

```
%LOCALAPPDATA%/PikPikMeter/PikPikMeter_<random>/<version>/
```

As there's no uninstaller (or installer, for that matter) for
PikPikMeter, to fully manually uninstall, remove the .exe file
and this config directory must be removed as well.

Reasons to use PikPikMeter
--------------------------

* No bullshit.
* No bloatware.
* No spyware.
* No whiny programmers.
* Open-Source (BSD 2-clause).
* Just one .exe.
* Just one XML config file.
* Paints graph.
* Stays on tray.
* Paints graph on tray.
* Can stay on top of other windows.
* Can start with system.
* Scalable graph.
* Bits or bytes scale.
* Giga, Mega, Kilo -bytes/-bits scale.
* Can set opacity.
* Can disable measure on each Network Interface separately.
* Doesn't crash when networking interfaces go down.
* Has a stupid name that immediately rings a bell.

Technology
----------

PikPikMeter is written in C# for .NET platform 4.5.0.

PikPikMeter runs on MS Windows. It was tested on Windows 7.

Name
----

PikPikMeter is named like this because if I get my ear close to the
network cable I can hear a faint "piiiiiiiii...". Or it might just
be my tinnitus.

Source Code
===========

Files that build the source code and their purpose are described
in smaller detail in [SOURCE.md](SOURCE.md) file.
