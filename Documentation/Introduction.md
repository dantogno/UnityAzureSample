# Using Azure Easy tables with Unity - sample game project

## Introduction

Azure provides a scalable solution to storing telemetry and other game data in the cloud. With the release of Unity 2017, Unity's support for .NET 4.6 makes Azure integration simpler than ever by allowing use of the Azure Mobile Client SDK.

The following sample project will walkthrough the steps of setting up a Unity project that leverages Azure for saving telemetry and leaderboard data in the cloud.

> [!NOTE]
> This project requires the "experimental" .NET 4.6 Mono scripting runtime in Unity 2017. [Unity has stated that soon this will be the default](https://forum.unity3d.com/threads/future-plans-for-the-mono-runtime-upgrade.464327/), however for now, it is still labeled as "experimental" and you may potentially experience issues.

> At the time of this document's writing, there are known issues that block this project from functioning on the Mac and Android platforms. While these are known issues and solutions will be introduced at some point, the specific timeline is uncertain. For more information, visit the Unity [experimental scripting forum](https://forum.unity3d.com/forums/experimental-scripting-previews.107/).

## Download the completed project

The completed project is available on GitHub. However, the walkthrough will assume you are starting from an empty, new project and will provide links to download assets when necessary.

## Next steps
* [Configure Easy tables in Azure](Configure%20Easy%20tables%20in%20Azure.md)
