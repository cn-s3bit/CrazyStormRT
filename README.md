# CrazyStormRT
Modified Runtime of the Famous Danmaku Designer CrazyStorm.

(中文版请向下翻)

## Introduction
CrazyStorm is a danmaku (or 2d particles) designer, which has a powerful event system
that enables us to implement complicated danmaku movements without any code.

This repository is a variation of CrazyStorm 1.03I. Parsing of MBG files and event logic remain the same,
but the rendering part is removed and thus there are no dependencies on other frameworks.

We are still working with lasers. Lasers are different from ordinary bullets.

## Get Started
You are able to clone and build the project with Visual Studio, but there's also an option
for .Net Core (actually CoreRT), which can compile the code to a native x64 image so that
there won't be JIT operations on the code, guaranteeing result accordance within different runs. (I.E. Replays)

CoreRT Compilation Command Line:
```batch
dotnet publish -r win-x64 -c release
```
You need to get .Net Core SDK 2.x ready.
The first compilation may take a long time because CoreRT itself needs to be downloaded from NuGet.

## Usage
Run the program (no command line options required). The program reads commands from `Stdin` and writes output data to `Stdout`.

The battle field is of the size `960x720`.

### Recognized Commands
+ `o<path>` Load an MBG file from `<path>`. Note that there are no whitespaces between `o` and `<path>`.
+ `p<x>,<y>` Sets the player position in CrazyStormRT to (<x>, <y>). Collision between player and bullets is removed, but snipes still work.
+ `u` Updating for one frame.
+ `r<integer>` Sets the random seed to <integer>.
+ `q` Exit.
+ `g` Fetch the current projectiles. For result formats, see [below](#Output).

Other Commands are ignored. A blank line will cause an exception.

### Output
For each `g` command, the output starts with a number `L` indicating output length.
The number is padded to the length of 10. Eg. `0000000125`.

The next `L` bytes is binary data in big endian.

A bullet is defined by 11 fields: `x, y, type, width, height, additive?, r, g, b, alpha, rotation`,
where most of them are single `float` with a size of 4 bytes.

#### Notes:

`type` is an integer with a size of 4 bytes, indicating bullet type in CrazyStorm.

`additive?` is an unsigned char with a size of 1 byte, 1 for additive rendered bullet and 0 otherwise.

`r`, `g`, `b` and `alpha` are all normalized to `[0, 1]`.
