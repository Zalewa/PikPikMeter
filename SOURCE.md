Source Code
===========

This file described elements of the Source Code, explaining
their role in the program and briefly explaining their
inner workings.

Files with source code controlled by Visual Studio, ie.
`*.Designer.cs`, `*.resx`, are omitted from the description.
Their source code is generated through visual controls
and they are accompanied by sibling files that have
code written by hand.

Section A - UI and utilities
============================

None of these files actually deal with traffic monitoring,
however they are essential to the operations of the program
as they provide other useful features - forms, system startup,
positioning, settings, collections.

[Program.cs](PikPikMeter/Program.cs)
====================================

This is the standard "main" file generated by Visual Studio.
It has the `Main()` function, it starts the main form (main
window) and that's pretty much it.

Moving on.

[MainWindow.cs](PikPikMeter/MainWindow.cs)
==========================================

The Main Window, sometimes known as "The Dreaded God Object". In fact, I
always find `MainWindow` classes to be the most difficult to code.
They bind the main user interface, with all the menus, task bar handling,
tray handling, minimize/maximize/normalize events, various dialog boxes,
context menus, tray icon, etc. With all this stuff happening in a single
place, `MainWindow` very quickly gets crammed with many different
attributes and methods that do different, small jobs. None of them can
be easily disconnected from the `MainWindow`.

Elegant solutions for `MainWindow` are not easy to achieve.

Let's summarize what `MainWindow` in PikPikMeter does:

* Lays out of all widgets.
* Customized handling of moving and resizing the window.
  As the usual window "resize" border and title bar are turned
  off, we need customized code to handle mouse events and do that.
* `LoadSettings`/`SaveSettings`. Some more on this topic below.
* Control `MainWindow's` opacity and provide slider & context menu
  action to allow user to change it.
* Setup the `TrafficMonitor`, which takes over statistics gathering,
  graph painting and label updates.
* Allows to set traffic unit scale of the graph and bytes/bits
  option of labels.
* Tick a refresh `Timer` that ticks the `TrafficMonitor`.
* Controls "top most" flag of itself.
* Is capable of bringing itself to front (of other Windows windows).
* Toggles "start with system" flag that is controlled by `SystemStart`.
* Toggles Network Interface monitoring on user's behest.

The very length of this description suggests that MainWindow
has a lot to do.

SaveSettings/LoadSettings in MainWindow
---------------------------------------

These operations have nothing to do with "MainWindowing", but because
`MainWindow` is at the topmost level of the source code, it can also
access all the objects used in the program. I opted not to reference
C#'s `Settings` singleton anywhere else in the code but here. It makes
the other objects decoupled and allows to configure them in different
ways if needed. MainWindow references all `Settings` values and
assigns them to appropriate attributes of other objects. When `closing`
event is received, it takes those attributes back and saves them
through the usual .NET means - in an XML file on disk in `%LOCALAPPDATA%`.

[ScreenPosition](PikPikMeter/ScreenPosition.cs)
===============================================

In order to delegate some responsibility away from `MainWindow`,
the screen positioning is actually controlled here. Default screen
position, as well as minimal window size, are defined here.

This class also implements `MainWindow` position validation check,
and a method to reposition the window to the default location.
If user configuration contains an invalid position - a Window is outside
of the visible area - it will try to reposition the Window back to the
default location. It will also prevent the window from going below its
minimal size. This last can also be controlled by directly setting
the minimal size attribute in `MainWindow` form designer, however
I wanted to have the screen positioning logic in one place.

`ScreenPosition` also takes multi-screens into account. When calculating
default window position, it will try to use the screen that contains
the mouse cursor. This behavior is more common in Linux apps, but
I personally like it very much.

[About.cs](PikPikMeter/About.cs)
================================

In contrast to MainWindows, About windows are always a joy to build.

An About window should contain:

* Program's name, version, development date span which by itself can
  be just a span of years during which the program was developed.
* Copyright information - who made this, how to contact them.
* License.
* Backlink to program's or author's website. In this case it's
  a hyperlink to GitHub's page. Extra props are given for making
  the URL clickable.
* More props are given for making the information easy to copy & paste.
  Users making bug reports will be thankful for being able to copy
  the program's version.

