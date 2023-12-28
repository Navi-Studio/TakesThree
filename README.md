# Takes Tree based On Unity

[<img alt="NPM" src="https://img.shields.io/badge/license-MIT-green">](https://opensource.org/license/mit) 

## Demo 演示

![demo](./ReadmeAssets/demo.gif)

## 操作说明

-   玩家 P1
    -   前进 - 交替按 `A` 和 `D` 键
    -   释放技能 - 按 `W` 键
-   玩家 P2
    -   前进 - 交替按方向键 `←` 和 `→` 键
    -   释放技能 - 按方向键 `↑` 键

## 项目介绍

- 此项目为 AI Game Jam 线下赛作品。开发时间只有两天，很多细节待后续更新补充。

- 由于本项目直接集成了 **[Virtual-Human-for-Chatting](https://github.com/Navi-Studio/Virtual-Human-for-Chatting)** 开源项目，因此可以实现 **AI 实时解说** 功能。但由于网络环境等各种因素，比赛时测试 ChatGPT API 响应速度过慢。因此我们暂时关闭了当前版本解说员的 AI 解说功能功能，替换成了内置语音包。

    - 如需开启 AI 实时解说功能。请在 `.\Assets\Scripts\Live\Scripts\DataBase\GameSettingsEntity.cs` 脚本中填入准备好的 API Key。

    ```c#
        this.ChatGPTAPI = " ";
        this.AzureAPI = " ";
        this.APISpaceAPI = " ";		// 非必要
    ```

    -   并通过调用代码来实现实时播报。

    ```c#
        ChatScript chatScript = GameObject.FindGameObjectWithTag("LM").GetComponent<ChatScript>();
        chatScript.SendData("跑步比赛即将开始，直接给我开场稿。");
    	// ...
        chatScript.SendData("现在米米选手领先，请给我简短的解说词。");
    ```

-   AI 智能语音相关的部署与实现请移步 **[Virtual-Human-for-Chatting](https://github.com/Navi-Studio/Virtual-Human-for-Chatting)** 查看详情。

## 项目部署

### Editor 版本

- Unity 2021.3.10f1c2

## 许可

-   本项目代码根据 [MIT](https://opensource.org/license/mit) 许可证获得许可。

-   [Live2D模型](https://github.com/Navi-Studio/Virtual-Human-for-Chatting#致谢) 由其作者 ( [草莓奶兔](https://www.bilibili.com/video/BV1hB4y1Q7vn) ) 拥有，必须在其作者的许可下使用。

-   除 Live2D模型以外的全部 [美术资源](#致谢) 已获得作者开源许可。


## 引用

如果您认为本项目对您的工作有用，请考虑引用：

```tex
@misc{TakesThree,
  author = {Tianyu and Si, Hanqing and Wei, Ruoyan and Chen},
  title = {Takes Three},
  year = {2023},
  publisher = {GitHub},
  journal = {https://github.com/Navi-Studio/TakesThree},
}
```

## 致谢

我们非常感谢画师 [草莓奶兔](https://www.bilibili.com/video/BV1hB4y1Q7vn) 提供的“桃花酪元子” Live2D 模型。
