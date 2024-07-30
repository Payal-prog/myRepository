#Check If IIS Application Initialization Feature is Enabled

    $output = dism /online /Get-Features /Format:Table | findstr /C:"IIS-ApplicationInit"
    if ($output -match "Enabled") {
        return "Enabled"
    } else {
        return "Not Enabled"
    }

