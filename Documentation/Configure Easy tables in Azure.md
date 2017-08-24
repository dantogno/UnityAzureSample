# Configure Easy tables in Azure

Easy tables are a feature of [Azure Mobile Apps](https://azure.microsoft.com/en-us/services/app-service/mobile/) that allow setup and management of SQL tables directly in the Azure portal GUI. Azure Mobile Apps support many features, but the scope of this example is limited to reading and writing data stored in an Azure Mobile App backend from a Unity project.

## Create a new Azure Mobile App

Log in to the [Azure portal](https://ms.portal.azure.com). If you do not have an Azure subscription, the [free trial](https://azure.microsoft.com/en-us/free/) or included credits from [Visual Studio Dev Essentials](https://www.visualstudio.com/dev-essentials/) will more than suffice for completing this walkthrough.

**Once inside the portal:**

1. Select **New > Web + Mobile > Mobile App > Create**.

  ![Create a new Mobile App](media/configure-easy-tables-image1.png)

2. Configure the new Mobile App:

  * **App Name**. This will build the URL used to connect to the Azure Mobile App backend. You must choose a unique name, indicated by the green checkmark.

  * **Subscription**. Choose the subscription the new Mobile App will use for billing.

  * **Resource Group**. Resource groups allow easier management of related resources. By default Azure creates a new resource group with the same name as the new app. The default setting works well for the walkthrough.

  *  **App Service Plan/Location**. The service plan dictates the computing power, location, and cost of the resources Azure uses to host your new Mobile App. By default Azure will create a new service plan with some default settings. This is the simplest option for this walkthrough. However, you can use this menu to customize a new service plan's pricing tier or geographic location. Additionally, settings for a service plan can be modified after deploying it.

  ![Create a new Mobile App](media/configure-easy-tables-image2.png)

3. Select **Create** and give Azure a few minutes to deploy the new resource. You will see a notification in the Azure Portal when deployment has completed.

## Add a new data connection

4. Once deployment has completed, click the **All resources** button and then select the newly created Mobile App.

  ![Select the new Mobile App](media/configure-easy-tables-image3.png)

5. In the newly opened blade, scroll down in the left side-menu and click the **Easy tables** button, listed under the **MOBILE** heading.

  ![Select Easy tables](media/configure-easy-tables-image4.png)

6. Click the blue **Need to configure Easy Tables/Easy APIs** notice displaying along the top of the Easy tables blade.

  ![Click configure Easy tables notice](media/configure-easy-tables-image5.png)

7. Click the notice that says **You need a database to use Easy Tables. Click here to create one**.

  ![Click the create database notice](media/configure-easy-tables-image6.png)

8. On the Data Connections blade, click the **Add** button.

  ![Click Add button](media/configure-easy-tables-image7.png)

9. On the Add a data connection blade, select **SQL Database**.

  ![Select SQL Database](media/configure-easy-tables-image8.png)

10. A blade will open for configuring a new SQL database and SQL server:

  * **Name**. Enter a name for the database.

  * **Target server**. Click **Target server** to open the New server blade.

      * **Server name**. Enter a name for the server.

      * **Server admin login and Password**. Create a username and password for the server admin.

      * **Location**. Choose a nearby location for the server.

      * Ensure that the **Allow azure services to access server** checkbox remains checked.

      * Click **Select** to complete configuration the server.

    * **Pricing tier**. Leave the default setting for the walkthrough. This can be modified later.

    * **Collation**. Leave the default setting.

    * Click **Select** to complete configuration of the database.

    ![Configure SQL server and database](media/configure-easy-tables-image9.png)

11. Back at the Add data connection blade, click **Connection String**. When the Connection string blade appears, leave the default settings and click **OK**.

  ![Click Connection String](media/configure-easy-tables-image9.1.png)

12. Back at the Add data connection blade, the text "MS_TableConnectionString" should no longer be in italics. Click **OK** and give Azure a few minutes to create the new data connection. A notification will arrive when the process is complete.

  ![Click OK](media/configure-easy-tables-image9.2.png)

## Complete the Easy table initialization

13. Once the new data connection has been created successfully, click the **All resources** button, and again navigate back to the Mobile App. It is important to complete this step to refresh the Easy table configuration notice.

14. Scroll down and select **Easy tables**, and once more select the blue **Need to configure Easy Tables/Easy APIs** notice.

  ![Click Easy tables notice](media/configure-easy-tables-image5.png)

15. This time the blade that appears should state that "You already have a data connection" below the **1** heading. Under the **2** heading, click the checkbox that says **I acknowledge that this will overwrite site contents.** Now click **Initialize App** and wait a few minutes for Azure to complete the initialization process. A new notification will announce when the process is complete.

  ![Click Initialize App](media/configure-easy-tables-image10.png)

## Next steps

* [Setup table schema](Setup%20table%20schema.md)
