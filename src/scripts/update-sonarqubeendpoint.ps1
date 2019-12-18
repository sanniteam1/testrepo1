Write-Host "SQ Token: $($env:sqToken)"
Write-Host "Project Key: $($env:sqProjectKey)"

$Org = "$(AzDoOrg)"
$Project = "$(AzDoProject)"
$SqEndpointName = "SQ-SmartHotel360.PublicWeb"
$SqUrl = "https://$(siteName).azurewebsites.net"
$SqToken = "$($env:sqToken)"
$PAT = "$(AzDoPAT)"
$Oauth = "$(AzDoOauth)"

if ([string]::IsNullOrEmpty($Oauth)) {
    $base64AuthInfo = [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes(":$($PAT)"))
    $authHeader = @{Authorization = 'Basic ' + $base64AuthInfo}
}
elseif ([string]::IsNullOrEmpty($PAT)) {
    $authHeader = @{Authorization = 'Bearer ' + $Oauth}
}

$body = '{
                "data" : {
                    },

                    "name": "--Sonarqube_Endpoint_Name--",
                    "type": "sonarqube",
                    "url": "--Sonarqube_Url--",
                    "authorization": {
                        "scheme": "UsernamePassword",
                        "parameters": {
                            "username": "--Sonarqube_Token--",
                            "password": ""
                        }
                    }
                }'

#Replacing values
$body = $body.Replace("--Sonarqube_Endpoint_Name--", $SqEndpointName)
$body = $body.Replace("--Sonarqube_Url--", $SqUrl)
$body = $body.Replace("--Sonarqube_Token--", $SqToken)

#Get Endpoint Id
$EndpointApi = "https://dev.azure.com/$Org/$Project/_apis/serviceendpoint/endpoints?endpointNames=$SqEndpointName&api-version=5.0-preview.2"
$Endpoint = Invoke-RestMethod -Method Get -Uri $EndpointApi -Headers $authHeader -ErrorAction Stop
$EndpointId = $Endpoint.value[0].id

#Update Endpoint
$ApiUrl = "https://dev.azure.com/$Org/$Project/_apis/serviceendpoint/endpoints/" + $EndpointId + "?api-version=4.1-preview.1"
$response = Invoke-RestMethod -Uri $ApiUrl -headers $authHeader -Body $body -ContentType 'application/json'-Method Put -ErrorAction Stop
$response