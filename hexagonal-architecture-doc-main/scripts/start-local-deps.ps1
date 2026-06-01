param()

$ErrorActionPreference = "Stop"

try
{
    & docker compose up -d | Out-Null
}
catch
{
    throw "Unable to start Docker Compose dependencies. Ensure Docker Desktop is running and 'docker compose' is available."
}

$maxAttempts = 30

for ($attempt = 1; $attempt -le $maxAttempts; $attempt++)
{
    try
    {
        $client = New-Object System.Net.Sockets.TcpClient
        $asyncResult = $client.BeginConnect("localhost", 27017, $null, $null)
        $connected = $asyncResult.AsyncWaitHandle.WaitOne(1000, $false)

        if ($connected -and $client.Connected)
        {
            $client.EndConnect($asyncResult)
            $client.Dispose()
            Write-Host "MongoDB is ready on localhost:27017."
            exit 0
        }

        $client.Dispose()
    }
    catch
    {
    }

    Start-Sleep -Seconds 1
}

throw "MongoDB did not become available on localhost:27017 after 30 seconds."
