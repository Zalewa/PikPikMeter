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

Tech Choices
============

Even though my usual "go to" for desktop apps is `C++` + `CMake` + `Qt`
trio, as I usually care that the program works on at least 2 Operating
Systems - Windows and Linux, in this case I wanted a stricte Windows
app. As much as Qt makes it easier to develop apps, and as much
as C++14 has pushed forward the comfort of using the language,
there's still some boiler-plate needed to even get the project up
and there's still some scaffolding needed to be built before you
can focus on the problem at hand.

C#, which is excellently supported by Visual Studio, gives you
the benefit of nearly immediately focusing on solving the actual
problem you want to solve. Benefits of C#, Visual Studio and .NET
platform:

* Excellent visual form editor.
* Excellent code auto-completion.
* Standard library solves most of the boring and tricky
  problems for you.
* Managed memory environment.
* C# structs (copy on assign).
* C# properties.
* Exceptions with useful stack traces.
* Static typing, allowing the compiler to detect many errors for you
  before the runtime.

Cons:

* Microsoft proposed standard for code style and symbol naming
  is incomplete and one of the strangest I've seen. Name collisions
  between types and attributes are not uncommon and sometimes
  you need to bend and twist your mind to figure out non-colliding
  naming patterns. Moreover, even one-word symbol names force
  you to press the `SHIFT` key.
* Even though there's now 'mono' for Linux, this particular
  program calls the native `DestroyIcon` which immediately
  causes it to crash. It also remains untested if mono
  on Linux provides the traffic statistics.
* Another IDE that you're stuck with. Between Eclipse for Java
  and Emacs for everything else, that's 3 IDEs whose keyboard
  shortcuts you need to learn and memorize.
* Horrendous XML doc-comments format that is garbage to read
  in plain-text and also doesn't integrate very well with
  Visual Studio's tooltip and IntelliSense systems.

The initial, fully-working version of the program, sans bugs,
was done in less than 24 hours, and even that is a bit too
long for the program of this scale.

Code style adopts Microsoft recommendations. Unfortunately,
Microsoft doesn't state any recommendations for naming private
class members. In PikPikMeter they just follow the naming convention
of public members (ie. `CapitalizeItLikeThis()`).


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

Files description here goes from detailed operations
to general overwatch mechanisms.

[TrafficUnit.cs](PikPikMeter/TrafficUnit.cs)
============================================

When the program needs to display size and accept size as user input,
it's a good idea to have conversion mechanism between different
units of said size. `TrafficUnit` `Humanizes` size in Bytes or bits
to Kilo, Mega and Giga sizes that are easier to understand for
the reader. It can also `Dehumanize` said scaled values back into
a `TrafficUnitValue` struct that conveys the size information in
scale understood by program either in Bytes or bits.

[TrafficNic.cs](PikPikmeter/TrafficNic.cs)
==========================================

Access point to the `System.Diagnostics` API. Responsibilities are

* List all Network Interfaces currently available in the system.
* Track each Network Interface in a separate object, allowing
  to get a traffic measure snapshot with `Measure()` method.

Measures are returned as `TrafficNicMeasure` structs and
errors are thrown as `TrafficNicMeasure` exceptions.

[TrafficNicMeasure.cs](PikPikMeter/TrafficNicMeasure.cs)
========================================================

One measure taken from a Network Interface. Carries over
name of that Interface and traffic stats.

[TrafficMeasureException.cs](PikPikMeter/TrafficMeasureException.cs)
====================================================================

Whenever a measure error happens, for example when OS reports
a problem with traffic stats grabbing, it will be captured
by the immediate code and re-raised as this exception. This
exception is further captured and handled to avoid program
crashes and recover from error states.

An error recovery happens when Network Interfaces go down.
When this happens, exception is captured and list of Interfaces
is refreshed in hopes that the program can continue normally with
a new list.

The Interfaces are also refreshed with each grab because
it is unknown when a new Network Interface will go up.
To reduce Garbage Collector work, objects for Interfaces
that do not change the state are preserved.

[TrafficGrabber.cs](PikPikMeter/TrafficGrabber.cs)
==================================================

`TrafficGrabber` collects `TrafficNic` instances. It keeps exactly
one `TrafficNic` instance per Network Interface. When a measure
is taken, it's job is to iterate over all `TrafficNic` it has,
query them for measures and then return those measures in
another collection. If during this grab an error occurs, it will
refresh the list of Network Interfaces, destroy all current `TrafficNic`
objects and create new ones. As measures history is not kept in
`TrafficGrabber` and neither in `TrafficNic`, this refresh
can be done without destroying that history.

