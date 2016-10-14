# Microsoft Graph Connect Sample for UWP (Library)

**Table of contents**

* [Introduction](#introduction)
* [Prerequisites](#prerequisites)
* [Register and configure the app](#register)
* [Build and debug](#build)
* [Questions and comments](#questions)
* [Additional resources](#additional-resources)

<a name="introduction"></a>
##Introduction

This sample shows how to connect your Windows 10 Universal app to Office 365 using the Microsoft Graph API (previously called Office 365 unified API) to send an email. It uses the [Microsoft Graph .NET Client Library](https://github.com/microsoftgraph/msgraph-sdk-dotnet) to work with data returned by Microsoft Graph.

<a name="prerequisites"></a>
## Prerequisites ##

This sample requires the following:  

  * [Visual Studio 2015](https://www.visualstudio.com/en-us/downloads) 
  * Windows 10 ([development mode enabled](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
  * An [Office 365 for business account](https://msdn.microsoft.com/en-us/office/office365/howto/setup-development-environment#bk_Office365Account).

<a name="register"></a>
##Register and configure the app

1.	Sign in to the [Azure Management Portal](http://manage.windowsazure.cn) using your Azure AD credentials.
2.	Click **Active Directory** on the left menu, then select the directory for your Office 365 developer site.
3.	On the top menu, click **Applications**.
4.	Click **Add** from the bottom menu.
5.	On the **What do you want to do page**, click **Add an application my organization is developing**.
6.	On the **Tell us about your application page**, select **NATIVE CLIENT APPLICATION** for type and enter a friendly name for the application.
7.	Click the arrow icon on the lower-right corner of the page.
8.	On the **Application information** page, enter **https://developer.graph.microsoft.com/** for the redirect URI value.
9.	Once the application is successfully added, you'll be taken to the **Quick Start** page for the application. From there, select **Configure** in the top menu.
10.	Under **permissions to other applications**, select **Add application**. In the dialog box, select the **Microsoft Graph** application. After you return to the application configuration page, select the following permissions:

	* Send mail as signed-in user
	* Sign in and read user profile
 
11.	Copy the value specified for **Client ID** on the **Configure** page.
12.	Click **Save** in the bottom menu.

<a name="build"></a>
## Build and debug ##

**Note:** If you see any errors while installing packages during step 2, make sure the local path where you placed the solution is not too long/deep. Moving the solution closer to the root of your drive resolves this issue.

1. After you've loaded the solution in Visual Studio, configure the sample to use the application (client) id and redirectURI that you registered by adding the corresponding values for these keys in the Application.Resources node of the App.xaml file.
![Office 365 UWP Microsoft Graph connect sample](/readme-images/appId_and_redirectURI.png "Client ID value in App.xaml file")`

2. Press F5 to build and debug. Run the solution and sign in with either your personal or work or school account.

###Summary of key methods

The code in the main page of the app is relatively straight-forward and self-explanatory, as the calls for authentication and email service actually occur in the helper classes. The main page code primarily consists of event handlers for the two buttons:

- **ConnectButton_Click**
	
	This method calls the **GetAuthenticatedClientAsync** method to acquire a **GraphServicesClient** object representing the current user, which it uses to set user email address and display name. If this is successful, it also enables the **send mail** button and the text box where the user can enter an email address, and populates that text box with the user's own email address.

- **MailButton_Click**
	
	This method calls the **ComposeAndSendMailAsync** method, using the email address and display name variables set during **ConnectButton_Click**. If this method call is successful, it also updates the UI text accordingly.

With that in mind, it's worth looking at two methods in the helper classes in a little more detail:

- **GetAuthenticatedClientAsync**
	
	This method of the **AuthenticationHelper** class authenticates the user with the Azure AD v2.0 endpoint.

	It does this by creating an AppConfig object that specifies the app client ID, return URL, and the scopes requested by the app. It then uses this AppConfig object to construct an **OAuth2AuthenticationProvider** object, and calls the **AuthenticateAsync** method on the authentication provider. Finally, it creates a GraphServicesClient object using the **OAuth2AuthenticationProvider** object.

	The **SignInCurrentUserAsync** method on the main page can then read user from this **GraphServicesClient** object and set the user email address and display name.

- **ComposeAndSendMailAsync**

	This method of the **MailHelper** class uses the Microsoft Graph SDK to authenticate the user with the Azure AD v2.0 endpoint, compose a sample email, and then send the email using the user's account.

	It does this by declaring a **GraphServicesClient** object and setting it equal to the return value of **AuthenticationHelper.GetAuthenticatedClientAsync**. The method then composes the sample email, using various objects in the **Microsoft.Graph** namespace. Finally, it calls the **SendMail** method.

<a name="contributing"></a>
## Contributing ##

If you'd like to contribute to this sample, see [CONTRIBUTING.MD](/CONTRIBUTING.md).

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

<a name="questions"></a>
## Questions and comments

We'd love to get your feedback about the UWP Microsoft Graph Connect SDK project. You can send your questions and suggestions to us in the [Issues](https://github.com/OfficeDev/Microsoft-Graph-UWP-Connect-SDK/issues) section of this repository.

Your feedback is important to us. Connect with us on [Stack Overflow](http://stackoverflow.com/questions/tagged/office365+or+microsoftgraph). Tag your questions with [MicrosoftGraph] and [office365].

<a name="additional-resources"></a>
## Additional resources ##

- [Other Office 365 Connect samples](https://github.com/OfficeDev?utf8=%E2%9C%93&query=-Connect)
- [Microsoft Graph overview](http://graph.microsoft.io)
- [Office 365 APIs platform overview](https://msdn.microsoft.com/office/office365/howto/platform-development-overview)
- [Office 365 API code samples and videos](https://msdn.microsoft.com/office/office365/howto/starter-projects-and-code-samples)
- [Office developer code samples](http://dev.office.com/code-samples)
- [Office dev center](http://dev.office.com/)


## Copyright
Copyright (c) 2016 Microsoft. All rights reserved.


