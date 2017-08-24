# Create data model classes

The Unity project must contain data model classes that match the table schema created in the Azure Mobile App backend.

## Create the CrashInfo class

1. In Unity, add a new folder in the root **Assets** directory named **Scripts**. Inside of the new Scripts folder, create another new folder named **Data Models**. This is for organization only.

2. Inside the new Data Models folder, create a new C# script called **CrashInfo**.

3. Open the new `CrashInfo` script, delete any template code, including the class declaration and using statements, and add the following:

  ```csharp
  public class CrashInfo
  {
      public string Id { get; set; }
      public float X { get; set; }
      public float Y { get; set; }
      public float Z { get; set; }
  }
  ```

  > [!NOTE]
  > For the walkthrough to work correctly, the name of the data model class must match the name of the Easy table created on the Azure Mobile App backend. Likewise, the names and types of properties inside a data model class must correspond with columns in the Easy table. A property for every column is not necessary, only the ones you need to use in code. Additionally, the property names do *not* have to match the case of the column names. This means the "id" column that is included by default in an Easy table corresponds with a C# property named "Id".

## Create the HighScoreInfo class

1. Inside the Data Models folder, create a new C# script called **HighScoreInfo**.

2. Open the new `HighScoreInfo` script, delete any template code, including the class declaration and using statements, and add the following:

  ```csharp
  public class HighScoreInfo
  {
      public string Name { get; set; }
      public float Time { get; set; }
      public string Id { get; set; }
  }
  ```

  ## Next steps

  * [Implement the Azure MobileServiceClient](/Implement%20the%20Azure%20MobileServiceClient.md)
