<p align="center"><img width="173" height="57" src="http://catlib.io/imgs/logo-txt.png"></p>

<p align="center">
<a href="https://github.com/CatLib/CatLib/blob/master/LICENSE"><img src="https://img.shields.io/badge/license-MIT-blue.svg" title="license-mit" /></a>
<a href="https://github.com/CatLib/CatLib/"><img src="https://badge.fury.io/gh/catlib%2Fcatlib.svg" title="GitHub version" /></a>
<a href="https://ci.appveyor.com/project/catlib/core"><img src="https://ci.appveyor.com/api/projects/status/tk3o571mwbw2rykj?svg=true" title="Build status"/></a>
<a href="https://codecov.io/gh/CatLib/Core">
  <img src="https://codecov.io/gh/CatLib/Core/branch/master/graph/badge.svg" alt="Codecov" />
</a>

## 如何使用CatLib For ILRuntime

这个Demo演示了如何在Unity中使用CatLib For ILRuntime扩展组件。

扩展组件文档请访问: [CatLib.ILRuntime 中文文档](https://ilruntime.catlib.io) 

## 起步

- clone 示例项目库

```csharp
git clone https://github.com/CatLib/demo-how-to-use-catlib-for-ilruntime.git
```

- 安装子模块

```csharp
git submodule update --init --recursive
```

> [CatLib.ILRuntime](https://github.com/CatLib/CatLib.ILRuntime) 将会以子模块的形式安装到`CatLib/Vendor`文件夹下

- 使用`Unity3d`打开这个项目，并设定框架调试等级：

| 调试等级                            | 描述                 |
| -------------------------------- |:----------------------------:|
| `Development`     | 不从热更新文件中读取代码      |
| `Stading`         | 从热更新文件中读取代码，并加载调试文件      |
| `Production`      | 从热更新文件中读取代码，不加载调试文件      |

## 生成热更新文件

在Demo中我们利用unity来生成热更新dll(实际项目根据您的情况自行决定)，所以在您发布的时候您需要将`Library/ScriptAssemblies`文件夹中生成的热更新文件复制到您的项目中。
