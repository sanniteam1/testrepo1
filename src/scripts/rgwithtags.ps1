param(   

 [Parameter(Mandatory=$True)]
 [string]
 $resourceGroupName,

 [Parameter(Mandatory=$True)]
 [string]
 $owner,

 [Parameter(Mandatory=$True)]
 [string]
 $team,

 [Parameter(Mandatory=$True)]
 [string]
 $environment,

 [Parameter(Mandatory=$True)]
 [string]
 $program,

 [Parameter(Mandatory=$True)]
 [string]
 $project,

 [Parameter(Mandatory=$True)]
 [string]
 $purpose,
 
 [Parameter(Mandatory=$True)]
 [string]
 $resourceGroupLocation
)

$RGTags = New-Object -TypeName Hashtable
$RGTags.Add("Owner", $owner)
$RGTags.Add("Team",$team)
$RGTags.Add("Environment", $environment)
$RGTags.Add("Program", $program)
$RGTags.Add("Project", $project)
$RGTags.Add("Purpose", $purpose)

# Create or update the resource group using the specified template file and template parameters file
New-AzureRmResourceGroup -Name $ResourceGroupName -Location $ResourceGroupLocation  -Tag $RGTags  -verbose -Force -ErrorAction Stop 