Program name and version are extracted from `Application`
class, kindly provided to us by the .NET platform. This
information is configured in project's configuration
in Visual Studio.

The license contents are incorporated into the executable
as a resource and retrieved using the `Resources` class.
The content of this file is ASCII, so I use UTF-8 decoder
to decode it. Always mind the encoding of the text you read and write!

Another thing is to make sure that About window closes when you press
`Escape` key on keyboard. There's nothing more annoying than windows
that don't respond to common keyboard events.

About window is also allowed to follow a different visual theme
than the rest of the program. It's okay to use the standard Windows
theming here. If anything shouldn't be bugged, it's the About
window, and a custom visual theme can introduce visual glitches.

[AskValue.cs](PikPikMeter/AskValue.cs)
======================================

This is a generic "value input" dialog box that can be reused
for getting many different values from the user.

It's possible to control the contents of the label directly
above the input box and the contents of the input box.

In current state it's not possible to change the type
of the input box, change its value masking (ie. ask for passwords)
or assign a validator.

The window will "Cancel" itself when pressing `Escape` and
"Accept" when pressing `Enter`. This is done by marking "Ok" button
and "Cancel" button with appropriate C#'s `DialogResult` values.

In PikPikMeter this window also follows the default Windows visual theme.
In this case it's, unfortunately, a bit jarring.

[SystemStart.cs](PikPikMeter/SystemStart.cs)
============================================

In an effort to further de-deityize `MainWindow`, `SystemStart` is
a small class that contains only one, static property: `On`.

When you do:

```C#
SystemStart.On = true;
```

`SystemStart` will try to write a `CurrentVersion\Run` registry entry
using `Assembly.GetExecutingAssembly().GetName().Name` property
as registry setting name, and `Application.ExecutablePath`
as registry setting value. Setting value is extra-wrapped in
double-quotation marks.

Doing:

```C#
SystemStart.On = false;
```

will remove the registry entry.

It's also possible to get the current state of the registry entry by
getting the property:

```C#
bool isSystemStart = SystemStart.On;
```

Upon this, the property will try to open the registry key for reading
and check if the setting is there and if it points to the same
executable as `Application.ExecutablePath`. If any `Exception` occurs,
it's converted to `false` return value, which is a bit of a programming
anti-pattern, but I'd rather have the program not crash.

[History.cs](PikPikMeter/History.cs)
====================================

Under this grandiose name hides a generic LIFO collection implementation
with limited maximum size. When new elements are added to the collection
and the maximum size is exceeded, the oldest elements are removed.
History can be read using `Elements` property.

`History` collection is used to accumulate traffic statistics.

[Resources](PikPikMeter/Resources/)
===================================

Icons, resizer and a copy of the LICENSE - this last one is
to satisfy Visual Studio's need of cramming it there. LICENSE
normally resides in the root dir of the repository.

Pictures were drawn in GIMP.

`ico` files were then created in IcoFX 1.6.4 - the last Freeware
version of this program.

Section B - Traffic Monitoring
==============================

The program needs to do several jobs in something that
could be described as a "pipeline" in order to show
the traffic measures to the user. Let's try to list them:

* Read the current traffic stats as provided by Windows.
* Accumulate them in a history collection for graph painting.
* Toggle monitoring of each Network Interface on demand.
* Handle Network Interfaces going down (disappearing) or up (appearing).
* Paint the history graph.
* Display current traffic in labels.
* Scale the traffic to a preset unit size and type.

These responsibilities were spread between several `Traffic*` classes.
It took some care and consideration to ensure that each class has
its own **single** purpose and **single** responsibility.

What's difficult here is to create a clearly visible hierarchy
and assign proper names.

Hierarchy makes it easy to know what code calls which other code and
to follow the execution routines from general to the details.

Naming should make it obvious what is the exact responsibility
of each class, what job it does and what code can be expected.

Unfortunately, I don't feel that these two "virtues" of good code were
fulfilled sufficiently here. Only because PikPikMeter is a simple
program, the problem is not that malicious. In bigger applications
accumulated issues of this nature wreak chaos in the code base and
cause long-lasting maintenance troubles and numerous refactoring
sessions if the team is willing and has time to do them.