# Prepare the development environment

There are some prerequisites to using the Azure Mobile Client SDK in Unity.

## Download and install Unity 2017

Unity 2017.1 or above is required. All Unity plans work with the walkthrough, including the free Personal plan. Download Unity from https://store.unity.com/.

## Download and install Visual Studio 2017 Preview 15.3

The walkthrough requires Visual Studio Tools for Unity 3.3, which is included in the Visual Studio 2017 Preview 15.3 Unity workload. All editions of Visual Studio 15.3 work with the walkthrough, including the free Community edition.

1. Download Visual Studio Preview 15.3 at https://www.visualstudio.com/vs/preview/.

2. Install Visual Studio Preview 15.3 and ensure that the **Game development with Unity** workload is enabled.

 ![Select Unity workload](media/prepare-dev-environment-image0.png)

## Create a new 3D Unity project

Launch Unity and create a new 3D project.

![Create new Unity project](media/prepare-dev-environment-image1.png)

## Set the script editor to Visual Studio Preview 15.3

It's possible that you already have Visual Studio 2017 set as Unity's external script editor, but it's important to ensure the 15.3 Preview version is selected.

1. From the Unity **Edit** menu, choose **Edit > Preferences...**.

  ![Open Preferences menu](media/prepare-dev-environment-image1.2.png)

2. When the Unity Preferences window pops up, select the **External Tools** tab on the left side.

3. In the **External Script Editor** dropdown menu, select **Browse...**.

4. Navigate to the directory where you installed Visual Studio 2017 Preview and browse to **Microsoft Visual Studio\Preview\Community\Common7\IDE\devenv.exe**, then click **Open**.

  ![Browse for Visual Studio Preview](media/prepare-dev-environment-image2.png)

Once you have completed these steps, the **External Script Editor** dropdown should display an entry that reads "**Visual Studio 2017**".

![Set external script editor](media/prepare-dev-environment-image3.png)

>**Note:** The above screenshot shows what the dropdown looks like if you already had Visual Studio 2017 Community installed. Note that the **Visual Studio 2017** entry should be selected (this is the entry for 15.3 Preview), not the entry for Visual Studio 2017 Community.

## Change the Unity scripting runtime to .NET 4.6
The walkthrough requires .NET 4.6 in order to use the Azure Mobile Client SDK and its dependencies.

1. From the Unity **File** menu, choose **File > Build Settings...**.

  ![Open build settings](media/prepare-dev-environment-image4.png)

2. Click the **Player Settings...** button.

  ![Open player settings](media/prepare-dev-environment-image5.png)

3. The Player Settings opens in the Unity Inspector window. Under the **Configuration** heading, click the **Scripting Runtime Version** dropdown and select **Experimental (.NET 4.6 Equivalent)**. This will prompt a dialog asking to restart Unity. Select **Restart**.

  ![Select .NET 4.6](media/prepare-dev-environment-image6.png)

## Add a reference to System.Net.Http.dll

The Unity .NET 4.6 equivalent scripting runtime allows use of the System.Net.Http package, which is required by the Azure Mobile Client SDK. The DLL file is included in Unity, however a reference must be added to use it.

1. In the Unity editor Project window, **right click** the **Assets** folder and select **Show in Explorer**.

  ![Show Assets folder in Explorer](media/prepare-dev-environment-image7.png)

2. In the Explorer window that pops up, double click the **Assets** directory to open it.

3. Inside the Assets directory, **right click** and select **New > Text Document**.

4. Open the new text document in a text editor and add the line: `r:System.Net.Http.dll`

5. Save the document and close it.

4. Rename the new text document to "**mcs.rsp**" and be sure to delete the .txt file extension.

  * If you have file extensions hidden, you will need to change your folder view options to show them.
  * Open the Start menu and type "folder options" to search. Select "**File Explorer Options**".
  * Select the **View** tab and in the advanced settings ensure "**Hide extensions for known file types**" is unchecked.

    ![Show Assets folder in Explorer](media/prepare-dev-environment-image8.png)

5. Restart Unity.

Upon completing these steps you should have a file named **mcs.rsp** with the line `r:System.Net.Http.dll` in your Unity project's root **Assets** directory.

>**Note:** The reference functionality requires Visual Studio Tools for Unity 3.3 and above, which is included in the Visual Studio Preview 15.3 Unity workload. If this step does not work for you, ensure that you have the correct version of VSTU installed.

## Add the Newtonsoft.Json NuGet package to your project

The Azure Mobile Client SDK requires the Newtonsoft.Json package. Unfortunately, Unity does not support NuGet. If you open a Unity project in Visual Studio and add a package with NuGet, Unity will erase it the next time you open the project in the Unity editor. However, packages from NuGet can be manually added to a Unity project.

1. Create a new folder in your Unity project's Assets directory called "**NuGet Packages**". This is for organization only.

2. Go to https://www.nuget.org/packages/Newtonsoft.Json/ and click the **Manual Download** button. Download the .nupkg file.

  ![Show Assets folder in Explorer](media/prepare-dev-environment-image9.png)

3. Locate the newly downloaded file and change the file extension from .nupkg to **.zip**. This should allow you to view and extract the included files like any other zip file.

4. Open or extract the zip directory and browse to **\lib\net45**.

5. Copy the **Newtonsoft.Json.dll** file to your Unity project's **Assets\NuGet Packages** directory.

## Add the Azure Mobile Client SDK NuGet package to your project

The Azure Mobile Client SDK contains functions for easily reading and writing to Azure Easy tables.

1. Go to https://www.nuget.org/packages/Microsoft.Azure.Mobile.Client/ and click the **Manual Download** button. Download the .nupkg file.

2. Locate the newly downloaded file and change the file extension from .nupkg to **.zip**. This should allow you to view and extract the included files like any other zip file.

3. Open or extract the zip directory and browse to **\lib\net45**.

4. Copy the **Microsoft.Azure.Mobile.Client.dll** file to your Unity project's **Assets\NuGet Packages** directory.

## Conclusion

After completing these steps, your Unity project should be setup to use the Azure Mobile Client SDK. You can test your development environment by creating a new C# script in your Unity project, opening it in Visual Studio, and typing the following using statements at the top:
```
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices;
```

If InteliSense detects these using statements, the setup was completed properly. If there are any errors or InteliSense does not recognize these packages, revisit the steps above.

In the next section, you will begin adding sample game assets and scripts.
