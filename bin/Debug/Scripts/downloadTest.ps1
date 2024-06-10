$bitsTransfers = Get-BitsTransfer
if ($bitsTransfers) {
    $bytesDownloaded = [long]$bitsTransfers[-1].BytesTransferred
    $bytesTotal = [long]$bitsTransfers[-1].BytesTotal

    if ($bytesTotal -gt 0) {
        $percent = ($bytesDownloaded / $bytesTotal) * 100
        $roundedValue = [math]::Round($percent)
        return $roundedValue
        #Write-Output $percent
    } else {
        return 0
    }
} 
