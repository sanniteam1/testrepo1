#  .Net Core 2.0 Web Application DevOps Accelerator
 #####  Release 1 - Beta Version

Using .Net Core 2.0 Web Application DevOps Accelerator, you can setup CI and CD pipeline for .Net Core 2.0 Web Apps.

Accelerator supports one click deployment, with minimum user inputs. Deployment can be triggered from any OS platform.

> **Deployment using this accelerator support 2 use cases**

-   Would like to setup demo along with supporting infrastructure

-   Would like to setup demo with existing infrastructure

## What is SmartHotel360
SmartHotel360 is a fictitious smart hospitality company showcasing the future of connected travel.
Their vision is to provide:

-   *Intelligent, conversational, and personalized apps and experiences to guests*
-   *Modern workplace experiences and smart conference rooms for business travelers*
-   *Real-time customer and business insights for hotel managers & investors*
-   *Unified analytics and package deal recommendations for campaign managers.*

[Click here for more details](
https://github.com/Microsoft/SmartHotel360)

## Target Audience 

> **As Solution Architect or Sales team member,**

I want to setup a quick and robust demo for my clients. Which showcase the our DevOps capability, tools/ assets.

> **As a Project Manager,**

I want to quickly enable my team to start with development and deployment by following the DevOps pattern and practices.

> **As a New Member in the team,**

I want to learn the DevOps by deploying the Azure components (e.g. WebApps, VMs, Azure) using VSTS.

## DevOps Implementation
-   Infrastructure as Code - ARM Templates
-   Build Automation - PowerShell, SonarQube - Code Analysis
-   Test Automation (Unit + Functional Test)
-   Release Automation - ARM Templates, CI CD JSON and PowerShell

> **Benefits**
-   Consistent, compliance and controlled based on the Organization policies
-   Cost reduction, better quality, and flexibility!
-   Never ship bad code!

## Prerequisite

>  Azure Subscription with rights to create ***Service Principal***

## Deployment
### [Download deployment startup script](https://innovsh360storage.blob.core.windows.net/sh360/deploy-SH360demo.ps1?sp=r&st=2018-09-13T12:29:11Z&se=2019-06-29T20:29:11Z&spr=https&sv=2017-11-09&sig=GNXu1B0dTgGmm5cHkGOZwGAHUJ%2Fx7skTiV1HwNekYc8%3D&sr=b )

> ### Deployment using Windows PowerShell
***Run Windows PowerShell as Admin*** and follow the deployment step
> ### Deployment using CloudShell
 - Download the above mention .ps1 file in your local folder.
 - Opend CloudShell (https://portal.azure.com or http://shell.azure.com/)

***Steps to deploy using CloudShell*** 
-  Open CloudShell (https://portal.azure.com)
        ![](./images/uploadtocloudshell.JPG)
- After the Cloud Shell has opened, click on Upload

    ![](./images/zoomupload.JPG)

- Select file to upload 

    ![](./images/seletfile.JPG)

- Navigate to Path

                cd $home
                Press Enter
                ./deploy-SH360demo.ps1 -deployCloudShell
   ![](./images/movetodir.JPG)
    
- Follow the instrctions mention in deployment steps.
## How Orchestration Script works

![](./images/uiandopc.JPG)


## Understand the user inputs and deployment choices
### Common inputs
-   **deploymentPrefix**: provide ad deployment prefix (e.g. MEP)
- **projectName**- Project Name (e.g. SH360)
- **environmentName** - Environment Name  (e.g. demo)
-   **resourceGroupLocation**: location of the resource group.

    *deployment automatically generate the resource group name based on the above parameters*
               
            deploymentprefix-projectName-environmentName
-  **subscriptionID** - against which subscription you would like to have deployment
-  **vstsAccountName** - VSTS Account Name
- **vstsProjectName** - VSTS ProjectName
- **End to End deployment** - Choose **'Y'** is you want to deploy Web app along with required infrastructure (to run the code analysis tool and dev machine).
Choose **'N'**  if you already have required infrastructure. In this case, you need to provide information of existing SonarQube server.

        - sonarqubeURL
        - sonarqubeToken
        - sonarqubeProjectName
        - sonarqubeProjectKey
- **Deploy VSTS Instance**: Choose **'Y'** if you would like to create a new VSTS instance. This new VSTS instance inside Azure Resource Group and always be in Centralus location, due to VSTS location constraint.

            deploymentprefix-projectName-environmentName-vsts

    Choose **'N'**, if you have want to use existing VSTS instance.
    
- **Create New Service Principal**: Choose **'Y'** if you would like to create a new service principal (make sure you have AAD rights to create service principal). 
Choose **'N'** if want to use existing one. in you choose **'N'**, you need to provide **Application ID** of your service principal.



## Deployment Steps
#### End to End deployment
![](./images/userinput.JPG)
#### Deployment with existing  infrastructure
![](./images/existing.JPG)

 ## Deployment Progress and verification  

#### VSTS provisioning, in case of new VSTS instance 
   ![](./images/vsts.JPG)

#### Infrastructure provisioning in case of end to end deployment
   ![](./images/iac.JPG)

#### SonarQube endpoint creation
  ![](./images/sqendpoint.JPG)

  #### SonarQube endpoint creation
  ![](./images/createrepo.JPG)

  #### Build and Release Definition creation
  ![](./images/releasedef.JPG)

 #### Build Definition 

 -  **Build Taks View**

  ![](./images/buiddef.JPG)

-  **Build Execution View**

   ![](./images/buildexecution.JPG)

-  **Build Test Results (Unit Test)**

  ![](./images/buildtest.JPG)


   #### Release Definition 

-  **Release Taks View**

  ![](./images/reldetails.JPG)

- **Release Execution View**

![](./images/relexecution.JPG)

- **Release Test (Selenium Test) Results**

![](./images/reltest.JPG)


#### SmartHotel Website

   ![](./images/e2efinalweb.JPG)



> [**Tell us you’ve used this asset**](https://innersource.visualstudio.com/MepSh360FieldDemo/_apps/hub/jepbacol.avanadeassets-assetfactorytab.avanadeassets-assetfactorytab)

>  [**Review and Feedback**](https://innersource.visualstudio.com/MepSh360FieldDemo/_apps/hub/jepbacol.avanadeassets-assetfactorytab.avanadeassets-assetfactorytab)