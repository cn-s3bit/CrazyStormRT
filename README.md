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
+ `p<x>,<y>` Sets the player position in CrazyStormRT to (`<x>`, `<y>`). Collision between player and bullets is removed, but snipes still work.
+ `u` Updating for one frame.
+ `r<integer>` Sets the random seed to `<integer>`.
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

# CrazyStormRT(中文版Readme)
著名的弹幕设计器CrazyStorm的修改版(中文版Readme并非英文版作者 目前尚未做校对 可能会有错误)
## 简介
CrazyStorm是一个弹幕(或者说是2D粒子)设计器，它拥有一个强大的事件系统，能让我们在不使用任何代码的情况下实现弹幕复杂的移动行为。

这个项目是CrazyStorm 1.03I的改动版。MBG文件的解析和事件逻辑仍和原来的一致，但是渲染部分被移除了，这样能让它不再依赖于其他的框架。

我们仍在修改激光。激光和一般的弹幕不太一样。
## 开始
你可以clone并且在Visual Studio上建立项目，不过这里要选择.Net Core(其实是CoreRT)，它可以编译x64图片的代码，所以不再需要在代码中添加JIT操作，保证结果能在不同的运行环境下保持一致(I.E. Replays)。

CoreRT编译指令行:
```batch
dotnet publish -r win-x64 -c release
```
你需要确定.Net Core SDK 2.x能正常使用。首次编译可能会花些许时间，因为需要CoreRT从NuGet上下载下来。
## 使用
运行项目(没有命令行选择必要)。项目从Stdin读取命令并且通过Stdout写入外部数据。

战斗区域是`960×720`
### 公认的命令
+ `o<path>`从`<path>`加载一个MBG文件。注意`o`和`<path>`之间没有空格。
+ `p<x>,<y>`设置自机在CrazyStormRT中的坐标(`<x>`,`<y>`)。自机与子弹的碰撞被移除了，但是snipes(狙击？)仍然可以使用。
+ `u`为每一帧更新
+ `r<integer>`设置一个`<integer>`的随机种子
+ `q`退出
+ `g`取得当前弹幕。关于格式，看[下面的"输出"](#输出)。
其他命令忽视掉了。空行会导致异常。
  
### 输出
对于每次`g`命令，输出都会开始于一个数`L`来指示输出长度。数字被填充到长度10.Eg.`0000000125`

下一个`L`字节是大字节序的二进制数据

子弹被定义了11个属性：`x, y, type, width, height, additive?, r, g, b, alpha, rotation`，这些属性大部分只是一个4字节的浮点数`float`。
#### 注意事项：
`type`是一个四字节大小的整数，在CrazyStorm中代表子弹类型

`additive?`是一个1字节的无符号字符型，添加被渲染的弹幕时为1，否则为0。

`r,g,b`以及`alpha`都是标准的`[0,1]`。
