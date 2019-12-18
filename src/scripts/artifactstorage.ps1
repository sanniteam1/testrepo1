
param(   

    [Parameter(Mandatory=$True)]
    [string]
    $resourceGroupName,
   
    [Parameter(Mandatory=$True)]
    [string]
    $storageAccount,
   
    [Parameter(Mandatory=$True)]
    [string]
    $containerName,   
    
    [Parameter(Mandatory=$True)]
    [string]
    $resourceGroupLocation
   )
   

Get-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation -ErrorVariable rgNotPresent -ErrorAction SilentlyContinue

if($rgNotPresent )
{
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation
}

$strExists = Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccount -ErrorAction SilentlyContinue

if($storageAccount -ne $strExists.StorageAccountName)
{
   $sa = New-AzureRmStorageAccount -ResourceGroupName $resourceGroupName `
  -Name $storageAccount `
  -SkuName Standard_LRS `
  -Location $resourceGroupLocation `
  -Kind Storage  
   $ctx = $sa.Context    
   New-AzureStorageContainer -Name $containerName -Context $ctx -Permission blob 
   #cd ..
   #Get-ChildItem -File -Recurse | Set-AzureStorageBlobContent -Container $containerName -Context $a.Context  
}
else{
    Write-host "Storage already exists"
    $a = Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccount
    $ctx = $a.Context
    #$ctx = $a.StorageAccountName.c
    #$cntExists = Get-AzureStorageContainer -Container $containerName -Context $a.Context 
    
    if($containerName -ne (Get-AzureStorageContainer -Container $containerName -Context $a.Context -ErrorAction SilentlyContinue).Name)
    {
        New-AzureStorageContainer -Name $containerName -Permission blob -Context $a.Context        
    }
    else {
        Write-host "Container already exists"

    }
    #cd ..
    #Get-ChildItem -File -Recurse | Set-AzureStorageBlobContent -Container $containerName -Context $a.Context
}