Nature of both `TrafficGrabber` and `TrafficNic` is immediate.
They exist and are useful in given instant and can be safely destroyed
and recreated as needed.

[TrafficStat.cs](PikPikMeter/TrafficStat.cs)
============================================

So, if neither `TrafficNic` nor `TrafficGrabber` keep history,
where is it kept? Is it just painted on the graph and then blitted
left when the graph updates, denting a one-pixel hole for the next
immediate measure?

The answer is `TrafficStat`. Its job is to accept immediate collections
of `TrafficNicMeasure` structs and store them in history, allowing
other parts of the program to retrieve valuable information from that
history.

As `TrafficNicMeasure` data is raw and directly useless to the program,
another job of `TrafficStat` is to convert this raw data into format
more pallatable for the various displays. To be more specific:
the graph and any label doesn't actually care what Network Interface
the traffic comes from. It always displays whole traffic in the system,
visible on all Network Interfaces. The raw data gets converted to
"System Totals" to avoid having to recalculate those totals each
time the graph repaints or the labels need updating.

This formatted data is stored as `StatMeasure` structs. There's
exactly one `StatMeasure` struct per collection of `TrafficNicMeasure`.
Moreover, `StatMeasure` struct contains the reference to the raw data
in case if the formatted data needs to be recalculated.

Such recalculation can happen when user toggles monitoring of
specific Network Interfaces. Internally, all Network Interfaces are
**always** monitored. Toggling them only disables the display.
Thanks to this, the display of the program can be changed to include
or exclude history of specific Network Interface at user's whim.
This mechanism also preserves history for Network Interfaces
that go down and then back up.

[TrafficMasterMonitor.cs](PikPikMeter/TrafficMasterMonitor.cs)
==============================================================

This are the ties that bind the UI with the traffic measures.
It is also another attempt to reduce the godobjectifity of
`MainWindow`.

`TrafficMasterMonitor` instantiates the measurement `TrafficGrabber`
and the history `TrafficStat` mechanisms, accepts references
to display controls located in `MainWindow`, updates them
when needed and paints graphs using `TrafficGraphPaint`.

`TrafficMasterMonitor` doesn't `Tick()` on its own. Each refresh
needs to be triggered externally. `MainWindow` has a `Timer` to
do just that.

The refresh process, or `Tick()`, does this in each iteration:

1. Grab current traffic measures from OS.
2. Store them in history.
3. Update displays.

There's also a `Repaint()` method for when `MainWindow` wants
the display to be repainted without grabbing new measures.
This is useful when `MainWindow` is resized or certain
options such as scale or tray icon painting get toggled.

`TrafficMasterMonitor` exposes some of its internals because
`MainWindow` in its `LoadSettings`/`SaveSettings` phases accesses
those internals to apply or read the actual setting values.
This breaks the "Law of Demeter", however in program of such
small scale this is a non-issue. It was much more benefitial
to get it done quickly without excessive boiler-plate.

Word "master" in its name underlines the hierarchy position
of this class. It's the border between the UI and the internals.

Graph painting doesn't happen here directly as this process
is complicated enough that it deserves a separate source code unit.

[TrafficGraphPaint.cs](PikPikMeter/TrafficGraphPaint.cs)
========================================================

Last, but not least, is the graph painter.

Its job is to paint both the main graph and the graph on
the tray icon. It controls the colors for each traffic unit,
the size of the traffic bars, the actual scale of the display
(also for the labels, which are updated by `TrafficMasterMonitor`).
It also prints the scale text on the graph, but only if
there's enough space to display it without visual glitches - this
validation check is what prevents the scale to be painted
on the tray icon.

The painter will only paint as many measures as there are pixels
in the graph's width. Each measure is exactly one pixel wide.
Graph bars also stick to the right edge of the graph, thus
it always appears that the graph moves left. The painter
chooses which traffic type - upload or download - is greater
in given measure and will paint this type in its own color
(red or green) and then overpaint the overlapping size in a common
color (yellow).

Each repaint causes the complete clear of the graph and complete
repaint. It doesn't reuse the already painted history by blitting
it left.

The colors are technically configurable in the class itself,
but the program doesn't provide any user interface to do so,
therefore the colors are hardcoded and cannot be changed without
editing the source code.
