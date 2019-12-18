$sqURL = "$(siteName).azurewebsites.net"
$userName = "admin"
$password = "admin"
$sonarqubeTokenName = "SmartHotel360-PublicWeb"
$sonarqubeProjectKey = "SmartHotel360-PublicWeb"
$sonarqubeProjectName = "SmartHotel360-PublicWeb"
$sonarqubeEndpoint
$status


while ($status -ne 200) { 
    try {
        $result = Invoke-WebRequest -Uri $sqURL -TimeoutSec 30
        $status = $result.StatusCode
        Write-Host ("StatusCode: $status")
        if ($status -eq 200) {
            $result.Dispose()
            Write-Host ("SonarQube Server is ready.")
        
        } 
    }
    catch {
        $_.Exception.Message
        Write-Host ("Retrying...")
    }
    Start-Sleep -Seconds 30
}


# Authentication Sonarqube
$authInfo = ("{0}:{1}" -f $username, $password)
$authInfo = [System.Text.Encoding]::UTF8.GetBytes($authInfo)
$authInfo = [System.Convert]::ToBase64String($authInfo)
$authHeader = @{Authorization = ("Basic {0}" -f $authInfo)}


$pingApiUrl = $sqUrl + "/api/system/ping"

$pingApiResponse

while ($pingApiResponse -ne "pong") {

    try {
        $pingApiResponse = Invoke-RestMethod -Uri $pingApiUrl -Headers $authHeader -Method GET -TimeoutSec 30
        if ($pingApiResponse -eq "pong")
        {
            Write-Host ("SonarQube APIs are ready.")
        }
    }
    catch {
        $exception = $_.Exception
        $exception

        Write-Host "StatusCode:" $_.Exception.Response.StatusCode.value__ 
    }
    Start-Sleep -Seconds 30
}

# Generate SonarQube security token
$SqTokenApiUrl = $sqURL + "/api/user_tokens/generate?name=$sonarqubeTokenName"
$sqTokenResponse = Invoke-RestMethod -Uri $SqTokenApiUrl -Headers $authHeader -Method POST -ContentType 'application/x-www-form-urlencoded'
$sqToken = $sqTokenResponse.token
Write-Host "##vso[task.setvariable variable=sqToken;]$sqToken"


# Create new SonarQube project
$createSqProjApiUrl = $sqURL + "/api/projects/create?project=$sonarqubeProjectName&name=$sonarqubeProjectKey"
$sqProject = Invoke-RestMethod -Uri $createSqProjApiUrl -Headers $authHeader -Method POST -ContentType 'application/x-www-form-urlencoded'
$sqProjectKey = $sqProject.project.key
Write-Host "##vso[task.setvariable variable=sqProjectKey;]$sqProjectKey"


# Create Sonar Exclusions
$uriSourceFileExclusion = $sqURL + "/api/settings/set?component=$sonarqubeProjectName&key=sonar.exclusions&values=**/dist/*.js&values=**/**/*.js"
Invoke-RestMethod -Uri $uriSourceFileExclusion  -Headers $authHeader -Method Post -ContentType 'application/x-www-form-urlencoded'
