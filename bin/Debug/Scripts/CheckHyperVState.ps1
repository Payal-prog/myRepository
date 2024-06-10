# Check if Hyper-V is already enabled.
# Get the Hyper-V feature and store it in $hyperv
$hyperv = Get-WindowsOptionalFeature -FeatureName Microsoft-Hyper-V-All -Online
$state=$hyperv.State
if($state -eq "Enabled")
{
    return 1
} else {
    return 0
}

