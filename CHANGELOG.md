# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [unreleased]

### Added

- Configuration options for window colors.

### Changed

- Bump .NET from 4.5.1 to 4.8.

### Fixed

- Prevent repeated bitmap allocations during graph repaint by reusing existing
  instances where possible.

## [1.0] - 2018-04-16

### Added

- Project conception!
- Custom-styled window that hovers anywhere you put it on the desktop.
- Can be configured as "always on top".
- Tracks network traffic on all or selected network interfaces.
- Paints upload and download as separate colors on a live time-series graph.
- Allows to set graph scale (only linear, though).
- Allows to set main window's opacity.
- Tray icon with graph painted on tray.

[unreleased]: https://github.com/Zalewa/PikPikMeter/compare/v1.0...HEAD
[1.0]: https://github.com/Zalewa/PikPikMeter/commits/v1.0
